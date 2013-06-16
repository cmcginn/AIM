using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIM.Administration.Models;
using System.Xml.Linq;
namespace AIM.Administration.Controllers
{
    [Authorize(Roles="Administrators")]
    public class ClientController : Controller
    {
        //
        // GET: /Clients/
        ClientService service = new ClientService();
        public ActionResult Index()
        {
            List<ClientModel> model = service.GellAllClients().Where(n=>!n.IsDeleted).ToList();
            return View(model);
        }
        public PartialViewResult ClientTypes()
        {
            List<ClientType> clientTypes = new List<ClientType>();
            clientTypes.Add(new ClientType { Id = 1, TypeName = "Mind Body Online" });
            clientTypes.Add(new ClientType { Id = 2, TypeName = "Other" });
            return PartialView(clientTypes);
        }
        //
        // GET: /Clients/Details/5

        public ActionResult Details(Guid id)
        {
            ClientModel model = service.GetClientModelByID(id);
            return View(model);
        }

        //
        // GET: /Clients/Create

        public ActionResult Create()
        {
            ViewResult view = View();
            view.ViewData.Add("ImportTypes", service.GetAllClientTypes());
            return view;
        } 

        //
        // POST: /Clients/Create

        [HttpPost]
        public ActionResult Create(NewClientModel model)
        {
            try
            {              
                service.CreateNewClient(model,Request.Params);
                return RedirectToAction("Index");
            }
            catch(System.Exception ex)
            {
                ViewResult view = View();
                view.ViewData.Add("AccountSetupException",ex.Message);
                return view;
            }
        }
        
        //
        // GET: /Clients/Edit/5
 
        public ActionResult Edit(Guid Id)
        {
            ClientModel model = service.GetClientModelByID(Id); 
            return View(model);
        }

        //
        // POST: /Clients/Edit/5 

        [HttpPost]
        public ActionResult Edit(ClientModel model)
        {
            try
            {
                service.SaveClient(model,Request.Params);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public PartialViewResult ClientParametersView(ClientModel model)
        {
            PartialViewResult result = PartialView("_BlankClientParametersView");
            if (model.ImportTypeId == 1)
            {
                var parameters = service.GetClientParametersObject(model);
                model.ClientParametersObject = (MindBodyParameters)parameters;
                //if (model.ClientParameters != null)
                //    model.ClientParametersObject = new Models.MindBodyParameters(model.ClientParameters);
                //else
                //    model.ClientParametersObject = new Models.MindBodyParameters();
                result = PartialView("_MindBodyParametersView",model);
            }

            return result;
        }        

        public ActionResult Delete(Guid deleteId)
        {
            try
            {
                service.DeleteClient(deleteId);
                
            }
            catch
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        public ActionResult ClientInfoEdit(ClientModel model)
        {
            ClientModel vm = service.GetClientModelByID(model.Id); 
            return PartialView("_ClientInfoEdit", vm);
        }
    }
}
