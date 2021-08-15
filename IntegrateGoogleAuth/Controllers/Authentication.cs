using System;
using System.IO;
using System.Net;
using System.Text;
using IntegrateGoogleAuth.Models;
using IntegrateGoogleAuth.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static IntegrateGoogleAuth.Utils.GoogleAuthHelper;

namespace IntegrateGoogleAuth.Controllers
{
    public class Authentication : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Login()
        {
            var url = GetAuthenticationUri(GoogleAuth.ClientId, GoogleAuth.RedirectUrl).ToString();
            return Redirect(url);
        }

        [HttpGet("google-login")]
        public IActionResult GoogleLogin()
        {
            var code = HttpContext.Request.Query["code"];

            if (string.IsNullOrEmpty(code))
                return RedirectToAction("Error", "Authentication");

            var googleAccess = GetGoogleAccess(code);
            return googleAccess == null ? RedirectToAction("Error", "Authentication") : RedirectToAction("GoogleProfile", new { accessToken = googleAccess.AccessToken });
        }

        public IActionResult GoogleProfile(string accessToken)
        {
            var profile = GetUserProfile(accessToken);

            if (profile == null)
                return RedirectToAction("Error", "Authentication");

            return View(profile);
        }
    }
}
