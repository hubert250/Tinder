using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tinder.Models
{
    public class LocalUser: User
    {
        [MaxLength(255)]
        public string AboutMe { get; set; }

    }
}
