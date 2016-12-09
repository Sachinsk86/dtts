using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApp1._0.Security
{
  public class CustomPrincipal : IPrincipal
  {
    public IIdentity Identity { get; private set; }
    public bool IsInRole(string role)
    {
      if (roles.Any(r => role.Contains(r)))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public CustomPrincipal(string username)
    {
      this.Identity = new GenericIdentity(username);
    }

    public int userid { get; set; }
    public string username { get; set; }
    public string name { get; set; }
    public string[] roles { get; set; }
  }
}