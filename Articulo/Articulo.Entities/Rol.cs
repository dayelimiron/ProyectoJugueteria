using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.Entities
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        [MaxLength(80)]
        [Required]
        public string Nombre { get; set; }

        [Required]
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }


    }
}
