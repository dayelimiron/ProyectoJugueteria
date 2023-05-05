using Articulo.DataAccess;
using Articulo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.BusinessLogic
{
    public class CargoBL
    {
        private static CargoBL _instance;

        public static CargoBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CargoBL();

                return _instance;
            }
        }

        public List<Cargo> SellecALL()
        {
            List<Cargo> result;
            try
            {
                result = CargoDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }
       


        public bool Insert(Cargo entity)
        {
            bool result = false;
            try
            {
                result = CargoDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Cargo entity)
        {
            bool result = false;
            try
            {
                result = CargoDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }


        public bool Delete(int id)
        {

            bool result = false;
            try
            {
                result = CargoDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error. " + ex.Message);
            }

            return result;
        }
    }
}
