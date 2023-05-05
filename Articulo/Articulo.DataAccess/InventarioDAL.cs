using Articulo.Entities.AppContext;
using Articulo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.DataAccess
{
    public class InventarioDAL
    {
        private static InventarioDAL _instance;

        public static InventarioDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InventarioDAL();
                }
                return _instance;

            }

        }

        public bool Insert(Inventario entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                var query = _context.Inventarios
                    .FirstOrDefault(x => x.cantidad.Equals(entity.cantidad)
                    );
                if (query == null)
                {
                    _context.Inventarios.Add(entity);
                    result = _context.SaveChanges() > 0;
                    

                }

                return result;

            }

        }


        public List<Inventario> SellectAll()
        {
            List<Inventario> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Inventarios.ToList();
            }

            return result;


        }

        public Inventario SellectById(int id)
        {
            Inventario result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Inventarios
                    .FirstOrDefault(x => x.InventarioId == id);
            }

            return result;


        }
    }
}
