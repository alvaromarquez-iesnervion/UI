using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Departamentos")]
    public class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Column("Nombre")]
        public string Nombre { get; set; }

        // Propiedad de navegación (opcional pero recomendada)
        public virtual ICollection<Persona> Personas { get; set; }

        public Departamento(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            Personas = new HashSet<Persona>();
        }

        public Departamento()
        {
            Personas = new HashSet<Persona>();
        }
    }
}