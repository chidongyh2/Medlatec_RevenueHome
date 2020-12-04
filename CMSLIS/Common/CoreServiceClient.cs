using log4net;
using System;
using Newtonsoft.Json;
 
using System.Configuration;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using RestSharp;

namespace CMS_Medicons.Common
{
    public class CoreServiceClient
    {
        ILog logIn = log4net.LogManager.GetLogger("CMSLISLogError");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static ResponseMessage Query(RequestMessage req, string bearerToken)
        {
            // Verify service certificate. 
            ServicePointManager.ServerCertificateValidationCallback
                += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);

            // Read client certificate
            byte[] sslClientP12 = null;
            X509Certificate2 certificates = new X509Certificate2();
            try
            {
                sslClientP12 = Convert.FromBase64String(ConfigurationManager.AppSettings["CLIENT_KEYSTORE"]);
                byte[] passData = Convert.FromBase64String(ConfigurationManager.AppSettings["CLIENT_KEYSTORE_PASS"]);
                var password = ASCIIEncoding.UTF8.GetString(passData);
                certificates.Import(sslClientP12, password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
               // certificates.Import(sslClientP12, password, X509KeyStorageFlags.Exportable);
            }
            catch (Exception ex)
            {
                CMSLIS.Common.Common.AddToLogFile("Query: " + ex.ToString());
                return null;
            }

            // Create RestClient instance and add client certificate
            RestClient client = new RestClient(ConfigurationManager.AppSettings["GateWay_Enpoint"])
            {
                ClientCertificates = new X509CertificateCollection() { certificates }
            };

            RestRequest request = new RestRequest(Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(req);
            request.AddHeader("Authorization", $"Bearer {bearerToken}");

            IRestResponse response = null;
            try
            {
                response = client.Execute(request);
            }
            catch (Exception ex)
            {
                CMSLIS.Common.Common.AddToLogFile("Query1: " + ex.ToString());
            }

            if (response == null || response.ErrorException != null)
            {
               
                return null;
            }
            if (response.StatusCode != HttpStatusCode.OK)
            {
                 
                return null;
            }

            var respContent = response.Content;
            try
            {
                return JsonConvert.DeserializeObject<ResponseMessage>(respContent);
            }
            catch (Exception ex)
            {
                CMSLIS.Common.Common.AddToLogFile("Query2: " + ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Validate serrver ssl certificate, implement more secure in real environment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="cert"></param>
        /// <param name="chain"></param>
        /// <param name="policyErrors"></param>
        /// <returns></returns>
        public static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        {
            bool result = true;
            return result;
        }

    }
}