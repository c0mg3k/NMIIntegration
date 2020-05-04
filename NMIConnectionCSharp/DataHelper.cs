using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NMIConnectionCSharp
{
    public class DataHelper
    {
        public static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            return (propertyExpression.Body as MemberExpression).Member.Name;
        }
        public static string GetNMIPropName(string val)
        {
            return getuntilchar(val, '=');
        }
        public static string GetNMIPropName(string val, char stopchar)
        {
            return getuntilchar(val, stopchar);
        }
        public static string GetNMIPropValue(string val)
        {
            return getafterchar(val, '=');
        }
        public static string GetNMIPropValue(string val, char startchar)
        {
            return getafterchar(val, startchar);
        }
        private static string getuntilchar(string val, char stopchar)
        {
            int stopcharlocation = val.IndexOf(stopchar);
            return val.Substring(0, stopcharlocation);
        }
        private static string getafterchar(string val, char startchar)
        {
            int startcharlocation = val.IndexOf(startchar);
            return val.Substring(startchar, val.Length);
        }
    }
}
