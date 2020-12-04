using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSNEW.Models
{
    public class pharmacyStoreViewModels
    {
        [Required]
        [Display(Name = "ngày bắt đầu")]
        public string startdate { get; set; }

        [Required]
        [Display(Name = "Ngày kết thúc")]
        public string enddate { get; set; }

        [Required]
        [Display(Name = "Số phiếu")]
        public string pharmacyStoreCode { get; set; }

        [Required]
        [Display(Name = "ID đối tác")]
        public int PARTNERID { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }
        

    }

    public class RefundStoreViewModels
    {
        [Required]
        public CMS_MEDICINE_EXPORT_STORE _MEDICINE_EXPORT_STORE { get; set; }
        [Required]
        public List<CMS_MEDICINE_EXPORT_DETAIL> _MEDICINE_EXPORT_DETAILS { get; set; }

        public CMS_MEDICINE_REFUND_STORE _CMS_MEDICINE_REFUND_STORE { get; set; }

        [Required]
        public List<CMS_MEDICINE_REFUND_DETAIL> _MEDICINE_REFUND_DETAILS  { get; set; }
    }

    //public class pharmacyStoreSearchViewModels
    //{
    //    [Required]
    //    [Display(Name = "ngày bắt đầu")]
    //    public string startdate { get; set; }

    //    [Required]
    //    [Display(Name = "Ngày kết thúc")]
    //    public string enddate { get; set; }

    //    [Required]
    //    [Display(Name = "Số phiếu")]
    //    public string pharmacyStoreCode { get; set; }

    //}
}