using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CMS_Core.Models
{
    public class OrderViewModels
    {
        [Required]
        public cms_Customer Customer   { get; set; }
        [Required]
        public List<cms_customer_detail> customer_details { get; set; }
        [Required]
        public List<cms_customer_Material> customer_Materials { get; set; }

        [Required]
        public cms_item Item { get; set; }


        [Required]
        public cms_Order Order  { get; set; }

        [Required]
        public List<cms_Order> cms_Orders { get; set; }


        [Required]
        public cms_Material Material { get; set; }

        public string action { get; set; }

        [Required]
        public cms_Order_Bill Order_Bill { get; set; }

        public List<cms_Order_Bill> cms_Order_Bills { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        public cms_OrderExport OrderExport { get; set; }

        [Required]
        public List<cms_OrderExport_detail> OrderExport_details { get; set; }
         
        public string customerid { get; set; }
        public string ListOrderID { get; set; }
        public string Customer_Detailid { get; set; }
        

        public string customer_MaterialID { get; set; }
        public string BillCodeGroup { get; set; }


        public cms_Producer Producer;

    }

    
}
