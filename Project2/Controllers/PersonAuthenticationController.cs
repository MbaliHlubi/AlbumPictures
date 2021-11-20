using Microsoft.AspNetCore.Mvc;
using Project2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    public class PersonAuthenticationController : Controller
    {
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(LoginInformation loginInformation)
        {
            return View();
        }

        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserRegister(People person)
        {
            return View();
        }
    }
}
