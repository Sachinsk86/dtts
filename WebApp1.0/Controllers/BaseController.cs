using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1._0.Models;
using WebApp1._0.Security;

namespace WebApp1._0.Controllers
{
  public class BaseController : Controller
  {
    protected virtual new CustomPrincipal User
    {
      get { return HttpContext.User as CustomPrincipal; }
    }
  }
}