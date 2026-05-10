using DietApi.DTO;

namespace DietApi.Services;

public class DietCalculatorService : IDietCalculatorService
{
    public DietCalculationResponse Calculate(CalculateDietRequest request)
    {
        var coefficient = GetActivityCoefficient(request.ActivityLevel);
        var baseMetabolism = GetBaseMetabolism(request);
        var goalCalories = ApplyGoal(baseMetabolism * coefficient, request.Goal);

        var proteins = (int)Math.Round(request.Weight * GetProteinRatio(request.Goal));
        var fats = (int)Math.Round(goalCalories * 0.25 / 9);
        var carbohydrates = (int)Math.Round((goalCalories - proteins * 4 - fats * 9) / 4);

        return new DietCalculationResponse
        {
            Name = request.Name.Trim(),
            Gender = request.Gender,
            Age = request.Age,
            Height = request.Height,
            Weight = request.Weight,
            Goal = request.Goal,
            ActivityLevel = request.ActivityLevel,
            ActivityCoefficient = coefficient,
            Calories = (int)Math.Round(goalCalories),
            Proteins = proteins,
            Fats = fats,
            Carbohydrates = Math.Max(carbohydrates, 0),
            MenuPlan = BuildMenuPlan(request.Goal),
            CreatedAt = DateTime.UtcNow
        };
    }

    private static double GetBaseMetabolism(CalculateDietRequest request)
    {
        var gender = request.Gender.Trim().ToLowerInvariant();
        var genderModifier = gender.StartsWith("м") ? 5 : -161;
        return 10 * request.Weight + 6.25 * request.Height - 5 * request.Age + genderModifier;
    }

    private static double GetActivityCoefficient(string activity) => activity.Trim().ToLowerInvariant() switch
    {
        var value when value.Contains("миним") => 1.2,
        var value when value.Contains("лег") => 1.375,
        var value when value.Contains("умер") => 1.55,
        var value when value.Contains("выс") => 1.725,
        var value when value.Contains("очень") || value.Contains("экстрем") => 1.9,
        _ => 1.2
    };

    private static double ApplyGoal(double calories, string goal) => goal.Trim().ToLowerInvariant() switch
    {
        var value when value.Contains("похуд") => calories - 400,
        var value when value.Contains("набор") || value.Contains("мас") => calories + 350,
        _ => calories
    };

    private static double GetProteinRatio(string goal) => goal.Trim().ToLowerInvariant() switch
    {
        var value when value.Contains("похуд") => 2.0,
        var value when value.Contains("набор") || value.Contains("мас") => 1.8,
        _ => 1.6
    };

    private static string BuildMenuPlan(string goal)
    {
        var normalizedGoal = goal.Trim().ToLowerInvariant();

        if (normalizedGoal.Contains("похуд"))
        {
            return "Завтрак: омлет из двух яиц с овощами. Обед: индейка, бурый рис и салат. Перекус: греческий йогурт. Ужин: запеченная рыба и брокколи.";
        }

        if (normalizedGoal.Contains("набор") || normalizedGoal.Contains("мас"))
        {
            return "Завтрак: овсянка на молоке с бананом и орехами. Обед: говядина, паста из твердых сортов и овощи. Перекус: творог с медом. Ужин: курица, картофель и салат.";
        }

        return "Завтрак: каша с ягодами и творогом. Обед: куриная грудка, гречка и овощной салат. Перекус: фрукт и йогурт. Ужин: рыба с овощами и цельнозерновым хлебом.";
    }
}
