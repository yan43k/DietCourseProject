using System.ComponentModel.DataAnnotations;

namespace DietApi.DTO;

public class FeedbackRequest
{
    [Required(ErrorMessage = "Введите имя")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Имя должно содержать от 2 до 100 символов")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введите email")]
    [EmailAddress(ErrorMessage = "Введите корректный email")]
    public string Email { get; set; } = string.Empty;

    [StringLength(30, ErrorMessage = "Телефон слишком длинный")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Введите сообщение")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "Сообщение должно содержать от 10 до 1000 символов")]
    public string Message { get; set; } = string.Empty;
}
