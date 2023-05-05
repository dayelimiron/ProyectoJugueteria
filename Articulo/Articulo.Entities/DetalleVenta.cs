using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.Entities
{
    public class DetalleVenta
    {
        [Key]

        public int DetalleVentaId { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]

        public decimal Subtotal { get; set; }

      
       [Required]
        
        public int ProductoId { get; set; }
        [Required]
        public int VentaId { get; set; }
        //de uno a uno
        public  virtual Venta Venta { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }


    }

}