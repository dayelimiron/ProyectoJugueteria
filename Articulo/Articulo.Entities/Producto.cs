using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.Entities
{
    public class Producto
    {
        [Key]//Para que sea key si se quiere Code
        public int ProductoId { get; set; }
        [MaxLength(30)]
        [Required]//No permite valores nulos
        public string NombreProducto { get; set; }
        [MaxLength(50)]
        [Required]
        public string Descripcion { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]

        public int CategoriaId { get; set; }
        [Required]
        public int EstadoId { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Categoria Categorias { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
        public virtual DetalleCompra DetalleCompras { get; set; }
        public virtual DetalleVenta DetalleVenta { get; set; }

    }
}
