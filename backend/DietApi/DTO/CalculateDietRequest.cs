using System.ComponentModel.DataAnnotations;

namespace DietApi.DTO;

public class CalculateDietRequest
{
    [Required(ErrorMessage = "Введите имя")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Имя должно содержать от 2 до 100 символов")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Выберите пол")]
    public string Gender { get; set; } = string.Empty;

    [Range(10, 100, ErrorMessage = "Возраст должен быть от 10 до 100 лет")]
    public int Age { get; set; }

    [Range(100, 250, ErrorMessage = "Рост должен быть от 100 до 250 см")]
    public double Height { get; set; }

    [Range(30, 250, ErrorMessage = "Вес должен быть от 30 до 250 кг")]
    public double Weight { get; set; }

    [Required(ErrorMessage = "Выберите цель")]
    public string Goal { get; set; } = string.Empty;

    [Required(ErrorMessage = "Выберите активность")]
    public string ActivityLevel { get; set; } = string.Empty;
}
