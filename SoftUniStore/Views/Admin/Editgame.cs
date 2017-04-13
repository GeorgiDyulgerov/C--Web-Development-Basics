using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Views.Admin
{
    class Editgame :IRenderable<EditGameViewModel>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation;
            if (Data.Data.Context.Logins.Any(log => log.IsActive == true))
            {
                navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLog);
            }
            else
            {
                navigation = File.ReadAllText(Constants.ContentPath + Constants.NavNotLog);
            }
            string editGame = this.Model.ToString();

            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(editGame);
            builder.Append(footer);

            return builder.ToString();
        }

        public EditGameViewModel Model { get; set; }
    }
}
