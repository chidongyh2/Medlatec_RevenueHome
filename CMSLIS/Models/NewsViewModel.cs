using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSLIS.Models
{
    public class NewsViewModel
    {
        public cms_News_Cate _News_Cate { get; set; }
        public cms_News _News { get; set; }
    }


    public class SearchNewsViewModel
    {
        [Required]
        [Display(Name = "Từ ngày")]
        public string tungay { get; set; }

        [Required]
        [Display(Name = "Đến ngày")]
        public string denngay { get; set; }

        [Required]
        [Display(Name = "Nguồn tin")]
        public int SourceId { get; set; }

        [Required]
        [Display(Name = "Chuyên mục")]
        public int ParrenId { get; set; }

        [Required]
        [Display(Name = "Tiểu mục")]
        public int cateId { get; set; }

        [Required]
        [Display(Name = "Loại tin")]
        public int newsTypeMessage { get; set; }

        [Required]
        [Display(Name = "Người tạo")]
        public int userId { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }

        [Required]
        [Display(Name = "Từ khóa tìm kiếm")]
        public string keyword { get; set; }

        [Required]
        [Display(Name = "Kiểu tìm kiếm")]
        public int TypeKeyword { get; set; }

    }

    public class FileModel
    {
        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }

    }

    public class FileImputModel
    {
        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase ImageFile { get; set; }

    }

}