using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Models
{
    public class ReceiptStoreViewModel
    {
        [Required]
        [Display(Name = "ID đối tác")]
        public int partnerid { get; set; }

        [Required]
        public CMS_MEDICINE_RECEIPT_STORE _MEDICINE_RECEIPT_STORE  { get; set; }
  
        [Required]
        public List<CMS_MEDICINE_RECEIPT_DETAIL> _MEDICINE_RECEIPT_DETAILS { get; set; }


        public CMS_MEDICINE_RECEIPT_DETAIL MEDICINE_RECEIPT_DETAIL { get; set; }

        public CMS_MEDICINE MEDICINE  { get; set; }


    }
}
