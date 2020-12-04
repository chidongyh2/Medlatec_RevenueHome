using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSLIS.Models
{
    public class AccountViewModels
    {
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Số ký tự phải lớn hơn {2}.", MinimumLength = 4)]        
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }        
    }


    public class ChangePasswordViewModel
    {


        [Required]
        [StringLength(100, ErrorMessage = "Số ký tự phải lớn hơn {2}.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Password hiện tại")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Số ký tự phải lớn hơn {2}.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Password mới")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Đánh lại password")]
        [Compare("Password", ErrorMessage = "Password không trùng khớp.")]
        public string ConfirmPassword { get; set; }

    }


    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

}