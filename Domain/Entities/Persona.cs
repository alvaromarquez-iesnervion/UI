using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Persona
    {
        public int Id { get; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        Persona(int id, string nombre, string apellidos, DateTime fechaNacimiento, string direccion, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Telefono = telefono;
        }

        
    }
}
