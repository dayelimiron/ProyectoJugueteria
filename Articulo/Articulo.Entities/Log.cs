using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.Entities
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public DateTime Fecha { get; set; }

        [MaxLength(50)]
        [Required]
        public string Tabla { get; set; }
        [MaxLength(50)]
        [Required]
        public string Accion { get; set; }
        [MaxLength(500)]
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Usuario { get; set; }
        public virtual Usuario Usuarios { get; set; }

    }
}
