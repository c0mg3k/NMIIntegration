using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMIConnectionCSharp
{
    class NMIResponse
    {
        public int Response { get; private set; }
        public string ResponseText { get; private set; }
        public string AuthCode { get; private set; }
        public string TransactionId { get; private set; }
        public string AvsResponse { get; private set; }
        public string CvvResponse { get; private set; }
        public string OrderId { get; private set; }
        public string Response_Code { get; private set; }
        public string Emv_Auth_Response_Data { get; set; }
        public NMIResponse(string response, string responsetext, string authcode, string transactionid, string avsresponse, string cvvresponse, string orderid, string response_code, string emv_auth_response_data)
        {
            Response = int.Parse(response);
            ResponseText = responsetext;
            AuthCode = authcode;
            TransactionId = transactionid;
            AvsResponse = avsresponse;
            CvvResponse = cvvresponse;
            OrderId = orderid;
            Response_Code = response_code;
            Emv_Auth_Response_Data = emv_auth_response_data;
        }
        public void PrintResponseInformation()
        {
            Console.WriteLine(@"Response: {0}
Response Text: {1}
Auth Code: {2}
TransactionId: {3}
AvsResponse: {4}
CvvResponse: {5}
OrderId: {6}
Response_Code: {7}
Emv_Auth_Response_Data : {8}", Response, ResponseText, AuthCode, TransactionId, AvsResponse, CvvResponse, OrderId, Response_Code, Emv_Auth_Response_Data);
        }
        
    }
}
