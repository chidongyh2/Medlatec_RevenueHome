using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Models
{
    public class ListServiceViewModel
    {
        [Required]
        public List<CMS_SERVICE> SERVICES  { get; set; }

        [Required]
        [Display(Name = "Menu cha")]
        public int PARTNERID { get; set; }

        [Required]
        [Display(Name = "Nhóm cha")]
        public int GroupID { get; set; }

        public List<CMS_SERVICE> SERVICESBYGROUP { get; set; }

        [Required]
        [Display(Name = "Nhóm cha")]
        public string GroupName{ get; set; }

        [Required]
        [Display(Name = "Lượt khám")]
        public int Visit_ID { get; set; }

        public string[] mulSERVICEID { get; set; }

    }

    public class ListServiceChoiseViewModel
    {
      

        [Required]
        [Display(Name = "ID đối tác")]
        public int PARTNERID { get; set; }

        [Required]
        [Display(Name = "ID phiên khám")]
        public string SID { get; set; }

        [Required]
        [Display(Name = "Tên bệnh nhân")]
        public string PatientName { get; set; }

    }

}
