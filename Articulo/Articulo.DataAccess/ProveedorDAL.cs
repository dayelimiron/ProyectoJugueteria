using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Articulo.Entities;
using Articulo.Entities.AppContext;

namespace Articulo.DataAccess
{
    public class ProveedorDAL
    {
        private static ProveedorDAL _instance;

        public static ProveedorDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProveedorDAL();
                }
                return _instance;

            }


        }
        public List<Proveedor> SellectAll()
        {
            List<Proveedor> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Proveedores.Include(x=>x.Estado).ToList();
            }

            return result;


        }

        public Proveedor SellectById(int id)
        {
            Proveedor result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Proveedores
                    .FirstOrDefault(x => x.ProveedorId == id);
            }

            return result;


        }
        public bool Insert(Proveedor entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                var query = _context.Proveedores.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));
                if (query == null)
                {
                    _context.Proveedores.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }

        public bool Update(Proveedor entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {

                var query = _context.Proveedores.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));


                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }

        public bool Delete(int Id)
        {
            using (AppDBContext _context = new AppDBContext())
            {

                bool result = false;

                var query = _context.Proveedores.FirstOrDefault(x => x.ProveedorId == Id);
                if (query != null)
                {
                    _context.Proveedores.Remove(query);
                    result = _context.SaveChanges() > 0;
                }

                return result;
            }

        }

    }
}
