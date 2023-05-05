using Articulo.DataAccess;
using Articulo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo.BusinessLogic
{
    public class ProveedorBL
    {
        private static ProveedorBL _instance;

        public static ProveedorBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProveedorBL();

                return _instance;
            }
        }

        public List<Proveedor> SellecALL()
        {
            List<Proveedor> result;
            try
            {
                result = ProveedorDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(Proveedor entity)
        {
            bool result = false;
            try
            {
                result = ProveedorDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Proveedor entity)
        {
            bool result = false;
            try
            {
                result = ProveedorDAL.Instance.Update(entity);
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
                result = ProveedorDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error. " + ex.Message);
            }

            return result;
        }
    }
}
