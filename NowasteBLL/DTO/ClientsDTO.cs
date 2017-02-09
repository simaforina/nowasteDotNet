using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NowasteBLL.DTO
{
    public class ClientCompanyDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<ClientInfoDTO> ClientPersonsList { get; set; }
    }

    public class ClientInfoDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<ClientCompanyPhoneDTO> CompanyPhonesList { get; set; }
    }

    public class ClientCompanyPhoneDTO
    {
        public Guid PhoneId { get; set; }
        public string PhoneCode { get; set; }
        public string PhoneNumber { get; set; }
    }

}
