using System.Web.Mvc;

namespace AIM.Administration
{
    public abstract class ApplicationViewPage<TModel> : WebViewPage<TModel> where TModel : class
    {
        protected string Error
        {
            get
            {
                return TempData.ContainsKey("error") ? TempData["error"].ToString() : string.Empty;
            }
        }

        protected string Success
        {
            get
            {
                return TempData.ContainsKey("success") ? TempData["success"].ToString() : string.Empty;
            }
        }

        protected string ControllerName
        {
            get
            {
                return ViewContext.RouteData.GetRequiredString("controller");
            }
        }

        protected string ActionName
        {
            get
            {
                return ViewContext.RouteData.GetRequiredString("action");
            }
        }
    }
}