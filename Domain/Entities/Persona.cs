using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Personas")]
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Column("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(60)]
        [Column("Apellidos")]
        public string Apellidos { get; set; }

        [StringLength(15)]
        [Column("Telefono")]
        public string Telefono { get; set; }

        [StringLength(60)]
        [Column("Direccion")]
        public string Direccion { get; set; }

        [StringLength(255)]
        [Column("Foto")]
        public string foto { get; set; }

        [Required]
        [Column("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Column("IDDepartamento")]
        [ForeignKey("Departamento")]
        public int IdDepartamento { get; set; }

        public virtual Departamento Departamento { get; set; }

        public Persona(int id, string nombre, string apellidos, DateTime fechaNacimiento, string direccion, string telefono, int idDepartamento, string foto)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Telefono = telefono;
            IdDepartamento = idDepartamento;
            this.foto = foto;
        }

        public Persona() { }
    }
}