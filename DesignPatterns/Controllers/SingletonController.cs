using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DesignPatterns.Infra.Singleton;


namespace DesignPatterns.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class SingletonController : ControllerBase
    {

        [HttpGet()]
        public IActionResult Get()
        {
            var singleton = new Singleton();
            
            return Ok(singleton);
        }
    }
}