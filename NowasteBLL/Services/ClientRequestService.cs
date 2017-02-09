using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NowasteBLL.Interfaces;
using Nowaste.DAL;
using NowasteBLL.DTO;
using NowasteBLL.Infrastucture;



namespace NowasteBLL.Services

{
    public class ClientRequestService : IClientRequestService
    {   
        private NowasteDAL _mng = new NowasteDAL();
        private nowasteDBEntities db = new nowasteDBEntities() ;

        public IList<RequestDTO> GetClientRequestsList(Guid clientID)
        {
            IList<RequestDTO> requestsList = new List<RequestDTO>();
            IList<Requests> requestListDB = _mng.GetRequestListByClientId(clientID);
            if (requestListDB != null && requestListDB.Count != 0)
            {
                foreach (var r in requestListDB)
                {
                    requestsList.Add(new RequestDTO
                    {
                        Id = r.id,
                        Comment = r.comments,
                        Status = r.RequestStatuses.name,
                        RecycleResourse = r.RecycledResourses.name,
                        RecycleWeight = r.recycleResoursesWeight,
                        RequestDate = r.requestDate,
                        TakeOutDate = r.takeOutDate
                    });
                }

            }
            return requestsList;

            /*попробуем сюда воткнуть базовое заполнение бд, потом удалим или перенесем в сервисы */
           
          

            //_mng.CreateStatus(new RequestStatuses() { id = 1, name = "New" });
            //_mng.CreateStatus(new RequestStatuses() { id = 2, name = "In processing" });
            //_mng.CreateStatus(new RequestStatuses() { id = 3, name = "Closed" });

            //IList<RequestStatuses> st = _mng.GetAllStatuses();

            ////_mng.CreateResourse(new RecycledResourses() { id = 1, name = "Paper" });
            ////_mng.CreateResourse(new RecycledResourses() { id = 2, name = "Plastic" });
            ////_mng.CreateResourse(new RecycledResourses() { id = 3, name = "Glass" });
            ////_mng.CreateResourse(new RecycledResourses() { id = 4, name = "Battery" });
            
            //IList<RecycledResourses> rec = _mng.GetAllResourses();
            //IList<Cities> city = _mng.GetAllCities();
            //IList<CityDistricts> cd = _mng.GetCityDistrictByCityID(1);
            //IList<Companies> c = _mng.GetAllCompanies();
            ////+		id	{cc2b6e86-d060-43f5-af9c-3740222c3811}	System.Guid
            ////+		id	{995f7936-605f-4da6-bd9a-cc8600c22848}	System.Guid
            //IList<ClientPersons> cp = _mng.GetAllClients();
            //// +		id	{4166c85b-5a2e-4267-bd6e-a22e81f1804a}	System.Guid
            //+		id	{d16ae30e-2df4-4234-bd35-ba4a9a895013}	System.Guid




            /* delete up*/
            
           
            /* наверное это была плохая идея, но пусть пока побудет тут
            var requestListDB = db.Requests
                .Where(client => client.clientPersonID == clientID)
                .Join(db.RequestStatuses, req => req.statusID, status => status.id, (req, status)
                    => new { RequestStatuses = status, Requests = req })
                    .Join(db.RecycledResourses, req => req.Requests.recycleResoursesID, res => res.id, (req, res)
                        => new { RecycledResourses = res, Requests = req }).ToList();

            if (requestListDB != null && requestListDB.Count != 0)
            {
                foreach (var r in requestListDB)
                {
                    requestsList.Add(new RequestDTO
                    {
                        Id = r.Requests.Requests.id,
                        Comment = r.Requests.Requests.comments,
                        Status = r.Requests.RequestStatuses.name,
                        RecycleResourse = r.RecycledResourses.name,
                        RecycleWeight = r.Requests.Requests.recycleResoursesWeight,
                        RequestDate = r.Requests.Requests.requestDate,
                        TakeOutDate = r.Requests.Requests.takeOutDate
                    });
                }
            }
*/
                      
        }

       public  RequestDTO GetRequestDetails(Guid id)
        {
            RequestDTO request = new RequestDTO();
            Requests requestDB = _mng.GetRequest(id);
            if (requestDB != null)
            {
                request.Id = requestDB.id;
                request.CityInfo = new CityInfoDTO()
                {
                    CityName = requestDB.Cities.name,
                    CityDistrictName = requestDB.CityDistricts.name
                };
                request.ClientInfo = new ClientInfoDTO()
                {
                    Name = requestDB.ClientPersons.name,
                    Email = requestDB.ClientPersons.email
                };
                request.RecycleResourse = requestDB.RecycledResourses.name;
                request.RecycleWeight = requestDB.recycleResoursesWeight;
                request.RequestDate = requestDB.requestDate;
                request.Status = requestDB.RequestStatuses.name;
                request.TakeOutAddress = requestDB.takeOutAddress;
                request.TakeOutDate = requestDB.takeOutDate;

            }
            return request;
            
        }

        public void CreateRequest(RequestDTO request)
        {
            Requests newRequest = new Requests();

            if (request != null)
            {
                newRequest.id = new Guid();
                newRequest.managerID = request.ManagerInfo.Id;
                newRequest.recycleResoursesID = request.RecyleResourseId;
                newRequest.recycleResoursesWeight = request.RecycleWeight;
                newRequest.requestDate = request.RequestDate;
                newRequest.statusID = StatusConstants.NEW;
                newRequest.takeOutAddress = request.TakeOutAddress;
                newRequest.takeOutDate = request.TakeOutDate;

            }
            var res = _mng.CreateRequest(newRequest);
        }

        public ClientCompanyDTO GetClientInfo(Guid clientID)
        {
            ClientCompanyDTO clientInfo = new ClientCompanyDTO();

            ClientPersons clientDB =_mng.GetClient(clientID);
            if (clientDB != null)
            {
                
                Companies companyDB = _mng.GetCompany(clientDB.companyID);
                if (companyDB != null)
                {
                    clientInfo.Id = companyDB.id;
                    clientInfo.Name = companyDB.name;
                    IList<ClientCompanyPhoneDTO> phoneList = new List<ClientCompanyPhoneDTO>();
                    List<ClientPersonPhoneNumbbers> phoneListDB =_mng.GetClientPhonesList(clientID) ;
                    if (phoneListDB != null && phoneListDB.Count != 0)
                        foreach (var phone in phoneListDB)
                            phoneList.Add(new ClientCompanyPhoneDTO() 
                            { 
                                PhoneCode = phone.operatorCode, PhoneNumber = phone.phoneNum 
                            });
                    clientInfo.ClientPersonsList = new List<ClientInfoDTO>();
                    clientInfo.ClientPersonsList.Add(new ClientInfoDTO() { 
                        Name = clientDB.name,
                        Email = clientDB.email,
                        CompanyPhonesList = phoneList
                    });
                }

            }
            return clientInfo;
        }

        public void UpdateClientInfo(ClientInfoDTO client)
        {
            if (client != null)
            {
                ClientPersons clientDB = new ClientPersons();
                clientDB.id = client.Id;
                clientDB.name = client.Name;
                clientDB.email = client.Email;
                _mng.UpdateClientPersons(clientDB);
            }
 
        }

        public void UpdateCompanyInfo(ClientCompanyDTO company) { }
        public void AddPhoneToList(ClientCompanyPhoneDTO phone) { }
        public void UpdatePhonesInList(IList<ClientCompanyPhoneDTO> phoneList) { }
        public void RemovePhoneFromList(ClientCompanyPhoneDTO phone) { }

        public void Dispose()
        {
            _mng.Dispose();
           
        }
    }
}
