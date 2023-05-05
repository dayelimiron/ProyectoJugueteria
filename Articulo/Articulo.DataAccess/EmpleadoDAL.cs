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
    public class EmpleadoDAL
    {
        private static EmpleadoDAL _instance;

        public static EmpleadoDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmpleadoDAL();
                }
                return _instance;

            }


        }
        public List<Empleado> SellectAll()
        {
            List<Empleado> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Empleados.Include(x => x.Estado).Include(u =>u.Usuario)
                    .Include(c =>c.Cargos).ToList();
            }

            return result;


        }

        public Empleado SellectById(int id)
        {
            Empleado result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Empleados
                    .FirstOrDefault(x => x.EmpleadoId == id);
            }

            return result;


        }
        public bool Insert(Empleado entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                var query = _context.Empleados.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));
                if (query == null)
                {
                    _context.Empleados.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }

        public bool Update(Empleado entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {

                var query = _context.Empleados.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));


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

                var query = _context.Empleados.FirstOrDefault(x => x.EmpleadoId == Id);
                if (query != null)
                {
                    _context.Empleados.Remove(query);
                    result = _context.SaveChanges() > 0;
                }

                return result;
            }

        }

    }
}
