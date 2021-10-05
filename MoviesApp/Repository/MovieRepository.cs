using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MovieContext db;
        public MovieRepository(MovieContext context)
        {
           db = context;
        }

        async Task<int> IMovieRepository.AddMovie(Movie movie)
        {
            if (db != null)
            {
                await db.Movies.AddAsync(movie);
                await db.SaveChangesAsync();

                return movie.Id;
            }

            return 0;
        }

        async Task<int> IMovieRepository.DeleteMovie(int? id)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var post = await db.Movies.FirstOrDefaultAsync(x => x.Id == id);

                if (post != null)
                {
                    //Delete that post
                    db.Movies.Remove(post);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        async Task<Movie> IMovieRepository.GetMovie(int? id)
        {
            if (db != null)
            {
                return await(from p in db.Movies
                             where p.Id == id
                             select new Movie
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 Type = p.Type,
                                 PublishedDate = p.PublishedDate,
                                 IsLike = p.IsLike,
                                 Rating = p.Rating
                             }).FirstOrDefaultAsync();
            }

            return null;
        }

        async Task<List<Movie>> IMovieRepository.GetMovies()
        {
            if (db != null)
            {
                return await db.Movies.ToListAsync();
            }

            return null;
        }

        async Task IMovieRepository.Updatemovie(Movie movie)
        {
            if (db != null)
            {
                //Delete that post
                db.Movies.Update(movie);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
