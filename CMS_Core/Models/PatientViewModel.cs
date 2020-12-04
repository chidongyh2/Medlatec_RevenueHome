using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Models
{
    public class PatientViewModel
    {
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

        [Required]
        [Display(Name = "ID đối tác")]
        public int partnerid { get; set; }
        [Required]
        [Display(Name = "ID nhóm dịch vụ")]
        public int channel { get; set; }

        [Required]
        [Display(Name = "ID phòng khám")]
        public int LOCATIONID { get; set; }

        [Required]
        [Display(Name = "Loại khách hàng bất thường")]
        public int Weirdo { get; set; }

        [Required]
        [Display(Name = "Loại dịch vụ")]
        public int SERVICETYPE { get; set; }

        [Required]
        [Display(Name = "nhóm dịch vụ")]
        public int SERVICE_GROUPID { get; set; }


    }

    public class PatientAddViewModel
    {

        [Required]
        [Display(Name = "ID đối tác")]
        public int partnerid { get; set; }

        [Required]
        public CMS_PATIENT PATIENT { get; set; }

        [Required]
        public List<CMS_PATIENT> PATIENTS { get; set; }


        [Required]
        public CMS_PATIENTINFO PATIENTINFO { get; set; }

        [Required]
        public List<CMS_PATIENT_ALLERGY> ALLERGGYS { get; set; }

        [Required]
        public CMS_PATIENT_ALLERGY ALLERGGY { get; set; }


        [Required]
        public List<CMS_PATIENT_HISTORY> HISTORIES { get; set; }

        [Required]
        public CMS_PATIENT_HISTORY HISTORIE { get; set; }


        [Required]
        public List<CMS_SERVICE> SERVICES { get; set; }


        [Required]
        public List<CMS_PATIENT_SERVICE> CMS_PATIENT_SERVICES { get; set; }

        [Required]
        [Display(Name = "Ảnh")]
        public string PATIENTIMAGE { get; set; }

        

    }

    public class PatientHistoryViewModel
    {

        [Required]
        [Display(Name = "ID đối tác")]
        public int partnerid { get; set; }

     

        [Required]
        public List<CMS_PATIENT> PATIENTS { get; set; }


        [Required]
        public CMS_PATIENTINFO PATIENTINFO { get; set; }

        [Required]
        public List<CMS_PATIENT> PATIENTS_PRESCRIPTION { get; set; }
    }


    public class MedicalExaminationViewModel
    {


        [Required]
        public CMS_PATIENTINFO PATIENTINFO { get; set; }


        [Required]
        public List<CMS_PATIENT_SERVICE> CMS_PATIENT_SERVICES { get; set; }

        [Required]
        public CMS_PATIENT PATIENT { get; set; }
        [Required]
        public List<CMS_PATIENT_ALLERGY> ALLERGGYS { get; set; }

        [Required]
        public CMS_PATIENT_ALLERGY ALLERGGY { get; set; }


        [Required]
        public List<CMS_PATIENT_HISTORY> HISTORIES { get; set; }

        [Required]
        public CMS_PATIENT_HISTORY HISTORIE { get; set; }

        [Required]
        public List<CMS_PATIENT> PATIENTS { get; set; }

        [Required]
        public CMS_PATIENT_SERVICE_RESULT PATIENT_SERVICE_RESULT { get; set; }

        [Required]
        public List<CMS_PATIENT_SERVICE_RESULT> CMS_PATIENT_SERVICE_RESULTS { get; set; }

        [Required]
        public List<CMS_PATIENT_IMAGES> PATIENT_IMAGES   { get; set; }



        //[Required]
        //public List<CMS_PATIENT_SERVICE_RESULT> CMS_PATIENT_SERVICE_RESULTS_INPUT { get; set; }


        [Required]
        public CMS_PATIENT_SERVICE_RESULT CMS_PATIENT_SERVICE_RESULTS_INPUT { get; set; }


        [Required]
        public List<CMS_PATIENT_PRESCRIPTION> CMS_PATIENT_PRESCRIPTIONS { get; set; }

        [Required]
        public CMS_PATIENT_PRESCRIPTION PATIENT_PRESCRIPTION { get; set; }


        [Required]
        public CMS_MEDICINE MEDICINE  { get; set; }

        [Required]
        [Display(Name = "ID CMS_PATIENT_SERVICE")]
        public int CMS_PATIENT_SERVICEID { get; set; }

        [Required]
        [Display(Name = "ID lượt khám")]
        public int SID { get; set; }

        [Required]
        [Display(Name = "ID nhóm dịch vu")]
        public int SERVICE_GROUPID { get; set; }

        [Required]
        [Display(Name = "ID dịch vụ")]
        public string SERVICEID { get; set; }

        [Required]
        [Display(Name = "ID phòng")]
        public string locationID { get; set; }


        [Required]
        [Display(Name = "KeyPrivate")]
        public string KeyPrivate { get; set; }


        [Required]
        [Display(Name = "channel")]
        public string channel { get; set; }

        [Required]
        [Display(Name = "channel")]
        public string channelName { get; set; }

        [Required]
        [Display(Name = "channel")]
        public int  idTemplate { get; set; }

        [Required]
        [Display(Name = "channel")]
        public string ListImageDelete { get; set; }
    }

    

    public class PatientPrintViewModel
    {
 

        [Required]
        public CMS_PATIENTINFO_TOTAL PATIENTINFO { get; set; }

        
        [Required]
        public List<CMS_PATIENT_SERVICE> CMS_PATIENT_SERVICES { get; set; }


        public List<CMS_PATIENT_SERVICE_REFUND> CMS_PATIENT_SERVICE_REFUNDS { get; set; }

    }


}
