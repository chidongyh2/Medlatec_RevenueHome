using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Medicons.Common
{
    public class RequestMessage
    {
        public string RequestID { get; set; }
        public string ServiceID { get; set; }
        public string FunctionName { get; set; }

        // Complex property in request message. See API document to custom object for each request type
        public object Parameter { get; set; }
    }

    /// <summary>
    /// Property 'Parameter' in request message
    /// </summary>
    public class Parameter
    {
        public string Email { get; set; }
    }

    // Certificate ----------------------------------------------------
    public class CertParameter : Parameter
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class CertResponse
    {
        public int Count { get; set; }
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public List<Certificate> Items { get; set; }
    }
    public class Certificate
    {
        public string ID { get; set; }
        public string CertBase64 { get; set; }
        // More properties, see json response
    }
    // ---------------------------------------------------------------

    // Signature -----------------------------------------------------
    public class SignParameter
    {
        public string CertID { get; set; }
        public string ServiceGroupID { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public string ContentType { get; set; }
        public string DataBase64 { get; set; }
        public string Image { get; set; }
        public string Rectangle { get; set; }
        public string Page { get; set; }
        public string VisibleType { get; set; }
        public string AccountEmail { get; set; }
    }

    public class SignPdfAdvanceParameter
    {
        public String ServiceGroupID { get; set; }
        public String CertID { get; set; }
        public String FileName { get; set; }
        public String DataBase64 { get; set; }
        public String VisibleType { get; set; }
        public String FontSize { get; set; }
        public String Signatures { get; set; }
        public String FontName { get; set; }
        public String Comment { get; set; }
        public String FontStyle { get; set; }
        public String FontColor { get; set; }
        public String SignatureText { get; set; }
        public String IsDebug { get; set; }
        public String ContentType { get; set; }
    }
    public class SignResponse
    {
        public string TranID { get; set; }
        public int ResponseCode { get; set; }
        public string Message { get; set; }
        public string SignedData { get; set; }
    }
    // ---------------------------------------------------------------

    // Verify response -----------------------------------------------
    public class VerifyResultModel
    {
        public string TranID { get; set; }
        public bool status { get; set; }
        public string message { get; set; }

        public List<SignServerVerifyResultModel> signatures { get; set; }
    }
    public class SignServerVerifyResultModel
    {
        public string signingTime { get; set; }
        public bool signatureStatus { get; set; }
        public string certStatus { get; set; }
        public string certificate { get; set; }
        public int signatureIndex { get; set; }
        public int code { get; set; }
    }
    // ---------------------------------------------------------------

    public class Profile
    {
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual int TrangThai { get; set; }
        public virtual string HoTenDayDu { get; set; }
        public virtual string GroupID { get; set; }
        public virtual bool KhachHangToChuc { get; set; }
        public virtual bool GioiTinh { get; set; }
        public virtual string DiaChi { get; set; }
        public virtual DateTime? NgaySinh { get; set; }
        public virtual DateTime? LanDangNhapCuoi { get; set; }
        public virtual bool IsSecondPassValid { get; set; }

        // Danh sách group mà account tham gia
        public virtual IList<ServicePack> Groups { get; set; }
    }

    public class ServicePack
    {
        public string ID { get; set; }
        public int GroupType { get; set; }
        public string AdminEmail { get; set; }
        public string TenNhom { get; set; }
        public string TenGoiCuoc { get; set; }
        public string TrangThaiGoiCuoc { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public int SoLuotKyConLai { get; set; }
    }
}