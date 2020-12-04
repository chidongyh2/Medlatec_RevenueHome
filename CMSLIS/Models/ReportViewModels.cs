using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSNEW.Models
{
    public class ReportViewModels
    {
        [Required]
        [Display(Name = "ngày bắt đầu")]
        public string startdate { get; set; }

        [Required]
        [Display(Name = "Ngày kết thúc")]
        public string enddate { get; set; }
        [Required]
        [Display(Name = "DOCTOR_ID ")]
        public int DOCTOR_ID { get; set; }

        [Required]
        [Display(Name = "DOCTOR_NAME ")]
        public string DOCTOR_NAME { get; set; }

        [Required]
        [Display(Name = "dich vu ")]
        public int SERVICETYPE { get; set; }
    }
}