using DietApi.Data;
using DietApi.DTO;
using DietApi.Models;
using DietApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietApi.Controllers;

[ApiController]
public class DietController : ControllerBase
{
    private readonly DietDbContext _db;
    private readonly IDietCalculatorService _calculator;

    public DietController(DietDbContext db, IDietCalculatorService calculator)
    {
        _db = db;
        _calculator = calculator;
    }

    [HttpPost("calculate")]
    public async Task<ActionResult<DietCalculationResponse>> Calculate([FromBody] CalculateDietRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var result = _calculator.Calculate(request);
        var user = new User
        {
            Name = result.Name,
            Gender = result.Gender,
            Age = result.Age,
            Height = result.Height,
            Weight = result.Weight
        };

        var calculation = new DietCalculation
        {
            User = user,
            Goal = result.Goal,
            ActivityLevel = result.ActivityLevel,
            ActivityCoefficient = result.ActivityCoefficient,
            Calories = result.Calories,
            Proteins = result.Proteins,
            Fats = result.Fats,
            Carbohydrates = result.Carbohydrates,
            MenuPlan = result.MenuPlan,
            CreatedAt = result.CreatedAt
        };

        _db.DietCalculations.Add(calculation);
        await _db.SaveChangesAsync();

        result.Id = calculation.Id;
        return Ok(result);
    }

    [HttpGet("history")]
    public async Task<ActionResult<IEnumerable<DietCalculationResponse>>> GetHistory(
        [FromQuery] string? search,
        [FromQuery] string? goal,
        [FromQuery] string sortBy = "date",
        [FromQuery] string sortOrder = "desc")
    {
        var query = _db.DietCalculations
            .AsNoTracking()
            .Include(calculation => calculation.User)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(calculation => calculation.User != null && calculation.User.Name.Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(goal))
        {
            query = query.Where(calculation => calculation.Goal == goal);
        }

        var descending = sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase);
        query = sortBy.ToLowerInvariant() switch
        {
            "calories" => descending ? query.OrderByDescending(x => x.Calories) : query.OrderBy(x => x.Calories),
            "name" => descending ? query.OrderByDescending(x => x.User!.Name) : query.OrderBy(x => x.User!.Name),
            _ => descending ? query.OrderByDescending(x => x.CreatedAt) : query.OrderBy(x => x.CreatedAt)
        };

        var history = await query.Select(calculation => new DietCalculationResponse
        {
            Id = calculation.Id,
            Name = calculation.User!.Name,
            Gender = calculation.User.Gender,
            Age = calculation.User.Age,
            Height = calculation.User.Height,
            Weight = calculation.User.Weight,
            Goal = calculation.Goal,
            ActivityLevel = calculation.ActivityLevel,
            ActivityCoefficient = calculation.ActivityCoefficient,
            Calories = calculation.Calories,
            Proteins = calculation.Proteins,
            Fats = calculation.Fats,
            Carbohydrates = calculation.Carbohydrates,
            MenuPlan = calculation.MenuPlan,
            CreatedAt = calculation.CreatedAt
        }).ToListAsync();

        return Ok(history);
    }

    [HttpDelete("history/{id:int}")]
    public async Task<IActionResult> DeleteHistory(int id)
    {
        var calculation = await _db.DietCalculations.FindAsync(id);
        if (calculation is null)
        {
            return NotFound(new { message = "Запись истории не найдена." });
        }

        _db.DietCalculations.Remove(calculation);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
