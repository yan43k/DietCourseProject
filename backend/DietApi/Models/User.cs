using System.ComponentModel.DataAnnotations;

namespace DietApi.Models;

public class User
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(20)]
    public string Gender { get; set; } = string.Empty;

    [Range(10, 100)]
    public int Age { get; set; }

    [Range(100, 250)]
    public double Height { get; set; }

    [Range(30, 250)]
    public double Weight { get; set; }

    public List<DietCalculation> Calculations { get; set; } = new();
}
