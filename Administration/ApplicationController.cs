using System.Web.Mvc;
using AIM.Administration.Models;
namespace AIM.Administration
{
    public abstract class ApplicationController : Controller
    {
        private AllClientsAccountModel _Account;

        protected AllClientsAccountModel Account
        {
            get {
                if (_Account == null)
                    GetAccount();
                return _Account; 
            }
            set { _Account = value; }
        }

        protected void GetAccount()
        {
            if (Session["allClientsAccountModel"] != null)
            {
                _Account = Session["allClientsAccountModel"] as AllClientsAccountModel;    
          
            }
            if (_Account == null)
                Response.Redirect("~/Account/ClientLogon");
        }
        protected string ControllerName
        {
            get
            {
                return ControllerContext.RouteData.GetRequiredString("controller");
            }
        }

        protected string ActionName
        {
            get
            {
                return ControllerContext.RouteData.GetRequiredString("action");
            }
        }

        protected void AddError(string error, params object[] args)
        {
            AddError(string.Format(error, args));
        }

        protected void AddError(string error)
        {
            TempData["error"] = error;
        }

        protected void AddSuccess(string success, params object[] args)
        {
            AddSuccess(string.Format(success, args));
        }

        protected void AddSuccess(string success)
        {
            TempData["success"] = success;
        }
        protected ActionResult RedirectToHome
        {
            get
            {
                return RedirectToAction("Index", "Import");
            }
        }
    }
}