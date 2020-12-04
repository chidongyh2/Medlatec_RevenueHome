using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSNEW.Models
{
    public class ClinicViewModels
    {
        [Required]
        public CMS_PATIENTINFO PATIENTINFO { get; set; }
        [Required]
        public List<CMS_PATIENT_SERVICE> CMS_PATIENT_SERVICES { get; set; }
        [Required]
        public CMS_PATIENT PATIENT { get; set; }

        [Required]
        [Display(Name = "Từ ngày")]
        public string tungay { get; set; }

        [Required]
        [Display(Name = "Đến ngày")]
        public string denngay { get; set; }

        [Required]
        [Display(Name = "Từ khóa tìm kiếm")]
        public string keyword { get; set; }

        [Required]
        [Display(Name = "Kiểu tìm kiếm")]
        public int TypeKeyword { get; set; }
    }
}