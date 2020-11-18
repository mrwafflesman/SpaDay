using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/User/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/User")]
        public IActionResult SubmitAddUserForm (User newUser, string verify)
        {
            if (newUser.Verify(verify))
            {
                ViewBag.username = newUser.Username;
                ViewBag.email = newUser.Email;
                return View("Index");
            }
            else
            {
                ViewBag.username = newUser.Username;
                ViewBag.email = newUser.Email;
                ViewBag.error = "Password does not match.";
                return View("Add");
            }
        }
    }
}
