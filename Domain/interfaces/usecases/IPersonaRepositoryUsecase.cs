using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces.usecases
{
    public interface IPersonaRepositoryUsecase
    {
        public List<PersonaConNombreDepartamento> getAllPersonasConNombreDepartamento();
        public PersonaConListadoDepartamento getPersonaConListadoDepartamento(int id);
        public PersonaConNombreDepartamento getPersonaConNombreDepartamento(int id);

        public int createPersona(Persona persona);
        public int updatePersona(int id, Persona persona);
        public int deletePersona(int id);
    }
}
