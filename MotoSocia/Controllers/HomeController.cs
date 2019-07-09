using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application;
using Application.Commands.User;
using Domain.Entities;

namespace MotoSocia.Controllers
{
    public class HomeController : Controller
    {
        private Persistence.MotoDBContext _context;
        private Invoker Inv;

        public HomeController(Persistence.MotoDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            User full_user = new User()
            {
                Name = "Muhammed",
                Surname = "ikinci",
                Email = "muhammedikinci@outlook.com",
                UserName = "muhammed2843",
                Password = "1357911"
            };

            var Data = new DataTransport() { _context = _context, Data = full_user };
            var CreateUserCommand = new CreateNewUser(Data);

            Inv = new Invoker(CreateUserCommand);
            Inv.Execute();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
