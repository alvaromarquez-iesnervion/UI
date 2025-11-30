using Domain.Entities;
using Domain.interfaces.repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class PersonaConNombreDepartamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string NombreDepartamento { get; set; }
        public string foto { get; set; }
        public PersonaConNombreDepartamento(Persona persona, IDepartamentoRepository repo)
        {
            Id= persona.Id;
            Nombre = persona.Nombre;
            Apellidos = persona.Apellidos;
            FechaNacimiento = persona.FechaNacimiento;
            Direccion = persona.Direccion;
            Telefono = persona.Telefono;
            NombreDepartamento=repo.getDepartamentoByID(persona.IdDepartamento).Nombre;
            foto = persona.foto;
        }
        public PersonaConNombreDepartamento()
        {
            Id= 0;
            Nombre = string.Empty;
            Apellidos = string.Empty;
            FechaNacimiento = DateTime.MinValue;
            Direccion = string.Empty;
            Telefono = string.Empty;
            NombreDepartamento = string.Empty;
            foto = string.Empty;
            
        }
    }
}
