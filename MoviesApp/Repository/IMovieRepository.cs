using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Repository
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetMovies();

        Task<Movie> GetMovie(int? id);

        Task<int> AddMovie(Movie movie);

        Task<int> DeleteMovie(int? id);

        Task Updatemovie(Movie movie);
    }
}
