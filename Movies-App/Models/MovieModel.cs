using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies-App.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string PublishedDate { get; set; }
        public bool IsLike { get; set; }
        public string Type { get; set; }
    }
}