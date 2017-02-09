using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nowaste.Models;
using NowasteBLL.DTO;
using NowasteBLL.Services;

namespace Nowaste.Controllers
{
    public class ClientController : Controller
    {
        ClientRequestService serv = new ClientRequestService();

        public ActionResult MyRequests()
        {
            IList<ClientRequestViewModels> requestsList= new List<ClientRequestViewModels>();
            IList<RequestDTO> requestsListDTO = serv.GetClientRequestsList(Guid.Parse("4166c85b-5a2e-4267-bd6e-a22e81f1804a"));
            if (requestsListDTO != null && requestsListDTO.Count != 0)
                foreach (var req in requestsListDTO)
                {
                    string weight = "не задано", outDate = "не  задано";
                    if (req.RecycleWeight.HasValue) weight = req.RecycleWeight.Value.ToString();
                    if (req.TakeOutDate.HasValue) outDate = req.TakeOutDate.Value.ToString();
                    requestsList.Add(new ClientRequestViewModels()
                    {
                        Id = req.Id.ToString(),
                        Comment = req.Comment,
                        RecycleResourse = req.RecycleResourse,
                        RecycleWeight = weight,
                        RequestDate = req.RequestDate.ToString(),
                        Status = req.Status,
                        TakeOutAddress = req.TakeOutAddress,
                        TakeOutDate = outDate
                    });
                }


            return View(requestsList);
        }

        public ActionResult _PartialNavList()
        {
            return PartialView();
        }
    }
}
