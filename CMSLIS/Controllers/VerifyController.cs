using Newtonsoft.Json;
using SignSevice.v4.Gateway.Client.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CMS_Medicons.Controllers
{
    public class VerifyController : Controller
    {
        public JsonResult Verify(string accEmail, string data, string type, string name, string contentType)
        {
            byte[] dataArray = null;
            try
            {
                dataArray = Convert.FromBase64String(data);
            }
            catch (Exception)
            {
                return Json(new ResponseMessage
                {
                    ResponseCode = 3,
                    ResponseContent = "Chọn tệp cần kiểm tra để tiếp tục"
                });
            }
            List<string> allowedTypes = new List<string>() { "xml", "docx", "xlsx", "pptx", "pdf", "p7b", "txt" };
            if (string.IsNullOrEmpty(type) || !allowedTypes.Contains(type))
            {
                return Json(new ResponseMessage
                {
                    ResponseCode = 3,
                    ResponseContent = "Định dạng chưa được hỗ trợ"
                });
            }

            if (type.Equals("txt") || type.Equals("p7b"))
            {
                dataArray = Encoding.ASCII.GetBytes(data);
            }


            var accessToken = Session["access_token"] as string;
            if (string.IsNullOrEmpty(accessToken))
            {
                return null;
            }
            try
            {
                var req = new RequestMessage
                {
                    RequestID = Guid.NewGuid().ToString(),
                    ServiceID = "SignServer",
                    FunctionName = "Verify",
                    Parameter = new SignParameter
                    {
                        AccountEmail = accEmail,
                        Type = type,
                        ContentType = contentType,
                        FileName = name,
                        DataBase64 = data
                    }
                };
                var resp = CoreServiceClient.Query(req, accessToken);
                if (resp == null)
                {
                    return Json(new ResponseMessage
                    {
                        ResponseCode = 2,
                        ResponseContent = "Dịch vụ không phản hồi"
                    });
                }
                if (resp.ResponseCode != 1)
                {
                    return Json(resp);
                }

                var res = new VerifyResultModel();
                try
                {
                    res = JsonConvert.DeserializeObject<VerifyResultModel>(JsonConvert.SerializeObject(resp.Content));
                }
                catch (Exception)
                {
                }

                if (res != null && res.status)
                {
                    var parsedList = new List<SignServerVerifyResultModel>();
                    foreach (var sig in res.signatures)
                    {
                        parsedList.Add(ParseSignature(sig));
                    }
                    res.signatures = parsedList;
                    resp.Content = res;
                    return Json(resp);
                }
                else
                {
                    return Json(new ResponseMessage
                    {
                        ResponseCode = 3,
                        ResponseContent = "Dịch vụ không phản hồi"
                    });
                }
            }
            catch (Exception)
            {
                return Json(new ResponseMessage
                {
                    ResponseCode = 3,
                    ResponseContent = "Lỗi ngoại lệ"
                });
            }
        }


        public class SignServerVerifyResultModel
        {
            public string signingTime { get; set; }
            public bool signatureStatus { get; set; }
            public string certStatus { get; set; }
            public string certificate { get; set; }
            public int signatureIndex { get; set; }
            public int code { get; set; }

            public string subject { get; set; }
            public string issuer { get; set; }
            public string validFrom { get; set; }
            public string validTo { get; set; }
            public string serial { get; set; }
        }
        public class VerifyResultModel
        {
            public string TranID { get; set; }
            public bool status { get; set; }
            public string message { get; set; }

            public List<SignServerVerifyResultModel> signatures { get; set; }
        }

        private SignServerVerifyResultModel ParseSignature(SignServerVerifyResultModel model)
        {
            try
            {
                DateTime timeSigning;
                var canParse = DateTime.TryParse(model.signingTime, out timeSigning);
                if (canParse)
                {
                    model.signingTime = timeSigning.ToString("dd/MM/yyy HH:mm:ss");
                }

                if (string.IsNullOrEmpty(model.certificate))
                {
                    return model;
                }

                byte[] certData = null;
                try
                {
                    certData = Convert.FromBase64String(model.certificate);
                }
                catch (Exception) { }
                X509Certificate2 cert = null;
                if (certData != null)
                {
                    cert = new X509Certificate2(certData);
                }
                model.certificate = "";

                model.subject = GetSubjectCN(cert.SubjectName.Name);
                model.issuer = GetSubjectCN(cert.IssuerName.Name);
                model.serial = cert.SerialNumber;
                model.validFrom = Convert.ToDateTime(cert.NotBefore).ToString("dd/MM/yyy HH:mm:ss");
                model.validTo = Convert.ToDateTime(cert.NotAfter).ToString("dd/MM/yyy HH:mm:ss");
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static readonly string _cnKey = "CN = ";
        public static string GetSubjectCN(string dn)
        {
            var key = _cnKey;
            if (dn.IndexOf(_cnKey) < 0)
            {
                key = "CN=";
            }
            if (string.IsNullOrEmpty(dn) || dn.IndexOf(key) < 0)
            {
                return dn;
            }
            var cn = dn.Substring(dn.IndexOf(key) + key.Length);
            if (cn.Contains(","))
            {
                cn = cn.Substring(0, cn.IndexOf(","));
            }
            return cn;
        }
    }
}