using System;
using System.Collections.Generic;

namespace Calc.Api.Operations
{
    public interface IOperationsMap
    {
        IOperation GetOperation(string @operator);
    }

    public class OperationsMap: IOperationsMap
    {
        private readonly Dictionary<string, IOperation> _commands = new Dictionary<string, IOperation>();

        public void Add(string key, IOperation operation)
        {
            _commands.Add(key, operation);
        }

        public IOperation GetOperation(string key)
        {
            if (!_commands.ContainsKey(key))
                throw new ArgumentException("Invalid operation");

            return _commands[key];
        }
    }

    
}