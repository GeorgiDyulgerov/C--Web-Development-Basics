using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.Utilities;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Views.Home
{
    public class All:IRenderable<IEnumerable<HomeViewModel>>
    {
        public IEnumerable<HomeViewModel> Model { get; set; }

        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation;           
            if (Data.Data.Context.Logins.Any(log=>log.IsActive==true))
            {
               navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLog); 
            }
            else
            {
                navigation = File.ReadAllText(Constants.ContentPath + Constants.NavNotLog);
            }
            StringBuilder home = new StringBuilder();
            home.Append(
                "<main>\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-12\">\r\n                <a class=\"btn btn-link\" href=\"/home/all\">All</a>\r\n                <a class=\"btn btn-link\" href=\"/home/owned\">Owned</a>\r\n");
            int counter = 0;
            foreach (var vm in this.Model)
            {
                if (counter%3==0)
                {
                    home.Append("<div class=\"card-group\">");
                }
                home.Append(vm);
                counter++;
                if (counter%3==0)
                {
                    home.Append("</div>");
                }
            }
            home.Append(" </div>\r\n        </div>\r\n        </div>\r\n</main>");
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(home);
            builder.Append(footer);

            return builder.ToString();
        }

       
    }
}
