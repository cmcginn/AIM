using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Configuration;
using AIM.Data;
using AIM.Administration.Models;

namespace AIM.Administration.Controllers
{
    public class AccountController : Controller
    {

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
       
        public ActionResult RemoteLogon(string username, string password)
        {
            var clientAuth = new ClientFormsAuthenticationService();
            var authenticated = clientAuth.SignIn(new AllClientsAccountModel { UserName = username, Password = password });
            return JavaScript(String.Format("var valid={0};", authenticated.ToString().ToLower()));
        }
      /*All Clients Logon*/
        public ActionResult ClientLogon() {
          var model = new AllClientsAccountModel();
          return View( model );
        }
      [HttpPost]
        public ActionResult ClientLogon(AllClientsAccountModel model) {
          if( ModelState.IsValid ) {
            var clientAuth = new ClientFormsAuthenticationService();
            var authenticated = clientAuth.SignIn( model );
            if( authenticated )
              return RedirectToAction( "Index", "Import" );
            else
              ModelState.AddModelError( "", "The user name or password provided is incorrect." );
          }
          // If we got this far, something failed, redisplay form
          return View( model );
        }

      public ActionResult PasswordRecovery()
      {
          return View();
      }
      [HttpPost]
      public ActionResult PasswordRecovery(string email)
      {
          try
          {
              string password = string.Empty;
              using (var ctx = new DomainContext())
              {

                  var account = ctx.ClientProperties.SingleOrDefault(n => n.AllClientsUsername.ToLower() == email.ToLower());
                  ViewData.Add("Email", email);
                  ViewData.Add("Result", 2);
                  if (account != null)
                  {

                      password = account.AllClientsPassword;
                      var emailTemplate = String.Format("Your password is {0}", password);
                      string fromEmail = ConfigurationManager.AppSettings["SupportEmail"].ToString();
                      string toEmail = account.AllClientsUsername;
                      var message = new System.Net.Mail.MailMessage(fromEmail, toEmail);
                      message.Subject = "Fitness Auto Pilot Request";
                      message.Body = emailTemplate;

                      var smtp = new System.Net.Mail.SmtpClient();
                      var enableSsl = false;
                      bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["EnableSSL"], out enableSsl);
                      smtp.EnableSsl = enableSsl;   
                      smtp.Send(message);
                      ViewData["Result"] = 0;
                  }
                  else
                  {
                      ViewData["Result"] = 1;
                  }
              }
          }
          catch
          {
              ViewData["Result"] = 2;
          }
          return View();
      }
    }
}
