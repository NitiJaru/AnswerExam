using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using A1.Lib;

namespace A1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {

        public static InterestCalculator calculator = new InterestCalculator();

        [HttpPost]
        public void SetInterestPercent(int interestPercent) => calculator.SetInterestPercent(interestPercent);

        [HttpGet("{principleAmount}/{yearAmount}")]
        public IEnumerable<double> Calculate(double principleAmount, int yearAmount) => calculator.Calculate(principleAmount, yearAmount).ToList();
    }
}
