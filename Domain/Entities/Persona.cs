using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string foto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdDepartamento { get; set; }

        public Persona(int id, string nombre, string apellidos, DateTime fechaNacimiento, string direccion, string telefono, int idDepartamento, string foto)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Telefono = telefono;
            this.IdDepartamento = idDepartamento;
            this.foto = foto;
        }

        public Persona() { }


    }
}
