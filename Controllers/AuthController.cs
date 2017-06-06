using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantIREnergy2.Controllers
{
  public class AuthController : Controller
  {
    public object CookieAuthenticationDefaults { get; private set; }

    public void SignIn()
    {
      // Send an OpenID Connect sign-in request.
      //if (!Request.IsAuthenticated)
      //{
      //  HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" },
      //      OpenIdConnectAuthenticationDefaults.AuthenticationType);
      //}
    }

    public void SignOut()
    {
      //string callbackUrl = Url.Action("SignOutCallback", "Account", routeValues: null, protocol: Request.Url.Scheme);

      //HttpContext.GetOwinContext().Authentication.SignOut(
      //    new AuthenticationProperties { RedirectUri = callbackUrl },
      //    OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
    }

    public ActionResult SignOutCallback()
    {
      //if (Request.IsAuthenticated)
      //{
      //  // Redirect to home page if the user is authenticated.
      //  return RedirectToAction("Index", "Home");
      //}

      return View();
    }
  }
}
