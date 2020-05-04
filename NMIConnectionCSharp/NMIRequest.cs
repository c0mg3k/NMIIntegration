using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMIConnectionCSharp
{
    class NMIRequest
    {
        private string _securitykey { get; set; }
        private string _firstname { get; set; }
        private string _lastname { get; set; }
        private string _address1 { get; set; }
        private string _city  { get; set; }
        private string _state { get; set; }
        private string _zip { get; set; }
        private decimal _amount { get; set; }
        private string _ccnumber { get; set; }
        private string _ccexpdate { get; set; }
        private string _cccsv { get; set; }
        public string RequestString { get; set; }
        public string ResponseString { get; set;}
        public StreamWriter StreamWriter { get; set; }
        public NMIRequest(string securitykey, string firstname, string lastname, string address1, string city, string state, string zip)
        {
            _securitykey = securitykey;
            _firstname = firstname;
            _lastname = lastname;
            _address1 = address1;
            _city = city;
            _state = state;
            _zip = zip;
            buildRequestString();
        }

        private void buildRequestString()
        {
            RequestString = "security_key=" + _securitykey + "&firstname=" + _firstname + "&lastname=" + _lastname + "&address1=" + _address1 + "&city=" + _city + "&state=" + _state + "&zip=" + _zip + "&payment=creditcard&type=sale" + "&amount=1.00&ccnumber=4111111111111111&ccexp=1015&cvv=123";
        }
    }
}
