using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Articulo.Entities
{
    public class Inventario
    {
        [Key]
        public int InventarioId { get; set; }
        [ForeignKey("Productos")]
        public int ProductoId { get; set; }
        [Required]
        public int cantidad { get; set; }

        public virtual Producto Productos { get; set; }


    }
}
