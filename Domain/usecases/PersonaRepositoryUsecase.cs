using Domain.DTOs;
using Domain.Entities;
using Domain.interfaces.repos;
using Domain.interfaces.usecases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.usecases
{
    public class PersonaRepositoryUsecase : IPersonaRepositoryUsecase
    {
        public IPersonaRepository _personaRepository;
        public IDepartamentoRepository _departamentoRepository;

        public PersonaRepositoryUsecase(IPersonaRepository personaRepository, IDepartamentoRepository departamentoRepository)
        {
            _personaRepository = personaRepository;
            _departamentoRepository = departamentoRepository;
        }
        
        public List<PersonaConNombreDepartamento> getAllPersonasConNombreDepartamento()
        {
            List<PersonaConNombreDepartamento> personaConNombreDepartamento = new List<PersonaConNombreDepartamento>();
            foreach (var persona in _personaRepository.getAllPersonas())
            {
                PersonaConNombreDepartamento dto = new PersonaConNombreDepartamento(persona, _departamentoRepository);
                personaConNombreDepartamento.Add(dto);
            }
            return personaConNombreDepartamento;
        }

        public PersonaConListadoDepartamento getPersonaConListadoDepartamento(int id)
        {
            var persona = new Persona();
            PersonaConListadoDepartamento dto = new PersonaConListadoDepartamento();

            if (id == 0)
            {
                dto = new PersonaConListadoDepartamento();
                dto.listadoDepartamentos = _departamentoRepository.getAllDepartamentos();
                dto.FechaNacimiento = DateTime.Now;
            }
            else
            {
                persona = _personaRepository.getPersonaByID(id);
                 dto = new PersonaConListadoDepartamento(persona, _departamentoRepository.getAllDepartamentos());
            }
                return dto;

        }

        public PersonaConNombreDepartamento getPersonaConNombreDepartamento(int id)
        {
            var persona = _personaRepository.getPersonaByID(id);
            PersonaConNombreDepartamento dto = new PersonaConNombreDepartamento(persona, _departamentoRepository);
            return dto;
        }

        public int createPersona(Persona persona)
        {
            return _personaRepository.createPersona(persona);
        }

        public int updatePersona(int Persona, Persona persona)
        {
            return _personaRepository.updatePersona(Persona, persona);
        }

        public int deletePersona(int id)
        {
            return _personaRepository.deletePersona(id);
        }

    }
}
