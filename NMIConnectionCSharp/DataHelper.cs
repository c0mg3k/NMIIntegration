using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
        public static object ResponseMapper(Dictionary<string, string> keyvals)
        {
            var responseobj = new NMIResponse();
            var objtype = typeof(NMIResponse);
            var props = getobjprops<NMIResponse>();
            foreach (var prop in props)
            {
                foreach (var val in keyvals)
                {
                    if (prop.ToLower() == val.Key.ToLower())
                    {
                        objtype.GetProperty(prop).SetValue(responseobj, val.Value);
                    }
                }
            }
            return responseobj;
        }
        private static string getuntilchar(string val, char stopchar)
        {
            int stopcharlocation = val.IndexOf(stopchar);
            return val.Substring(0, stopcharlocation);
        }
        private static string getafterchar(string val, char startchar)
        {
            int startcharlocation = val.IndexOf(startchar) + 1;
            return val.Substring(startcharlocation);
        }
        private static List<string> getobjprops<T>()
        {
            var props = typeof(T).GetProperties();
            var names = new List<string>();

            foreach (PropertyInfo prop in props)
            {
                names.Add(prop.Name);
            }
            return names;
        }
    }
}
