using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NMIConnectionCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://secure.networkmerchants.com/api/transact.php";
            var request = new NMIRequest("6457Thfj624V5r7WUwc5v6a68Zsd6YEm", "John", "Smith", "1234 Main St.", "Chicago", "IL", "60193");
            var requestObj = (HttpWebRequest)WebRequest.Create(url);

            requestObj.Method = "POST";
            requestObj.ContentLength = request.RequestString.Length;
            requestObj.ContentType = "application/x-www-form-urlencoded";
            StreamWriter NMIWriter = new StreamWriter((requestObj.GetRequestStream()));
            var resprops = GetObjProps<NMIResponse>();
            foreach(var name in resprops)
            {
                Console.WriteLine(name.ToLower());
            }
            try
            {

                NMIWriter.Write(request.RequestString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception has occured...  ");
                Console.WriteLine("Exception Message : {0}", ex.Message);
                Console.WriteLine("Stack Trace: {0}", ex.StackTrace);
            }
            finally
            {
                NMIWriter.Close();
            }

            HttpWebResponse NMIResponse = (HttpWebResponse)requestObj.GetResponse();
            using (StreamReader sr = new StreamReader(NMIResponse.GetResponseStream()))
            {
                request.ResponseString = sr.ReadToEnd();
            }
            Console.WriteLine("raw response string: {0}", request.ResponseString);
            Console.WriteLine("");
            Dictionary<string, string> responsekeyvals = new Dictionary<string, string>();
            var items = ParseResponseString(request.ResponseString);
            foreach (var item in items)
            {
                responsekeyvals.Add(DataHelper.GetNMIPropName(item), DataHelper.GetNMIPropValue(item));
            }
            foreach(var keyval in responsekeyvals)
            {
                Console.WriteLine("Key: {0} Val: {1}", keyval.Key, keyval.Value);
            }
            var result = DataHelper.ResponseMapper(responsekeyvals);

            Console.ReadLine();
        }
        public static string[] ParseResponseString(string response)
        {
            var nmiresponse = new NMIResponse();
            var items = response.Split('&');
            foreach (var item in items)
            {
                var propname = DataHelper.GetNMIPropName(item);
                
                var stuff = DataHelper.GetPropertyName(() => nmiresponse.AuthCode).ToString();
                //switch (item)
                //{
                //    case stuff:
                //        break;
                //}
            }

            return items;
        }

        public static List<string> GetObjProps<T>()
        {
            var props = typeof(T).GetProperties();
            var names = new List<string>();

            foreach(PropertyInfo prop in props)
            {
                names.Add(prop.Name);
            }
            return names;
        }
    }
}
