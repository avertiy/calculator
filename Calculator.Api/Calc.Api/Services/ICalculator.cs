using System;
using System.Linq;
using Calc.Api.Models;
using Calc.Api.Operations;

namespace Calc.Api.Services
{
    public interface ICalculator
    {
        double Calculate(CalcRequest request);
    }
    
    public class SimpleCalculator : ICalculator
    {
        protected readonly IOperationsMap OperationsMap;

        public SimpleCalculator(IOperationsMapCreator operationsMapCreator)
        {
            OperationsMap = operationsMapCreator.CreateMap();
        }

        /// <summary>
        /// performs simple binary calculations over 2 operands and 1 operator 
        /// </summary>
        public virtual double Calculate(CalcRequest request)
        {
            //as my task is just to operate with 2 arguments and 1 operator
            //I implement simple and strait approach
            ValidateRequest(request);
            var operation = OperationsMap.GetOperation(request.Operators.First());
            var value = operation.Execute(request.Operands[0], request.Operands[1]);
            return value;
        }

        protected virtual void ValidateRequest(CalcRequest request)
        {
            if (null == request)
                throw new ArgumentNullException(nameof(request));

            if (request.Operands.Length != 2)
                throw new ArgumentException(Resources.InvalidOperandsCount);

            if (request.Operators.Length != 1)
                throw new ArgumentException(Resources.InvalidOperatorsCount);
        }
    }

    


}