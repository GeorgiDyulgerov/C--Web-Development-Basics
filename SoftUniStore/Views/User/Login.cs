﻿using System.IO;
using System.Text;
using SimpleMVC.Interfaces;

namespace SoftUniStore.Views.User
{
    public class Login : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavNotLog);
            string login = File.ReadAllText(Constants.ContentPath + Constants.Login);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(login);
            builder.Append(footer);

            return builder.ToString();
        }

    }
}
