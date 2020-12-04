using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS_Medicons.Models
{
    public class RevenueViewModel
    {
        [Required]
        [Display(Name = "Từ ngày")]
        public string tungay { get; set; }

        [Required]
        [Display(Name = "Đến ngày")]
        public string denngay { get; set; }

        [Required]
        [Display(Name = "Trạng thái thanh toán")]
        public int Payment { get; set; }
        [Required]
        [Display(Name = "User thu tiền")]
        public int userid { get; set; }
        [Display(Name = "Loại tìm kiếm")]
        public int typeKeyword { get; set; }

        [Required]
        [Display(Name = "Từ khóa tìm kiếm")]
        public string keyword { get; set; }

    }

    public class RevenueViewAgreeModel
    {


        [Required]
        public List<tblReportRevenue> Patients { get; set; }
        public List<tblReportRevenue> Patients2 { get; set; }
        public cms_Account cms_AccountValue { get; set; }

        [Required]
        [Display(Name = "userid")]
        public string userid { get; set; }

        [Display(Name = "Loại tìm kiếm")]
        public int typeKeyword { get; set; }

        [Required]
        [Display(Name = "Từ khóa tìm kiếm")]
        public string keyword { get; set; }

        [Required]
        [Display(Name = "Đơn vị")]
        public string Locationid { get; set; }
        [Required]
        [Display(Name = "Nhóm doanh thu")]
        public string Groupid { get; set; }

        [Required]
        [Display(Name = "Từ ngày")]
        public string tungay { get; set; }

        [Required]
        [Display(Name = "Đến ngày")]
        public string denngay { get; set; }

        public string ngaythu { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Số ký tự phải lớn hơn {2}.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }


    public class RevenueResultViewAgreeModel
    {


        [Required]
        public List<VP> Results { get; set; }

        [Required]
        [Display(Name = "userid")]
        public string userid { get; set; }

        [Required]
        [Display(Name = "sid")]
        public string sid { get; set; }


        [Display(Name = "Loại tìm kiếm")]
        public int typeKeyword { get; set; }

        [Required]
        [Display(Name = "Từ khóa tìm kiếm")]
        public string keyword { get; set; }

        [Required]
        [Display(Name = "mabn")]
        public Int64 mabn { get; set; }
    }

}