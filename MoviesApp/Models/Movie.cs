
namespace MoviesApp.Models
{
    public class Movie
    {
        public string Name { get; set;  }
        public int Id { get; set;  }
        public string Type { get; set;  }
        public string PublishedDate { get; set;  }
        public int Rating { get; set;  }
        public bool IsLike { get; set; }
    }
}
