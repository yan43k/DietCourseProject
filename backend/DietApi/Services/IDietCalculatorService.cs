using DietApi.DTO;

namespace DietApi.Services;

public interface IDietCalculatorService
{
    DietCalculationResponse Calculate(CalculateDietRequest request);
}
