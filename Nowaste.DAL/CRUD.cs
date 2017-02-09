using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nowaste.DAL
{
    public class NowasteDAL : IDisposable
    {

        public nowasteDBEntities db;
        #region systeminfo
        private bool _disposed = false;
        public NowasteDAL(nowasteDBEntities context = null)
        {
            if (context == null) this.db = new nowasteDBEntities();
            else this.db = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                if (disposing)
                    db.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Requests

        public bool CreateRequest(Requests newRequest)
        {
            bool res = false;
            Requests checkRequest = db.Requests.FirstOrDefault(x => x.id == newRequest.id);
            if (checkRequest == null)
            {
                db.Requests.Add(newRequest);
                try
                {
                    db.SaveChanges();
                    res = true;
                }
                catch
                {
                    res = false;
                }
            }

            return res;

        }

        public IList<Requests> GetAllRequests()
        {
            return db.Requests.ToList();
        }

        public Requests GetRequest(Guid _id)
        {
            return db.Requests.SingleOrDefault(x => x.id == _id);
        }

        public IList<Requests> GetRequestListByClientId(Guid _userId)
        {
            return db.Requests.Where(x => x.clientPersonID == _userId).ToList();
        }

        public bool UpdateRequest(Requests updRequest)
        {
            bool res = false;
            Requests checkRequest = db.Requests.SingleOrDefault(x => x.id == updRequest.id);
            if (checkRequest != null)
            {
                try
                {
                    db.Entry(updRequest).State = EntityState.Modified;
                    db.SaveChanges();
                    res = true;
                }
                catch { }

            }
            return res;
        }

        public bool DeleteRequest(Guid _id)
        {
            bool res = false;
            Requests checkRequest = db.Requests.FirstOrDefault(x => x.id == _id);
            if (checkRequest != null)
            {
                db.Requests.Remove(checkRequest);
                try
                {
                    db.SaveChanges();
                    res = true;
                }
                catch { }
            }

            return res;
        }

        #endregion

        #region Cities

        public bool CreateCity(Cities city)
        {
            bool res = false;
            Cities checkCity = db.Cities.FirstOrDefault(x => x.id == city.id);
            if (checkCity == null)
            {
                db.Cities.Add(city);
                try
                {
                    db.SaveChanges();
                    res = true;
                }
                catch
                {
                    res = false;
                }
            }

            return res;
 
        }

        public bool CreateCityDistrictList(IList<CityDistricts> districtList)
        {
            bool res = false;
            foreach (var district in districtList)
            {
                CityDistricts checkDistrict = db.CityDistricts.FirstOrDefault(x => x.id == district.id);
                if (checkDistrict == null)
                    db.CityDistricts.Add(district);
            }
            try
            {
                db.SaveChanges();
                res = true;
            }
            catch
            {
                res = false;
            }
            return res;
        }

        public IList<Cities> GetAllCities()
        {
            return db.Cities.ToList();
        }

        public Cities GetCity(int _id)
        {
            return db.Cities.SingleOrDefault(x => x.id == _id);
        }

       
        public CityDistricts GetCityDistrict(int _id)
        {
            return db.CityDistricts.SingleOrDefault(x => x.id == _id);
        }

        public IList<CityDistricts> GetCityDistrictByCityID(int _cityID)
        {
            return db.CityDistricts.Where(x => x.cityID == _cityID).ToList();
        }


        #endregion

        #region Emploees

        public Emploees GetEmploee(Guid _id)
        {
            return db.Emploees.SingleOrDefault(x => x.id == _id);
        }
        #endregion

        #region Clients

        public bool CreateClientPerson(ClientPersons client)
        {
            bool res = false;
            ClientPersons checkCompany = db.ClientPersons.FirstOrDefault(x => x.id == client.id);
            if (checkCompany == null)
            {
                db.ClientPersons.Add(client);
                try
                {
                    db.SaveChanges();
                    res = true;
                }
                catch
                {
                    res = false;
                }
            }

            return res;

 
        }

        public bool CreateCompany(Companies company)
        {
            bool res = false;
            Companies checkCompany = db.Companies.FirstOrDefault(x => x.id == company.id);
            if (checkCompany == null)
            {
                db.Companies.Add(company);
                try
                {
                    db.SaveChanges();
                    res = true;
                }
                catch
                {
                    res = false;
                }
            }

            return res;

 
        }
            
        public ClientPersons GetClient(Guid _id)
        {
            return db.ClientPersons.SingleOrDefault(x => x.id == _id);
        }

        public IList<ClientPersons> GetAllClients()
        {
            return db.ClientPersons.ToList();
        }

        public List<ClientPersons> GetContactListByCompany(Guid _id)
        {
            return db.ClientPersons.Where(x => x.companyID == _id).ToList();
        }

        public List<ClientPersonPhoneNumbbers> GetClientPhonesList(Guid _id)
        {
            return db.ClientPersonPhoneNumbbers.Where(x => x.id == _id).ToList();
        }

        public IList<Companies> GetAllCompanies()
        {
            return db.Companies.ToList();
        }

        public Companies GetCompany(Guid _id)
        {
            return db.Companies.SingleOrDefault(x => x.id == _id);
        }

        public bool UpdateClientPersons(ClientPersons client)
        {
            bool res = false;
            ClientPersons checkClient = db.ClientPersons.SingleOrDefault(x => x.id == client.id);
            if (checkClient != null)
            {
                try
                {
                    db.Entry(client).State = EntityState.Modified;
                    db.SaveChanges();
                    res = true;
                }
                catch { }

            }
            return res;

        }

        #endregion

        #region Statuses

        public bool CreateStatus(RequestStatuses status)
        {
            bool res = false;
            RequestStatuses checkStatus = db.RequestStatuses.FirstOrDefault(x => x.id == status.id);
            if (checkStatus == null)
            {
                db.RequestStatuses.Add(status);
                try
                {
                    db.SaveChanges();
                    res = true;
                }
                catch
                {
                    res = false;
                }
            }

            return res;

        }

        public RequestStatuses GetRequestStatus(int _id)
        {
            return db.RequestStatuses.SingleOrDefault(x => x.id == _id);
        }

        public IList<RequestStatuses> GetAllStatuses()
        {
            return db.RequestStatuses.ToList();
        }

        #endregion

        #region RecycleRecourses

        public bool CreateResourse(RecycledResourses resourse)
        {
            bool res = false;
            RecycledResourses checkResourse = db.RecycledResourses.FirstOrDefault(x => x.id == resourse.id);
            if (checkResourse == null)
            {
                db.RecycledResourses.Add(resourse);
                try
                {
                    db.SaveChanges();
                    res = true;
                }
                catch
                {
                    res = false;
                }
            }

            return res;

        }

        public IList<RecycledResourses> GetAllResourses()
        {
            return db.RecycledResourses.ToList();
        }
        public RecycledResourses GetRecycleResourse(int _id)
        {
            return db.RecycledResourses.SingleOrDefault(x => x.id == _id);
        }

        #endregion



    }


}
