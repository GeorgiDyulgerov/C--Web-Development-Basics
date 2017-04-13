using System;
using System.Collections.Generic;
using SoftUniStore.Models;

namespace SoftUniStore.ViewModels
{
    public class GameDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Trailer { get; set; }

        public string ImageThumbnail { get; set; }

        public double Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {
            string representation = $"<h1 class=\"display-3\">{this.Title}</h1>\r\n" +
                                    $"<br/>\r\n\r\n" +
                                    $"<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/{this.Trailer}\" frameborder=\"0\" allowfullscreen></iframe>\r\n\r\n" +
                                    $"<br/>\r\n<br/>\r\n\r\n<p>{this.Description}</p>\r\n\r\n" +
                                    $"<p><strong>Price</strong> - {this.Price}&euro;</p>\r\n" +
                                    $"<p><strong>Size</strong> - {this.Size} GB</p>\r\n" +
                                    $"<p><strong>Release Date</strong> - {this.ReleaseDate}</p>\r\n\r\n" +
                                    $"<a class=\"btn btn-outline-primary\" name=\"back\" href=\"javascript:history.back()\">Back</a>\r\n" +
                                    $"<form action=\"#\" method=\"post\">\r\n" +
                                    $"<input type=\"number\" value=\"2\" hidden=\"hidden\" />\r\n" +
                                    $"<br/>\r\n<a href=\"/game/buy?id={this.Id}\" type=\"submit\" class=\"btn btn-success\" value=\"Buy\">Buy</a>\r\n</form>\r\n<br/>\r\n<br/>";

            return representation;
        }
    }
}
