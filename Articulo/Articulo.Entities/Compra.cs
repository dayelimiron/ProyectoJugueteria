using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.Entities
{
    public class Compra
    {
        [Key]
        public int CompraId { get; set; }
        [Required]
        public DateTime FechaCompra { get; set; }
        [Required]
        public decimal TotalCompra { get; set; }
        [Required]
        public int ProveedorId { get; set; }
        [Required]
        public int UsuarioId { get; set; }

        public virtual ICollection <DetalleCompra> DetalleCompras { get; set; }


        public virtual Proveedor Proveedors { get; set; }

        public virtual Usuario Usuarios { get; set; }



    }
}
