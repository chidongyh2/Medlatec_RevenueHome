using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSLIS.Models
{
    public class SystemViewModel
    {
    }


    public class SearchMenuViewModel
    {
        [Required]
        [Display(Name = "Menu cha")]
        public string parentID { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Đối tác")]
        public string Partnerid { get; set; }

        [Required]
        [Display(Name = "Đối tác")]
        public string PartneridUser { get; set; }

        [Required]
        [Display(Name = "Nhóm")]
        public string accounttypeid { get; set; }

        [Required]
        [Display(Name = "Từ khóa tìm kiếm")]
        public string keyword { get; set; }

        [Required]
        [Display(Name = "Kiểu tìm kiếm")]
        public int TypeKeyword { get; set; }

        [Required]
        [Display(Name = "bắt đầu")]
        public string startdate { get; set; }

        [Required]
        [Display(Name = "kết thúc ")]
        public string enddate { get; set; }

        [Required]
        [Display(Name = "Kiểu tìm kiếm")]
        public int ItemCateItemID { get; set; }

        [Required]
        [Display(Name = "Kiểu tìm kiếm")]
        public int ItemUnit { get; set; }
        [Required]
        [Display(Name = "Kiểu tìm kiếm")]
        public int ProducerID { get; set; }

        public int userid { get; set; }
    }



    //public class SearchCategoryViewModel
    //{
    //    [Required]
    //    [Display(Name = "Menu cha")]
    //    public string cateParrent { get; set; }

    //    [Required]
    //    [Display(Name = "Trạng thái")]
    //    public string Status { get; set; }
         

    //    [Required]
    //    [Display(Name = "Từ khóa tìm kiếm")]
    //    public string keyword { get; set; }

    //    [Required]
    //    [Display(Name = "Kiểu tìm kiếm")]
    //    public int TypeKeyword { get; set; }

    //}

    public class GroupAccountMenuPermissionViewModel
    {

        
        [Required]
        public List<cms_Menu> _Menus   { get; set; }

        [Required]
        [Display(Name = "Menu cha")]
        public string parentID { get; set; }

        [Required]
        [Display(Name = "Nhóm cha")]
        public string GroupID { get; set; }

    }


    public class ListControlViewModel
    {
        [Required]
        public List<cms_ControlName> _Menus { get; set; }

        [Required]
        [Display(Name = "Menu Cha")]
        public string MenParent { get; set; }
        [Required]
        [Display(Name = "Menu con")]
        public string MenChild { get; set; }

        public cms_ControlName _ControlName { get; set; }
    }


    public class PermissionControlViewModel
    {
        [Required]
        public List<Sys_GroupMenuControlPermission> _GroupMenuControlPermissions  { get; set; }

        [Required]
        [Display(Name = "Menu Cha")]
        public string MenParent { get; set; }
        [Required]
        [Display(Name = "Menu con")]
        public string MenChild { get; set; }

        [Required]
        [Display(Name = "Nhóm")]
        public string GroupID { get; set; }
    }


}