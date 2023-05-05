using Articulo.Entities.AppContext;
using Articulo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.DataAccess
{
    public class DetalleVentaDAL
    {
        private static DetalleVentaDAL _instance;

        public static DetalleVentaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DetalleVentaDAL();
                }
                return _instance;

            }

        }

        public bool Insert(DetalleVenta entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                var query = _context.DetalleVentas
                    .FirstOrDefault(x => x.Cantidad.Equals(entity.Cantidad)
                    );
                if (query == null)
                {
                    _context.DetalleVentas.Add(entity);
                    result = _context.SaveChanges() > 0;
                   
                }

                return result;

            }

        }


        public List<DetalleVenta> SellectAll()
        {
            List<DetalleVenta> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.DetalleVentas.ToList();
            }

            return result;


        }

        public DetalleVenta SellectById(int id)
        {
            DetalleVenta result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.DetalleVentas
                    .FirstOrDefault(x => x.DetalleVentaId == id);
            }

            return result;


        }
    }
}
