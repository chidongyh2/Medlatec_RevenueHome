using Newtonsoft.Json;
using SignSevice.v4.Gateway.Client.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Gateway.v4.SampleWeb.Common
{
    public class Sign
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(Sign));
        private static string Error = "";
        public static string GetLastError()
        {
            return Error;
        }

        public static byte[] SignPdf(byte[] unsignData, string fileName, string groupId, string certId, string access_token)
        {
            // Node chứa chữ ký ex: root/desigs/desig
            //((XmlHashSigner)signer).SetParentNodePath("note/disigns/disign");
            var fileDataBase64 = Convert.ToBase64String(unsignData);

            // Sign file using service api
            var signedDataBase64 = _sign(fileDataBase64, fileName, "pdf", groupId, certId, access_token);
            if (string.IsNullOrEmpty(signedDataBase64))
            {
                Error = "Sign error";
                return null;
            }

            byte[] signed = Convert.FromBase64String(signedDataBase64);
            return signed;
        }


        public static byte[] SignXml(byte[] unsignData, string fileName, string groupId, string certId, string access_token)
        {
            // Node chứa chữ ký ex: root/desigs/desig
            //((XmlHashSigner)signer).SetParentNodePath("note/disigns/disign");
            var fileDataBase64 = Convert.ToBase64String(unsignData);

            // Sign file using service api
            var signedDataBase64 = _sign(fileDataBase64, fileName,"xml", groupId, certId, access_token);
            if (string.IsNullOrEmpty(signedDataBase64))
            {
                Error = "Sign error";
                return null;
            }

            byte[] signed = Convert.FromBase64String(signedDataBase64);
            return signed;
        }

        public static byte[] SignOffice(byte[] unsignData, string fileName, string groupId, string certId, string access_token)
        {
            var fileDataBase64 = Convert.ToBase64String(unsignData);

            // Sign file using service api
            var signedDataBase64 = _sign(fileDataBase64, fileName, "docx", groupId, certId, access_token);
            if (string.IsNullOrEmpty(signedDataBase64))
            {
                Error = "Sign error";
                return null;
            }

            byte[] signed = Convert.FromBase64String(signedDataBase64);
            return signed;
        }

        private static string _sign(string fileDataBase64, string fileName, string type, string groupId, string certId, string token)
        {
            var response = CoreServiceClient.Query(new RequestMessage
            {
                RequestID = Guid.NewGuid().ToString(),
                ServiceID = "SignServer",
                FunctionName = "Sign",
                Parameter = new SignParameter
                {
                    ServiceGroupID = groupId,
                    CertID = certId,
                    Type = type,
                    FileName = fileName,
                    DataBase64 = fileDataBase64
                }
            }, token);
            if (response == null)
            {
                Error = "Service not response";
                return null;
            }
            if (response.ResponseCode == 1)
            {
                var str = JsonConvert.SerializeObject(response.Content);
                SignResponse acc = JsonConvert.DeserializeObject<SignResponse>(str);
                if (acc != null)
                {
                    return acc.SignedData;
                }
            }
            else
            {
                Error = response.ResponseContent;
            }

            return null;
        }
    }
}