using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase
{
    public class Auxiliares
    {
        public static void SetEnumProp<t>(t Property, string value)
        {
            try
            {
                Property = (t)Enum.Parse(typeof(t), value);
            }
            catch (Exception)
            {
                throw new Exception("No se puede asignar el valor: " + value + " a la propiedad " + typeof(t).Name); ;
            }
        }
        public static string GetInnerException(Exception Ex)
        {
            if (Ex.InnerException != null)
            {
                return GetInnerException(Ex.InnerException);
            }
            else
            {
                return Ex.Message;
            }
        }
        public static List<System.Data.Entity.Validation.DbValidationError> GetErrors(Contexto.DataBaseContexto DB)
        {
            List<System.Data.Entity.Validation.DbValidationError> Returned = new List<System.Data.Entity.Validation.DbValidationError>();
            DB.GetValidationErrors().ToList().ForEach(o => { Returned.AddRange(o.ValidationErrors); });
            return Returned;
        }
    }
}
