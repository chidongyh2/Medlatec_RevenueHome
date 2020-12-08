using CMS_Core.Entity;
using CMS_Core.Implementtion;
using CMS_Medicons.Common;
using CMS_Medicons.Models;
using CMSLIS.Common;
using CMSLIS.Controllers;
using CMSLIS.Models;
using CMSNEW.Models;
using DotNetOpenAuth.OAuth2;

using log4net;
using MsgBot.BusinessLayer;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QRCoder;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace CMS_Medicons.Controllers
{
    [CheckAuthorization]
    public class RevenueHomeController : BaseController
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        // GET: RevenueHome
        private WebServerClient _webServerClient;
        private Imptbl_Patient imptbl_Patient;
        private Imptbl_Result imptbl_Result;
        private Imptbl_Revenue imptbl_Revenue;
        private Imptbl_Location imptbl_Location;
        private ImptblReportRevenue imptblReportRevenue;
        private ImpCms_Account impCms_Account;
        private ObjectCache _cache = MemoryCache.Default;
        public RevenueHomeController()
        {
            imptbl_Patient = new Imptbl_Patient();
            imptbl_Result = new Imptbl_Result();
            imptbl_Revenue = new Imptbl_Revenue();
            imptbl_Location = new Imptbl_Location();
            imptblReportRevenue = new ImptblReportRevenue();
            impCms_Account = new ImpCms_Account();
        }


        public ActionResult Index()
        {
            return View();
        }

        #region --> Danh sách dich vụ theo SID
        public ActionResult RevenueResult(string SID, string mabn, string userid, string Token)
        {


            // Initialization.  
            AddPageHeader("Chi tiết dịch vụ CBTN", "");
            AddBreadcrumb("Chi tiết dịch vụ CBTN", "");
            AddBreadcrumb("Chi tiết dịch vụ CBTN", "/RevenueHome/RevenueResult");
            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeResultKeyword();


            var UserInfo = ((cms_Account)Session["UserInfo"]);

            RevenueResultViewAgreeModel obj = new RevenueResultViewAgreeModel();

            if (string.IsNullOrEmpty(SID))
            {
                SID = string.Empty;
            }
            if (string.IsNullOrEmpty(mabn))
            {
                mabn = "0";
            }

            if (string.IsNullOrEmpty(userid))
            {
                userid = string.Empty;
            }

            obj.userid = userid;
            obj.sid = SID;
            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            obj.mabn = Convert.ToInt64(mabn);
            try
            {
                if (CMSLIS.Common.Common.CheckKeyPrivate(SID, Token))
                {
                    List<VP> Results = imptbl_Result.Gettbl_ResultBySID(obj.userid, obj.sid, obj.mabn, 0, string.Empty);
                    obj.Results = Results;
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueResult:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RevenueResult(RevenueResultViewAgreeModel obj, string submit)
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "/RevenueHome/RevenueResult");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();
            try
            {

                var UserInfo = ((cms_Account)Session["UserInfo"]);
                switch (submit)
                {
                    case "SearchRevenueResult":
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }
                        List<VP> Results = imptbl_Result.Gettbl_ResultBySID(obj.userid, obj.sid, obj.mabn, obj.typeKeyword, obj.keyword);
                        obj.Results = Results;
                        break;
                    case "ExportRevenueResult":
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }

                        AddLogAction("", Constant.ActionExport.ToString());


                        Results = imptbl_Result.Gettbl_ResultBySID(obj.userid, obj.sid, obj.mabn, obj.typeKeyword, obj.keyword);
                        obj.Results = Results;


                        ExcelPackage Ep = new ExcelPackage();
                        ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Revenue");


                        Sheet.Cells["A1"].Value = "BỆNH VIỆN ĐA KHOA MEDLATEC";
                        Sheet.Cells["A1:I1"].Merge = true;
                        Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        Sheet.Cells["A2"].Value = "ĐT: 1900 565656";
                        Sheet.Cells["A2:I2"].Merge = true;
                        Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        if (Results != null)
                        {
                            if (Results.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(obj.sid))
                                {
                                    Sheet.Cells["A3"].Value = "Thông tin doanh thu của " + obj.sid + " tại nhà ngày :" + DateTime.Now.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    Sheet.Cells["A3"].Value = "Thông tin doanh thu cán bộ " + obj.userid + " tại nhà ngày :" + DateTime.Now.ToString("dd/MM/yyyy");
                                }
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            Sheet.Cells["A3"].Value = "Thông tin doanh thu của " + obj.sid + " tại nhà ngày :" + DateTime.Now.ToString("dd/MM/yyyy");
                        }
                        Sheet.Cells["A3:I3"].Merge = true;
                        Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        Sheet.Cells["A4"].Value = "STT";
                        Sheet.Cells["B4"].Value = "Người thu tiền";
                        Sheet.Cells["C4"].Value = "SID";
                        Sheet.Cells["D4"].Value = "Mã bệnh nhân";
                        Sheet.Cells["E4"].Value = "Mã dịch vụ";
                        Sheet.Cells["F4"].Value = "Tên dịch vụ";
                        Sheet.Cells["G4"].Value = "Giá tiền";
                        Sheet.Cells["H4"].Value = "Nội dung phê duyệt";
                        Sheet.Cells["I4"].Value = "Trạng thái duyệt";



                        int row = 5;
                        int stt = 1;
                        foreach (var item in Results)
                        {
                            Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                            if (string.IsNullOrEmpty(obj.userid))
                            {
                                Sheet.Cells[string.Format("B{0}", row)].Value = string.Empty;
                            }
                            else
                            {
                                Sheet.Cells[string.Format("B{0}", row)].Value = obj.userid;
                            }

                            Sheet.Cells[string.Format("C{0}", row)].Value = obj.sid;
                            Sheet.Cells[string.Format("D{0}", row)].Value = obj.mabn;
                            Sheet.Cells[string.Format("E{0}", row)].Value = item.MaCP;
                            Sheet.Cells[string.Format("F{0}", row)].Value = item.MaCP;
                            Sheet.Cells[string.Format("G{0}", row)].Value = item.SL * item.DG;
                            Sheet.Cells[string.Format("H{0}", row)].Value = item.Commentagree;
                            Sheet.Cells[string.Format("I{0}", row)].Value = item.Typeagree;
                            row++;
                            stt++;
                        }


                        Sheet.Cells["A:AZ"].AutoFitColumns();
                        Response.Clear();
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment: filename=" + "RevenueResult.xlsx");
                        Response.BinaryWrite(Ep.GetAsByteArray());
                        Response.End();

                        break;

                    case "SaveRevenueResult":
                        bool validate = true;
                        #region --> Check validate

                        AddLogAction("", Constant.ActionInsertOK.ToString());

                        foreach (var data in obj.Results)
                        {
                            if (!data.agree)
                            {
                                if (string.IsNullOrEmpty(data.Commentagree))
                                {
                                    validate = false;
                                    break;
                                }
                            }
                        }

                        if (!validate)
                        {
                            ViewBag.TitleSuccsess = "Dòng không đồng ý phải nhập và comment. Xin mời bạn nhập lại!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                        }
                        else
                        {
                            foreach (var data in obj.Results)
                            {
                                tbl_Revenue revenue = new tbl_Revenue();
                                revenue.userid = obj.userid;
                                revenue.sid = obj.sid;
                                revenue.locationid = "";
                                revenue.price = (float)(data.SL * data.DG);
                                revenue.testcode = data.MaCP;
                                revenue.testname = data.MaCP;
                                revenue.useridAgree = UserInfo.uid.ToString();
                                revenue.levelAgree = 1;
                                revenue.IDSouce = data.MaBN;
                                if (string.IsNullOrEmpty(data.Commentagree))
                                {
                                    revenue.CommentAgree = string.Empty;
                                }
                                else
                                {
                                    revenue.CommentAgree = data.Commentagree;
                                }

                                if (data.agree)
                                {
                                    revenue.Typeagree = 1;
                                }
                                else
                                {
                                    revenue.Typeagree = 0;
                                }

                                var errorsSave = revenue.Validate(new ValidationContext(revenue));
                                if (errorsSave.ToList().Count == 0)
                                {
                                    imptbl_Revenue.Add(revenue);
                                }
                                else
                                {
                                    ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                }
                            }

                            ViewBag.TitleSuccsess = "Cập nhật thành công!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;

                            //Results = imptbl_Result.Gettbl_ResultBySID(obj.sid, obj.typeKeyword, obj.keyword);
                            //obj.Results = Results;
                        }


                        #endregion
                        break;

                }

            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("ListOrder:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        #endregion

        #region --> Danh sách khách hàng theo userid
        public ActionResult Revenue()
        {

            //  string abcd = SaltedHash.GetSHA512("tinngan123$%^");
            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "/RevenueHome/Revenue");
            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();


            var UserInfo = ((cms_Account)Session["UserInfo"]);

            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();

            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            if (UserInfo.uid == 1)
            {
                obj.userid = UserInfo.AccountLis;
            }
            else
            {
                obj.userid = UserInfo.Username;
            }



            try
            {
                List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUserid(obj.userid, 0, string.Empty);
                obj.Patients = Patients;
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueAll:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Revenue(RevenueViewAgreeModel obj, string submit)
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "/RevenueHome/Revenue");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();
            try
            {

                var UserInfo = ((cms_Account)Session["UserInfo"]);
                switch (submit)
                {
                    case "SearchRevenue":
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }
                        List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUserid(obj.userid, obj.typeKeyword, obj.keyword);
                        obj.Patients = Patients;
                        break;
                    case "ExportRevenue":
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }
                        AddLogAction("", Constant.ActionExport.ToString());
                        Patients = imptbl_Patient.Gettbl_PatientByUserid(obj.userid, obj.typeKeyword, obj.keyword);
                        obj.Patients = Patients;


                        ExcelPackage Ep = new ExcelPackage();
                        ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Revenue");


                        Sheet.Cells["A1"].Value = "BỆNH VIỆN ĐA KHOA MEDLATEC";
                        Sheet.Cells["A1:U1"].Merge = true;
                        Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        Sheet.Cells["A2"].Value = "ĐT: 1900 565656";
                        Sheet.Cells["A2:U2"].Merge = true;
                        Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        Sheet.Cells["A3"].Value = "Thông tin doanh thu cán bộ " + obj.userid + " tại nhà ngày :" + DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                        Sheet.Cells["A3:U3"].Merge = true;
                        Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                        Sheet.Cells["A4"].Value = "STT";
                        Sheet.Cells["B4"].Value = "Người thu";
                        Sheet.Cells["C4"].Value = "Ngày thu";
                        Sheet.Cells["D4"].Value = "Nhóm doanh thu";
                        Sheet.Cells["E4"].Value = "Đơn vị";
                        Sheet.Cells["F4"].Value = "SID";
                        Sheet.Cells["G4"].Value = "Tên bệnh nhân";
                        Sheet.Cells["H4"].Value = "Tổng tiền";
                        Sheet.Cells["I4"].Value = "Giảm giá";
                        Sheet.Cells["J4"].Value = "Phí đi lại";
                        Sheet.Cells["K4"].Value = "BHTT";
                        Sheet.Cells["L4"].Value = "BHBLTT";
                        Sheet.Cells["M4"].Value = "Thực thu";
                        Sheet.Cells["N4"].Value = "Thẻ Pos";
                        Sheet.Cells["O4"].Value = "Trả trước";
                        Sheet.Cells["P4"].Value = "Trả sau";
                        Sheet.Cells["Q4"].Value = "Tiền còn phải nộp";
                        Sheet.Cells["R4"].Value = "Tiền cán bộ đồng ý";
                        Sheet.Cells["S4"].Value = "Nội dung Điều chỉnh";
                        Sheet.Cells["T4"].Value = "Trạng thái cấp user";
                        Sheet.Cells["U4"].Value = "Trạng thái cấp kế toán";


                        int stt = 1;
                        int row = 5;
                        foreach (var item in Patients)
                        {
                            Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                            Sheet.Cells[string.Format("B{0}", row)].Value = item.UserTC;
                            Sheet.Cells[string.Format("C{0}", row)].Value = CMSLIS.Common.Common.ReFmtTime(item.NgayThu);
                            Sheet.Cells[string.Format("D{0}", row)].Value = item.GroupName;
                            Sheet.Cells[string.Format("E{0}", row)].Value = item.LocationName;
                            Sheet.Cells[string.Format("F{0}", row)].Value = item.S_ID;
                            Sheet.Cells[string.Format("G{0}", row)].Value = item.HoTen;
                            Sheet.Cells[string.Format("H{0}", row)].Value = item.TongCP;
                            Sheet.Cells[string.Format("I{0}", row)].Value = item.TienGG + item.TienDiemPID;
                            Sheet.Cells[string.Format("J{0}", row)].Value = item.PhiDiLai;
                            Sheet.Cells[string.Format("K{0}", row)].Value = item.BHTT;
                            Sheet.Cells[string.Format("L{0}", row)].Value = item.BHBLTT;
                            Sheet.Cells[string.Format("M{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHTT - item.TienDiemPID - item.TienGG;
                            Sheet.Cells[string.Format("N{0}", row)].Value = item.ThePOS;
                            Sheet.Cells[string.Format("O{0}", row)].Value = item.TraTruoc;
                            Sheet.Cells[string.Format("P{0}", row)].Value = item.TraSau;
                            Sheet.Cells[string.Format("Q{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHTT - item.TienDiemPID - item.TienGG - item.ThePOS - item.TraTruoc - item.TraSau;
                            Sheet.Cells[string.Format("R{0}", row)].Value = item.SumAgree;
                            Sheet.Cells[string.Format("S{0}", row)].Value = item.Commentagree;
                            Sheet.Cells[string.Format("T{0}", row)].Value = item.Typeagree;
                            Sheet.Cells[string.Format("U{0}", row)].Value = item.Typeagree1;


                            row++;
                            stt++;
                        }


                        Sheet.Cells["A:AZ"].AutoFitColumns();
                        Response.Clear();
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment: filename=" + "Revenue.xlsx");
                        Response.BinaryWrite(Ep.GetAsByteArray());
                        Response.End();

                        break;

                    case "SaveRevenue":
                        bool validate = true;
                        //Get Upload path from Web.Config file AppSettings.
                        string UploadPath = CMSLIS.Common.Common.getImagePath() + "ImagePath\\";
                        bool validateImage = true;
                        #region --> Check validate

                        foreach (var data in obj.Patients)
                        {
                            if (!data.agree)
                            {
                                if (string.IsNullOrEmpty(data.Commentagree))
                                {
                                    validate = false;
                                    break;
                                }
                            }

                            //Upload Image
                            if (data.ImageFile != null)
                            {
                                // Use Namespace called: System.IO
                                string FileName = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);

                                //To Get File Extension
                                string FileExtension = Path.GetExtension(data.ImageFile.FileName);

                                //Add Current Date To Attached File Name                      
                                data.RevenueImages = UploadPath + DateTime.Now.ToString("yyyyMMdd");
                                if (!System.IO.Directory.Exists(data.RevenueImages))
                                    Directory.CreateDirectory(data.RevenueImages);

                                data.RevenueImages = data.RevenueImages + "/" + DateTime.Now.ToString("yyyyMMdd") + "_" + FileName.Trim() + FileExtension;
                                if (System.IO.File.Exists(data.RevenueImages))
                                {
                                    System.IO.File.Delete(data.RevenueImages);
                                }

                                if (!data.ImageFile.FileName.EndsWith("gif") && !data.ImageFile.FileName.EndsWith("jpg") && !data.ImageFile.FileName.EndsWith("jpeg") && !data.ImageFile.FileName.EndsWith("jpg") && !data.ImageFile.FileName.EndsWith("png"))
                                {
                                    ViewBag.TitleSuccsess = "Không upload được file \"" + FileExtension + "\". Chỉ upload được file  .jpeg .gif .png";
                                    validateImage = false;
                                    break;
                                }

                                if (!FileExtension.EndsWith("gif") && !FileExtension.EndsWith("jpg") && !FileExtension.EndsWith("jpeg") && !FileExtension.EndsWith("jpg") && !FileExtension.EndsWith("png"))
                                {
                                    ViewBag.TitleSuccsess = "Không upload được file \"" + FileExtension + "\". Chỉ upload được file  .jpeg .gif .png";
                                    validateImage = false;
                                    break;
                                }

                                //Its Create complete path to store in server.
                                //To copy and save file into server.
                                if (validateImage)
                                {
                                    data.ImageFile.SaveAs(data.RevenueImages);

                                }
                            }



                        }

                        if (!validate)
                        {
                            ViewBag.TitleSuccsess = "Dòng không đồng ý phải nhập và comment. Xin mời bạn nhập lại!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                            AddLogAction("", Constant.ActionInsertNOK.ToString());
                        }
                        else if (!validateImage)
                        {
                            ViewBag.TitleSuccsess = "Ảnh nhập vào bị lỗi. Xin mời bạn nhập lại!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                            AddLogAction("", Constant.ActionInsertNOK.ToString());
                        }
                        else
                        {
                            foreach (var data in obj.Patients)
                            {

                                tbl_Revenue revenue = new tbl_Revenue();
                                revenue.userid = data.UserTC;
                                revenue.sid = data.S_ID;
                                revenue.locationid = data.LocationName;

                                revenue.testcode = string.Empty;
                                revenue.testname = string.Empty;
                                revenue.useridAgree = UserInfo.uid.ToString();
                                revenue.levelAgree = 2;
                                revenue.IDSouce = data.MaBN;
                                revenue.NgayThu = data.NgayThu;
                                revenue.IDCLS = data.IDCLS;
                                if (!string.IsNullOrEmpty(data.RevenueImages))
                                {
                                    revenue.RevenueImages = data.RevenueImages.Replace(CMSLIS.Common.Common.getImagePath(), "");
                                }
                                else
                                {
                                    revenue.RevenueImages = string.Empty;
                                }

                                if (string.IsNullOrEmpty(data.Commentagree))
                                {
                                    revenue.CommentAgree = string.Empty;
                                }
                                else
                                {
                                    revenue.CommentAgree = data.Commentagree;
                                }

                                if (data.agree)
                                {
                                    revenue.Typeagree = 1;
                                    revenue.price = data.TongCP - data.BHBLTT - data.BHBLTT - data.TienGG - data.TienDiemPID - data.ThePOS - data.TraSau - data.TraTruoc;

                                }
                                else
                                {

                                    revenue.Typeagree = 0;
                                    revenue.price = 0;
                                }

                                var errorsSave = revenue.Validate(new ValidationContext(revenue));
                                if (errorsSave.ToList().Count == 0)
                                {
                                    imptbl_Revenue.Add(revenue);
                                    errorsSave = revenue.Validate(new ValidationContext(data));
                                    if (errorsSave.ToList().Count == 0)
                                    {
                                        if (data.agree)
                                        {
                                            data.Typeagree = "1";
                                            data.IDSouce = 0;
                                            data.useridAgree = UserInfo.uid.ToString();
                                            data.SumAgree = data.TongCP - data.BHBLTT - data.BHTT - data.TienDiemPID - data.TienGG - data.ThePOS - data.TraTruoc - data.TraSau;
                                            imptblReportRevenue.Add(data);
                                        }
                                        else
                                        {
                                            data.Typeagree = "0";
                                            data.IDSouce = 0;
                                            data.useridAgree = UserInfo.uid.ToString();
                                            data.SumAgree = 0;
                                            imptblReportRevenue.Add(data);
                                        }
                                    }

                                }
                                else
                                {
                                    ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                }
                            }

                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }

                            Patients = imptbl_Patient.Gettbl_PatientByUserid(obj.userid.Trim(), obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;

                            ViewBag.TitleSuccsess = "Cập nhật thành công!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                            AddLogAction("", Constant.ActionInsertOK.ToString());
                            //Results = imptbl_Result.Gettbl_ResultBySID(obj.sid, obj.typeKeyword, obj.keyword);
                            //obj.Results = Results;
                        }


                        #endregion
                        break;


                }

            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("ListOrder:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        #endregion

        #region --> Danh sách khách hàng theo userid
        public ActionResult RevenueOrder()
        {


            // Initialization.  
            AddPageHeader("Ký Hợp đồng CB", "");
            AddBreadcrumb("Ký Hợp đồng CB", "");
            AddBreadcrumb("Ký Hợp đồng CB", "/RevenueHome/RevenueOrder");
            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();


            var UserInfo = ((cms_Account)Session["UserInfo"]);

            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();

            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            obj.userid = UserInfo.AccountLis;


            try
            {
                List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUserid(obj.userid, 0, string.Empty);
                obj.Patients = Patients;
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueAll:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RevenueOrder(RevenueViewAgreeModel obj, string submit)
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "/RevenueHome/Revenue");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();
            try
            {

                var UserInfo = ((cms_Account)Session["UserInfo"]);
                switch (submit)
                {
                    case "SearchRevenue":
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }
                        List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUserid(obj.userid, obj.typeKeyword, obj.keyword);
                        obj.Patients = Patients;
                        break;
                    case "ExportRevenue":
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }
                        AddLogAction("", Constant.ActionExport.ToString());
                        Patients = imptbl_Patient.Gettbl_PatientByUserid(obj.userid, obj.typeKeyword, obj.keyword);
                        obj.Patients = Patients;


                        ExcelPackage Ep = new ExcelPackage();
                        ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Revenue");


                        Sheet.Cells["A1"].Value = "BỆNH VIỆN ĐA KHOA MEDLATEC";
                        Sheet.Cells["A1:U1"].Merge = true;
                        Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        Sheet.Cells["A2"].Value = "ĐT: 1900 565656";
                        Sheet.Cells["A2:U2"].Merge = true;
                        Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        Sheet.Cells["A3"].Value = "Thông tin doanh thu cán bộ " + obj.userid + " tại nhà ngày :" + DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                        Sheet.Cells["A3:U3"].Merge = true;
                        Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                        Sheet.Cells["A4"].Value = "STT";
                        Sheet.Cells["B4"].Value = "Người thu";
                        Sheet.Cells["C4"].Value = "Ngày thu";
                        Sheet.Cells["D4"].Value = "Nhóm doanh thu";
                        Sheet.Cells["E4"].Value = "Đơn vị";
                        Sheet.Cells["F4"].Value = "SID";
                        Sheet.Cells["G4"].Value = "Tên bệnh nhân";
                        Sheet.Cells["H4"].Value = "Tổng tiền";
                        Sheet.Cells["I4"].Value = "Giảm giá";
                        Sheet.Cells["J4"].Value = "Phí đi lại";
                        Sheet.Cells["K4"].Value = "BHTT";
                        Sheet.Cells["L4"].Value = "BHBLTT";
                        Sheet.Cells["M4"].Value = "Thực thu";
                        Sheet.Cells["N4"].Value = "Thẻ Pos";
                        Sheet.Cells["O4"].Value = "Trả trước";
                        Sheet.Cells["P4"].Value = "Trả sau";
                        Sheet.Cells["Q4"].Value = "Tiền còn phải nộp";
                        Sheet.Cells["R4"].Value = "Tiền cán bộ đồng ý";
                        Sheet.Cells["S4"].Value = "Nội dung Điều chỉnh";
                        Sheet.Cells["T4"].Value = "Trạng thái cấp user";
                        Sheet.Cells["U4"].Value = "Trạng thái cấp kế toán";


                        int stt = 1;
                        int row = 5;
                        foreach (var item in Patients)
                        {
                            Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                            Sheet.Cells[string.Format("B{0}", row)].Value = item.UserTC;
                            Sheet.Cells[string.Format("C{0}", row)].Value = CMSLIS.Common.Common.ReFmtTime(item.NgayThu);
                            Sheet.Cells[string.Format("D{0}", row)].Value = item.GroupName;
                            Sheet.Cells[string.Format("E{0}", row)].Value = item.LocationName;
                            Sheet.Cells[string.Format("F{0}", row)].Value = item.S_ID;
                            Sheet.Cells[string.Format("G{0}", row)].Value = item.HoTen;
                            Sheet.Cells[string.Format("H{0}", row)].Value = item.TongCP;
                            Sheet.Cells[string.Format("I{0}", row)].Value = item.TienGG + item.TienDiemPID;
                            Sheet.Cells[string.Format("J{0}", row)].Value = item.PhiDiLai;
                            Sheet.Cells[string.Format("K{0}", row)].Value = item.BHTT;
                            Sheet.Cells[string.Format("L{0}", row)].Value = item.BHBLTT;
                            Sheet.Cells[string.Format("M{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHTT - item.TienDiemPID - item.TienGG;
                            Sheet.Cells[string.Format("N{0}", row)].Value = item.ThePOS;
                            Sheet.Cells[string.Format("O{0}", row)].Value = item.TraTruoc;
                            Sheet.Cells[string.Format("P{0}", row)].Value = item.TraSau;
                            Sheet.Cells[string.Format("Q{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHTT - item.TienDiemPID - item.TienGG - item.ThePOS - item.TraTruoc - item.TraSau;
                            Sheet.Cells[string.Format("R{0}", row)].Value = item.SumAgree;
                            Sheet.Cells[string.Format("S{0}", row)].Value = item.Commentagree;
                            Sheet.Cells[string.Format("T{0}", row)].Value = item.Typeagree;
                            Sheet.Cells[string.Format("U{0}", row)].Value = item.Typeagree1;


                            row++;
                            stt++;
                        }


                        Sheet.Cells["A:AZ"].AutoFitColumns();
                        Response.Clear();
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment: filename=" + "Revenue.xlsx");
                        Response.BinaryWrite(Ep.GetAsByteArray());
                        Response.End();

                        break;

                    case "SaveRevenue":
                        bool validate = true;
                        #region --> Check validate

                        foreach (var data in obj.Patients)
                        {
                            if (!data.agree)
                            {
                                if (string.IsNullOrEmpty(data.Commentagree))
                                {
                                    validate = false;
                                    break;
                                }
                            }
                        }

                        if (!validate)
                        {
                            ViewBag.TitleSuccsess = "Dòng không đồng ý phải nhập và comment. Xin mời bạn nhập lại!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                            AddLogAction("", Constant.ActionInsertNOK.ToString());
                        }
                        else
                        {
                            foreach (var data in obj.Patients)
                            {

                                tbl_Revenue revenue = new tbl_Revenue();
                                revenue.userid = data.UserTC;
                                revenue.sid = data.S_ID;
                                revenue.locationid = data.LocationName;

                                revenue.testcode = string.Empty;
                                revenue.testname = string.Empty;
                                revenue.useridAgree = UserInfo.uid.ToString();
                                revenue.levelAgree = 2;
                                revenue.IDSouce = data.MaBN;
                                if (string.IsNullOrEmpty(data.Commentagree))
                                {
                                    revenue.CommentAgree = string.Empty;
                                }
                                else
                                {
                                    revenue.CommentAgree = data.Commentagree;
                                }

                                if (data.agree)
                                {
                                    revenue.Typeagree = 1;
                                    revenue.price = data.TongCP - data.BHBLTT - data.BHBLTT - data.TienGG - data.TienDiemPID - data.ThePOS - data.TraSau - data.TraTruoc;

                                }
                                else
                                {

                                    revenue.Typeagree = 0;
                                    revenue.price = 0;
                                }

                                var errorsSave = revenue.Validate(new ValidationContext(revenue));
                                if (errorsSave.ToList().Count == 0)
                                {
                                    imptbl_Revenue.Add(revenue);
                                    errorsSave = revenue.Validate(new ValidationContext(data));
                                    if (errorsSave.ToList().Count == 0)
                                    {
                                        if (data.agree)
                                        {
                                            data.Typeagree = "1";
                                            data.IDSouce = 0;
                                            data.useridAgree = UserInfo.uid.ToString();
                                            data.SumAgree = data.TongCP - data.BHBLTT - data.BHTT - data.TienDiemPID - data.TienGG - data.ThePOS - data.TraTruoc - data.TraSau;
                                            imptblReportRevenue.Add(data);
                                        }
                                        else
                                        {
                                            data.Typeagree = "0";
                                            data.IDSouce = 0;
                                            data.useridAgree = UserInfo.uid.ToString();
                                            data.SumAgree = 0;
                                            imptblReportRevenue.Add(data);
                                        }
                                    }

                                }
                                else
                                {
                                    ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                }
                            }

                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }

                            Patients = imptbl_Patient.Gettbl_PatientByUserid(obj.userid.Trim(), obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;

                            ViewBag.TitleSuccsess = "Cập nhật thành công!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                            AddLogAction("", Constant.ActionInsertOK.ToString());
                            //Results = imptbl_Result.Gettbl_ResultBySID(obj.sid, obj.typeKeyword, obj.keyword);
                            //obj.Results = Results;
                        }


                        #endregion
                        break;


                }

            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("ListOrder:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }


        public ActionResult RevenueByUserPdf(string userid, string random, string Token, string ngaythu)
        {


            // Initialization.  
            AddPageHeader("Ký Hợp đồng CB", "");
            AddBreadcrumb("Ký Hợp đồng CB", "");
            AddBreadcrumb("Ký Hợp đồng CB", "/RevenueHome/RevenueByUserPdf");


            var UserInfo = ((cms_Account)Session["UserInfo"]);

            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();

            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            obj.userid = UserInfo.AccountLis;

            if (string.IsNullOrEmpty(userid))
            {
                userid = "0";
            }

            if (string.IsNullOrEmpty(Token))
            {
                Token = "";
            }
            if (string.IsNullOrEmpty(ngaythu))
            {
                ngaythu = "";
            }

            try
            {
                if (!string.IsNullOrEmpty(userid) && !string.IsNullOrEmpty(Token))
                {
                    if (CMSLIS.Common.Common.CheckKeyPrivate(userid, random, Token))
                    {
                        var _Accounts = impCms_Account.Getcms_AccountByUserName(userid);
                        string hoten = string.Empty;
                        if (_Accounts != null)
                            if (_Accounts.Count > 0)
                            {
                                hoten = _Accounts[0].Hoten;
                            }

                        List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUserAgree(userid, ngaythu);
                        obj.Patients = Patients;
                        obj.userid = hoten;

                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                            {
                                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(hoten + " " + DateTime.Now.ToString("dd/MM/yyyy"), QRCodeGenerator.ECCLevel.L))
                                {
                                    using (QRCode qrCode = new QRCode(qrCodeData))
                                    {

                                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                                        {
                                            bitMap.Save(ms, ImageFormat.Png);
                                            ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                                        }
                                    }
                                }
                            }
                        }




                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueAll:" + ex.ToString());
            }



            // Info.  
            //  return View(orderViewModels);

            var root = Server.MapPath("~/PDF/");
            root = root + DateTime.Now.ToString("yyyyMMdd");
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            var pdfname = "\\" + userid + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + random + ".pdf";
            var path = root + pdfname;



            string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Trang: [page]/[toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";
            return new Rotativa.MVC.PartialViewAsPdf(obj)
            {
                RotativaOptions = new Rotativa.Core.DriverOptions()
                {
                    CustomSwitches = footer,
                    PageSize = Rotativa.Core.Options.Size.A4
                },
                // SaveOnServerPath = path,
            };


            // Info.  
            // return View(obj);
        }


        public ActionResult RevenueByUserPdfIpad(string userid, string random, string Token)
        {


            // Initialization.  
            AddPageHeader("Ký Hợp đồng CB", "");
            AddBreadcrumb("Ký Hợp đồng CB", "");
            AddBreadcrumb("Ký Hợp đồng CB", "/RevenueHome/RevenueByUserPdfIpad");



            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();
            List<cms_Account> _Accounts = new List<cms_Account>();


            if (string.IsNullOrEmpty(userid))
            {
                userid = "0";
            }

            if (string.IsNullOrEmpty(Token))
            {
                Token = "";
            }

            if (string.IsNullOrEmpty(random))
            {
                random = "";
            }

            try
            {
                if (!string.IsNullOrEmpty(userid) && !string.IsNullOrEmpty(Token) && !string.IsNullOrEmpty(random))
                {
                    if (CMSLIS.Common.Common.CheckKeyPrivate(userid, random, Token))
                    {
                        _Accounts = impCms_Account.Getcms_AccountByUserName(userid);

                        if (_Accounts != null)
                        {
                            if (_Accounts.Count > 0)
                            {
                                List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUserAgree(userid);
                                obj.Patients = Patients;

                                if (Patients == null)
                                {
                                    ViewBag.TitleSuccsess = "Chưa có dữ liệu, mời bạn kiểm tra lại!";
                                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                    return View(obj);
                                }


                                obj.cms_AccountValue = _Accounts[0];
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                                    {
                                        using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(_Accounts[0].Hoten + " " + DateTime.Now.ToString("dd/MM/yyyy"), QRCodeGenerator.ECCLevel.L))
                                        {
                                            using (QRCode qrCode = new QRCode(qrCodeData))
                                            {

                                                using (Bitmap bitMap = qrCode.GetGraphic(20))
                                                {
                                                    bitMap.Save(ms, ImageFormat.Png);
                                                    ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueAll:" + ex.ToString());
            }



            // Info.  
            //  return View(orderViewModels);

            var root = Server.MapPath("~/PDF/");
            root = root + DateTime.Now.ToString("yyyyMMdd");
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            var pdfname = "\\" + _Accounts[0].Username + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + random + ".pdf";
            var path = root + pdfname;

            string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Trang: [page]/[toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";
            return new Rotativa.MVC.PartialViewAsPdf(obj)
            {
                RotativaOptions = new Rotativa.Core.DriverOptions()
                {
                    CustomSwitches = footer,
                    PageSize = Rotativa.Core.Options.Size.A4
                },
                // FileName = _Accounts[0].Username + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + random + ".pdf",
                // SaveOnServerPath = path,
            };


            // Info.  
            // return View(obj);
        }


        public ActionResult RevenueOrderpdf()
        {


            // Initialization.  
            AddPageHeader("Ký Hợp đồng CB", "");
            AddBreadcrumb("Ký Hợp đồng CB", "");
            AddBreadcrumb("Ký Hợp đồng CB", "/RevenueHome/RevenueOrderpdf");
            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();


            var UserInfo = ((cms_Account)Session["UserInfo"]);

            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();

            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            obj.userid = UserInfo.AccountLis;


            try
            {
                List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUserAgree(obj.userid);
                obj.Patients = Patients;

                if (Patients == null)
                {
                    ViewBag.TitleSuccsess = "Chưa có dữ liệu, mời bạn kiểm tra lại!";
                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                    return View(obj);
                }

            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueAll:" + ex.ToString());
            }




            using (MemoryStream ms = new MemoryStream())
            {
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                {
                    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(UserInfo.Hoten + " " + DateTime.Now.ToString("dd/MM/yyyy"), QRCodeGenerator.ECCLevel.L))
                    {
                        using (QRCode qrCode = new QRCode(qrCodeData))
                        {

                            using (Bitmap bitMap = qrCode.GetGraphic(20))
                            {
                                bitMap.Save(ms, ImageFormat.Png);
                                ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                            }



                        }
                    }
                }
            }



            // Info.  
            //  return View(orderViewModels);
            string random = CMSLIS.Common.Common.getRandom();
            var root = Server.MapPath("~/PDF/");
            root = root + DateTime.Now.ToString("yyyyMMdd");
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            var pdfname = "\\" + UserInfo.Username + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + random + ".pdf";
            var path = root + pdfname;
            // path = Path.GetFullPath(path);

            string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Trang: [page]/[toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";



            return new Rotativa.MVC.PartialViewAsPdf(obj)
            {
                RotativaOptions = new Rotativa.Core.DriverOptions()
                {
                    CustomSwitches = footer,
                    PageSize = Rotativa.Core.Options.Size.A4
                },
                // FileName = UserInfo.Username + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + random + ".pdf",
                // SaveOnServerPath = path,
            };

            // Info.  
            // return View(obj);
        }


        public ActionResult RevenueOrderAcceptpdf(string userid, string token, string random)
        {


            // Initialization.  
            AddPageHeader("Ký Hợp đồng CB", "");
            AddBreadcrumb("Ký Hợp đồng CB", "");
            AddBreadcrumb("Ký Hợp đồng CB", "/RevenueHome/RevenueOrderAcceptpdf");
            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();

            List<cms_Account> _Accounts = new List<cms_Account>();
            List<tblReportRevenue> Patients = null;
            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();

            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            obj.userid = "0";


            if (string.IsNullOrEmpty(userid))
            {
                userid = "0";
            }

            if (string.IsNullOrEmpty(token))
            {
                token = "";
            }


            try
            {
                if (!string.IsNullOrEmpty(userid) && !string.IsNullOrEmpty(token))
                {
                    if (CMSLIS.Common.Common.CheckKeyPrivate(userid, random, token))
                    {


                        _Accounts = impCms_Account.Getcms_AccountByUserName(userid);
                        obj.cms_AccountValue = _Accounts[0];

                        Patients = imptbl_Patient.Gettbl_Patient_TotalInvoiceByUsser(userid, 1, string.Empty);
                        //  Patients = imptbl_Patient.Gettbl_PatientByUserAgree(obj.userid);
                        obj.Patients = Patients;

                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                            {
                                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(_Accounts[0].Hoten + " " + DateTime.Now.ToString("dd/MM/yyyy"), QRCodeGenerator.ECCLevel.L))
                                {
                                    using (QRCode qrCode = new QRCode(qrCodeData))
                                    {

                                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                                        {
                                            bitMap.Save(ms, ImageFormat.Png);
                                            ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                                        }



                                    }
                                }
                            }
                        }


                        if (Patients == null)
                        {
                            ViewBag.TitleSuccsess = "Chưa có dữ liệu, mời bạn kiểm tra lại!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                            return View(obj);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueAll:" + ex.ToString());
            }





            if (Patients != null)
            {
                if (Patients.Count > 0)
                {
                    // Info.  

                    var root = Server.MapPath("~/PDF/");
                    root = root + DateTime.Now.ToString("yyyyMM");
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }

                    root = root + "/" + DateTime.Now.ToString("yyyyMMdd");
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    var pdfname = "\\" + _Accounts[0].Username + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + random + "12.pdf";
                    var path = root + pdfname;
                    // path = Path.GetFullPath(path);

                    string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Trang: [page]/[toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";

                    // imptbl_Patient.Gettbl_Patient_TotalInvoiceByUsser(obj.userid, 1, string.Empty);

                    imptbl_Patient.tbl_Revenue_SignInsert(userid, Patients[0].NgayThu.ToString("yyyyMMdd"), "PDF/" + DateTime.Now.ToString("yyyyMM") + "/" + DateTime.Now.ToString("yyyyMMdd") + pdfname, Patients[0].LocationName, Patients[0].GroupName);

                    return new Rotativa.MVC.PartialViewAsPdf(obj)
                    {
                        RotativaOptions = new Rotativa.Core.DriverOptions()
                        {
                            CustomSwitches = footer,
                            PageSize = Rotativa.Core.Options.Size.A4
                        },
                        SaveOnServerPath = path,

                    };
                }
                else
                {
                    return View(obj);
                }
            }
            else
            {
                return View(obj);
            }

            // CMSLIS.Common.Common.WriteFileFromByte(CMSLIS.Common.Common.SignPDF(ReadFileToByte(pdfname)), pdfname + "_HopDong_Singapore.pdf"),

            // Info.  
            // return View(obj);
        }




        #endregion

        #region --> Ký xác nhận của cán bộ
        public ActionResult RevenueOrderAgree()
        {


            // Initialization.  
            AddPageHeader("Ký xác nhận của cán bộ", "");
            AddBreadcrumb("Ký xác nhận của cán bộ", "");
            AddBreadcrumb("Ký xác nhận của cán bộ", "/RevenueHome/RevenueOrderAgree");
            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();

            ViewBag.AccessToken = Session["access_token"];
            ViewBag.RefreshToken = Session["refresh_token"];


            var UserInfo = ((cms_Account)Session["UserInfo"]);

            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();

            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            if (UserInfo.AccountTypeId == 1)
            {
                obj.userid = UserInfo.AccountLis;
            }
            else
            {
                obj.userid = UserInfo.Username;
            }

            obj.tungay = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");


            try
            {
                List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_Patient_TotalInvoiceByUsser(obj.userid, 1, string.Empty);

                List<tblReportRevenue> Patient2s = imptbl_Patient.Gettbl_Patient_TotalInvoiceByUserAgree(obj.userid, 1, string.Empty);


                obj.Patients = Patients;
                obj.Patients2 = Patient2s;
                if (Patients == null)
                {
                    ViewBag.TitleSuccsess = "Chưa có dữ liệu, mời bạn kiểm tra lại!";
                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                    return View(obj);
                }

            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueAll:" + ex.ToString());
            }



            //using (MemoryStream ms = new MemoryStream())
            //{
            //    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            //    {
            //        using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(UserInfo.Hoten + " " + DateTime.Now.ToString("dd/MM/yyyy"), QRCodeGenerator.ECCLevel.L))
            //        {
            //            using (QRCode qrCode = new QRCode(qrCodeData))
            //            {

            //                using (Bitmap bitMap = qrCode.GetGraphic(20))
            //                {
            //                    bitMap.Save(ms, ImageFormat.Png);
            //                    ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
            //                }
            //            }
            //        }
            //    }
            //}



            // Info.  
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RevenueOrderAgree(RevenueViewAgreeModel obj, string submit)
        {
            // Initialization.  
            AddPageHeader("Ký xác nhận của cán bộ", "");
            AddBreadcrumb("Ký xác nhận của cán bộ", "");
            AddBreadcrumb("Ký xác nhận của cán bộ", "/RevenueHome/RevenueOrderAgree");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();
            List<tblReportRevenue> Patients = new List<tblReportRevenue>();
            List<tblReportRevenue> Patient2s1 = new List<tblReportRevenue>();
            DateTime Tungay = new DateTime();

            try
            {
                var UserInfo = ((cms_Account)Session["UserInfo"]);



                #region Check input data
                try
                {
                    if (!string.IsNullOrEmpty(obj.tungay.Trim()))
                        Tungay = DateTime.ParseExact(obj.tungay.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                }
                catch
                {

                }
                #endregion


                switch (submit)
                {


                    case "SearchRevenueOrderAgree":
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }
                        Patients = imptbl_Patient.Gettbl_Patient_TotalInvoiceByUserDate(obj.userid, Tungay.ToString("yyyyMMdd"), obj.typeKeyword, obj.keyword);
                        obj.Patients = Patients;
                        List<tblReportRevenue> Patient2s = imptbl_Patient.Gettbl_Patient_TotalInvoiceByUserDateAgree(obj.userid, Tungay.ToString("yyyyMMdd"), obj.typeKeyword, obj.keyword);
                        obj.Patients2 = Patient2s;

                        break;

                    case "signinvnpt":



                        if (string.IsNullOrEmpty(obj.Username) || string.IsNullOrEmpty(obj.Password))
                        {
                            ViewBag.TitleSuccsess = "Mời bạn nhập thông tin email và mật khẩu!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                            return View(obj);
                        }

                        // Exchange email and password for access_token
                        _initializeWebServerClient();
                        try
                        {

                            var userAuthorization = _webServerClient.ExchangeUserCredentialForToken(obj.Username, obj.Password, scopes: new[] { "public_profile", "sign_request" });
                            if (userAuthorization != null)
                            {
                                AddLogin(CMSLIS.Common.Constant.StatusLoginOK, obj.Username);
                                var x = userAuthorization.AccessTokenExpirationUtc;
                                var y = TimeZoneInfo.ConvertTimeFromUtc(x.Value, TimeZoneInfo.Local);
                                Session.Add("access_token", userAuthorization.AccessToken);
                                Session.Add("refresh_token", userAuthorization.RefreshToken);

                            }
                            else
                            {
                                ViewBag.TitleSuccsess = "Không tìm thấy thông tin account!";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                AddLogin(CMSLIS.Common.Constant.StatusLoginNOK, obj.Username);
                            }

                        }
                        catch (Exception ex)
                        {
                            ViewBag.TitleSuccsess = "Không tìm thấy thông tin account!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                            AddLogin(CMSLIS.Common.Constant.StatusLoginNOK, obj.Username);
                        }
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }
                        Patients = imptbl_Patient.Gettbl_Patient_TotalInvoiceByUserDate(obj.userid, Tungay.ToString("yyyyMMdd"), obj.typeKeyword, obj.keyword);
                        obj.Patients = Patients;
                        Patient2s1 = imptbl_Patient.Gettbl_Patient_TotalInvoiceByUserDateAgree(obj.userid, Tungay.ToString("yyyyMMdd"), obj.typeKeyword, obj.keyword);
                        obj.Patients2 = Patient2s1;

                        break;

                    case "SaveRevenueOrderAgreee":
                        byte[] unsignData;
                        byte[] signedBytes = null;
                        var accessToken = Session["access_token"] as string;
                        if (string.IsNullOrEmpty(accessToken))
                        {
                            ViewBag.TitleSuccsess = "Mời đăng nhập lại để ký!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;


                        }
                        logError.Info("RevenueOrderAgree:Bước 1");

                        #region Bước 1: Lấy danh sách chữ ký số trên hệ thống VNPT Ký số
                        var userCert = _getAccoutCert(accessToken);
                        if (userCert == null)
                        {
                            ViewBag.TitleSuccsess = "Lỗi trong quá trình kết nối với vnpt!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                            logError.Info("RevenueOrderAgree:Bước 1 d");
                        }

                        // TODO: Bổ sung chức năng chọn chữ ký số cho người dùng
                        string certID = userCert.ID;
                        #endregion

                        #region Bước 2: Lấy thông tin thanh toán giao dịch
                        var servicePack = _getAccoutServicePack(accessToken);
                        if (servicePack == null)
                        {
                            ViewBag.TitleSuccsess = "Lỗi trong quá trình kết nối với vnpt!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                            logError.Info("RevenueOrderAgree:Bước 2 d" + _error);
                        }
                        string servicePackID = servicePack.ID;
                        #endregion

                        #region Đọc dữ liệu cần ký file upload

                        logError.Info("RevenueOrderAgree:Bước 2");
                        string signedFile = "";

                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }

                        Patients = imptbl_Patient.Gettbl_Patient_TotalInvoiceByUserDate(obj.userid, Tungay.ToString("yyyyMMdd"), obj.typeKeyword, obj.keyword);
                        obj.Patients = Patients;
                        List<tblReportRevenue> Patient2s2 = imptbl_Patient.Gettbl_Patient_TotalInvoiceByUserDateAgree(obj.userid, Tungay.ToString("yyyyMMdd"), obj.typeKeyword, obj.keyword);
                        obj.Patients2 = Patient2s2;

                        string filepath = Server.MapPath("~/PDF/") + Patients[0].pathpdf.Replace("\\", "/").Replace("PDF/", "");


                        using (Stream inputStream = new FileStream(path: filepath, mode: FileMode.Open, access: FileAccess.Read, share: FileShare.Read))
                        {
                            try
                            {
                                if (!(inputStream is MemoryStream memoryStream))
                                {
                                    memoryStream = new MemoryStream();
                                    inputStream.CopyTo(memoryStream);
                                }

                                unsignData = memoryStream.ToArray();



                                signedFile = filepath.Replace(".pdf", "_signed.pdf");

                                #region Bước 4: Ký dữ liệu 


                                // signedBytes = Gateway.v4.SampleWeb.Common.SignHash.SignHashPdf(unsignData, servicePackID, certID,
                                //_parseCert(userCert.CertBase64), accessToken);

                                signedBytes = SignHash.SignHashPdf(unsignData, servicePackID, certID,
                                    _parseCert(userCert.CertBase64), accessToken);


                                if (signedBytes == null)
                                {
                                    ViewBag.TitleSuccsess = "Lỗi ký số VNPT!";
                                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;

                                }
                                #endregion

                            }
                            catch (Exception ex)
                            {
                                ViewBag.TitleSuccsess = "Không thể phân tích dữ liệu cần ký!";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;

                                logError.Info("RevenueOrderAgree:Bước 3" + ex.ToString());
                            }
                        }
                        #endregion

                        // Cập nhật ngày ký
                        if (UserInfo.uid == 1)
                        {
                            imptblReportRevenue.tblReportRevenueAccuracyDate(UserInfo.AccountLis.ToString(), Tungay.ToString("yyyyMMdd"));
                        }
                        else
                        {
                            imptblReportRevenue.tblReportRevenueAccuracyDate(UserInfo.Username.ToString(), Tungay.ToString("yyyyMMdd"));
                        }

                        FileContentResult pdf = File(signedBytes, System.Net.Mime.MediaTypeNames.Application.Octet, signedFile);

                        System.IO.File.WriteAllBytes(filepath.Replace(".pdf", "_signed.pdf"), (pdf.FileContents));

                        imptbl_Patient.tbl_Revenue_SignUpdate(Patients[0].UserTC, Patients[0].NgayThu.ToString("yyyyMMdd"), filepath.Replace(".pdf", "_signed.pdf").Replace(Server.MapPath("~/PDF/"), "/PDF/"));

                        logError.Info("RevenueOrderAgree:Bước 4");
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }



                        return File(signedBytes, System.Net.Mime.MediaTypeNames.Application.Octet, signedFile);

                        //    //   // break;
                }

            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!" + ex.ToString();
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueOrderAgree:" + ex.ToString());
            }


            if (string.IsNullOrEmpty(obj.keyword))
            {
                obj.keyword = string.Empty;
            }
            Patients = imptbl_Patient.Gettbl_Patient_TotalInvoiceByUserDate(obj.userid, Tungay.ToString("yyyyMMdd"), obj.typeKeyword, obj.keyword);
            obj.Patients = Patients;
            Patient2s1 = imptbl_Patient.Gettbl_Patient_TotalInvoiceByUserDateAgree(obj.userid, Tungay.ToString("yyyyMMdd"), obj.typeKeyword, obj.keyword);
            obj.Patients2 = Patient2s1;


            // Info.  
            return View(obj);
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
        /// Lấy thông tin chữ ký số tập trung trên hệ thống
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private static Certificate _getAccoutCert(string token)
        {
            try
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
            }
            catch (Exception ex)
            {
                CMSLIS.Common.Common.AddToLogFile("RevenueOrderAgree:Bước 1 d" + ex.ToString());
            }
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
        private void _initializeWebServerClient()
        {
            var baseUrl = ConfigurationManager.AppSettings["AUTH_SERVER_BASE_URL"];
            var authorizationServerUri = new Uri(baseUrl);
            var clientId = ConfigurationManager.AppSettings["CLIENT_ID"];
            var clientSecret = ConfigurationManager.AppSettings["CLIENT_SECRET"];
            var authorizationServer = new AuthorizationServerDescription
            {
                AuthorizationEndpoint = new Uri(authorizationServerUri, "/signservice/v4/oauth/authorize"),
                TokenEndpoint = new Uri(authorizationServerUri, "/signservice/v4/oauth/token"),
            };

            // SSL configure
            ServicePointManager.ServerCertificateValidationCallback
                += new RemoteCertificateValidationCallback(CoreServiceClient.ValidateRemoteCertificate);


            _webServerClient = new WebServerClient(authorizationServer, clientId, clientSecret);
        }


        #endregion
        #region --> Danh sách khách hàng theo không đồng ý userid
        public ActionResult RevenueNoAgree()
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN không đồng ý", "");
            AddBreadcrumb("Danh sách doanh thu CBTN không đồng ý", "");
            AddBreadcrumb("Danh sách doanh thu CBTN không đồng ý", "/RevenueHome/RevenueOrderAgree");
            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();


            var UserInfo = ((cms_Account)Session["UserInfo"]);

            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();

            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            if (UserInfo.AccountTypeId == 1)
            {
                obj.userid = UserInfo.AccountLis;
            }
            else
            {
                obj.userid = UserInfo.Username;
            }
            obj.tungay = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
            obj.denngay = DateTime.Now.ToString("dd/MM/yyyy");

            try
            {
                List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUseridNoAgree(DateTime.Now.AddDays(-1).ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd"), obj.userid, 0, string.Empty);
                obj.Patients = Patients;
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueNoAgree:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RevenueNoAgree(RevenueViewAgreeModel obj, string submit)
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN không đồng ý", "");
            AddBreadcrumb("Danh sách doanh thu CBTN không đồng ý", "");
            AddBreadcrumb("Danh sách doanh thu CBTN không đồng ý", "/RevenueHome/RevenueNoAgree");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();
            string TextErr = string.Empty;

            DateTime Tungay = new DateTime();
            DateTime Denngay = new DateTime();

            try
            {

                #region Check input data
                try
                {
                    if (!string.IsNullOrEmpty(obj.tungay.Trim()))
                        Tungay = DateTime.ParseExact(obj.tungay.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                    if (!string.IsNullOrEmpty(obj.denngay.Trim()))
                        Denngay = DateTime.ParseExact(obj.denngay.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));

                    if (Tungay > Denngay)
                    {
                        TextErr = "Từ ngày phải nhỏ hơn hoặc bằng đến ngày";
                    }

                    if (Tungay.Date.AddMonths(12) < Denngay.Date)
                    {
                        TextErr = "Chỉ được phép tra cứu tối đa trong vòng 10 tháng";
                    }
                }
                catch
                {
                    TextErr = "Dữ liệu ngày tháng không đúng định dạng";
                }
                #endregion


                var UserInfo = ((cms_Account)Session["UserInfo"]);

                if (TextErr.Length >= 0)
                {
                    switch (submit)
                    {
                        case "SearchRevenueNoAgree":
                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }

                            if (string.IsNullOrEmpty(obj.userid))
                            {
                                obj.userid = string.Empty;
                            }
                            List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUseridNoAgree(Tungay.ToString("yyyyMMdd"), Denngay.AddDays(1).ToString("yyyyMMdd"), obj.userid, obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;
                            break;
                        case "ExportRevenueNoAgree":
                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }
                            AddLogAction("", Constant.ActionExport.ToString());
                            Patients = imptbl_Patient.Gettbl_PatientByUseridNoAgree(Tungay.ToString("yyyyMMdd"), Denngay.AddDays(1).ToString("yyyyMMdd"), obj.userid, obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;


                            ExcelPackage Ep = new ExcelPackage();
                            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Revenue");


                            Sheet.Cells["A1"].Value = "BỆNH VIỆN ĐA KHOA MEDLATEC";
                            Sheet.Cells["A1:U1"].Merge = true;
                            Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            Sheet.Cells["A2"].Value = "ĐT: 1900 565656";
                            Sheet.Cells["A2:U2"].Merge = true;
                            Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            Sheet.Cells["A3"].Value = "Thông tin doanh thu cán bộ " + obj.userid + " không đồng ý tại nhà từ ngày :" + Tungay.ToString("dd/MM/yyyy") + " đến ngày:" + Denngay.ToString("dd/MM/yyyy");
                            Sheet.Cells["A3:U3"].Merge = true;
                            Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                            Sheet.Cells["A4"].Value = "STT";
                            Sheet.Cells["B4"].Value = "Người thu";
                            Sheet.Cells["C4"].Value = "Ngày thu";
                            Sheet.Cells["D4"].Value = "Nhóm doanh thu";
                            Sheet.Cells["E4"].Value = "Đơn vị";
                            Sheet.Cells["F4"].Value = "SID";
                            Sheet.Cells["G4"].Value = "Tên bệnh nhân";
                            Sheet.Cells["H4"].Value = "Tổng tiền";
                            Sheet.Cells["I4"].Value = "Giảm giá";
                            Sheet.Cells["J4"].Value = "Phí đi lại";
                            Sheet.Cells["K4"].Value = "BHTT";
                            Sheet.Cells["L4"].Value = "BHBLTT";
                            Sheet.Cells["M4"].Value = "Thực thu";
                            Sheet.Cells["N4"].Value = "Thẻ Pos";
                            Sheet.Cells["O4"].Value = "Trả trước";
                            Sheet.Cells["P4"].Value = "Trả sau";
                            Sheet.Cells["Q4"].Value = "Tiền còn phải nộp";
                            Sheet.Cells["R4"].Value = "Tiền cán bộ đồng ý";
                            Sheet.Cells["S4"].Value = "Nội dung Điều chỉnh";
                            Sheet.Cells["T4"].Value = "Trạng thái cấp user";
                            Sheet.Cells["U4"].Value = "Trạng thái cấp kế toán";


                            int stt = 1;
                            int row = 5;
                            foreach (var item in Patients)
                            {
                                Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                                Sheet.Cells[string.Format("B{0}", row)].Value = item.UserTC;
                                Sheet.Cells[string.Format("C{0}", row)].Value = CMSLIS.Common.Common.ReFmtTime(item.NgayThu);
                                Sheet.Cells[string.Format("D{0}", row)].Value = item.GroupName;
                                Sheet.Cells[string.Format("E{0}", row)].Value = item.LocationName;
                                Sheet.Cells[string.Format("F{0}", row)].Value = item.S_ID;
                                Sheet.Cells[string.Format("G{0}", row)].Value = item.HoTen;
                                Sheet.Cells[string.Format("H{0}", row)].Value = item.TongCP;
                                Sheet.Cells[string.Format("I{0}", row)].Value = item.TienGG + item.TienDiemPID;
                                Sheet.Cells[string.Format("J{0}", row)].Value = item.PhiDiLai;
                                Sheet.Cells[string.Format("K{0}", row)].Value = item.BHTT;
                                Sheet.Cells[string.Format("L{0}", row)].Value = item.BHBLTT;
                                Sheet.Cells[string.Format("M{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHTT - item.TienDiemPID - item.TienGG;
                                Sheet.Cells[string.Format("N{0}", row)].Value = item.ThePOS;
                                Sheet.Cells[string.Format("O{0}", row)].Value = item.TraTruoc;
                                Sheet.Cells[string.Format("P{0}", row)].Value = item.TraSau;
                                Sheet.Cells[string.Format("Q{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHTT - item.TienDiemPID - item.TienGG - item.ThePOS - item.TraTruoc - item.TraSau;
                                Sheet.Cells[string.Format("R{0}", row)].Value = item.SumAgree;
                                Sheet.Cells[string.Format("S{0}", row)].Value = item.Commentagree;
                                Sheet.Cells[string.Format("T{0}", row)].Value = item.Typeagree;
                                Sheet.Cells[string.Format("U{0}", row)].Value = item.Typeagree1;


                                row++;
                                stt++;
                            }


                            Sheet.Cells["A:AZ"].AutoFitColumns();
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment: filename=" + "Revenue.xlsx");
                            Response.BinaryWrite(Ep.GetAsByteArray());
                            Response.End();

                            break;


                        case "SaveRevenueNoAgree":
                            bool validate = true;
                            #region --> Check validate

                            foreach (var data in obj.Patients)
                            {
                                if (!data.agree)
                                {
                                    if (string.IsNullOrEmpty(data.Commentagree))
                                    {
                                        validate = false;
                                        break;
                                    }
                                }
                            }

                            if (!validate)
                            {
                                ViewBag.TitleSuccsess = "Dòng không đồng ý phải nhập và comment. Xin mời bạn nhập lại!";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                AddLogAction("", Constant.ActionInsertNOK.ToString());
                            }
                            else
                            {
                                foreach (var data in obj.Patients)
                                {

                                    tbl_Revenue revenue = new tbl_Revenue();
                                    revenue.userid = data.UserTC;
                                    revenue.sid = data.S_ID;
                                    revenue.locationid = data.LocationName;

                                    revenue.testcode = string.Empty;
                                    revenue.testname = string.Empty;
                                    revenue.useridAgree = UserInfo.uid.ToString();
                                    revenue.levelAgree = 2;
                                    revenue.IDSouce = 0;
                                    if (string.IsNullOrEmpty(data.Commentagree))
                                    {
                                        revenue.CommentAgree = string.Empty;
                                    }
                                    else
                                    {
                                        revenue.CommentAgree = data.Commentagree;
                                    }

                                    if (data.agree)
                                    {
                                        revenue.Typeagree = 1;
                                        revenue.price = data.TongCP - data.BHBLTT - data.BHBLTT - data.TienGG - data.TienDiemPID - data.ThePOS - data.TraSau - data.TraTruoc;

                                    }
                                    else
                                    {
                                        imptblReportRevenue.tblReportRevenueDelete(data.MaBN, data.S_ID, UserInfo.uid.ToString());
                                        revenue.Typeagree = 0;
                                        revenue.price = data.TongCP - data.BHBLTT - data.BHBLTT - data.TienGG - data.TienDiemPID - data.ThePOS - data.TraSau - data.TraTruoc;
                                    }

                                    var errorsSave = revenue.Validate(new ValidationContext(revenue));
                                    if (errorsSave.ToList().Count == 0)
                                    {
                                        imptbl_Revenue.Add(revenue);
                                        errorsSave = revenue.Validate(new ValidationContext(data));
                                        if (errorsSave.ToList().Count == 0)
                                        {
                                            data.useridAgree = UserInfo.uid.ToString();
                                            data.SumAgree = data.TongCP - data.BHBLTT - data.BHBLTT - data.TienGG - data.TienDiemPID - data.ThePOS - data.TraSau - data.TraTruoc;
                                            imptblReportRevenue.Add(data);

                                        }

                                    }
                                    else
                                    {
                                        ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                    }
                                }

                                ViewBag.TitleSuccsess = "Cập nhật thành công!";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                                AddLogAction("", Constant.ActionInsertOK.ToString());
                                //Results = imptbl_Result.Gettbl_ResultBySID(obj.sid, obj.typeKeyword, obj.keyword);
                                //obj.Results = Results;
                            }


                            #endregion
                            break;


                    }
                }
                else
                {
                    ViewBag.TitleSuccsess = TextErr;
                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("ListOrder:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        #endregion


        #region --> Danh sách khách hàng theo không đồng ý userid
        public ActionResult RevenueAllNoAgree()
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN không đồng ý", "");
            AddBreadcrumb("Danh sách doanh thu CBTN không đồng ý", "");
            AddBreadcrumb("Danh sách doanh thu CBTN không đồng ý", "/RevenueHome/RevenueAllNoAgree");
            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();


            var UserInfo = ((cms_Account)Session["UserInfo"]);

            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();

            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            obj.userid = UserInfo.Username;
            obj.tungay = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
            obj.denngay = DateTime.Now.ToString("dd/MM/yyyy");
            obj.Locationid = "0";
            obj.Groupid = "MBD";


            try
            {
                List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUseridAllNoAgree(DateTime.Now.AddDays(-1).ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, string.Empty, obj.typeKeyword, obj.keyword);
                obj.Patients = Patients;
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueNoAgree:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RevenueAllNoAgree(RevenueViewAgreeModel obj, string submit)
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN không đồng ý", "");
            AddBreadcrumb("Danh sách doanh thu CBTN không đồng ý", "");
            AddBreadcrumb("Danh sách doanh thu CBTN không đồng ý", "/RevenueHome/RevenueAllNoAgree");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();
            string TextErr = string.Empty;

            DateTime Tungay = new DateTime();
            DateTime Denngay = new DateTime();

            try
            {

                #region Check input data
                try
                {
                    if (!string.IsNullOrEmpty(obj.tungay.Trim()))
                        Tungay = DateTime.ParseExact(obj.tungay.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                    if (!string.IsNullOrEmpty(obj.denngay.Trim()))
                        Denngay = DateTime.ParseExact(obj.denngay.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));

                    if (Tungay > Denngay)
                    {
                        TextErr = "Từ ngày phải nhỏ hơn hoặc bằng đến ngày";
                    }

                    if (Tungay.Date.AddMonths(12) < Denngay.Date)
                    {
                        TextErr = "Chỉ được phép tra cứu tối đa trong vòng 10 tháng";
                    }
                }
                catch
                {
                    TextErr = "Dữ liệu ngày tháng không đúng định dạng";
                }
                #endregion


                var UserInfo = ((cms_Account)Session["UserInfo"]);

                if (TextErr.Length >= 0)
                {
                    switch (submit)
                    {
                        case "SearchRevenueAllNoAgree":
                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }

                            if (string.IsNullOrEmpty(obj.userid))
                            {
                                obj.userid = string.Empty;
                            }
                            List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUseridAllNoAgree(Tungay.ToString("yyyyMMdd"), Denngay.AddDays(1).ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;
                            break;
                        case "ExportRevenueAllNoAgree":
                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }
                            AddLogAction("", Constant.ActionExport.ToString());
                            Patients = imptbl_Patient.Gettbl_PatientByUseridAllNoAgree(Tungay.ToString("yyyyMMdd"), Denngay.AddDays(1).ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;


                            ExcelPackage Ep = new ExcelPackage();
                            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Revenue");


                            Sheet.Cells["A1"].Value = "BỆNH VIỆN ĐA KHOA MEDLATEC";
                            Sheet.Cells["A1:W1"].Merge = true;
                            Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            Sheet.Cells["A2"].Value = "ĐT: 1900 565656";
                            Sheet.Cells["A2:W2"].Merge = true;
                            Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            Sheet.Cells["A3"].Value = "Thông tin doanh thu cán bộ không đồng ý tại nhà ngày :" + Tungay.ToString("dd/MM/yyyy") + " đến ngày:" + Denngay.ToString("dd/MM/yyyy");
                            Sheet.Cells["A3:W3"].Merge = true;
                            Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                            Sheet.Cells["A4"].Value = "STT";
                            Sheet.Cells["B4"].Value = "Người thu";
                            Sheet.Cells["C4"].Value = "Ngày thu thu";
                            Sheet.Cells["D4"].Value = "Nhóm doanh thu";
                            Sheet.Cells["E4"].Value = "Đơn vị";
                            Sheet.Cells["F4"].Value = "SID";
                            Sheet.Cells["G4"].Value = "Tên bệnh nhân";
                            Sheet.Cells["H4"].Value = "Tổng tiền";
                            Sheet.Cells["I4"].Value = "Thực thu";
                            Sheet.Cells["J4"].Value = "Tạm thu";
                            Sheet.Cells["K4"].Value = "Phí đi lại";
                            Sheet.Cells["L4"].Value = "Tiền mặt";
                            Sheet.Cells["M4"].Value = "Tiền POS";
                            Sheet.Cells["N4"].Value = "Trả trước";
                            Sheet.Cells["O4"].Value = "Chuyển khoản";
                            Sheet.Cells["P4"].Value = "Trả sau";
                            Sheet.Cells["Q4"].Value = "Tiền giảm giá";
                            Sheet.Cells["R4"].Value = "Tên giảm giá";
                            Sheet.Cells["S4"].Value = "Tiền điểm PID";
                            Sheet.Cells["T4"].Value = "Thẻ giảm giá";
                            Sheet.Cells["U4"].Value = "Tiền cán bộ đồng ý";
                            Sheet.Cells["V4"].Value = "Nội dung Điều chỉnh (CB Gửi)";
                            Sheet.Cells["W4"].Value = "Trạng thái duyệt (CB)";


                            int stt = 1;
                            int row = 5;
                            foreach (var item in Patients)
                            {
                                Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                                Sheet.Cells[string.Format("B{0}", row)].Value = item.UserTC;
                                Sheet.Cells[string.Format("C{0}", row)].Value = CMSLIS.Common.Common.ReFmtTime(item.NgayThu);
                                Sheet.Cells[string.Format("D{0}", row)].Value = item.GroupName;
                                Sheet.Cells[string.Format("E{0}", row)].Value = item.LocationName;
                                Sheet.Cells[string.Format("F{0}", row)].Value = item.S_ID;
                                Sheet.Cells[string.Format("G{0}", row)].Value = item.HoTen;
                                Sheet.Cells[string.Format("H{0}", row)].Value = item.TongCP;
                                Sheet.Cells[string.Format("I{0}", row)].Value = item.ThucThu;
                                Sheet.Cells[string.Format("J{0}", row)].Value = item.TamThu;
                                Sheet.Cells[string.Format("K{0}", row)].Value = item.PhiDiLai;
                                Sheet.Cells[string.Format("L{0}", row)].Value = item.TienMat;
                                Sheet.Cells[string.Format("M{0}", row)].Value = item.ThePOS;
                                Sheet.Cells[string.Format("N{0}", row)].Value = item.TraTruoc;
                                Sheet.Cells[string.Format("O{0}", row)].Value = item.ChKhoan;
                                Sheet.Cells[string.Format("P{0}", row)].Value = item.TraSau;
                                Sheet.Cells[string.Format("Q{0}", row)].Value = item.TienGG;
                                Sheet.Cells[string.Format("R{0}", row)].Value = item.TenGG;
                                Sheet.Cells[string.Format("S{0}", row)].Value = item.TienDiemPID;
                                Sheet.Cells[string.Format("T{0}", row)].Value = item.TheSuDung;
                                Sheet.Cells[string.Format("U{0}", row)].Value = item.ThucThu - item.SumAgree;
                                Sheet.Cells[string.Format("V{0}", row)].Value = item.Commentagree;
                                Sheet.Cells[string.Format("W{0}", row)].Value = item.Typeagree;

                                row++;
                                stt++;
                            }


                            Sheet.Cells["A:AZ"].AutoFitColumns();
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment: filename=" + "Revenue.xlsx");
                            Response.BinaryWrite(Ep.GetAsByteArray());
                            Response.End();

                            break;

                        case "SaveRevenueAllNoAgree":
                            bool validate = true;
                            #region --> Check validate

                            //foreach (var data in obj.Patients)
                            //{
                            //    if (data.agree)
                            //    {
                            //        if (string.IsNullOrEmpty(data.Commentagree))
                            //        {
                            //            validate = false;
                            //            break;
                            //        }
                            //    }
                            //}

                            if (!validate)
                            {
                                ViewBag.TitleSuccsess = "Dòng không đồng ý phải nhập và comment. Xin mời bạn nhập lại!";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                AddLogAction("", Constant.ActionInsertNOK.ToString());
                            }
                            else
                            {


                                foreach (var data in obj.Patients)
                                {

                                    tbl_Revenue revenue = new tbl_Revenue();
                                    revenue.userid = data.UserTC;
                                    revenue.sid = data.S_ID;
                                    revenue.locationid = data.LocationName;

                                    revenue.testcode = string.Empty;
                                    revenue.testname = string.Empty;
                                    revenue.useridAgree = UserInfo.uid.ToString();
                                    revenue.levelAgree = 3;
                                    revenue.IDSouce = data.MaBN;
                                    revenue.NgayThu = data.NgayThu;
                                    revenue.IDCLS = data.IDCLS;
                                    revenue.RevenueImages = data.RevenueImages;
                                    if (string.IsNullOrEmpty(data.Commentagree1))
                                    {
                                        revenue.CommentAgree = string.Empty;
                                    }
                                    else
                                    {
                                        revenue.CommentAgree = data.Commentagree1;
                                    }

                                    if (data.agree)
                                    {
                                        revenue.Typeagree = 1;
                                        revenue.price = data.TongCP - data.BHBLTT - data.BHBLTT - data.TienGG - data.TienDiemPID - data.ThePOS - data.TraSau - data.TraTruoc;

                                        var errorsSave = revenue.Validate(new ValidationContext(revenue));
                                        if (errorsSave.ToList().Count == 0)
                                        {

                                            imptbl_Revenue.Add(revenue);
                                            errorsSave = revenue.Validate(new ValidationContext(data));
                                            if (errorsSave.ToList().Count == 0)
                                            {
                                                if (data.agree)
                                                {
                                                    //data.Typeagree = "1";
                                                    //data.IDSouce = 0;
                                                    //data.useridAgree = UserInfo.uid.ToString();
                                                    //data.SumAgree = data.TongCP - data.BHBLTT - data.BHTT - data.TienDiemPID - data.TienGG - data.ThePOS - data.TraTruoc - data.TraSau;

                                                    //imptblReportRevenue.Add(data);

                                                    //Bắn noti cho người dùng và cập nhật tiền
                                                    imptblReportRevenue.tblReportRevenueSendNoti(data.S_ID);
                                                }


                                                //else
                                                //{
                                                //    data.Typeagree = "0";
                                                //    data.IDSouce = 0;
                                                //    data.useridAgree = UserInfo.uid.ToString();
                                                //    data.SumAgree = 0;
                                                //    imptblReportRevenue.Add(data);
                                                //}
                                            }

                                        }
                                        else
                                        {
                                            ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                        }

                                    }

                                    if (data.typeNotAgree)
                                    {
                                        revenue.Typeagree = 0;
                                        revenue.price = data.TongCP - data.BHBLTT - data.BHBLTT - data.TienGG - data.TienDiemPID - data.ThePOS - data.TraSau - data.TraTruoc;

                                        var errorsSave = revenue.Validate(new ValidationContext(revenue));
                                        if (errorsSave.ToList().Count == 0)
                                        {
                                            imptbl_Revenue.Add(revenue);
                                        }
                                        imptblReportRevenue.tblReportRevenueSendNotiNotAgree(data.S_ID);
                                    }


                                    //else
                                    //{
                                    //   // imptblReportRevenue.tblReportRevenueDelete(data.MaBN, data.S_ID, UserInfo.uid.ToString());
                                    //    revenue.Typeagree = 0;
                                    //    revenue.price = 0;
                                    //}


                                }

                                ViewBag.TitleSuccsess = "Cập nhật thành công!";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                                AddLogAction("", Constant.ActionInsertOK.ToString());
                                //Results = imptbl_Result.Gettbl_ResultBySID(obj.sid, obj.typeKeyword, obj.keyword);
                                //obj.Results = Results;
                            }


                            if (string.IsNullOrEmpty(obj.keyword))
                                obj.keyword = string.Empty;
                            Patients = imptbl_Patient.Gettbl_PatientByUseridAllNoAgree(Tungay.ToString("yyyyMMdd"), Denngay.AddDays(1).ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;

                            #endregion
                            break;

                        case "SaveRevenueAgree":
                            validate = true;
                            #region --> Check validate

                            foreach (var data in obj.Patients)
                            {
                                if (data.typeNotAgree)
                                {
                                    if (string.IsNullOrEmpty(data.Commentagree1))
                                    {
                                        validate = false;
                                        break;
                                    }
                                }
                            }

                            if (!validate)
                            {
                                ViewBag.TitleSuccsess = "Dòng đồng ý phải nhập và comment. Xin mời bạn nhập lại!";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                AddLogAction("", Constant.ActionInsertNOK.ToString());
                            }
                            else
                            {
                                foreach (var data in obj.Patients)
                                {

                                    tbl_Revenue revenue = new tbl_Revenue();
                                    revenue.userid = data.UserTC;
                                    revenue.sid = data.S_ID;
                                    revenue.locationid = data.LocationName;

                                    revenue.testcode = string.Empty;
                                    revenue.testname = string.Empty;
                                    revenue.useridAgree = UserInfo.uid.ToString();
                                    revenue.levelAgree = 3;
                                    revenue.IDSouce = data.MaBN;
                                    revenue.NgayThu = data.NgayThu;
                                    revenue.IDCLS = data.IDCLS;
                                    revenue.RevenueImages = data.RevenueImages;
                                    if (string.IsNullOrEmpty(data.Commentagree1))
                                    {
                                        revenue.CommentAgree = string.Empty;
                                    }
                                    else
                                    {
                                        revenue.CommentAgree = data.Commentagree1;
                                    }

                                    if (data.agree)
                                    {
                                        revenue.Typeagree = 1;
                                        revenue.price = data.TongCP - data.BHBLTT - data.BHBLTT - data.TienGG - data.TienDiemPID - data.ThePOS - data.TraSau - data.TraTruoc;
                                        var errorsSave = revenue.Validate(new ValidationContext(revenue));
                                        if (errorsSave.ToList().Count == 0)
                                        {

                                            imptbl_Revenue.Add(revenue);


                                            errorsSave = revenue.Validate(new ValidationContext(data));
                                            if (errorsSave.ToList().Count == 0)
                                            {
                                                if (data.agree)
                                                {
                                                    //data.Typeagree = "1";
                                                    //data.IDSouce = 0;
                                                    //data.useridAgree = UserInfo.uid.ToString();
                                                    //data.SumAgree = data.TongCP - data.BHBLTT - data.BHTT - data.TienDiemPID - data.TienGG - data.ThePOS - data.TraTruoc - data.TraSau;

                                                    //imptblReportRevenue.Add(data);
                                                    //Bắn noti cho người dùng
                                                    imptblReportRevenue.tblReportRevenueSendNoti(data.S_ID);
                                                }
                                                //else
                                                //{
                                                //    data.Typeagree = "0";
                                                //    data.IDSouce = 0;
                                                //    data.useridAgree = UserInfo.uid.ToString();
                                                //    data.SumAgree = 0;
                                                //    imptblReportRevenue.Add(data);
                                                //}



                                            }

                                        }
                                        else
                                        {
                                            ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                        }
                                    }

                                    if (data.typeNotAgree)
                                    {
                                        revenue.Typeagree = 0;
                                        revenue.price = data.TongCP - data.BHBLTT - data.BHBLTT - data.TienGG - data.TienDiemPID - data.ThePOS - data.TraSau - data.TraTruoc;

                                        var errorsSave = revenue.Validate(new ValidationContext(revenue));
                                        if (errorsSave.ToList().Count == 0)
                                        {
                                            imptbl_Revenue.Add(revenue);
                                        }
                                        imptblReportRevenue.tblReportRevenueSendNotiNotAgree(data.S_ID);
                                    }

                                    //else
                                    //{
                                    //    // imptblReportRevenue.tblReportRevenueDelete(data.MaBN, data.S_ID, UserInfo.uid.ToString());
                                    //    revenue.Typeagree = 0;
                                    //    revenue.price = 0;
                                    //}


                                }

                                ViewBag.TitleSuccsess = "Cập nhật thành công!";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                                AddLogAction("", Constant.ActionInsertOK.ToString());
                                //Results = imptbl_Result.Gettbl_ResultBySID(obj.sid, obj.typeKeyword, obj.keyword);
                                //obj.Results = Results;
                            }

                            if (string.IsNullOrEmpty(obj.keyword))
                                obj.keyword = string.Empty;
                            Patients = imptbl_Patient.Gettbl_PatientByUseridAllNoAgree(Tungay.ToString("yyyyMMdd"), Denngay.AddDays(1).ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;

                            #endregion
                            break;


                    }
                }
                else
                {
                    ViewBag.TitleSuccsess = TextErr;
                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("ListOrder:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        #endregion

        #region --> Danh sách sử lý đồng ý
        public ActionResult RevenueAllNoAgree1()
        {


            // Initialization.  
            AddPageHeader("Danh sách sử lý đồng ý", "");
            AddBreadcrumb("Danh sách sử lý đồng ý", "");
            AddBreadcrumb("Danh sách sử lý đồng ý", "/RevenueHome/RevenueAllNoAgree1");
            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();


            var UserInfo = ((cms_Account)Session["UserInfo"]);

            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();

            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            obj.userid = UserInfo.Username;
            obj.tungay = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
            obj.denngay = DateTime.Now.ToString("dd/MM/yyyy");
            obj.Locationid = "0";
            obj.Groupid = "MBD";


            try
            {
                List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUseridAllNoAgree1(DateTime.Now.AddDays(-1).ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, string.Empty, obj.typeKeyword, obj.keyword);
                obj.Patients = Patients;
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueNoAgree:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RevenueAllNoAgree1(RevenueViewAgreeModel obj, string submit)
        {


            // Initialization.  
            AddPageHeader("Danh sách sử lý đồng ý", "");
            AddBreadcrumb("Danh sách sử lý đồng ý", "");
            AddBreadcrumb("Danh sách sử lý đồng ý", "/RevenueHome/RevenueAllNoAgree1");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();
            string TextErr = string.Empty;

            DateTime Tungay = new DateTime();
            DateTime Denngay = new DateTime();

            try
            {

                #region Check input data
                try
                {
                    if (!string.IsNullOrEmpty(obj.tungay.Trim()))
                        Tungay = DateTime.ParseExact(obj.tungay.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                    if (!string.IsNullOrEmpty(obj.denngay.Trim()))
                        Denngay = DateTime.ParseExact(obj.denngay.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));

                    if (Tungay > Denngay)
                    {
                        TextErr = "Từ ngày phải nhỏ hơn hoặc bằng đến ngày";
                    }

                    if (Tungay.Date.AddMonths(12) < Denngay.Date)
                    {
                        TextErr = "Chỉ được phép tra cứu tối đa trong vòng 10 tháng";
                    }
                }
                catch
                {
                    TextErr = "Dữ liệu ngày tháng không đúng định dạng";
                }
                #endregion


                var UserInfo = ((cms_Account)Session["UserInfo"]);

                if (TextErr.Length >= 0)
                {
                    switch (submit)
                    {
                        case "SearchRevenueAllNoAgree":
                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }

                            if (string.IsNullOrEmpty(obj.userid))
                            {
                                obj.userid = string.Empty;
                            }
                            List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUseridAllNoAgree1(Tungay.ToString("yyyyMMdd"), Denngay.AddDays(1).ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;
                            break;
                        case "ExportRevenueAllNoAgree":
                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }
                            AddLogAction("", Constant.ActionExport.ToString());
                            Patients = imptbl_Patient.Gettbl_PatientByUseridAllNoAgree1(Tungay.ToString("yyyyMMdd"), Denngay.AddDays(1).ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;


                            ExcelPackage Ep = new ExcelPackage();
                            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Revenue");


                            Sheet.Cells["A1"].Value = "BỆNH VIỆN ĐA KHOA MEDLATEC";
                            Sheet.Cells["A1:W1"].Merge = true;
                            Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            Sheet.Cells["A2"].Value = "ĐT: 1900 565656";
                            Sheet.Cells["A2:W2"].Merge = true;
                            Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            Sheet.Cells["A3"].Value = "Thông tin danh sách duyệt đồng ý :" + Tungay.ToString("dd/MM/yyyy") + " đến ngày:" + Denngay.ToString("dd/MM/yyyy");
                            Sheet.Cells["A3:W3"].Merge = true;
                            Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                            Sheet.Cells["A4"].Value = "STT";
                            Sheet.Cells["B4"].Value = "Người thu";
                            Sheet.Cells["C4"].Value = "Ngày thu thu";
                            Sheet.Cells["D4"].Value = "Nhóm doanh thu";
                            Sheet.Cells["E4"].Value = "Đơn vị";
                            Sheet.Cells["F4"].Value = "SID";
                            Sheet.Cells["G4"].Value = "Tên bệnh nhân";
                            Sheet.Cells["H4"].Value = "Tổng tiền";
                            Sheet.Cells["I4"].Value = "Thực thu";
                            Sheet.Cells["J4"].Value = "Tạm thu";
                            Sheet.Cells["K4"].Value = "Phí đi lại";
                            Sheet.Cells["L4"].Value = "Tiền mặt";
                            Sheet.Cells["M4"].Value = "Tiền POS";
                            Sheet.Cells["N4"].Value = "Trả trước";
                            Sheet.Cells["O4"].Value = "Chuyển khoản";
                            Sheet.Cells["P4"].Value = "Trả sau";
                            Sheet.Cells["Q4"].Value = "Tiền giảm giá";
                            Sheet.Cells["R4"].Value = "Tên giảm giá";
                            Sheet.Cells["S4"].Value = "Tiền điểm PID";
                            Sheet.Cells["T4"].Value = "Thẻ giảm giá";
                            Sheet.Cells["U4"].Value = "Tiền cán bộ đồng ý";
                            Sheet.Cells["V4"].Value = "Nội dung Điều chỉnh (CB Gửi)";
                            Sheet.Cells["W4"].Value = "Trạng thái duyệt (CB)";


                            int stt = 1;
                            int row = 5;
                            foreach (var item in Patients)
                            {
                                Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                                Sheet.Cells[string.Format("B{0}", row)].Value = item.UserTC;
                                Sheet.Cells[string.Format("C{0}", row)].Value = CMSLIS.Common.Common.ReFmtTime(item.NgayThu);
                                Sheet.Cells[string.Format("D{0}", row)].Value = item.GroupName;
                                Sheet.Cells[string.Format("E{0}", row)].Value = item.LocationName;
                                Sheet.Cells[string.Format("F{0}", row)].Value = item.S_ID;
                                Sheet.Cells[string.Format("G{0}", row)].Value = item.HoTen;
                                Sheet.Cells[string.Format("H{0}", row)].Value = item.TongCP;
                                Sheet.Cells[string.Format("I{0}", row)].Value = item.ThucThu;
                                Sheet.Cells[string.Format("J{0}", row)].Value = item.TamThu;
                                Sheet.Cells[string.Format("K{0}", row)].Value = item.PhiDiLai;
                                Sheet.Cells[string.Format("L{0}", row)].Value = item.TienMat;
                                Sheet.Cells[string.Format("M{0}", row)].Value = item.ThePOS;
                                Sheet.Cells[string.Format("N{0}", row)].Value = item.TraTruoc;
                                Sheet.Cells[string.Format("O{0}", row)].Value = item.ChKhoan;
                                Sheet.Cells[string.Format("P{0}", row)].Value = item.TraSau;
                                Sheet.Cells[string.Format("Q{0}", row)].Value = item.TienGG;
                                Sheet.Cells[string.Format("R{0}", row)].Value = item.TenGG;
                                Sheet.Cells[string.Format("S{0}", row)].Value = item.TienDiemPID;
                                Sheet.Cells[string.Format("T{0}", row)].Value = item.TheSuDung;
                                Sheet.Cells[string.Format("U{0}", row)].Value = item.ThucThu - item.SumAgree;
                                Sheet.Cells[string.Format("V{0}", row)].Value = item.Commentagree;
                                Sheet.Cells[string.Format("W{0}", row)].Value = item.Typeagree;

                                row++;
                                stt++;
                            }


                            Sheet.Cells["A:AZ"].AutoFitColumns();
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment: filename=" + "RevenueAgree.xlsx");
                            Response.BinaryWrite(Ep.GetAsByteArray());
                            Response.End();

                            break;





                    }
                }
                else
                {
                    ViewBag.TitleSuccsess = TextErr;
                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("ListOrder:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        #endregion

        #region --> Danh sách sử lý đồng ý
        public ActionResult RevenueAllNoAgree2()
        {


            // Initialization.  
            AddPageHeader("Danh sách sử lý không đồng ý", "");
            AddBreadcrumb("Danh sách sử lý không đồng ý", "");
            AddBreadcrumb("Danh sách sử lý không đồng ý", "/RevenueHome/RevenueAllNoAgree2");
            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();


            var UserInfo = ((cms_Account)Session["UserInfo"]);

            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();

            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            obj.userid = UserInfo.Username;
            obj.tungay = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
            obj.denngay = DateTime.Now.ToString("dd/MM/yyyy");
            obj.Locationid = "0";
            obj.Groupid = "MBD";


            try
            {
                List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUseridAllNoAgree2(DateTime.Now.AddDays(-1).ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, string.Empty, obj.typeKeyword, obj.keyword);
                obj.Patients = Patients;
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueNoAgree:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RevenueAllNoAgree2(RevenueViewAgreeModel obj, string submit)
        {


            // Initialization.  
            AddPageHeader("Danh sách sử lý không đồng ý", "");
            AddBreadcrumb("Danh sách sử lý không đồng ý", "");
            AddBreadcrumb("Danh sách sử lý không đồng ý", "/RevenueHome/RevenueAllNoAgree2");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();
            string TextErr = string.Empty;

            DateTime Tungay = new DateTime();
            DateTime Denngay = new DateTime();

            try
            {

                #region Check input data
                try
                {
                    if (!string.IsNullOrEmpty(obj.tungay.Trim()))
                        Tungay = DateTime.ParseExact(obj.tungay.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                    if (!string.IsNullOrEmpty(obj.denngay.Trim()))
                        Denngay = DateTime.ParseExact(obj.denngay.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));

                    if (Tungay > Denngay)
                    {
                        TextErr = "Từ ngày phải nhỏ hơn hoặc bằng đến ngày";
                    }

                    if (Tungay.Date.AddMonths(12) < Denngay.Date)
                    {
                        TextErr = "Chỉ được phép tra cứu tối đa trong vòng 10 tháng";
                    }
                }
                catch
                {
                    TextErr = "Dữ liệu ngày tháng không đúng định dạng";
                }
                #endregion


                var UserInfo = ((cms_Account)Session["UserInfo"]);

                if (TextErr.Length >= 0)
                {
                    switch (submit)
                    {
                        case "SearchRevenueAllNoAgree":
                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }

                            if (string.IsNullOrEmpty(obj.userid))
                            {
                                obj.userid = string.Empty;
                            }
                            List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUseridAllNoAgree2(Tungay.ToString("yyyyMMdd"), Denngay.AddDays(1).ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;
                            break;
                        case "ExportRevenueAllNoAgree":
                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }
                            AddLogAction("", Constant.ActionExport.ToString());
                            Patients = imptbl_Patient.Gettbl_PatientByUseridAllNoAgree2(Tungay.ToString("yyyyMMdd"), Denngay.AddDays(1).ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;


                            ExcelPackage Ep = new ExcelPackage();
                            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Revenue");


                            Sheet.Cells["A1"].Value = "BỆNH VIỆN ĐA KHOA MEDLATEC";
                            Sheet.Cells["A1:W1"].Merge = true;
                            Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            Sheet.Cells["A2"].Value = "ĐT: 1900 565656";
                            Sheet.Cells["A2:W2"].Merge = true;
                            Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            Sheet.Cells["A3"].Value = "Thông tin danh sách duyệt không đồng ý :" + Tungay.ToString("dd/MM/yyyy") + " đến ngày:" + Denngay.ToString("dd/MM/yyyy");
                            Sheet.Cells["A3:W3"].Merge = true;
                            Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                            Sheet.Cells["A4"].Value = "STT";
                            Sheet.Cells["B4"].Value = "Người thu";
                            Sheet.Cells["C4"].Value = "Ngày thu thu";
                            Sheet.Cells["D4"].Value = "Nhóm doanh thu";
                            Sheet.Cells["E4"].Value = "Đơn vị";
                            Sheet.Cells["F4"].Value = "SID";
                            Sheet.Cells["G4"].Value = "Tên bệnh nhân";
                            Sheet.Cells["H4"].Value = "Tổng tiền";
                            Sheet.Cells["I4"].Value = "Thực thu";
                            Sheet.Cells["J4"].Value = "Tạm thu";
                            Sheet.Cells["K4"].Value = "Phí đi lại";
                            Sheet.Cells["L4"].Value = "Tiền mặt";
                            Sheet.Cells["M4"].Value = "Tiền POS";
                            Sheet.Cells["N4"].Value = "Trả trước";
                            Sheet.Cells["O4"].Value = "Chuyển khoản";
                            Sheet.Cells["P4"].Value = "Trả sau";
                            Sheet.Cells["Q4"].Value = "Tiền giảm giá";
                            Sheet.Cells["R4"].Value = "Tên giảm giá";
                            Sheet.Cells["S4"].Value = "Tiền điểm PID";
                            Sheet.Cells["T4"].Value = "Thẻ giảm giá";
                            Sheet.Cells["U4"].Value = "Tiền cán bộ đồng ý";
                            Sheet.Cells["V4"].Value = "Nội dung Điều chỉnh (CB Gửi)";
                            Sheet.Cells["W4"].Value = "Trạng thái duyệt (CB)";


                            int stt = 1;
                            int row = 5;
                            foreach (var item in Patients)
                            {
                                Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                                Sheet.Cells[string.Format("B{0}", row)].Value = item.UserTC;
                                Sheet.Cells[string.Format("C{0}", row)].Value = CMSLIS.Common.Common.ReFmtTime(item.NgayThu);
                                Sheet.Cells[string.Format("D{0}", row)].Value = item.GroupName;
                                Sheet.Cells[string.Format("E{0}", row)].Value = item.LocationName;
                                Sheet.Cells[string.Format("F{0}", row)].Value = item.S_ID;
                                Sheet.Cells[string.Format("G{0}", row)].Value = item.HoTen;
                                Sheet.Cells[string.Format("H{0}", row)].Value = item.TongCP;
                                Sheet.Cells[string.Format("I{0}", row)].Value = item.ThucThu;
                                Sheet.Cells[string.Format("J{0}", row)].Value = item.TamThu;
                                Sheet.Cells[string.Format("K{0}", row)].Value = item.PhiDiLai;
                                Sheet.Cells[string.Format("L{0}", row)].Value = item.TienMat;
                                Sheet.Cells[string.Format("M{0}", row)].Value = item.ThePOS;
                                Sheet.Cells[string.Format("N{0}", row)].Value = item.TraTruoc;
                                Sheet.Cells[string.Format("O{0}", row)].Value = item.ChKhoan;
                                Sheet.Cells[string.Format("P{0}", row)].Value = item.TraSau;
                                Sheet.Cells[string.Format("Q{0}", row)].Value = item.TienGG;
                                Sheet.Cells[string.Format("R{0}", row)].Value = item.TenGG;
                                Sheet.Cells[string.Format("S{0}", row)].Value = item.TienDiemPID;
                                Sheet.Cells[string.Format("T{0}", row)].Value = item.TheSuDung;
                                Sheet.Cells[string.Format("U{0}", row)].Value = item.ThucThu - item.SumAgree;
                                Sheet.Cells[string.Format("V{0}", row)].Value = item.Commentagree;
                                Sheet.Cells[string.Format("W{0}", row)].Value = item.Typeagree;

                                row++;
                                stt++;
                            }


                            Sheet.Cells["A:AZ"].AutoFitColumns();
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment: filename=" + "RevenuenotAgree.xlsx");
                            Response.BinaryWrite(Ep.GetAsByteArray());
                            Response.End();

                            break;





                    }
                }
                else
                {
                    ViewBag.TitleSuccsess = TextErr;
                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("ListOrder:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        #endregion


        #region --> Danh sách khách hàng theo userid
        public ActionResult RevenueAll()
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "/RevenueHome/RevenueAll");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueAllKeyword();
            var UserInfo = ((cms_Account)Session["UserInfo"]);
            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();
            obj.userid = "";
            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            obj.Locationid = string.Empty;
            obj.Groupid = "MBD";
            try
            {
                List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByAll(obj.Groupid, obj.Locationid, "", 0, string.Empty);
                obj.Patients = Patients;
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueAll:" + ex.ToString());
            }


            // Info.  
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RevenueAll(RevenueViewAgreeModel obj, string submit)
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "/RevenueHome/RevenueAll");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueAllKeyword();
            try
            {

                var UserInfo = ((cms_Account)Session["UserInfo"]);
                switch (submit)
                {
                    case "SearchRevenueAll":
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }

                        List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByAll(obj.Groupid, obj.Locationid, obj.userid.ToString().Trim(), obj.typeKeyword, obj.keyword);
                        obj.Patients = Patients;


                        break;
                    case "ExportRevenueAll":
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }
                        AddLogAction("", Constant.ActionExport.ToString());
                        Patients = imptbl_Patient.Gettbl_PatientByAll(obj.Groupid, obj.Locationid, obj.userid.ToString().Trim(), obj.typeKeyword, obj.keyword);
                        obj.Patients = Patients;


                        ExcelPackage Ep = new ExcelPackage();
                        ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("RevenueAll");


                        Sheet.Cells["A1"].Value = "BỆNH VIỆN ĐA KHOA MEDLATEC";
                        Sheet.Cells["A1:U1"].Merge = true;
                        Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        Sheet.Cells["A2"].Value = "ĐT: 1900 565656";
                        Sheet.Cells["A2:U2"].Merge = true;
                        Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        if (!string.IsNullOrEmpty(obj.userid))
                        {
                            Sheet.Cells["A3"].Value = "Duyệt doanh thu cán bộ " + obj.userid.Trim() + " tại nhà ngày :" + DateTime.Now.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            Sheet.Cells["A3"].Value = "Duyệt doanh thu cán bộ tại nhà ngày :" + DateTime.Now.ToString("dd/MM/yyyy");
                        }

                        Sheet.Cells["A3:U3"].Merge = true;
                        Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                        Sheet.Cells["A4"].Value = "STT";
                        Sheet.Cells["B4"].Value = "Người thu";
                        Sheet.Cells["C4"].Value = "Đơn vị";
                        Sheet.Cells["D4"].Value = "SID";
                        Sheet.Cells["E4"].Value = "Tên bệnh nhân";
                        Sheet.Cells["F4"].Value = "Tổng tiền";
                        Sheet.Cells["G4"].Value = "Thực thu";
                        Sheet.Cells["H4"].Value = "Tạm thu";
                        Sheet.Cells["I4"].Value = "Phí đi lại";
                        Sheet.Cells["J4"].Value = "Tiền mặt";
                        Sheet.Cells["K4"].Value = "Tiền POS";
                        Sheet.Cells["L4"].Value = "Trả trước";
                        Sheet.Cells["M4"].Value = "Chuyển khoản";
                        Sheet.Cells["N4"].Value = "Trả sau";
                        Sheet.Cells["O4"].Value = "Tiền giảm giá";
                        Sheet.Cells["P4"].Value = "Tên giảm giá";
                        Sheet.Cells["Q4"].Value = "Tiền điểm PID";
                        Sheet.Cells["R4"].Value = "Thẻ giảm giá";
                        Sheet.Cells["S4"].Value = "Tiền cán bộ đồng ý";
                        Sheet.Cells["T4"].Value = "Nội dung phê duyệt";
                        Sheet.Cells["U4"].Value = "Trạng thái duyệt";


                        int stt = 1;
                        int row = 5;
                        foreach (var item in Patients)
                        {
                            Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                            Sheet.Cells[string.Format("B{0}", row)].Value = item.UserTC;
                            Sheet.Cells[string.Format("C{0}", row)].Value = item.LocationName;
                            Sheet.Cells[string.Format("D{0}", row)].Value = item.S_ID;
                            Sheet.Cells[string.Format("E{0}", row)].Value = item.HoTen;
                            Sheet.Cells[string.Format("F{0}", row)].Value = item.TongCP;
                            Sheet.Cells[string.Format("G{0}", row)].Value = item.ThucThu;
                            Sheet.Cells[string.Format("H{0}", row)].Value = item.TamThu;
                            Sheet.Cells[string.Format("I{0}", row)].Value = item.PhiDiLai;
                            Sheet.Cells[string.Format("J{0}", row)].Value = item.TienMat;
                            Sheet.Cells[string.Format("K{0}", row)].Value = item.ThePOS;
                            Sheet.Cells[string.Format("L{0}", row)].Value = item.TraTruoc;
                            Sheet.Cells[string.Format("M{0}", row)].Value = item.ChKhoan;
                            Sheet.Cells[string.Format("N{0}", row)].Value = item.TraSau;
                            Sheet.Cells[string.Format("O{0}", row)].Value = item.TienGG;
                            Sheet.Cells[string.Format("P{0}", row)].Value = item.TenGG;
                            Sheet.Cells[string.Format("Q{0}", row)].Value = item.TienDiemPID;
                            Sheet.Cells[string.Format("R{0}", row)].Value = item.TheSuDung;
                            Sheet.Cells[string.Format("S{0}", row)].Value = item.SumAgree;
                            Sheet.Cells[string.Format("T{0}", row)].Value = item.Commentagree;
                            Sheet.Cells[string.Format("U{0}", row)].Value = item.Typeagree;

                            row++;
                            stt++;
                        }


                        Sheet.Cells["A:AZ"].AutoFitColumns();
                        Response.Clear();
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment: filename=" + "RevenueAll.xlsx");
                        Response.BinaryWrite(Ep.GetAsByteArray());
                        Response.End();
                        break;

                    case "SaveRevenueAll":
                        DataTable dt = new DataTable();
                        //Add columns  
                        dt.Columns.Add(new DataColumn("userid", typeof(string)));
                        dt.Columns.Add(new DataColumn("locationid", typeof(string)));
                        dt.Columns.Add(new DataColumn("sid", typeof(string)));
                        dt.Columns.Add(new DataColumn("testcode", typeof(string)));
                        dt.Columns.Add(new DataColumn("testname", typeof(string)));
                        dt.Columns.Add(new DataColumn("CommentAgree", typeof(string)));
                        dt.Columns.Add(new DataColumn("Typeagree", typeof(int)));
                        dt.Columns.Add(new DataColumn("useridAgree", typeof(string)));
                        dt.Columns.Add(new DataColumn("levelAgree", typeof(int)));
                        dt.Columns.Add(new DataColumn("price", typeof(float)));
                        dt.Columns.Add(new DataColumn("IDSouce", typeof(Int64)));


                        bool validate = true;
                        AddLogAction("", Constant.ActionInsertOK.ToString());
                        #region --> Check validate
                        foreach (var data in obj.Patients)
                        {
                            if (!data.agree)
                            {
                                if (string.IsNullOrEmpty(data.Commentagree))
                                {
                                    validate = false;
                                    break;
                                }
                            }
                        }
                        #endregion

                        if (validate)
                        {
                            foreach (var data in obj.Patients)
                            {
                                //Add rows  
                                if (data.agree)
                                {
                                    dt.Rows.Add(data.UserTC, "", data.S_ID, "", "", data.Commentagree, 1, UserInfo.uid, 3, data.ThucThu, data.MaBN);
                                }
                                else
                                {
                                    dt.Rows.Add(data.UserTC, "", data.S_ID, "", "", data.Commentagree, 0, UserInfo.uid, 3, data.SumAgree, data.MaBN);
                                }
                            }

                            try
                            {
                                SqlConnection con = new SqlConnection(CMS_Core.Common.Common.getConnectionStringRevenue());
                                con.Open();
                                SqlCommand cmd = new SqlCommand("usp_tbl_Revenue", con);
                                cmd.Parameters.AddWithValue("@RevenueTable", dt); // passing Datatable  
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            catch (Exception ex)
                            {

                            }


                            ViewBag.TitleSuccsess = "Cập nhật thành công!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;

                        }



                        break;
                }

            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("ListOrder:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        #endregion

        #region --> Danh sách khách hàng theo userid
        public ActionResult RevenueByUserID(string userid, string token, string ngaythu)
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "/RevenueHome/RevenueByUserID");
            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();


            var UserInfo = ((cms_Account)Session["UserInfo"]);

            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();

            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            obj.userid = userid;
            obj.ngaythu = ngaythu;

            try
            {
                if (CMSLIS.Common.Common.CheckKeyPrivate(userid, token))
                {
                    List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUseridAndDay(obj.userid, 0, string.Empty, ngaythu);
                    obj.Patients = Patients;
                }
                else
                {
                    ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueAll:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        public ActionResult RevenueByUserIDByDate(string userid, string datetime, string token)
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "/RevenueHome/RevenueByUserIDByDate");
            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();


            var UserInfo = ((cms_Account)Session["UserInfo"]);

            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();

            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            obj.userid = userid;


            try
            {
                if (CMSLIS.Common.Common.CheckKeyPrivate(userid, datetime, token))
                {
                    List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUseridDate(obj.userid, datetime);
                    obj.Patients = Patients;
                }
                else
                {
                    ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueAll:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RevenueByUserID(RevenueViewAgreeModel obj, string submit)
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "/RevenueHome/RevenueByUserID");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueKeyword();
            try
            {

                var UserInfo = ((cms_Account)Session["UserInfo"]);
                switch (submit)
                {
                    case "SearchRevenue":
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }
                        List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUseridAndDay(obj.userid, obj.typeKeyword, obj.keyword, obj.ngaythu);
                        obj.Patients = Patients;
                        break;
                    case "ExportRevenue":
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }
                        AddLogAction("", Constant.ActionExport.ToString());
                        Patients = imptbl_Patient.Gettbl_PatientByUseridAndDay(obj.userid, obj.typeKeyword, obj.keyword, obj.ngaythu);
                        obj.Patients = Patients;


                        ExcelPackage Ep = new ExcelPackage();
                        ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Revenue");


                        Sheet.Cells["A1"].Value = "BỆNH VIỆN ĐA KHOA MEDLATEC";
                        Sheet.Cells["A1:U1"].Merge = true;
                        Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        Sheet.Cells["A2"].Value = "ĐT: 1900 565656";
                        Sheet.Cells["A2:U2"].Merge = true;
                        Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        Sheet.Cells["A3"].Value = "Thông tin doanh thu cán bộ " + obj.userid + " tại nhà ngày :" + DateTime.Now.ToString("dd/MM/yyyy");
                        Sheet.Cells["A3:U3"].Merge = true;
                        Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                        Sheet.Cells["A4"].Value = "STT";
                        Sheet.Cells["B4"].Value = "Người thu";
                        Sheet.Cells["C4"].Value = "Ngày thu";
                        Sheet.Cells["D4"].Value = "Nhóm doanh thu";
                        Sheet.Cells["E4"].Value = "Đơn vị";
                        Sheet.Cells["F4"].Value = "SID";
                        Sheet.Cells["G4"].Value = "Tên bệnh nhân";
                        Sheet.Cells["H4"].Value = "Tổng tiền";
                        Sheet.Cells["I4"].Value = "Giảm giá";
                        Sheet.Cells["J4"].Value = "Phí đi lại";
                        Sheet.Cells["K4"].Value = "BHTT";
                        Sheet.Cells["L4"].Value = "BHBLTT";
                        Sheet.Cells["M4"].Value = "Thực thu";
                        Sheet.Cells["N4"].Value = "Thẻ Pos";
                        Sheet.Cells["O4"].Value = "Trả trước";
                        Sheet.Cells["P4"].Value = "Trả sau";
                        Sheet.Cells["Q4"].Value = "Tiền còn phải nộp";
                        Sheet.Cells["R4"].Value = "Tiền cán bộ đồng ý";
                        Sheet.Cells["S4"].Value = "Nội dung Điều chỉnh";
                        Sheet.Cells["T4"].Value = "Trạng thái cấp user";
                        Sheet.Cells["U4"].Value = "Trạng thái cấp kế toán";


                        int stt = 1;
                        int row = 5;
                        foreach (var item in Patients)
                        {
                            Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                            Sheet.Cells[string.Format("B{0}", row)].Value = item.UserTC;
                            Sheet.Cells[string.Format("C{0}", row)].Value = CMSLIS.Common.Common.ReFmtTime(item.NgayThu);
                            Sheet.Cells[string.Format("D{0}", row)].Value = item.GroupName;
                            Sheet.Cells[string.Format("E{0}", row)].Value = item.LocationName;
                            Sheet.Cells[string.Format("F{0}", row)].Value = item.S_ID;
                            Sheet.Cells[string.Format("G{0}", row)].Value = item.HoTen;
                            Sheet.Cells[string.Format("H{0}", row)].Value = item.TongCP;
                            Sheet.Cells[string.Format("I{0}", row)].Value = item.TienGG + item.TienDiemPID;
                            Sheet.Cells[string.Format("J{0}", row)].Value = item.PhiDiLai;
                            Sheet.Cells[string.Format("K{0}", row)].Value = item.BHTT;
                            Sheet.Cells[string.Format("L{0}", row)].Value = item.BHBLTT;
                            Sheet.Cells[string.Format("M{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHTT - item.TienDiemPID - item.TienGG;
                            Sheet.Cells[string.Format("N{0}", row)].Value = item.ThePOS;
                            Sheet.Cells[string.Format("O{0}", row)].Value = item.TraTruoc;
                            Sheet.Cells[string.Format("P{0}", row)].Value = item.TraSau;
                            Sheet.Cells[string.Format("Q{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHTT - item.TienDiemPID - item.TienGG - item.ThePOS - item.TraTruoc - item.TraSau;
                            Sheet.Cells[string.Format("R{0}", row)].Value = item.SumAgree;
                            Sheet.Cells[string.Format("S{0}", row)].Value = item.Commentagree;
                            Sheet.Cells[string.Format("T{0}", row)].Value = item.Typeagree;
                            Sheet.Cells[string.Format("U{0}", row)].Value = item.Typeagree1;


                            row++;
                            stt++;
                        }


                        Sheet.Cells["A:AZ"].AutoFitColumns();
                        Response.Clear();
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment: filename=" + "Revenue.xlsx");
                        Response.BinaryWrite(Ep.GetAsByteArray());
                        Response.End();

                        break;

                    case "SaveRevenue":
                        bool validate = true;
                        #region --> Check validate

                        foreach (var data in obj.Patients)
                        {
                            if (!data.agree)
                            {
                                if (string.IsNullOrEmpty(data.Commentagree))
                                {
                                    validate = false;
                                    break;
                                }
                            }
                        }

                        if (!validate)
                        {
                            ViewBag.TitleSuccsess = "Dòng không đồng ý phải nhập và comment. Xin mời bạn nhập lại!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                            AddLogAction("", Constant.ActionInsertNOK.ToString());
                        }
                        else
                        {
                            foreach (var data in obj.Patients)
                            {

                                tbl_Revenue revenue = new tbl_Revenue();
                                revenue.userid = data.UserTC;
                                revenue.sid = data.S_ID;
                                revenue.locationid = data.LocationName;

                                revenue.testcode = string.Empty;
                                revenue.testname = string.Empty;
                                revenue.useridAgree = UserInfo.uid.ToString();
                                revenue.levelAgree = 3;
                                revenue.IDSouce = data.MaBN;
                                revenue.NgayThu = data.NgayThu;
                                revenue.IDCLS = data.IDCLS;
                                if (string.IsNullOrEmpty(data.Commentagree))
                                {
                                    revenue.CommentAgree = string.Empty;
                                }
                                else
                                {
                                    revenue.CommentAgree = data.Commentagree;
                                }

                                if (data.agree)
                                {
                                    revenue.Typeagree = 1;
                                    revenue.price = data.TongCP - data.BHBLTT - data.BHBLTT - data.TienGG - data.TienDiemPID - data.ThePOS - data.TraSau - data.TraTruoc;
                                }
                                else
                                {
                                    //Bắn tin tele cho cán bộ từ chối
                                    int AppID = 6;
                                    long MyEmployeeID = 6382;
                                    MsgBotFactory factory = new MsgBotFactory();

                                    var _Accounts = impCms_Account.Getcms_AccountByUserName(data.UserTC);
                                    if (_Accounts != null)
                                    {
                                        if (_Accounts.Count > 0)
                                        {
                                            if (!string.IsNullOrEmpty(_Accounts[0].Manv))
                                            {
                                                string content = "Xin chào: " + _Accounts[0].Hoten + Environment.NewLine + Environment.NewLine;
                                                content += "Thời gian hiện tại là " + DateTime.Now.ToString("HH:mm") + " ngày " + DateTime.Now.ToString("dd/MM/yyyy");
                                                content += " Phòng TKCKT Ba Đình thông báo xác nhận không đồng ý doanh thu mã " + data.S_ID + " KH " + data.HoTen + ". Cán bộ vui lòng kiểm tra lại mã khách hàng trên,  kết hợp cùng PKT đưa về mã doanh thu đúng trước 17h " + DateTime.Now.ToString("dd/MM/yyyy");
                                                content += Environment.NewLine + Environment.NewLine + "Mọi thắc mắc vui lòng liên hệ CB Đỗ Hà/ CB Hạnh Nhung - Kế toán doanh thu (EXT: 29035 / 29038)";
                                                content += Environment.NewLine + "Trân trọng!";
                                                factory.custom_MsgBotInsert(content, null, _Accounts[0].Manv, AppID, null, MyEmployeeID);
                                                // factory.custom_MsgBotInsert(content, null, "6382", AppID, null, MyEmployeeID);
                                                //  factory.custom_MsgBotInsert(content, null, "6477", AppID, null, MyEmployeeID);
                                                // factory.custom_MsgBotInsert(content, null, "5564", AppID, null, MyEmployeeID);

                                            }
                                            else
                                            {
                                                factory.custom_MsgBotInsert("Xin thông báo. Có lỗi khi bắn từ chối doanh thu cho bạn :" + data.UserTC, null, "6382", AppID, null, MyEmployeeID);
                                            }

                                        }
                                        else
                                        {
                                            factory.custom_MsgBotInsert("Xin thông báo. Có lỗi khi bắn từ chối doanh thu cho bạn :" + data.UserTC, null, "6382", AppID, null, MyEmployeeID);
                                        }
                                    }
                                    else
                                    {
                                        factory.custom_MsgBotInsert("Xin thông báo. Có lỗi khi bắn từ chối doanh thu cho bạn :" + data.UserTC, null, "6382", AppID, null, MyEmployeeID);
                                    }


                                    imptblReportRevenue.tblReportRevenueDelete(data.MaBN, data.S_ID, UserInfo.uid.ToString());
                                    revenue.Typeagree = 0;
                                    revenue.price = 0;
                                }

                                var errorsSave = revenue.Validate(new ValidationContext(revenue));
                                if (errorsSave.ToList().Count == 0)
                                {
                                    imptbl_Revenue.Add(revenue);
                                    errorsSave = revenue.Validate(new ValidationContext(data));
                                    if (errorsSave.ToList().Count == 0)
                                    {
                                        if (data.agree)
                                        {
                                            data.Typeagree = "1";
                                            data.IDSouce = 0;
                                            data.useridAgree = UserInfo.uid.ToString();
                                            data.IDCLS = data.IDCLS;
                                            data.SumAgree = data.TongCP - data.BHBLTT - data.BHTT - data.TienDiemPID - data.TienGG - data.ThePOS - data.TraTruoc - data.TraSau;
                                            imptblReportRevenue.Add(data);
                                        }
                                        else
                                        {
                                            data.Typeagree = "0";
                                            data.IDSouce = 0;
                                            data.useridAgree = UserInfo.uid.ToString();
                                            data.SumAgree = 0;
                                            imptblReportRevenue.Add(data);
                                        }



                                    }

                                }
                                else
                                {
                                    ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                }
                            }

                            ViewBag.TitleSuccsess = "Cập nhật thành công!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                            AddLogAction("", Constant.ActionInsertOK.ToString());
                            //Results = imptbl_Result.Gettbl_ResultBySID(obj.sid, obj.typeKeyword, obj.keyword);
                            //obj.Results = Results;
                        }

                        if (string.IsNullOrEmpty(obj.keyword))
                            obj.keyword = string.Empty;
                        Patients = imptbl_Patient.Gettbl_PatientByUseridAndDay(obj.userid, obj.typeKeyword, obj.keyword, obj.ngaythu);
                        obj.Patients = Patients;

                        #endregion
                        break;


                }

            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("ListOrder:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        #endregion



        #region --> Danh sách khách hàng theo userid
        public ActionResult RevenueTotalAll()
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "/RevenueHome/RevenueTotalAll");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueVoidKeyword();

            var UserInfo = ((cms_Account)Session["UserInfo"]);
            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();
            obj.userid = "";
            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            obj.Locationid = string.Empty;
            obj.Groupid = "MBD";
            try
            {
                List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientTotalByAll(obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                obj.Patients = Patients;
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueTotalAll:" + ex.ToString());
            }


            // Info.  
            return View(obj);
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult getListLocationByGroupID(string groupid)
        {
            try
            {
                IEnumerable<tbl_Location> modelList = new List<tbl_Location>();

                modelList = imptbl_Location.Gettbl_LocationByGroupID(groupid);
                return Json(modelList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logError.Info("getListAccount:" + groupid + "  " + ex.ToString());
                return Json(string.Empty);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RevenueTotalAll(RevenueViewAgreeModel obj, string submit)
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "/RevenueHome/RevenueAll");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueVoidKeyword();
            try
            {

                var UserInfo = ((cms_Account)Session["UserInfo"]);
                switch (submit)
                {
                    case "SearchRevenueTotalAll":
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }

                        List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientTotalByAll(obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                        obj.Patients = Patients;
                        break;
                    case "ExportRevenueTotalAll":
                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }
                        AddLogAction("", Constant.ActionExport.ToString());
                        Patients = imptbl_Patient.Gettbl_PatientTotalByAll(obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                        obj.Patients = Patients;


                        ExcelPackage Ep = new ExcelPackage();
                        ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("RevenueTotalAll");


                        Sheet.Cells["A1"].Value = "THỐNG KÊ CÔNG NỢ THEO USER CÁC CÁN BỘ TẠI NHÀ";
                        Sheet.Cells["A1:T1"].Merge = true;
                        Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        Sheet.Cells["A2"].Value = "Từ ngày 00:00 ngày " + DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") + " đến 23:59 ngày " + DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                        Sheet.Cells["A2:T2"].Merge = true;
                        Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        Sheet.Cells["A3"].Value = " ";
                        Sheet.Cells["A3:T3"].Merge = true;
                        Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        Sheet.Cells["A4"].Value = "STT";
                        Sheet.Cells["B4"].Value = "Người thu";
                        Sheet.Cells["C4"].Value = "Ngày thu";
                        Sheet.Cells["D4"].Value = "Họ và tên";
                        Sheet.Cells["E4"].Value = "Mã nhân viên";
                        Sheet.Cells["F4"].Value = "Nhóm doanh thu";
                        Sheet.Cells["G4"].Value = "Đơn vị";
                        Sheet.Cells["H4"].Value = "Tổng tiền";
                        Sheet.Cells["I4"].Value = "Giảm giá";
                        Sheet.Cells["J4"].Value = "Phí đi lại";
                        Sheet.Cells["K4"].Value = "BHTT";
                        Sheet.Cells["L4"].Value = "BHBLTT";
                        Sheet.Cells["M4"].Value = "Thực thu";
                        Sheet.Cells["N4"].Value = "Tiền POS";
                        Sheet.Cells["O4"].Value = "Trả trước";
                        Sheet.Cells["P4"].Value = "Trả sau";
                        Sheet.Cells["Q4"].Value = "Tiền còn phải nộp";
                        Sheet.Cells["R4"].Value = "Trạng thái cán bộ";
                        Sheet.Cells["S4"].Value = "Nội dung phê duyệt";
                        Sheet.Cells["T4"].Value = "Trạng thái duyệt";


                        int row = 5;
                        int stt = 1;
                        foreach (var item in Patients)
                        {
                            Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                            Sheet.Cells[string.Format("B{0}", row)].Value = item.UserTC;
                            Sheet.Cells[string.Format("C{0}", row)].Value = item.NgayThutext;
                            Sheet.Cells[string.Format("D{0}", row)].Value = item.UserName;
                            Sheet.Cells[string.Format("E{0}", row)].Value = item.MaNV;
                            Sheet.Cells[string.Format("F{0}", row)].Value = item.GroupName;
                            Sheet.Cells[string.Format("G{0}", row)].Value = item.LocationName;
                            Sheet.Cells[string.Format("H{0}", row)].Value = item.TongCP;
                            Sheet.Cells[string.Format("I{0}", row)].Value = item.TienDiemPID + item.TienGG;
                            Sheet.Cells[string.Format("J{0}", row)].Value = item.PhiDiLai;
                            Sheet.Cells[string.Format("K{0}", row)].Value = item.BHTT;
                            Sheet.Cells[string.Format("L{0}", row)].Value = item.BHBLTT;
                            Sheet.Cells[string.Format("M{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHBLTT - item.TienGG - item.TienDiemPID;
                            Sheet.Cells[string.Format("N{0}", row)].Value = item.ThePOS;
                            Sheet.Cells[string.Format("O{0}", row)].Value = item.TraTruoc;
                            Sheet.Cells[string.Format("P{0}", row)].Value = item.TraSau;
                            Sheet.Cells[string.Format("Q{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHBLTT - item.TienGG - item.TienDiemPID - item.ThePOS - item.TraTruoc - item.TraSau;
                            Sheet.Cells[string.Format("R{0}", row)].Value = item.Typeagree21;
                            Sheet.Cells[string.Format("S{0}", row)].Value = item.Commentagree;
                            Sheet.Cells[string.Format("T{0}", row)].Value = item.Typeagree;
                            row++;
                            stt++;
                        }


                        Sheet.Cells["A:AZ"].AutoFitColumns();
                        Response.Clear();
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment: filename=" + "RevenueTotalAll.xlsx");
                        Response.BinaryWrite(Ep.GetAsByteArray());
                        Response.End();

                        break;

                    case "SaveRevenueTotalAll":
                        bool validate = true;
                        #region --> Check validate
                        AddLogAction("", Constant.ActionInsertOK.ToString());
                        foreach (var data in obj.Patients)
                        {
                            if (!data.agree)
                            {
                                if (string.IsNullOrEmpty(data.Commentagree))
                                {
                                    validate = false;
                                    break;
                                }
                            }
                        }

                        if (!validate)
                        {
                            ViewBag.TitleSuccsess = "Dòng không đồng ý phải nhập và comment. Xin mời bạn nhập lại!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                        }
                        else
                        {
                            foreach (var data in obj.Patients)
                            {
                                tbl_Revenue revenue = new tbl_Revenue();
                                revenue.userid = data.UserTC;
                                revenue.sid = "";
                                revenue.locationid = data.LocationName;

                                revenue.testcode = string.Empty;
                                revenue.testname = string.Empty;
                                revenue.useridAgree = UserInfo.uid.ToString();
                                revenue.levelAgree = 4;
                                revenue.IDSouce = 0;
                                if (string.IsNullOrEmpty(data.Commentagree))
                                {
                                    revenue.CommentAgree = string.Empty;
                                }
                                else
                                {
                                    revenue.CommentAgree = data.Commentagree;
                                }

                                if (data.agree)
                                {
                                    revenue.Typeagree = 1;
                                    revenue.price = data.TongCP - data.BHBLTT - data.BHBLTT - data.TienGG - data.TienDiemPID - data.ThePOS - data.TraSau - data.TraTruoc;
                                }
                                else
                                {
                                    revenue.Typeagree = 0;
                                    revenue.price = 0;
                                }

                                var errorsSave = revenue.Validate(new ValidationContext(revenue));
                                if (errorsSave.ToList().Count == 0)
                                {
                                    imptbl_Revenue.Add(revenue);
                                }
                                else
                                {
                                    ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                }
                            }

                            ViewBag.TitleSuccsess = "Cập nhật thành công!";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;

                            //Results = imptbl_Result.Gettbl_ResultBySID(obj.sid, obj.typeKeyword, obj.keyword);
                            //obj.Results = Results;
                        }


                        #endregion

                        break;
                    case "ExportRevenueAll":

                        if (string.IsNullOrEmpty(obj.keyword))
                        {
                            obj.keyword = string.Empty;
                        }
                        AddLogAction("", Constant.ActionExport.ToString());
                        Patients = imptbl_Patient.Gettbl_PatientByAll(obj.Groupid, obj.Locationid, obj.userid.ToString().Trim(), obj.typeKeyword, obj.keyword);

                        obj.Patients = Patients;


                        Ep = new ExcelPackage();
                        Sheet = Ep.Workbook.Worksheets.Add("RevenueAll");


                        Sheet.Cells["A1"].Value = "BỆNH VIỆN ĐA KHOA MEDLATEC";
                        Sheet.Cells["A1:U1"].Merge = true;
                        Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        Sheet.Cells["A2"].Value = "ĐT: 1900 565656";
                        Sheet.Cells["A2:U2"].Merge = true;
                        Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        if (!string.IsNullOrEmpty(obj.userid))
                        {
                            Sheet.Cells["A3"].Value = "Duyệt doanh thu cán bộ " + obj.userid.Trim() + " tại nhà ngày :" + DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            Sheet.Cells["A3"].Value = "Duyệt doanh thu cán bộ tại nhà ngày :" + DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                        }

                        Sheet.Cells["A3:U3"].Merge = true;
                        Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                        Sheet.Cells["A4"].Value = "STT";
                        Sheet.Cells["B4"].Value = "Người thu";
                        Sheet.Cells["C4"].Value = "Ngày thu";
                        Sheet.Cells["D4"].Value = "Nhóm doanh thu";
                        Sheet.Cells["E4"].Value = "Đơn vị";
                        Sheet.Cells["F4"].Value = "SID";
                        Sheet.Cells["G4"].Value = "Tên bệnh nhân";
                        Sheet.Cells["H4"].Value = "Tổng tiền";
                        Sheet.Cells["I4"].Value = "Giảm giá";
                        Sheet.Cells["J4"].Value = "Phí đi lại";
                        Sheet.Cells["K4"].Value = "BHTT";
                        Sheet.Cells["L4"].Value = "BHBLTT";
                        Sheet.Cells["M4"].Value = "Thực thu";
                        Sheet.Cells["N4"].Value = "Thẻ Pos";
                        Sheet.Cells["O4"].Value = "Trả trước";
                        Sheet.Cells["P4"].Value = "Trả sau";
                        Sheet.Cells["Q4"].Value = "Tiền còn phải nộp";
                        Sheet.Cells["R4"].Value = "Tiền cán bộ đồng ý";
                        Sheet.Cells["S4"].Value = "Nội dung Điều chỉnh";
                        Sheet.Cells["T4"].Value = "Trạng thái cấp user";
                        Sheet.Cells["U4"].Value = "Trạng thái cấp kế toán";


                        stt = 1;
                        row = 5;
                        foreach (var item in Patients)
                        {
                            Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                            Sheet.Cells[string.Format("B{0}", row)].Value = item.UserTC;
                            Sheet.Cells[string.Format("C{0}", row)].Value = CMSLIS.Common.Common.ReFmtTime(item.NgayThu);
                            Sheet.Cells[string.Format("D{0}", row)].Value = item.GroupName;
                            Sheet.Cells[string.Format("E{0}", row)].Value = item.LocationName;
                            Sheet.Cells[string.Format("F{0}", row)].Value = item.S_ID;
                            Sheet.Cells[string.Format("G{0}", row)].Value = item.HoTen;
                            Sheet.Cells[string.Format("H{0}", row)].Value = item.TongCP;
                            Sheet.Cells[string.Format("I{0}", row)].Value = item.TienGG + item.TienDiemPID;
                            Sheet.Cells[string.Format("J{0}", row)].Value = item.PhiDiLai;
                            Sheet.Cells[string.Format("K{0}", row)].Value = item.BHTT;
                            Sheet.Cells[string.Format("L{0}", row)].Value = item.BHBLTT;
                            Sheet.Cells[string.Format("M{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHTT - item.TienDiemPID - item.TienGG;
                            Sheet.Cells[string.Format("N{0}", row)].Value = item.ThePOS;
                            Sheet.Cells[string.Format("O{0}", row)].Value = item.TraTruoc;
                            Sheet.Cells[string.Format("P{0}", row)].Value = item.TraSau;
                            Sheet.Cells[string.Format("Q{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHTT - item.TienDiemPID - item.TienGG - item.ThePOS - item.TraTruoc - item.TraSau;
                            Sheet.Cells[string.Format("R{0}", row)].Value = item.SumAgree;
                            Sheet.Cells[string.Format("S{0}", row)].Value = item.Commentagree;
                            Sheet.Cells[string.Format("T{0}", row)].Value = item.Typeagree;
                            Sheet.Cells[string.Format("U{0}", row)].Value = item.Typeagree1;

                            row++;
                            stt++;
                        }


                        Sheet.Cells["A:AZ"].AutoFitColumns();
                        Response.Clear();
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment: filename=" + "RevenueAll.xlsx");
                        Response.BinaryWrite(Ep.GetAsByteArray());
                        Response.End();
                        break;


                }

            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("ListOrder:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }
        #endregion

        #region --> Danh sách khách hàng theo userid
        public ActionResult RevenueTotalAgree()
        {
            // Initialization.  
            AddPageHeader("Danh sách cán bộ ký", "");
            AddBreadcrumb("Danh sách cán bộ ký", "");
            AddBreadcrumb("Danh sách cán bộ ký", "/RevenueHome/RevenueTotalAgree");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueVoidKeyword();

            var UserInfo = ((cms_Account)Session["UserInfo"]);
            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();
            obj.userid = "";
            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            obj.Locationid = string.Empty;
            obj.Groupid = "MBD";
            obj.tungay = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
            obj.denngay = DateTime.Now.ToString("dd/MM/yyyy");

            try
            {
                List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientTotalByAgree(DateTime.Now.AddDays(-1).ToString("yyyyMMdd"), DateTime.Now.AddDays(1).ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                obj.Patients = Patients;
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueTotalAll:" + ex.ToString());
            }


            // Info.  
            return View(obj);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RevenueTotalAgree(RevenueViewAgreeModel obj, string submit)
        {


            // Initialization.  
            AddPageHeader("Danh sách cán bộ ký", "");
            AddBreadcrumb("Danh sách cán bộ ký", "");
            AddBreadcrumb("Danh sách cán bộ ký", "/RevenueHome/RevenueTotalAgree");

            string TextErr = string.Empty;

            DateTime Tungay = new DateTime();
            DateTime Denngay = new DateTime();

            #region Check input data
            try
            {
                if (!string.IsNullOrEmpty(obj.tungay.Trim()))
                    Tungay = DateTime.ParseExact(obj.tungay.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                if (!string.IsNullOrEmpty(obj.denngay.Trim()))
                    Denngay = DateTime.ParseExact(obj.denngay.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));

                if (Tungay > Denngay)
                {
                    TextErr = "Từ ngày phải nhỏ hơn hoặc bằng đến ngày";
                }

                if (Tungay.Date.AddMonths(20) < Denngay.Date)
                {
                    TextErr = "Chỉ được phép tra cứu tối đa trong vòng 20 ngày";
                }
            }
            catch
            {
                TextErr = "Dữ liệu ngày tháng không đúng định dạng";
            }
            #endregion


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueVoidKeyword();
            try
            {

                if (string.IsNullOrEmpty(TextErr))
                {
                    var UserInfo = ((cms_Account)Session["UserInfo"]);
                    switch (submit)
                    {
                        case "SearchRevenueTotalAgree":
                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }

                            List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientTotalByAgree(Tungay.ToString("yyyyMMdd"), Denngay.ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;
                            break;
                        case "ExportRevenueTotalAgree":
                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }
                            AddLogAction("", Constant.ActionExport.ToString());
                            Patients = imptbl_Patient.Gettbl_PatientTotalByAgree(Tungay.ToString("yyyyMMdd"), Denngay.ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;




                            ExcelPackage Ep = new ExcelPackage();
                            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("RevenueTotalAll");


                            Sheet.Cells["A1"].Value = "THỐNG KÊ CÔNG NỢ THEO USER CÁC CÁN BỘ TẠI NHÀ";
                            Sheet.Cells["A1:S1"].Merge = true;
                            Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            Sheet.Cells["A2"].Value = "Từ ngày 00:00 ngày " + DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") + " đến 23:59 ngày " + DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                            Sheet.Cells["A2:S2"].Merge = true;
                            Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            Sheet.Cells["A3"].Value = " ";
                            Sheet.Cells["A3:S3"].Merge = true;
                            Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            Sheet.Cells["A4"].Value = "STT";
                            Sheet.Cells["B4"].Value = "Người thu";
                            Sheet.Cells["C4"].Value = "Ngày thu";
                            Sheet.Cells["D4"].Value = "Họ và tên";
                            Sheet.Cells["E4"].Value = "Mã nhân viên";
                            Sheet.Cells["F4"].Value = "Nhóm doanh thu";
                            Sheet.Cells["G4"].Value = "Đơn vị";
                            Sheet.Cells["H4"].Value = "Tổng tiền";
                            Sheet.Cells["I4"].Value = "Giảm giá";
                            Sheet.Cells["J4"].Value = "Phí đi lại";
                            Sheet.Cells["K4"].Value = "BHTT";
                            Sheet.Cells["L4"].Value = "BHBLTT";
                            Sheet.Cells["M4"].Value = "Thực thu";
                            Sheet.Cells["N4"].Value = "Tiền POS";
                            Sheet.Cells["O4"].Value = "Trả trước";
                            Sheet.Cells["P4"].Value = "Trả sau";
                            Sheet.Cells["Q4"].Value = "Tiền còn phải nộp";
                            Sheet.Cells["R4"].Value = "Nội dung phê duyệt";
                            Sheet.Cells["S4"].Value = "Trạng thái duyệt";


                            int row = 5;
                            int stt = 1;
                            foreach (var item in Patients)
                            {
                                Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                                Sheet.Cells[string.Format("B{0}", row)].Value = item.UserTC;
                                Sheet.Cells[string.Format("C{0}", row)].Value = item.NgayThutext;
                                Sheet.Cells[string.Format("D{0}", row)].Value = item.UserName;
                                Sheet.Cells[string.Format("E{0}", row)].Value = item.MaNV;
                                Sheet.Cells[string.Format("F{0}", row)].Value = item.GroupName;
                                Sheet.Cells[string.Format("G{0}", row)].Value = item.LocationName;
                                Sheet.Cells[string.Format("H{0}", row)].Value = item.TongCP;
                                Sheet.Cells[string.Format("I{0}", row)].Value = item.TienDiemPID + item.TienGG;
                                Sheet.Cells[string.Format("J{0}", row)].Value = item.PhiDiLai;
                                Sheet.Cells[string.Format("K{0}", row)].Value = item.BHTT;
                                Sheet.Cells[string.Format("L{0}", row)].Value = item.BHBLTT;
                                Sheet.Cells[string.Format("M{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHBLTT - item.TienGG - item.TienDiemPID;
                                Sheet.Cells[string.Format("N{0}", row)].Value = item.ThePOS;
                                Sheet.Cells[string.Format("O{0}", row)].Value = item.TraTruoc;
                                Sheet.Cells[string.Format("P{0}", row)].Value = item.TraSau;
                                Sheet.Cells[string.Format("Q{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHBLTT - item.TienGG - item.TienDiemPID - item.ThePOS - item.TraTruoc - item.TraSau;
                                Sheet.Cells[string.Format("R{0}", row)].Value = item.Commentagree;
                                Sheet.Cells[string.Format("S{0}", row)].Value = item.Typeagree;
                                row++;
                                stt++;
                            }


                            Sheet.Cells["A:AZ"].AutoFitColumns();
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment: filename=" + "RevenueTotalAll.xlsx");
                            Response.BinaryWrite(Ep.GetAsByteArray());
                            Response.End();

                            break;

                        case "ExportRevenueTotalAllAgree":

                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }
                            AddLogAction("", Constant.ActionExport.ToString());

                            Patients = imptbl_Patient.Gettbl_PatientByAgreeAll(Tungay.ToString("yyyyMMdd"), Denngay.ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;



                            Ep = new ExcelPackage();
                            Sheet = Ep.Workbook.Worksheets.Add("RevenueTotalAllAgree");


                            Sheet.Cells["A1"].Value = "BỆNH VIỆN ĐA KHOA MEDLATEC";
                            Sheet.Cells["A1:U1"].Merge = true;
                            Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            Sheet.Cells["A2"].Value = "ĐT: 1900 565656";
                            Sheet.Cells["A2:U2"].Merge = true;
                            Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                            Sheet.Cells["A3"].Value = "Danh sách mã bệnh nhân đã được cán bộ ký xác nhận xuất báo cáo từ :" + Tungay.ToString("dd/MM/yyyy") + " đến ngày:" + Denngay.ToString("dd/MM/yyyy");


                            Sheet.Cells["A3:U3"].Merge = true;
                            Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                            Sheet.Cells["A4"].Value = "STT";
                            Sheet.Cells["B4"].Value = "Người thu";
                            Sheet.Cells["C4"].Value = "Đơn vị";
                            Sheet.Cells["D4"].Value = "SID";
                            Sheet.Cells["E4"].Value = "Tên bệnh nhân";
                            Sheet.Cells["F4"].Value = "Tổng tiền";
                            Sheet.Cells["G4"].Value = "Thực thu";
                            Sheet.Cells["H4"].Value = "Tạm thu";
                            Sheet.Cells["I4"].Value = "Phí đi lại";
                            Sheet.Cells["J4"].Value = "Tiền mặt";
                            Sheet.Cells["K4"].Value = "Tiền POS";
                            Sheet.Cells["L4"].Value = "Trả trước";
                            Sheet.Cells["M4"].Value = "Chuyển khoản";
                            Sheet.Cells["N4"].Value = "Trả sau";
                            Sheet.Cells["O4"].Value = "Tiền giảm giá";
                            Sheet.Cells["P4"].Value = "Tên giảm giá";
                            Sheet.Cells["Q4"].Value = "Tiền điểm PID";
                            Sheet.Cells["R4"].Value = "Thẻ giảm giá";
                            Sheet.Cells["S4"].Value = "Tiền cán bộ đồng ý";
                            Sheet.Cells["T4"].Value = "Nội dung phê duyệt";
                            Sheet.Cells["U4"].Value = "Trạng thái duyệt";


                            stt = 1;
                            row = 5;
                            foreach (var item in Patients)
                            {
                                Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                                Sheet.Cells[string.Format("B{0}", row)].Value = item.UserTC;
                                Sheet.Cells[string.Format("C{0}", row)].Value = item.LocationName;
                                Sheet.Cells[string.Format("D{0}", row)].Value = item.S_ID;
                                Sheet.Cells[string.Format("E{0}", row)].Value = item.HoTen;
                                Sheet.Cells[string.Format("F{0}", row)].Value = item.TongCP;
                                Sheet.Cells[string.Format("G{0}", row)].Value = item.ThucThu;
                                Sheet.Cells[string.Format("H{0}", row)].Value = item.TamThu;
                                Sheet.Cells[string.Format("I{0}", row)].Value = item.PhiDiLai;
                                Sheet.Cells[string.Format("J{0}", row)].Value = item.TienMat;
                                Sheet.Cells[string.Format("K{0}", row)].Value = item.ThePOS;
                                Sheet.Cells[string.Format("L{0}", row)].Value = item.TraTruoc;
                                Sheet.Cells[string.Format("M{0}", row)].Value = item.ChKhoan;
                                Sheet.Cells[string.Format("N{0}", row)].Value = item.TraSau;
                                Sheet.Cells[string.Format("O{0}", row)].Value = item.TienGG;
                                Sheet.Cells[string.Format("P{0}", row)].Value = item.TenGG;
                                Sheet.Cells[string.Format("Q{0}", row)].Value = item.TienDiemPID;
                                Sheet.Cells[string.Format("R{0}", row)].Value = item.TheSuDung;
                                Sheet.Cells[string.Format("S{0}", row)].Value = item.ThucThu - item.SumAgree;
                                Sheet.Cells[string.Format("T{0}", row)].Value = item.Commentagree;
                                Sheet.Cells[string.Format("U{0}", row)].Value = item.Typeagree;

                                row++;
                                stt++;
                            }


                            Sheet.Cells["A:AZ"].AutoFitColumns();
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment: filename=" + "RevenueTotalAllAgree.xlsx");
                            Response.BinaryWrite(Ep.GetAsByteArray());
                            Response.End();
                            break;


                    }
                }
                else
                {
                    ViewBag.TitleSuccsess = TextErr;
                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("ListOrder:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }
        #endregion

        #region --> Danh sách khách hàng theo userid
        public ActionResult RevenueTotalByDate()
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "/RevenueHome/RevenueTotalByDate");


            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueVoidKeyword();

            var UserInfo = ((cms_Account)Session["UserInfo"]);
            RevenueViewAgreeModel obj = new RevenueViewAgreeModel();
            obj.userid = "";
            obj.typeKeyword = 0;
            obj.keyword = string.Empty;
            obj.Locationid = string.Empty;
            obj.Groupid = "MBD";
            obj.tungay = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
            obj.denngay = DateTime.Now.ToString("dd/MM/yyyy");

            try
            {
                List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientTotalByAllDay(DateTime.Now.AddDays(-1).ToString("yyyyMMdd"), DateTime.Now.Date.ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                obj.Patients = Patients;
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueTotalAll:" + ex.ToString());
            }


            // Info.  
            return View(obj);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RevenueTotalByDate(RevenueViewAgreeModel obj, string submit)
        {


            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "/RevenueHome/RevenueTotalByDate");

            DateTime Tungay = new DateTime();
            DateTime Denngay = new DateTime();
            string TextErr = string.Empty;
            this.ViewBag.GetTypeKeyword = CMSLIS.Common.Common.GetTypeRevenueVoidKeyword();
            #region Check input data
            try
            {
                if (!string.IsNullOrEmpty(obj.tungay.Trim()))
                    Tungay = DateTime.ParseExact(obj.tungay.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                if (!string.IsNullOrEmpty(obj.denngay.Trim()))
                    Denngay = DateTime.ParseExact(obj.denngay.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));

                if (Tungay > Denngay)
                {
                    TextErr = "Từ ngày phải nhỏ hơn hoặc bằng đến ngày";
                }

                if (Tungay.Date.AddDays(10) < Denngay.Date)
                {
                    TextErr = "Chỉ được phép tra cứu tối đa trong vòng 10 ngày";
                }
            }
            catch
            {
                TextErr = "Dữ liệu ngày tháng không đúng định dạng";
            }
            #endregion
            if (TextErr.Length >= 0)
            {
                try
                {

                    var UserInfo = ((cms_Account)Session["UserInfo"]);
                    switch (submit)
                    {
                        case "SearchRevenueTotalByDate":
                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }
                            List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientTotalByAllDay(Tungay.ToString("yyyyMMdd"), Denngay.ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);

                            obj.Patients = Patients;
                            break;
                        case "ExportRevenueTotalByDate":
                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }
                            AddLogAction("", Constant.ActionExport.ToString());
                            Patients = imptbl_Patient.Gettbl_PatientTotalByAllDay(Tungay.ToString("yyyyMMdd"), Denngay.ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid, obj.typeKeyword, obj.keyword);
                            obj.Patients = Patients;


                            ExcelPackage Ep = new ExcelPackage();
                            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("ExportRevenueTotalByDate");


                            Sheet.Cells["A1"].Value = "CÔNG TY TNHH CÔNG NGHỆ VÀ XÉT NGHIỆM Y HỌC";
                            Sheet.Cells["A1:E1"].Merge = true;
                            Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                            Sheet.Cells["A2"].Value = "Địa chỉ: 42-44 Phố Nghĩa Dũng, Phường Phúc Xá, Quận Ba Đình, TP Hà Nội";
                            Sheet.Cells["A2:E2"].Merge = true;
                            Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                            Sheet.Cells["A3"].Value = "SĐT:……. ";
                            Sheet.Cells["A3:E3"].Merge = true;
                            Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                            Sheet.Cells["A4"].Value = "DANH SÁCH CÁC CBNV LÀM ỦY NHIỆM THU";
                            Sheet.Cells["A4:E4"].Merge = true;
                            Sheet.Cells["A4"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            Sheet.Cells["A5"].Value = "Tháng " + DateTime.Now.ToString("MM/yyyyy");
                            Sheet.Cells["A5:E5"].Merge = true;
                            Sheet.Cells["A5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            string[] words = Patients[0].NgayThutext.Split('/');

                            Sheet.Cells["A6"].Value = "Danh sách này được gửi  kèm theo ủy nhiệm thu từ ngày " + Tungay.ToString("dd/MM/yyyy") + " đến ngày " + Denngay.ToString("dd/MM/yyyy"); ;

                            Sheet.Cells["A6:E6"].Merge = true;
                            Sheet.Cells["A6"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                            Sheet.Cells["A7"].Value = "STT";
                            Sheet.Cells["B7"].Value = "Họ và Tên";
                            Sheet.Cells["C7"].Value = "Số TK tại SHB";
                            Sheet.Cells["D7"].Value = "Nơi mở tk";
                            Sheet.Cells["E7"].Value = "Tiền cán bộ phải nộpp";



                            int row = 8;
                            int stt = 1;
                            foreach (var item in Patients)
                            {
                                Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                                Sheet.Cells[string.Format("B{0}", row)].Value = item.UserName;
                                Sheet.Cells[string.Format("C{0}", row)].Value = item.BankCardSHB;
                                Sheet.Cells[string.Format("D{0}", row)].Value = item.BankCardSHBAddress;
                                Sheet.Cells[string.Format("E{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHBLTT - item.TienGG - item.TienDiemPID - item.ThePOS - item.TraTruoc - item.TraSau;

                                row++;
                                stt++;
                            }


                            Sheet.Cells["A:AZ"].AutoFitColumns();
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment: filename=" + "ExportRevenueTotalByDate.xlsx");
                            Response.BinaryWrite(Ep.GetAsByteArray());
                            Response.End();

                            break;


                        case "ExportRevenueTotalByDateAll":

                            if (string.IsNullOrEmpty(obj.keyword))
                            {
                                obj.keyword = string.Empty;
                            }
                            AddLogAction("", Constant.ActionExport.ToString());
                            var PatientsDetails = imptbl_Patient.Gettbl_PatientByAllDay(Tungay.ToString("yyyyMMdd"), Denngay.ToString("yyyyMMdd"), obj.Groupid, obj.Locationid, obj.userid.ToString().Trim(), obj.typeKeyword, obj.keyword);


                            if (PatientsDetails.Count < 20000)

                            {
                                Ep = new ExcelPackage();
                                Sheet = Ep.Workbook.Worksheets.Add("ExportRevenueTotalByDateAll");


                                Sheet.Cells["A1"].Value = "BỆNH VIỆN ĐA KHOA MEDLATEC";
                                Sheet.Cells["A1:V1"].Merge = true;
                                Sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                                Sheet.Cells["A2"].Value = "ĐT: 1900 565656";
                                Sheet.Cells["A2:V2"].Merge = true;
                                Sheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                                if (!string.IsNullOrEmpty(obj.userid))
                                {
                                    Sheet.Cells["A3"].Value = "Duyệt doanh thu cán bộ " + obj.userid.Trim() + " tại nhà từ ngày " + Tungay.ToString("dd/MM/yyyy") + " đến ngày " + Denngay.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    Sheet.Cells["A3"].Value = "Duyệt doanh thu cán bộ tại nhà từ ngày " + Tungay.ToString("dd/MM/yyyy") + " đến ngày " + Denngay.ToString("dd/MM/yyyy");
                                }

                                Sheet.Cells["A3:V3"].Merge = true;
                                Sheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                                Sheet.Cells["A4"].Value = "STT";
                                Sheet.Cells["B4"].Value = "Người thu";
                                Sheet.Cells["C4"].Value = "Đơn vị";
                                Sheet.Cells["D4"].Value = "SID";
                                Sheet.Cells["E4"].Value = "Tên bệnh nhân";
                                Sheet.Cells["F4"].Value = "Tổng tiền";
                                Sheet.Cells["G4"].Value = "Thực thu";
                                Sheet.Cells["H4"].Value = "Tạm thu";
                                Sheet.Cells["I4"].Value = "Phí đi lại";
                                Sheet.Cells["J4"].Value = "Tiền mặt";
                                Sheet.Cells["K4"].Value = "Tiền POS";
                                Sheet.Cells["L4"].Value = "Trả trước";
                                Sheet.Cells["M4"].Value = "Chuyển khoản";
                                Sheet.Cells["N4"].Value = "Trả sau";
                                Sheet.Cells["O4"].Value = "Tiền giảm giá";
                                Sheet.Cells["P4"].Value = "Tên giảm giá";
                                Sheet.Cells["Q4"].Value = "Tiền điểm PID";
                                Sheet.Cells["R4"].Value = "Thẻ giảm giá";
                                Sheet.Cells["S4"].Value = "Tiền cán bộ phải nộp";
                                Sheet.Cells["T4"].Value = "Tiền cán bộ đồng ý";
                                Sheet.Cells["U4"].Value = "Nội dung phê duyệt";
                                Sheet.Cells["V4"].Value = "Trạng thái duyệt";


                                stt = 1;
                                row = 5;
                                foreach (var item in PatientsDetails)
                                {
                                    Sheet.Cells[string.Format("A{0}", row)].Value = stt;
                                    Sheet.Cells[string.Format("B{0}", row)].Value = item.UserTC;
                                    Sheet.Cells[string.Format("C{0}", row)].Value = item.LocationName;
                                    Sheet.Cells[string.Format("D{0}", row)].Value = item.S_ID;
                                    Sheet.Cells[string.Format("E{0}", row)].Value = item.HoTen;
                                    Sheet.Cells[string.Format("F{0}", row)].Value = item.TongCP;
                                    Sheet.Cells[string.Format("G{0}", row)].Value = item.ThucThu;
                                    Sheet.Cells[string.Format("H{0}", row)].Value = item.TamThu;
                                    Sheet.Cells[string.Format("I{0}", row)].Value = item.PhiDiLai;
                                    Sheet.Cells[string.Format("J{0}", row)].Value = item.TienMat;
                                    Sheet.Cells[string.Format("K{0}", row)].Value = item.ThePOS;
                                    Sheet.Cells[string.Format("L{0}", row)].Value = item.TraTruoc;
                                    Sheet.Cells[string.Format("M{0}", row)].Value = item.ChKhoan;
                                    Sheet.Cells[string.Format("N{0}", row)].Value = item.TraSau;
                                    Sheet.Cells[string.Format("O{0}", row)].Value = item.TienGG;
                                    Sheet.Cells[string.Format("P{0}", row)].Value = item.TenGG;
                                    Sheet.Cells[string.Format("Q{0}", row)].Value = item.TienDiemPID;
                                    Sheet.Cells[string.Format("R{0}", row)].Value = item.TheSuDung;
                                    Sheet.Cells[string.Format("S{0}", row)].Value = item.TongCP - item.BHBLTT - item.BHBLTT - item.TienGG - item.TienDiemPID - item.ThePOS - item.TraSau - item.TraTruoc;
                                    Sheet.Cells[string.Format("T{0}", row)].Value = item.SumAgree;
                                    Sheet.Cells[string.Format("U{0}", row)].Value = item.Commentagree;
                                    Sheet.Cells[string.Format("V{0}", row)].Value = item.Typeagree21;

                                    row++;
                                    stt++;
                                }


                                Sheet.Cells["A:AZ"].AutoFitColumns();
                                Response.Clear();
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment: filename=" + "ExportRevenueTotalByDateAll.xlsx");
                                Response.BinaryWrite(Ep.GetAsByteArray());
                                Response.End();

                            }
                            else
                            {
                                ViewBag.TitleSuccsess = "Số lượng export lớn hơn 20000 dòng, Mời bạn thực hiện lại!";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                            }
                            break;


                    }

                }
                catch (Exception ex)
                {
                    ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                    logError.Info("ListOrder:" + ex.ToString());
                }
            }
            else
            {
                ViewBag.TitleSuccsess = TextErr;
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
            }
            // Info.  
            return View(obj);
        }

        #endregion

        #region --> Bản đồ theo dõi khách hàng
        public async Task<ActionResult> TrackingStatistic()
        {
            var lstLocation = new List<LocationHistoryViewModel>();
            // Initialization.  
            AddPageHeader("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "");
            AddBreadcrumb("Danh sách doanh thu CBTN", "/RevenueHome/RevenueTotalByDate");
            try
            {
                var token = _cache.Get("LOCATION_ACCESS_TOKEN") != null ? _cache.Get("LOCATION_ACCESS_TOKEN").ToString() : null;
                var apiUrl = ConfigurationSettings.AppSettings["LOCATION_URL"];
                var httpClient = new CMS_Core.Common.HttpClientService(token);
                lstLocation = await httpClient.GetAsync<List<LocationHistoryViewModel>>($"{apiUrl}api/location/latestLocationUsers");
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("RevenueTotalAll:" + ex.ToString());
            }

            ViewBag.ListLocation = lstLocation;
            // Info.  
            return View();
        }

        [HttpGet]
        public ActionResult RevenueDetailByUser(string userId)
        {
            try
            {
                List<tblReportRevenue> Patients = imptbl_Patient.Gettbl_PatientByUserid(userId, 0, string.Empty);
                var list = JsonConvert.SerializeObject(Patients, Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
                return Content(list, "application/json");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}