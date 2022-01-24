using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tinder.Models
{
    public class Reqres
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<User> data { get; set; }
    }
}
