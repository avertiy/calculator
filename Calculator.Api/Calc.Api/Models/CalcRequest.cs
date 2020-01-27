namespace Calc.Api.Models
{
    //The idea about the json object
    //{
    //operands: [a,b,c,d,...], 
    //operators: [+,-,*,...],  //commands
    //resultType: 0 //'default' or 1 //'colored' etc.
    //}

    public class CalcRequest
    {
        public double[] Operands { get; set; }
        public string[] Operators { get; set; }
        public ResultType ResultType { get; set; }
    }

    public enum ResultType
    {
        Default = 0,
        Colored = 1,
        //etc.
    }


    public interface ICalculationResult
    {
        double Value { get; set; }
    }

    public class CalculationResult: ICalculationResult
    {
        public double Value { get; set; }
    }

    public class ColoredCalculationResult: CalculationResult
    {
        public string Color { get; set; }
    }
}