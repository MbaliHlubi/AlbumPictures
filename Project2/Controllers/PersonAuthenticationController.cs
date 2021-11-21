using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.Database;
using Project2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Controllers
{
  
    public class PersonAuthenticationController : Controller
    {
        DBContext database;

        public PersonAuthenticationController(DBContext x)
        {
            database = x;
        }
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(LoginInformation loginInformation)
        {
            People person = database.people.Where(e => e.person_userName.Equals(loginInformation.username) && e.password.Equals(loginInformation.password)).First();
            if (person == null)
            {
                return NotFound();
            }
            else {
                HttpContext.Response.Cookies.Append("user_name", person.person_name);
                HttpContext.Response.Cookies.Append("user", person.person_userName);
                return RedirectToActionPermanent("Index", "Home");
            }
            return View();
        }

        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserRegister(People person)
        {
            People user = new People();
            user.person_id = new Guid();
            user.person_name = person.person_name;
            user.person_surname = person.person_userName;
            user.password = person.password;
            user.person_userName = person.person_userName;
            database.people.Add(user);
            database.SaveChanges();
            return RedirectToActionPermanent("UserLogin");
        }
    }
}
