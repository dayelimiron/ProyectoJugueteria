using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.Entities
{
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }
        [Required]
        public DateTime FechaVenta { get; set; }
        [Required]
        public decimal TotalVenta { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int EstadoId { get; set; }
        [Required]
        public int UsuarioId { get; set; }


        //de uno a uno
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }


        public virtual Cliente Clientes { get; set; }
        public virtual Usuario Usuarios { get; set; }

    }
}
