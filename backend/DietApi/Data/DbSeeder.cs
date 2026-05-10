using DietApi.Models;

namespace DietApi.Data;

public static class DbSeeder
{
    public static void Seed(DietDbContext db)
    {
        if (db.Users.Any())
        {
            return;
        }

        var user = new User
        {
            Name = "Анна Иванова",
            Gender = "Женский",
            Age = 24,
            Height = 168,
            Weight = 62
        };

        user.Calculations.Add(new DietCalculation
        {
            Goal = "Поддержание веса",
            ActivityLevel = "Умеренная активность",
            ActivityCoefficient = 1.55,
            Calories = 2100,
            Proteins = 126,
            Fats = 70,
            Carbohydrates = 241,
            MenuPlan = "Завтрак: овсянка с ягодами и йогуртом. Обед: куриная грудка, гречка и овощной салат. Перекус: творог и яблоко. Ужин: рыба с овощами.",
            CreatedAt = DateTime.UtcNow.AddDays(-2)
        });

        db.Users.Add(user);
        db.FeedbackMessages.Add(new FeedbackMessage
        {
            Name = "Иван Петров",
            Email = "ivan@example.com",
            Phone = "+7 900 000-00-00",
            Message = "Отличная программа для учебного проекта и контроля питания.",
            CreatedAt = DateTime.UtcNow.AddDays(-1)
        });

        db.SaveChanges();
    }
}
