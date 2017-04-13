using System.Collections;
using System.Collections.Generic;
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
    public class HomeController:Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<HomeViewModel>> All(HttpSession session)
        {
            AuthenticationManager.GetAuthenticatedUser(session.Id);
            IEnumerable<HomeViewModel> games = this.service.GetGames();
            return this.View(games);
        }

        [HttpGet]
        public IActionResult<IEnumerable<HomeViewModel>> Owned(HttpSession session,HttpResponse response)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (user == null)
            {
                this.Redirect(response,"/user/login");
                return null;
            }

            IEnumerable<HomeViewModel> games = this.service.GetOwnedGames(user);
            return this.View(games);
        }

    }
}
