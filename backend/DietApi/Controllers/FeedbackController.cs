using DietApi.Data;
using DietApi.DTO;
using DietApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietApi.Controllers;

[ApiController]
public class FeedbackController : ControllerBase
{
    private readonly DietDbContext _db;

    public FeedbackController(DietDbContext db)
    {
        _db = db;
    }

    [HttpPost("feedback")]
    public async Task<IActionResult> Create([FromBody] FeedbackRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var message = new FeedbackMessage
        {
            Name = request.Name.Trim(),
            Email = request.Email.Trim(),
            Phone = request.Phone?.Trim(),
            Message = request.Message.Trim(),
            CreatedAt = DateTime.UtcNow
        };

        _db.FeedbackMessages.Add(message);
        await _db.SaveChangesAsync();

        return Ok(new { message = "Сообщение успешно отправлено." });
    }

    [HttpGet("feedback")]
    public async Task<ActionResult<IEnumerable<FeedbackMessage>>> GetAll()
    {
        var messages = await _db.FeedbackMessages
            .AsNoTracking()
            .OrderByDescending(message => message.CreatedAt)
            .ToListAsync();

        return Ok(messages);
    }
}
