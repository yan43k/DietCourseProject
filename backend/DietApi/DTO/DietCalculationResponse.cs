namespace DietApi.DTO;

public class DietCalculationResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public int Age { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public string Goal { get; set; } = string.Empty;
    public string ActivityLevel { get; set; } = string.Empty;
    public double ActivityCoefficient { get; set; }
    public int Calories { get; set; }
    public int Proteins { get; set; }
    public int Fats { get; set; }
    public int Carbohydrates { get; set; }
    public string MenuPlan { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
