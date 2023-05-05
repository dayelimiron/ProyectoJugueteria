using Articulo.Entities.AppContext;
using Articulo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.DataAccess
{
    public class VentaDAL
    {
        private static VentaDAL _instance;

        public static VentaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VentaDAL();
                }
                return _instance;

            }

        }

        public bool Insert(Venta entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                var query = _context.Ventas
                    .FirstOrDefault(x => x.FechaVenta.Equals(entity.FechaVenta)
                    );
                if (query == null)
                {
                    _context.Ventas.Add(entity);
                    result = _context.SaveChanges() > 0;
                    

                }

                return result;

            }

        }


        public List<Venta> SellectAll()
        {
            List<Venta> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Ventas.ToList();
            }

            return result;


        }

        public Venta SellectById(int id)
        {
            Venta result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Ventas
                    .FirstOrDefault(x => x.VentaId == id);
            }

            return result;


        }

    }
}
