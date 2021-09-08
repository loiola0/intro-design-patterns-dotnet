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

        private readonly SingletonContainer singletonContainer;

        public SingletonController(SingletonContainer singletonContainer)
        {
            this.singletonContainer = singletonContainer;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            //var singleton = Singleton.Instance;
            
            return Ok(singletonContainer);
        }
    }
}