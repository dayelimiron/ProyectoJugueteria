using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Articulo.Entities
{
    public class Empleado
    {
        [Key]//Para que sea key si se quiere Code
        public int EmpleadoId { get; set; }
        [MaxLength(80)]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(80)]
        [Required]
        public string Apellido { get; set; }
        [MaxLength(80)]
        [Required]
        public string Direccion { get; set; }

        [MaxLength(20)]
        [Required]
        public string Telefono { get; set; }

        [MaxLength(30)]
        [Required]
        public string DUi { get; set; }
        [Required]
        public int CargoId { get; set; }

        [Required]
        public int EstadoId { get; set; }
        [Required]
        public int UsuarioId { get; set; }

        public virtual Cargo Cargos { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Usuario Usuario { get; set; }


    }
}
