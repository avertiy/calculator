using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calc.Api.Models;
using Calc.Api.Operations;
using Calc.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly ICalculator _calculator;
        private readonly IPostCalculationProcessor _postCalculationProcessor;

        public CalcController(ICalculator calculator, IPostCalculationProcessor postCalculationProcessor)
        {
            _calculator = calculator;
            _postCalculationProcessor = postCalculationProcessor;
        }

        // POST api/calc
        [HttpPost]
        public CalculationResult Post([FromBody] CalcRequest request)
        {
            var value = _calculator.Calculate(request);
            var result = _postCalculationProcessor.Process(request.ResultType, value);
            return result;
        }
    }

    
}
