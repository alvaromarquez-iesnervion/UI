using Microsoft.AspNetCore.Mvc;
using Domain.interfaces.usecases;
using Domain.interfaces.repos;
using Domain.usecases;
using Domain.Entities;
using Domain.DTOs;

namespace UI.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersonaRepositoryUsecase _personaRepositoryUsecase;

        public PersonaController(IPersonaRepositoryUsecase personaRepositoryUsecase)
        {
            _personaRepositoryUsecase = personaRepositoryUsecase;
        }

        public IActionResult Index()
        {
            var personas = _personaRepositoryUsecase.getAllPersonasConNombreDepartamento();
            return View(personas);
        }

        public IActionResult Details(int id)
        {
            var persona = _personaRepositoryUsecase.getPersonaConNombreDepartamento(id);

            return View(persona);
        }

        public IActionResult Create()
        {
            var personaConDepartamentos = _personaRepositoryUsecase.getPersonaConListadoDepartamento(0);

            return View(personaConDepartamentos);
        }


        [HttpPost]
        public IActionResult Create(PersonaConListadoDepartamento personaConListado)
        {
            Persona persona = new Persona
            {
                Id = 0,
                Nombre = personaConListado.Nombre,
                Apellidos = personaConListado.Apellidos,
                FechaNacimiento = personaConListado.FechaNacimiento,
                Direccion = personaConListado.Direccion,
                Telefono = personaConListado.Telefono,
                foto = personaConListado.foto,
                IdDepartamento = personaConListado.IdDepartamentoSeleccionado
            };

            _personaRepositoryUsecase.createPersona(persona);
            return RedirectToAction("Index");
        
        }

        public IActionResult Edit(int id)
        {
            var persona = _personaRepositoryUsecase.getPersonaConListadoDepartamento(id);
            return View(persona);
        }

        
        [HttpPost]
        public IActionResult Edit(PersonaConListadoDepartamento model)
        {
            
             Persona persona = new Persona
             {
                 Id = model.Id,
                 Nombre = model.Nombre,
                 Apellidos = model.Apellidos,
                 FechaNacimiento = model.FechaNacimiento,
                 Direccion = model.Direccion,
                 Telefono = model.Telefono,
                 IdDepartamento = model.IdDepartamentoSeleccionado,
                 foto = model.foto
             };

            _personaRepositoryUsecase.updatePersona(model.Id, persona);
            return RedirectToAction("Index");
        }
        

        public IActionResult Delete(int id)
        {
            var persona = _personaRepositoryUsecase.getPersonaConNombreDepartamento(id);
            return View(persona);
        }
        
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult PostDelete(PersonaConListadoDepartamento persona)
        {
            _personaRepositoryUsecase.deletePersona(persona.Id);
            return RedirectToAction("Index");
        }
    }
}
