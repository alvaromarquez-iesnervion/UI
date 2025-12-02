using Domain.DTOs;
using Domain.Entities;
using Domain.interfaces.usecases;
using Domain.usecases;
using Microsoft.AspNetCore.Mvc;
using UI.Mappers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {

        private readonly IPersonaRepositoryUsecase _personaRepositoryUsecase;
        public PersonasController(IPersonaRepositoryUsecase personaRepositoryUsecase)
        {
            _personaRepositoryUsecase = personaRepositoryUsecase;
        }

        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<PersonaConNombreDepartamento> personas = _personaRepositoryUsecase.getAllPersonasConNombreDepartamento();

            try
            {
                if (personas.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(personas);
                }

            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            PersonaConNombreDepartamento persona = new PersonaConNombreDepartamento();
            try
            {
                persona = _personaRepositoryUsecase.getPersonaConNombreDepartamento(id);
                if (persona == null)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(persona);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post([FromBody] PersonaConListadoDepartamento personaConListadoDepartamento)
        {
            
            IActionResult salida;
            Persona persona = new Persona(); 
            try
            {
                persona= DTOtoPersona.personaConListadoDepartamentoToPersona(personaConListadoDepartamento);
                _personaRepositoryUsecase.createPersona(persona);
                salida = CreatedAtAction(nameof(Get), new { id = persona.Id }, persona);
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PersonaConListadoDepartamento personaConListadoDepartamento)
        {   
            IActionResult salida;
            Persona persona = new Persona();

            try
            {
                persona = DTOtoPersona.personaConListadoDepartamentoToPersona(personaConListadoDepartamento);
                _personaRepositoryUsecase.updatePersona(id, persona);
                salida = CreatedAtAction(nameof(Get), new { id = persona.Id }, persona);
            }
            catch
            {
                salida = BadRequest();

            }

            return salida;

        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            IActionResult salida;
            try
            {
                _personaRepositoryUsecase.deletePersona(id);
                salida = NoContent();
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }
    }
}
