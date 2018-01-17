using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase
{
    public class Auxiliares       
    {
        /// <summary>
        /// Transforma un string en un valor de enumeracion y lo asigna a una propiedad del tipo de la enumeracion
        /// </summary>
        /// <typeparam name="t">Tipo de la Enumeracion</typeparam>
        /// <param name="Property">Propiedad del objecto al que se le asignara el valor(Debe ser del tipo de la enumeración)</param>
        /// <param name="value">string con el valor a asiganr</param>
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
        /// <summary>
        /// Devuelve la Excepcion mas profunda.
        /// </summary>
        /// <param name="Ex">Excepcion a analizar</param>
        /// <returns></returns>
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
        /// <summary>
        /// Devuelve una lista con los errores del entity.
        /// </summary>
        /// <param name="DB">Contexto que se analizara</param>
        /// <returns></returns>
        public static List<System.Data.Entity.Validation.DbValidationError> GetErrors(Contexto.DataBaseContexto DB)
        {
            List<System.Data.Entity.Validation.DbValidationError> Returned = new List<System.Data.Entity.Validation.DbValidationError>();
            DB.GetValidationErrors().ToList().ForEach(o => { Returned.AddRange(o.ValidationErrors); });
            return Returned;
        }
    }
}
