using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WappExcelNobleza.Extensiones
{
    public static class EventExtension
    {
        public static void RemoveEvents<T>(this T target) where T : class
        {
            var propInfo = typeof(T).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            var list = (EventHandlerList)propInfo.GetValue(target, null);
            list.Dispose();
        }
    }
}
