using Domain.Entities;
using Domain.interfaces.usecases;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoRepositoryUsecase _departamentoRepositoryUsecase;

        public DepartamentosController(IDepartamentoRepositoryUsecase departamentoRepositoryUsecase)
        {
            _departamentoRepositoryUsecase = departamentoRepositoryUsecase;
        }

        // GET: api/<DepartamentosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var departamentos = _departamentoRepositoryUsecase.getAllDepartamentos();
                if (departamentos == null || !departamentos.Any())
                {
                    return NoContent();
                }
                return Ok(departamentos);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<DepartamentosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var departamento = _departamentoRepositoryUsecase.getDepartamentoByID(id);
                if (departamento == null)
                {
                    return NoContent();
                }
                return Ok(departamento);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/<DepartamentosController>
        [HttpPost]
        public IActionResult Post([FromBody] Departamento departamento)
        {
            try
            {
                _departamentoRepositoryUsecase.createDepartamento(departamento);
                return CreatedAtAction(nameof(Get), new { id = departamento.Id }, departamento);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<DepartamentosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Departamento departamento)
        {
            try
            {
                var departamentoExistente = _departamentoRepositoryUsecase.getDepartamentoByID(id);
                if (departamentoExistente == null)
                {
                    return NotFound();
                }

                _departamentoRepositoryUsecase.updateDepartamento(id, departamento);
                return Ok(departamento);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<DepartamentosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _departamentoRepositoryUsecase.deleteDepartamento(id);
                if (result == -1)
                {
                    return BadRequest("No se puede eliminar el departamento porque tiene personas asignadas.");
                }
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
