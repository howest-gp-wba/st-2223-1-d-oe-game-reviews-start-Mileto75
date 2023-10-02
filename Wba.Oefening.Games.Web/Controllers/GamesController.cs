using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Core;
using Wba.Oefening.Games.Web.ViewModels;

namespace Wba.Oefening.Games.Web.Controllers
{

    public class GamesController : Controller
    {
        private readonly GameRepository _gameRepository;

        public GamesController()
        {
            _gameRepository = new GameRepository();
        }

       
        public IActionResult Index()
        {
            //get the data
            //fill the model
            //pass tot the view
            var gamesIndexViewModel = new GamesIndexViewModel
            {
                Games = _gameRepository
                .GetGames()
                .Select(g => new BaseviewModel 
                {
                    Id = g.Id,
                    Text = g.Title
                })
            };
            return View(gamesIndexViewModel);
        }

        public IActionResult SearchByTitle(string title)
        {
            return View();
        }
        public IActionResult ShowGame(int id)
        {
            return Content("I should make a view + view model for this!");
        }

    }
}