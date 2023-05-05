using Articulo.Entities;
using Articulo.Entities.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //Para usar expresiones lamda

namespace Articulo.DataAccess
{
    public class CategoriaDAL
    {
        private static CategoriaDAL _instance;

        public static CategoriaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CategoriaDAL();
                }
                return _instance;

            }


        }

        public List<Categoria> SellectAll()
        {
            List<Categoria> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Categorias.Include(x => x.Estado).ToList();
            }

            return result;


        }

        public Categoria SellectById(int id)
        {
            Categoria result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Categorias
                    .FirstOrDefault(x => x.CategoriaId == id);
            }

            return result;


        }

        public List<Producto> SellecProductotById(int id)
        {
            List<Producto> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Productos.Where(x => x.CategoriaId.Equals(id)).ToList();
            }

            return result;


        }

        public bool Insert(Categoria entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {
                var query = _context.Categorias.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));
                if (query == null)
                {
                    _context.Categorias.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }
        }

        public bool Update(Categoria entity)
        {
            bool result = false;
            using (AppDBContext _context = new AppDBContext())
            {

                var query = _context.Categorias.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));


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

                var query = _context.Categorias.FirstOrDefault(x => x.CategoriaId == Id);
                if (query != null)
                {
                     _context.Categorias.Remove(query);
                    result = _context.SaveChanges()>0;
                }

                return result;
            }

        }
    }
}
