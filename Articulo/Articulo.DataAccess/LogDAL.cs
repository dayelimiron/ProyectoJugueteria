using Articulo.Entities;
using Articulo.Entities.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.DataAccess
{
   public class LogDAL
    {
        private static LogDAL _instance;

        public static LogDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LogDAL();
                }
                return _instance;

            }


        }

        public List<Log> SellectAll()
        {
            List<Log> result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Logs.ToList();
            }

            return result;


        }

        public Log SellectById(int id)
        {
            Log result = null;
            using (AppDBContext _context = new AppDBContext())
            {
                result = _context.Logs
                    .FirstOrDefault(x => x.LogId == id);
            }

            return result;


        }
       
    }
}
