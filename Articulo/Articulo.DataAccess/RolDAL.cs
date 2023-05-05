using Articulo.Entities;
using Articulo.Entities.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Articulo.DataAccess
{
    public class RolDAL
    {
        private static RolDAL _instance;

        public static RolDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RolDAL();
                }
                return _instance;

            }


        }

        public List<Rol> SellectAll()
        {

            List<Rol> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Roles.Include(x => x.Estado).ToList();
            }

            return result;


        }

        public Rol SellectById(int id)
        {
            Rol result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Roles
                    .FirstOrDefault(x => x.RolId == id);
            }

            return result;


        }
        public bool Insert(Rol entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                var query = _context.Roles.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));
                if (query == null)
                {
                    _context.Roles.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }
        public bool Update(Rol entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {

                var query = _context.Roles.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));


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

                var query = _context.Roles.FirstOrDefault(x => x.RolId == Id);
                if (query != null)
                {
                    _context.Roles.Remove(query);
                    result = _context.SaveChanges() > 0;
                }

                return result;
            }

        }
    }
}
