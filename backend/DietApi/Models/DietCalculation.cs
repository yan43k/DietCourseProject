using System.ComponentModel.DataAnnotations;

namespace DietApi.Models;

public class DietCalculation
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    [Required, MaxLength(40)]
    public string Goal { get; set; } = string.Empty;

    [Required, MaxLength(80)]
    public string ActivityLevel { get; set; } = string.Empty;

    public double ActivityCoefficient { get; set; }
    public int Calories { get; set; }
    public int Proteins { get; set; }
    public int Fats { get; set; }
    public int Carbohydrates { get; set; }

    [Required]
    public string MenuPlan { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
