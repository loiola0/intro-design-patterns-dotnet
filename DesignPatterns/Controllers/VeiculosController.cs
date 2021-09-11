using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DesignPatterns.Domain;

namespace DesignPatterns.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VeiculosController : ControllerBase
    {

        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculosController(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_veiculoRepository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var veiculo = _veiculoRepository.GetById(id);
            if(veiculo == null)
                return NotFound();
            return Ok(veiculo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Veiculo veiculo)
        {
            _veiculoRepository.Add(veiculo);
            return CreatedAtAction(nameof(Get),new {id = veiculo.Id},veiculo);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] Veiculo veiculo)
        {
            _veiculoRepository.Update(veiculo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var veiculo = _veiculoRepository.GetById(id);
            if(veiculo == null)
                return NotFound();
            
            _veiculoRepository.Update(veiculo);

            return NoContent();

        }

    }
}