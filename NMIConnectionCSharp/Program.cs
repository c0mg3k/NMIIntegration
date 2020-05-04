using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
            try
            {
                NMIWriter.Write(request.RequestString);
            }
            catch(Exception ex)
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
            Console.WriteLine(request.ResponseString);
            Console.ReadLine();
        }
    }
}
