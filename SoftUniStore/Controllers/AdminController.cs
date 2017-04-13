using System.Collections.Generic;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.BindingModel;
using SoftUniStore.Models;
using SoftUniStore.Services;
using SoftUniStore.Utilities;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Controllers
{
    public class AdminController : Controller
    {
        private AdminService service;

        public AdminController()
        {
            this.service=new AdminService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<AdminGamesViewModel>> Allgames(HttpSession session,HttpResponse response)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (user==null || user.IsAdmin == false)
            {
                this.Redirect(response,"/home/all");
                return null;
            }

            IEnumerable<AdminGamesViewModel> gamesVM = this.service.GetAllGames();

            return this.View(gamesVM);
        }

        [HttpGet]
        public IActionResult Addgame(HttpSession session, HttpResponse response)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (user == null || user.IsAdmin == false)
            {
                this.Redirect(response, "/home/all");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Addgame(HttpSession session, HttpResponse response,AddGameBindingModel bind)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (user == null || user.IsAdmin == false)
            {
                this.Redirect(response, "/home/all");
                return null;
            }

            if (!this.service.GameIsValid(bind))
            {
                this.Redirect(response,"/admin/AddGame");
                return null;
            }

            Game game = this.service.GetGameFromBind(bind);
            this.service.AddGame(game);

            return null;

        }

        [HttpGet]
        public IActionResult<DeleteGameViewModel> Deletegame(string id, HttpSession session, HttpResponse response)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (user == null || user.IsAdmin == false)
            {
                this.Redirect(response, "/home/all");
                return null;
            }

            DeleteGameViewModel deleteGame = this.service.GetGameForDeleteVM(int.Parse(id));

            return this.View(deleteGame);

        }

        [HttpPost]
        public IActionResult Deletegame(int id,HttpSession session, HttpResponse response)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (user == null || user.IsAdmin == false)
            {
                this.Redirect(response, "/home/all");
                return null;
            }

            Game game = this.service.GetGameForDelete(id);
            this.service.DeleteGame(game);
            this.Redirect(response,"/admin/AllGames");

            return null;

        }

        [HttpGet]
        public IActionResult<EditGameViewModel> Editgame(string id, HttpSession session, HttpResponse response)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (user == null || user.IsAdmin == false)
            {
                this.Redirect(response, "/home/all");
                return null;
            }

            EditGameViewModel editGame = this.service.GetGameForEditVM(int.Parse(id));

            return this.View(editGame);

        }

    }
}
