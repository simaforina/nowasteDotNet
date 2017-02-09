using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NowasteBLL.DTO
{
    public class RequestDTO
    {
        public Guid Id { get; set; }
        public ClientInfoDTO ClientInfo { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? TakeOutDate { get; set; }
        public int RecyleResourseId { get; set; }
        public string RecycleResourse { get; set; }
        public decimal? RecycleWeight { get; set; }
        public EmploeeDTO ManagerInfo { get; set; }
        public int? StatusId { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public CityInfoDTO CityInfo { get; set; }
        public EmploeeDTO ExecutorInfo { get; set; }
        public string TakeOutAddress { get; set; }
    }
    
    public class CityInfoDTO
    {
        public int CityID { get; set; }
        public int CityDistrictID { get; set; }
        public string CityName { get; set; }
        public string CityDistrictName { get; set; }
    }
}
