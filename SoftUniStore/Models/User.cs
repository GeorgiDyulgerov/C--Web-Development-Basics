using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace SoftUniStore.Models
{
    public class User
    {

        public User()
        {
            this.Games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }

        [RegularExpression("[a-zA-Z@.0-9]+")]
        [Index(IsUnique = true)]
        [StringLength(450)]
        public string Email { get; set; }

        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{6,}$")]
        [MinLength(6)]
        public string Password { get; set; }

        public string FullName { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Game> Games { get; set; }


    }
}
