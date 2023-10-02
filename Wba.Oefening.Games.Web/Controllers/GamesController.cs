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

        public IActionResult ShowGame(int id)
        {
            //get the game
            var game = _gameRepository
                .GetGames()
                .FirstOrDefault(g => g.Id == id);
            //check if exists
            if(game == null) 
            {
                return NotFound();
            }
            //fill the model
            var gamesShowGameViewModel
                = new GamesShowGameViewModel
                {
                    Id = game.Id,
                    Text = game.Title,
                    Rating = game.Rating,
                    Developer = new BaseviewModel
                    {
                        Id = game.Developer.Id,
                        Text = game.Developer.Name
                    }
                };
            //pass to view
            return View(gamesShowGameViewModel);
        }
    }
}