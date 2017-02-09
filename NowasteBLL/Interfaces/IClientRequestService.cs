using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NowasteBLL.DTO;

namespace NowasteBLL.Interfaces
{
    public interface IClientRequestService
    {
        void CreateRequest(RequestDTO request);
        IList<RequestDTO> GetClientRequestsList(Guid clientID);
        RequestDTO GetRequestDetails(Guid id);
        ClientCompanyDTO GetClientInfo(Guid clientID);
        void UpdateClientInfo(ClientInfoDTO client);
        void UpdateCompanyInfo(ClientCompanyDTO company);
        void AddPhoneToList(ClientCompanyPhoneDTO phone);
        void UpdatePhonesInList(IList<ClientCompanyPhoneDTO> phoneList);
        void RemovePhoneFromList(ClientCompanyPhoneDTO phone);
        void Dispose();
    }
}
