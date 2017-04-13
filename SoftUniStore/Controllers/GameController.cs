using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.Models;
using SoftUniStore.Services;
using SoftUniStore.Utilities;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Controllers
{
    public class GameController:Controller
    {
        private GameService service;

        public GameController()
        {
            this.service = new GameService();
        }

        [HttpGet]
        public IActionResult<GameDetailsViewModel> Details(int id,HttpSession session)
        {
            AuthenticationManager.GetAuthenticatedUser(session.Id);

            GameDetailsViewModel gameDetails = this.service.GetGameDetails(id);

            return this.View(gameDetails);
        }

        [HttpGet]
        public void Buy(int id, HttpSession session,HttpResponse response)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (user==null)
            {
                this.Redirect(response,"/user/login");
                return;
            }

            this.service.BuyGame(user, id);
            this.Redirect(response,"/home/owned");
            
        }
    }
}
