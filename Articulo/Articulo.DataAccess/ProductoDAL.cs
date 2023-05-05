using Articulo.Entities;
using Articulo.Entities.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.DataAccess
{
    public class ProductoDAL
    {

        private static ProductoDAL _instance;

        public static ProductoDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductoDAL();
                }
                return _instance;

            }


        }

        public bool Insert(Producto entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                var query = _context.Productos
                    .FirstOrDefault(x => x.NombreProducto.Equals(entity.NombreProducto)
                    );
                if (query == null)
                {
                    _context.Productos.Add(entity);
                    result = _context.SaveChanges() > 0;
                    _context.Inventarios.Add(new Inventario { ProductoId = entity.ProductoId, cantidad = 0 });

                }

                return result;

            }

        }

       
        public List<Producto> SellectAll()
        {
            List<Producto> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Productos.ToList();
            }

            return result;


        }

        public Producto SellectById(int id)
        {
            Producto result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Productos
                    .FirstOrDefault(x => x.ProductoId == id);
            }

            return result;


        }
       
    }
}
