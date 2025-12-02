using Domain.DTOs;
using Domain.Entities;
using Domain.interfaces.repos;
using Domain.interfaces.usecases;

namespace UI.Mappers
{
    public class DTOtoPersona
    {
        
        public static Persona personaConNombreDepartamentoToPersona(PersonaConNombreDepartamento personaConNombreDepartamento, IDepartamentoRepositoryUsecase departamentoRepositoryUsecase)
        {
            Persona persona = new Persona
            {
                Id = personaConNombreDepartamento.Id,
                Nombre = personaConNombreDepartamento.Nombre,
                Apellidos = personaConNombreDepartamento.Apellidos,
                FechaNacimiento = personaConNombreDepartamento.FechaNacimiento,
                Direccion = personaConNombreDepartamento.Direccion,
                Telefono = personaConNombreDepartamento.Telefono,
                foto = personaConNombreDepartamento.foto,

            };
            foreach (Departamento dept in departamentoRepositoryUsecase.getAllDepartamentos())
            {
                if (dept.Nombre == personaConNombreDepartamento.NombreDepartamento)
                {
                    persona.IdDepartamento = dept.Id;
                    break;
                }
            }
            return persona;

        }

        public static Persona personaConListadoDepartamentoToPersona(PersonaConListadoDepartamento personaConListadoDepartamento)
        {
            Persona persona = new Persona
            {
                Id = personaConListadoDepartamento.Id,
                Nombre = personaConListadoDepartamento.Nombre,
                Apellidos = personaConListadoDepartamento.Apellidos,
                FechaNacimiento = personaConListadoDepartamento.FechaNacimiento,
                Direccion = personaConListadoDepartamento.Direccion,
                Telefono = personaConListadoDepartamento.Telefono,
                foto = personaConListadoDepartamento.foto,
                IdDepartamento = personaConListadoDepartamento.IdDepartamentoSeleccionado,
            };
            
            return persona;
        }


    }
}
