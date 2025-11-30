using Domain.Entities;
using Domain.interfaces.repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class PersonaConListadoDepartamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public String foto { get; set; }
        public int IdDepartamentoSeleccionado { get; set; }
        public List<Departamento> listadoDepartamentos { get; set; }
        public PersonaConListadoDepartamento(Persona persona, List<Departamento> departamentos)
        {
            Id = persona.Id;
            Nombre = persona.Nombre;
            Apellidos = persona.Apellidos;
            FechaNacimiento = persona.FechaNacimiento;
            Direccion = persona.Direccion;
            Telefono = persona.Telefono;
            listadoDepartamentos = departamentos;
            foto = persona.foto;
        }

        public PersonaConListadoDepartamento()
        {

        }
    }
}
