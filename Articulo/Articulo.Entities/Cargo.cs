using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.Entities
{
   public class Cargo
    {
        [Key]//Para que sea key si se quiere Code
        public int CargoId { get; set; }
        [MaxLength(30)]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
