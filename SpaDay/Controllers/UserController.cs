using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/user/add")]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        [Route("/user")]
        public IActionResult SubmitAddUserForm (User newUser, string verify)
        {
            
            if (newUser.Password == verify)
            {
                ViewBag.username = newUser.Name;
                ViewBag.email = newUser.email;
                return View("Index");
            }
            else
            {
                ViewBag.error = "Password does not match.";
                return View("Add");
            }
        }
    }
}
