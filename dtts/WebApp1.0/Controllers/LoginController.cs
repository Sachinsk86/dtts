using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp1._0.Models;

namespace WebApp1._0.Controllers
{
  public class LoginController : Controller
  {
    private DBContext _db = new DBContext();
    public ActionResult Login()
    {
      Session.Abandon();
      FormsAuthentication.SignOut();
      return View();
    }

    [HttpPost]
    //[ValidateAntiForgeryToken()]
    public ActionResult Login(Model_muser user)
    {
      try
      {
        if (user.useremailid != null && user.password != null)
        {
          var userExistOrNot = _db.Users.Single(d => d.useremailid == user.useremailid && d.password == user.password);

          if (userExistOrNot != null) // check user exist
          {
            var roles = _db.roles.Where(r => r.roleid == userExistOrNot.ref_roleid).Select(r => r.rolename).ToArray(); // get all roles

            Model_userResultData userdata = new Model_userResultData(); // required data after login
            userdata.userid = userExistOrNot.userid;
            userdata.username = userExistOrNot.username;
            userdata.name = userExistOrNot.name;
            userdata.roles = roles;

            string userData = JsonConvert.SerializeObject(userdata); // convert to json

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
            1,
            user.useremailid,
            DateTime.Now,
            DateTime.Now.AddMinutes(30),
            false, //pass here true, if you want to implement remember me functionality
            userData);  // Authenticate data

            string encTicket = FormsAuthentication.Encrypt(authTicket); // encrypt
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(faCookie); // Add to cookie

            //System.Web.HttpContext.Current.Session["UserName"] = userExistOrNot.username;
            return RedirectToAction("Index", "Dashboard");
          }
          else
          {
            return View();
          }
        }
      }
      catch (Exception ex)
      {
        Console.Write(ex.Message);
      }
      return View();
    }
  }
}