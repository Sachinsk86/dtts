using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebApp1._0.Models;
using WebApp1._0.Security;

namespace WebApp1._0
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      GlobalConfiguration.Configure(WebApiConfig.Register);
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);

      //Database.SetInitializer<DBContext>(new DataContextInitilizer());
    }

    protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
    {
      HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
      if (authCookie != null)
      {

        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

        Model_userResultData serializeModel = JsonConvert.DeserializeObject<Model_userResultData>(authTicket.UserData);
        CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
        newUser.userid = serializeModel.userid;
        newUser.username = serializeModel.username;
        newUser.name = serializeModel.name;
        newUser.roles = serializeModel.roles;

        HttpContext.Current.User = newUser;
      }

    }
  }
}
