using Articulo.Entities.AppContext;
using Articulo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.DataAccess
{
    public class CompraDAL
    {
        private static CompraDAL _instance;

        public static CompraDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CompraDAL();
                }
                return _instance;

            }

        }

        public bool Insert(Compra entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                var query = _context.Compras
                    .FirstOrDefault(x => x.FechaCompra.Equals(entity.FechaCompra)
                    );
                if (query == null)
                {
                    _context.Compras.Add(entity);
                    result = _context.SaveChanges() > 0;
                   

                }

                return result;

            }

        }


        public List<Compra> SellectAll()
        {
            List<Compra> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Compras.ToList();
            }

            return result;


        }

        public Compra SellectById(int id)
        {
            Compra result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Compras
                    .FirstOrDefault(x => x.CompraId == id);
            }

            return result;


        }
    }
}
