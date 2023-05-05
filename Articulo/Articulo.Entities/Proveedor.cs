using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.Entities
{
    public class Proveedor
    {
        [Key]
        public int ProveedorId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(50)]
        [Required]
        public string Apellido { get; set; }
        [MaxLength(50)]
        [Required]
        public string Telefono { get; set; }
        [MaxLength(50)]
        [Required]
        public string Direccion { get; set; }
        [Required]
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }

    }
}
