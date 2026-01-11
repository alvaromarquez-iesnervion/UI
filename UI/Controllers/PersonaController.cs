using Microsoft.AspNetCore.Mvc;
using Domain.interfaces.usecases;
using Domain.Entities;
using Domain.DTOs;
using UI.Mappers;

namespace UI.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersonaRepositoryUsecase _personaRepositoryUsecase;
        private readonly IDepartamentoRepositoryUsecase _departamentoRepositoryUsecase;

        public PersonaController(
            IPersonaRepositoryUsecase personaRepositoryUsecase,
            IDepartamentoRepositoryUsecase departamentoRepositoryUsecase)
        {
            _personaRepositoryUsecase = personaRepositoryUsecase;
            _departamentoRepositoryUsecase = departamentoRepositoryUsecase;
        }

        public IActionResult Index()
        {
            List<PersonaConNombreDepartamento> personas = _personaRepositoryUsecase.getAllPersonasConNombreDepartamento();
            return View(personas);
        }

        public IActionResult Details(int id)
        {
            PersonaConNombreDepartamento persona = _personaRepositoryUsecase.getPersonaConNombreDepartamento(id);
            return View(persona);
        }

        public IActionResult Create()
        {
            List<Departamento> departamentos= _departamentoRepositoryUsecase.getAllDepartamentos();
            ViewBag.ListadoDepartamentos = departamentos;
            return View();
        }


        [HttpPost]
        public IActionResult Create(Persona persona)
        {

            _personaRepositoryUsecase.createPersona(persona);
            return RedirectToAction("Index");
        
        }

        public IActionResult Edit(int id)
        {
            PersonaConListadoDepartamento persona = _personaRepositoryUsecase.getPersonaConListadoDepartamento(id);
            return View(persona);
        }
        
        
        [HttpPost]
        public IActionResult Edit(PersonaConListadoDepartamento personaConListadoDepartamento)
        {
            
             Persona persona = DTOtoPersona.personaConListadoDepartamentoToPersona(personaConListadoDepartamento);

            _personaRepositoryUsecase.updatePersona(personaConListadoDepartamento.Id, persona);
            return RedirectToAction("Index");
        }
        

        public IActionResult Delete(int id)
        {
            PersonaConNombreDepartamento persona = _personaRepositoryUsecase.getPersonaConNombreDepartamento(id);
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
