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
            var games = _gameRepository.GetGames();
            //fill the model
            var gamesIndexViewModel = new GamesIndexViewModel();
            gamesIndexViewModel.Games = games
                .Select(g => new BaseViewModel 
                {
                    Id = g.Id,
                    Value = g.Title,
                });
            //pass tot the view
            return View(gamesIndexViewModel);
        }

        public IActionResult ShowGame(int id)
        {
            //get the game using Id
            //check for null
            //fill the model
            //pass to the view
            var game  = _gameRepository.GetGames()
                .FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            var gamesShowGameViewModel = new GamesShowGameViewModel
            {
                Id = game.Id,
                Value = game.Title,
                Rating = game.Rating,
                Developer = new BaseViewModel
                {
                    Id = game.Developer.Id,
                    Value = game.Developer.Name
                }
            };
            return View(gamesShowGameViewModel);
        }
    }
}