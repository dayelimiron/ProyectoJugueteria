using Articulo.Entities.AppContext;
using Articulo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.DataAccess
{
    public class DetalleCompraDAL
    {
        private static DetalleCompraDAL _instance;

        public static DetalleCompraDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DetalleCompraDAL();
                }
                return _instance;

            }

        }

        public bool Insert(DetalleCompra entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                var query = _context.DetalleCompras
                    .FirstOrDefault(x => x.Cantidad.Equals(entity.Cantidad)
                    );
                if (query == null)
                {
                    _context.DetalleCompras.Add(entity);
                    result = _context.SaveChanges() > 0;
                   

                }

                return result;

            }

        }


        public List<DetalleCompra> SellectAll()
        {
            List<DetalleCompra> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.DetalleCompras.ToList();
            }

            return result;


        }

        public DetalleCompra SellectById(int id)
        {
            DetalleCompra result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.DetalleCompras
                    .FirstOrDefault(x => x.DetalleCompraId == id);
            }

            return result;


        }
    }
}
