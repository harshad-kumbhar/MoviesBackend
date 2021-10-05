using Movies-App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies-App.Interfaces
{
    public interface IMovieService
    {
        int Delete(int Id);
        Movie GetByJobId(int ID);
        string Update(Movie job);
        int Create(Movie JobDetails);
        List<Movie> ListAll();
    }
}