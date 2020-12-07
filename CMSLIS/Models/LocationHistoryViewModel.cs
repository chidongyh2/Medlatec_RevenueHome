using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Medicons.Models
{
    public class LocationHistoryViewModel
    {
        public string Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public Double Lat { get; set; }
        public Double Lng { get; set; }
        public string Geo { get; set; }
    }
}