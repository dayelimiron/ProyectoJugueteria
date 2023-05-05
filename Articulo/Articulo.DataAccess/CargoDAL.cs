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
    public class CargoDAL
    {
        private static CargoDAL _instance;

        public static CargoDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CargoDAL();
                }
                return _instance;

            }


        }

        public List<Cargo> SellectAll()
        {
            List<Cargo> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Cargos.Include(x => x.Estado).ToList();
            }

            return result;


        }

        public Cargo SellectById(int id)
        {
            Cargo result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Cargos
                    .FirstOrDefault(x => x.CargoId == id);
            }

            return result;


        }
        public bool Insert(Cargo entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                var query = _context.Cargos.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));
                if (query == null)
                {
                    _context.Cargos.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }

        public bool Update(Cargo entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {

                var query = _context.Cargos.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));


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

                var query = _context.Cargos.FirstOrDefault(x => x.CargoId == Id);
                if (query != null)
                {
                    _context.Cargos.Remove(query);
                    result = _context.SaveChanges() > 0;
                }

                return result;
            }

        }
    }
}

