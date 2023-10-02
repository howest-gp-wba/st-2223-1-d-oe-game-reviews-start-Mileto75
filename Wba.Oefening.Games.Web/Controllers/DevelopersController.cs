using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Core;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly DeveloperRepository _developerRepository;

        public DevelopersController()
        {
            //initialize service classes
            _developerRepository = new DeveloperRepository();
        }

       
        public IActionResult Index()
        {
            return Content("I should make a view + view model for this!");
        }

      
        public IActionResult ShowDeveloper(int id)
        {
            return Content("I should make a view + view model for this!");
        }

    }
}