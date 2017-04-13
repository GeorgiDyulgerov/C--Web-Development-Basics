using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SoftUniStore.BindingModel;
using SoftUniStore.Models;
using SoftUniStore.Services;
using SoftUniStore.Utilities;

namespace SoftUniStore.Controllers
{
    public class UserController : Controller
    {
        private UserService service;

        public UserController()
        {
            this.service = new UserService();
        }

        [HttpGet]
        public IActionResult Register(HttpResponse response,HttpSession session)
        {
            if (AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/all");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, HttpSession session, UserRegisterBindingModel bind)
        {
            if (AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/all");
                return null;
            }
            if (!this.service.UserRegisterIsValid(bind))
            {
                this.Redirect(response,"/user/register");
                return null;
            }

            User user = this.service.GetUserFromRegisterBind(bind);
            this.service.RegisterUser(user);

            this.Redirect(response, "/user/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession session)
        {
            if (AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/all");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response,HttpSession session, UserLoginBindingModel bind)
        {
            if (AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/all");
                return null;
            } 
            if (!this.service.UserLoginIsValid(bind))
            {
                this.Redirect(response,"/user/login");
                return null;
            }

            User user = this.service.GetUserFromLoginBind(bind);
            this.service.LoginUser(user,session.Id);
            this.Redirect(response,"/home/all");
            return null;
        }

        [HttpGet]
        public void Logout(HttpResponse response, HttpSession session)
        {
            AuthenticationManager.Logout(response, session.Id);
            this.Redirect(response, "/home/all");
        }

    }
}
