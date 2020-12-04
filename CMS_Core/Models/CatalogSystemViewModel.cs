using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Models
{
    public class CatalogSystemViewModel
    {
      

        [Required]
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "ID đối tác")]
        public string PARTNERID { get; set; }

        [Required]
        [Display(Name = "Từ ngày")]
        public string tungay { get; set; }

        [Required]
        [Display(Name = "Đến ngày")]
        public string denngay { get; set; }

        [Required]
        [Display(Name = "Kiểu tìm kiếm")]
        public int Type { get; set; }

        [Required]
        [Display(Name = "Từ khóa")]
        public string Keyword { get; set; }

    }

    public class CMS_SERVICEViewModel
    {


        [Required]
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "ID đối tác")]
        public string PARTNERID { get; set; }

        [Required]
        [Display(Name = "Từ ngày")]
        public string tungay { get; set; }

        [Required]
        [Display(Name = "Đến ngày")]
        public string denngay { get; set; }

        [Required]
        [Display(Name = "Kiểu tìm kiếm")]
        public int Type { get; set; }

        [Required]
        [Display(Name = "Từ khóa")]
        public string Keyword { get; set; }

    }

}
