using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSLIS.Models
{
    public class CatalogSystemViewModels
    {
    }

    public class SearchCategoryViewModel
    {
        [Required]
        [Display(Name = "Chuyên mục cha")]
        public string parentID { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "ID đối tác")]
        public string PARTNERID { get; set; }

        [Required]
        [Display(Name = "Từ khóa tìm kiếm")]
        public string keyword { get; set; }

        [Required]
        [Display(Name = "Kiểu tìm kiếm")]
        public int TypeKeyword { get; set; }

    }


   


    public class CategoryDynamicViewModel
    {
        [Required]
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Chuyên mục cha")]
        public string parentID { get; set; }

        [Required]
        public List<cms_Category> cms_Categories   { get; set; }

        [Required]
        public List<COMPLEMENT_SETTUP> SETTUPS   { get; set; }

        [Required]
        [Display(Name = "Đối tác")]
        public string Partnerid { get; set; }
    }

    //public class CategoryDynamicAddViewModel
    //{
    //    [Required]
    //    [Display(Name = "Trạng thái")]
    //    public string Status { get; set; }

    //    [Required]
    //    [Display(Name = "Chuyên mục cha")]
    //    public string parentID { get; set; }

    //    [Required]
    //    public cms_Category cms_Categorie { get; set; }

    //    [Required]
    //    public List<COMPLEMENT_SETTUP> SETTUPS { get; set; }

    //    [Required]
    //    public List<CATEGORY_COMPLEMENT> COMPLEMENTS { get; set; }


    //    [Required]
    //    [Display(Name = "Đối tác")]
    //    public string Partnerid { get; set; }
    //}



    public class COMPLEMENT_SETTUPViewModel
    {
        [Required]
        public List<COMPLEMENT_SETTUP> COMPLEMENT_SETTUPS  { get; set; }
        
        public COMPLEMENT_SETTUP _SETTUP  { get; set; }
    }


}