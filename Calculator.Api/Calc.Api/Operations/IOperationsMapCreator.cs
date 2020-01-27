namespace Calc.Api.Operations
{
    public interface IOperationsMapCreator
    {
        IOperationsMap CreateMap();
    }

    public class OperationsMapCreator : IOperationsMapCreator
    {
        public virtual IOperationsMap CreateMap()
        {
            var map = new OperationsMap();
            map.Add("+", new Plus());
            map.Add("-", new Minus());
            map.Add("*", new Mul());
            map.Add("/", new Div());
            return map;
        }
    }
}