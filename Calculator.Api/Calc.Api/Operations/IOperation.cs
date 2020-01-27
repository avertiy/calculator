namespace Calc.Api.Operations
{
    public interface IOperation{
        double Execute(double arg1, double arg2);
    }

    public class Plus : IOperation
    {
        public double Execute(double arg1, double arg2)
        {
            return arg1 + arg2;
        }
    }

    public class Minus : IOperation
    {
        public double Execute(double arg1, double arg2)
        {
            return arg1 - arg2;
        }
    }

    public class Mul : IOperation
    {
        public double Execute(double arg1, double arg2)
        {
            return arg1 * arg2;
        }
    }
    
    public class Div : IOperation
    {
        public double Execute(double arg1, double arg2)
        {
            return arg1 / arg2;
        }
    }
}