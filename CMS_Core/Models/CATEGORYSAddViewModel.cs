using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Models
{
    


    public class CategoryDynamicAddViewModel
    {
        [Required]
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Chuyên mục cha")]
        public string parentID { get; set; }

        [Required]
        public cms_Category cms_Categorie { get; set; }

        [Required]
        public List<COMPLEMENT_SETTUP> SETTUPS { get; set; }

        //[Required]
        //public List<CATEGORY_COMPLEMENT> COMPLEMENTS { get; set; }


        [Required]
        [Display(Name = "Đối tác")]
        public string Partnerid { get; set; }

        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

    }


}
