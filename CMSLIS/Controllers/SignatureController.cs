using Gateway.v4.SampleWeb.Common;
using Newtonsoft.Json;
using SignSevice.v4.Gateway.Client.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Medicons.Controllers
{
    public class SignatureController : Controller
    {
        // GET: Signature
        public ActionResult Index(string mesg)
        {
            ViewBag.Message = mesg;
            return View();
        }

        [HttpPost]
        public ActionResult SignFile(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return RedirectToAction("Index", new { mesg = $"Chọn tệp cần ký để tiếp tục" });
            }

            var accessToken = Session["access_token"] as string;
            if (string.IsNullOrEmpty(accessToken))
            {
                return RedirectToAction("Index", new { mesg = $"Get access_token để tiếp tục" });
            }

            #region Bước 1: Lấy danh sách chữ ký số trên hệ thống VNPT Ký số
            var userCert = _getAccoutCert(accessToken);
            if (userCert == null)
            {
                return RedirectToAction("Index", new { mesg = $"Lỗi: {GetLastError()}" });
            }

            // TODO: Bổ sung chức năng chọn chữ ký số cho người dùng
            string certID = userCert.ID;
            #endregion

            #region Bước 2: Lấy thông tin thanh toán giao dịch
            var servicePack = _getAccoutServicePack(accessToken);
            if (servicePack == null)
            {
                return RedirectToAction("Index", new { mesg = $"Lỗi: {GetLastError()}" });
            }
            string servicePackID = servicePack.ID;
            #endregion

            #region Đọc dữ liệu cần ký file upload
            Filetype fileType = null;
            byte[] unsignData;
            string signedFile = "";
            using (Stream inputStream = file.InputStream)
            {
                try
                {
                    if (!(inputStream is MemoryStream memoryStream))
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    unsignData = memoryStream.ToArray();

                    fileType = GetFileType(unsignData, file);
                    if (fileType == null)
                    {
                        return RedirectToAction("Index", new { mesg = "Định dạng chưa được hỗ trợ" });
                    }
                    signedFile = file.FileName.Replace($".{fileType.Extension}", $"_signed.{fileType.Extension}");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", new { mesg = $"Không thể phân tích dữ liệu cần ký: {ex.Message}" });
                }
            }
            #endregion

            #region Bước 4: Ký dữ liệu 
            byte[] signedBytes = null;
            switch (fileType.Extension)
            {
                case "pdf":
                    signedBytes = SignHash.SignHashPdf(unsignData, servicePackID, certID,
                        _parseCert(userCert.CertBase64), accessToken);
                    break;
                case "xml":
                    signedBytes = SignHash.SignHashXml(unsignData, servicePackID, certID,
                        _parseCert(userCert.CertBase64), accessToken);
                    break;
                case "docx":
                case "xlsx":
                case "pptx":
                    signedBytes = SignHash.SignHashOffice(unsignData, servicePackID, certID,
                        _parseCert(userCert.CertBase64), accessToken);
                    break;
            }
            if (signedBytes == null)
            {
                return RedirectToAction("Index", new { mesg = $"Lỗi ký số: {GetLastError()}" });
            }
            #endregion

            return File(signedBytes, System.Net.Mime.MediaTypeNames.Application.Octet, signedFile);
        }

        [HttpPost]
        public ActionResult SignFileNormal(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return RedirectToAction("Index", new { mesg = $"Chọn tệp cần ký để tiếp tục" });
            }

            var accessToken = Session["access_token"] as string;
            if (string.IsNullOrEmpty(accessToken))
            {
                return RedirectToAction("Index", new { mesg = $"Get access_token để tiếp tục" });
            }

            #region Bước 1: Lấy danh sách chữ ký số trên hệ thống VNPT Ký số
            var userCert = _getAccoutCert(accessToken);
            if (userCert == null)
            {
                return RedirectToAction("Index", new { mesg = $"Lỗi: {GetLastError()}" });
            }

            // TODO: Bổ sung chức năng chọn chữ ký số cho người dùng
            string certID = userCert.ID;
            #endregion

            #region Bước 2: Lấy thông tin thanh toán giao dịch
            var servicePack = _getAccoutServicePack(accessToken);
            if (servicePack == null)
            {
                return RedirectToAction("Index", new { mesg = $"Lỗi: {GetLastError()}" });
            }
            string servicePackID = servicePack.ID;
            #endregion

            #region Đọc dữ liệu cần ký file upload
            Filetype fileType = null;
            byte[] unsignData;
            string signedFile = "";
            using (Stream inputStream = file.InputStream)
            {
                try
                {
                    if (!(inputStream is MemoryStream memoryStream))
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    unsignData = memoryStream.ToArray();

                    fileType = GetFileType(unsignData, file);
                    if (fileType == null)
                    {
                        return RedirectToAction("Index", new { mesg = "Định dạng chưa được hỗ trợ" });
                    }
                    signedFile = file.FileName.Replace($".{fileType.Extension}", $"_signed.{fileType.Extension}");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", new { mesg = $"Không thể phân tích dữ liệu cần ký: {ex.Message}" });
                }
            }
            #endregion

            #region Bước 4: Ký dữ liệu 
            byte[] signedBytes = null;

            switch (fileType.Extension)
            {
                case "pdf":
                    signedBytes = Sign.SignPdf(unsignData, signedFile, servicePackID, certID, accessToken);
                    break;
                case "xml":
                    signedBytes = Sign.SignXml(unsignData, signedFile, servicePackID, certID, accessToken);
                    break;
                case "docx":
                case "xlsx":
                case "pptx":
                    signedBytes = Sign.SignOffice(unsignData, signedFile, servicePackID, certID, accessToken);
                    break;
            }
            if (signedBytes == null)
            {
                return RedirectToAction("Index", new { mesg = $"Lỗi ký số: {GetLastError()}" });
            }
            #endregion

            return File(signedBytes, System.Net.Mime.MediaTypeNames.Application.Octet, signedFile);
        }


        [HttpPost]
        public ActionResult SignPdfAdvance(HttpPostedFileBase file, HttpPostedFileBase logo)
        {
            if (file == null)
            {
                return RedirectToAction("Index", new { mesg = $"Chọn tệp cần ký để tiếp tục" });
            }

            var accessToken = Session["access_token"] as string;
            if (string.IsNullOrEmpty(accessToken))
            {
                return RedirectToAction("Index", new { mesg = $"Get access_token để tiếp tục" });
            }

            #region Bước 1: Lấy danh sách chữ ký số trên hệ thống VNPT Ký số
            var userCert = _getAccoutCert(accessToken);
            if (userCert == null)
            {
                return RedirectToAction("Index", new { mesg = $"Lỗi: {GetLastError()}" });
            }

            // TODO: Bổ sung chức năng chọn chữ ký số cho người dùng
            string certID = userCert.ID;
            #endregion

            #region Bước 2: Lấy thông tin thanh toán giao dịch
            var servicePack = _getAccoutServicePack(accessToken);
            if (servicePack == null)
            {
                return RedirectToAction("Index", new { mesg = $"Lỗi: {GetLastError()}" });
            }
            string servicePackID = servicePack.ID;
            #endregion

            #region Đọc dữ liệu cần ký file upload
            Filetype fileType = null;
            byte[] unsignData;
            string signedFile = "";
            using (Stream inputStream = file.InputStream)
            {
                try
                {
                    if (!(inputStream is MemoryStream memoryStream))
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    unsignData = memoryStream.ToArray();

                    fileType = GetFileType(unsignData, file);
                    if (fileType == null)
                    {
                        return RedirectToAction("Index", new { mesg = "Định dạng chưa được hỗ trợ" });
                    }
                    signedFile = file.FileName.Replace($".{fileType.Extension}", $"_signed.{fileType.Extension}");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", new { mesg = $"Không thể phân tích dữ liệu cần ký: {ex.Message}" });
                }
            }
            #endregion

            #region Bước 4: Ký dữ liệu 
            if (fileType.Extension != "pdf") return RedirectToAction("Index", new { mesg = "File không đúng định dạng" }); ;
            byte[] signedBytes = null;
            string dataBase64 = Convert.ToBase64String(unsignData);
            var response = CoreServiceClient.Query(new RequestMessage
            {
                RequestID = Guid.NewGuid().ToString(),
                ServiceID = "SignServer",
                FunctionName = "SignPdfAdvance",
                Parameter = new SignPdfAdvanceParameter
                {
                    ServiceGroupID = servicePackID,
                    CertID = certID,
                    FileName = "sample.pdf",
                    DataBase64 = dataBase64,
                    VisibleType = "5",
                    FontSize = "13",
                    Signatures = "W3sicmVjdGFuZ2xlIjoiMzQ5LDQ4OCw1NjksNTU0IiwicGFnZSI6MX0seyJyZWN0YW5nbGUiOiI0OSw0ODgsMjY5LDU1NCIsInBhZ2UiOjF9XQ==",
                    FontName = "Time",
                    Comment = "W3sidGV4dCI6IkfEkC9RxJAtMDEyNyIsInJlY3RhbmdsZSI6IjkzLDcwMCwyOTMsNzIwIiwicGFnZSI6MSwiZm9udE5hbWUiOiJUaW1lIiwiZm9udFN0eWxlIjoyLCJmb250U2l6ZSI6MTMsImZvbnRDb2xvciI6IkZGMDAwMCJ9LHsidGV4dCI6IjE0IiwicmVjdGFuZ2xlIjoiMzk2LDY4MCw0MTcsNzIwIiwicGFnZSI6MSwiZm9udE5hbWUiOiJUaW1lIiwiZm9udFN0eWxlIjozLCJmb250U2l6ZSI6MTMsImZvbnRDb2xvciI6IjA2MDlGRiJ9LHsidGV4dCI6IjA1IiwicmVjdGFuZ2xlIjoiNDU1LDY4NCw0NzUsNzE5IiwicGFnZSI6MSwiZm9udE5hbWUiOiJSb2JvdG8iLCJmb250U3R5bGUiOjEsImZvbnRTaXplIjoxMCwiZm9udENvbG9yIjoiIn1d",
                    FontStyle = "0",
                    FontColor = "FF0000",
                    SignatureText = "Ký bởi: Bùi Sĩ Tuấn\nChức vụ: Giám Đốc",
                    IsDebug = "false"
                }
            }, accessToken);
            if (response == null)
            {
                return RedirectToAction("Index", new { mesg = "Sign error" });
            }
            if (response.ResponseCode == 1)
            {
                var str = JsonConvert.SerializeObject(response.Content);
                SignResponse acc = JsonConvert.DeserializeObject<SignResponse>(str);
                if (acc != null)
                {
                    signedBytes = Convert.FromBase64String(acc.SignedData);
                }
            }
            else
            {
                return RedirectToAction("Index", new { mesg = $"Lỗi ký số: {response.ResponseContent}" });
            }

            if (signedBytes == null)
            {
                return RedirectToAction("Index", new { mesg = $"Lỗi ký số: {GetLastError()}" });
            }
            #endregion

            return File(signedBytes, System.Net.Mime.MediaTypeNames.Application.Octet, signedFile);
        }

        /// <summary>
        /// Lấy kiểu dữ liệu file dựa vào byte[] của file
        /// </summary>
        /// <param name="fileBytes"></param>
        /// <returns></returns>
        public static Filetype GetFileType(byte[] fileBytes, HttpPostedFileBase file)
        {
            if (fileBytes[0] == 0x25 && fileBytes[1] == 0x50 && fileBytes[2] == 0x44 && fileBytes[3] == 0x46)
                return new Filetype
                {
                    Extension = "pdf",
                    MimeType = "application/pdf"
                };
            if (fileBytes[3] == 0x3C && fileBytes[4] == 0x3F && fileBytes[5] == 0x78 && fileBytes[6] == 0x6D && fileBytes[7] == 0x6C && fileBytes[8] == 0x20 && fileBytes[9] == 0x76 && fileBytes[10] == 0x65 && fileBytes[11] == 0x72 && fileBytes[12] == 0x73 && fileBytes[13] == 0x69 && fileBytes[14] == 0x6F && fileBytes[15] == 0x6E && fileBytes[16] == 0x3D && fileBytes[17] == 0x22 && fileBytes[18] == 0x31 && fileBytes[19] == 0x2E && fileBytes[20] == 0x30 && fileBytes[21] == 0x22 //&& fileBytes[22] == 0x3F && fileBytes[23] == 0x3E
                || fileBytes[0] == 0x3C && fileBytes[1] == 0x3F && fileBytes[2] == 0x78 && fileBytes[3] == 0x6D && fileBytes[4] == 0x6C && fileBytes[5] == 0x20 && fileBytes[6] == 0x76 && fileBytes[7] == 0x65 && fileBytes[8] == 0x72 && fileBytes[9] == 0x73 && fileBytes[10] == 0x69 && fileBytes[11] == 0x6F && fileBytes[12] == 0x6E && fileBytes[13] == 0x3D && fileBytes[14] == 0x22 && fileBytes[15] == 0x31 && fileBytes[16] == 0x2E && fileBytes[17] == 0x30 && fileBytes[18] == 0x22 //&& fileBytes[19] == 0x3F && fileBytes[20] == 0x3E
                )
                return new Filetype
                {
                    Extension = "xml",
                    MimeType = "text/xml"
                };
            // docx/pptx/xlsx
            if (fileBytes[0] == 0x50 && fileBytes[1] == 0x4B && fileBytes[2] == 0x03 && fileBytes[3] == 0x04 && fileBytes[4] == 0x14 && fileBytes[5] == 0x00 && fileBytes[6] == 0x06 && fileBytes[7] == 0x00)
                return new Filetype
                {
                    Extension = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1),
                    MimeType = file.ContentType
                };
            return null;
        }
        public class Filetype
        {
            public string Extension { get; set; }
            public string MimeType { get; set; }
        }

        private static string _error = "";
        public static string GetLastError()
        {
            return _error;
        }

        /// <summary>
        /// Lấy thông tin chữ ký số tập trung trên hệ thống
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private static Certificate _getAccoutCert(string token)
        {
            var response = CoreServiceClient.Query(new RequestMessage
            {
                RequestID = Guid.NewGuid().ToString(),
                ServiceID = "Certificate",
                FunctionName = "GetAccountCertificateByEmail",
                Parameter = new CertParameter
                {
                    PageIndex = 0,
                    PageSize = 10
                }
            }, token);
            if (response != null)
            {
                if (response.Content == null)
                {
                    _error = response.ResponseContent;
                    return null;
                }
                var str = JsonConvert.SerializeObject(response.Content);
                CertResponse acc = JsonConvert.DeserializeObject<CertResponse>(str);
                if (acc != null && acc.Count > 0)
                {
                    return acc.Items[0];
                }
                else
                {
                    _error = "Tài khoản chưa đăng ký chữ ký số tập trung. Không có chứng thư số trên hệ thống";
                }
            }

            return null;
        }


        /// <summary>
        /// Lấy thông tin chữ ký số tập trung trên hệ thống
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private static ServicePack _getAccoutServicePack(string token)
        {
            var response = CoreServiceClient.Query(new RequestMessage
            {
                RequestID = Guid.NewGuid().ToString(),
                ServiceID = "UserAccount",
                FunctionName = "GetProfile"
            }, token);
            if (response != null)
            {
                if (response.Content == null)
                {
                    _error = response.ResponseContent;
                    return null;
                }
                var str = JsonConvert.SerializeObject(response.Content);
                var acc = JsonConvert.DeserializeObject<Profile>(str);
                if (acc == null || acc.Groups == null || acc.Groups.Count < 1)
                {
                    _error = "Chưa có thông tin thanh toán giao dịch";
                    return null;
                }

                foreach (var pack in acc.Groups)
                {
                    if (pack.GroupType == 1 || (pack.SoLuotKyConLai > 0
                        && pack.NgayHetHan.HasValue
                        && (pack.NgayHetHan.Value - DateTime.Now).TotalSeconds > 0))
                    {
                        return pack;
                    }
                }
            }
            _error = "Thông tin thanh toán không hợp lệ";
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certBase64"></param>
        /// <returns></returns>
        private static string _parseCert(string certBase64)
        {
            if (string.IsNullOrEmpty(certBase64))
            {
                return certBase64;
            }

            certBase64 = certBase64.Replace("-----BEGIN CERTIFICATE-----", "").Replace("\r\n", "");
            certBase64 = certBase64.Replace("-----END CERTIFICATE-----", "").Replace("\r\n", "");

            return certBase64;
        }
    }
}