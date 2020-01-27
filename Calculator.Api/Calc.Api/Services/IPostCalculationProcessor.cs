using Calc.Api.Models;

namespace Calc.Api.Services
{
    public interface IPostCalculationProcessor
    {
        CalculationResult Process(ResultType type, double value);
    }

    public class PostCalculationProcessor : IPostCalculationProcessor
    {
        public virtual CalculationResult Process(ResultType type, double value)
        {
            switch (type)
            {
                case ResultType.Colored:
                    return new ColoredCalculationResult()
                    {
                        Value = value,
                        Color = (int)value % 2 == 0 ? "green" : "red"
                    };
                default:
                    return new CalculationResult() { Value = value };
            }
        }
    }
}