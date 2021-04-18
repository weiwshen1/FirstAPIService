using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Example.Service.Services
{
    [Route("api/[controller]")]
    [ApiController]

    public class ValuesController : ControllerBase
    {
        public IEnumerable<string> GetValues() => new string[] {"value1", "value2", "value3" };

        public string GetValue => GetValues().First();
    }
}
