using Articulo.Entities;
using Articulo.Entities.AppContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.DataAccess
{
    public class EstadoDAL
    {
        private static EstadoDAL _instance;

        public static EstadoDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EstadoDAL();
                }
                return _instance;

            }


        }

        public List<Estado> SellectAll()
        {
            List<Estado> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Estados.ToList();
            }

            return result;


        }

        public Estado SellectById(int id)
        {
            Estado result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Estados
                    .FirstOrDefault(x => x.EstadoId == id);
            }

            return result;
        }

        public bool Insert(Estado entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                var query = _context.Estados.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));
                if (query == null)
                {
                    _context.Estados.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }
        public bool Update(Estado entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {

                var query = _context.Estados.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));


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

                var query = _context.Estados.FirstOrDefault(x => x.EstadoId == Id);
                if (query != null)
                {
                    _context.Estados.Remove(query);
                    result = _context.SaveChanges() > 0;
                }

                return result;
            }

        }


    }
}

