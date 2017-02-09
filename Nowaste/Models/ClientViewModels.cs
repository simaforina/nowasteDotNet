using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nowaste.Models
{
    public class ClientRequestViewModels
    {
        public string Id { get; set; }
        public string ClientName { get; set; }
        public string RequestDate { get; set; }
        public string TakeOutDate { get; set; }
        public string RecycleResourse { get; set; }
        public string RecycleWeight { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public string CityName { get; set; }
        public string CityDistrictName { get; set; }
        public string TakeOutAddress { get; set; }
    }
}