using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tinder.Models
{
    public class User
    {
        [PrimaryKey]
        [JsonProperty("id")]
        public int Id { get; set; }

        [MaxLength(255)]
        [JsonProperty("email")]
        public string Email { get; set; }

        [MaxLength(100)]
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [MaxLength(255)]
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [Ignore]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
