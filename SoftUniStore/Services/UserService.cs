
using System.Text.RegularExpressions;
using AutoMapper;
using SoftUniStore.BindingModel;
using SoftUniStore.Models;

namespace SoftUniStore.Services
{
    public class UserService : Service
    {
        public bool UserRegisterIsValid(UserRegisterBindingModel bind)
        {
            if (string.IsNullOrEmpty(bind.FullName))
            {
                return false;
            }

            if (bind.Password.Length < 6)
            {
                return false;
            }

            Regex passRegx = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{6,}$");
            if (!passRegx.IsMatch(bind.Password))
            {
                return false;
            }

            if (bind.Password != bind.ConfirmPassword)
            {
                return false;
            }

            Regex emailRegx = new Regex("[a-zA-Z@.0-9]+");
            if (!emailRegx.IsMatch(bind.Email))
            {
                return false;
            }

            return true;
        }

        public User GetUserFromRegisterBind(UserRegisterBindingModel bind)
        {
            User user = Mapper.Map<UserRegisterBindingModel, User>(bind);
            return user;
        }

        public void RegisterUser(User user)
        {
            if (this.Context.Users.Count() == 0)
            {
                user.IsAdmin = true;
            }
            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }

        public User GetUserFromLoginBind(UserLoginBindingModel bind)
        {
            return this.Context.Users.FirstOrDefault(user => user.Email == bind.Email && user.Password == bind.Password);
        }

        public bool UserLoginIsValid(UserLoginBindingModel bind)
        {
            return this.Context.Users.Any(user => user.Email == bind.Email && user.Password == bind.Password);
        }


        public void LoginUser(User user, string id)
        {
            Login login = new Login()
            {
                SessionId = id,
                User = user,
                IsActive = true
            };

            this.Context.Logins.Add(login);
            this.Context.SaveChanges();
        }
    }
}
