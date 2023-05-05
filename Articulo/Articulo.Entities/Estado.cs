using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.Entities
{
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Cargo> Cargos { get; set; }
        public virtual ICollection<Categoria> Categorias  { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<Proveedor> Proveedors { get; set; }
        public virtual ICollection<Rol> Rols { get; set; }


        //public virtual Compra Compras { get; set; }
        //public virtual Venta Ventas { get; set; }
        //public virtual Usuario Usuarios { get; set; }


    }
}
