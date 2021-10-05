using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;
using MoviesApp.Repository;

namespace MoviesApp.Controllers
{
    [EnableCors()]
    [Route("api/movies")]
    public class MoviesController : Controller
    {
    
        IMovieRepository movieRepository;

        public MoviesController(IMovieRepository _movieRepository)
        {
            movieRepository = _movieRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetMovies()
        {
            try
            {
                var movies = await movieRepository.GetMovies();
                if (movies == null)
                {
                    return NotFound();
                }

                return Ok(movies);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [Route("Add")]
        public async Task<IActionResult> AddMovie([FromBody] Movie model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await movieRepository.AddMovie(model);
                    if (postId > 0)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await movieRepository.DeleteMovie(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [Route("UpdateMovie")]
        public async Task<IActionResult> UpdateMovie([FromBody] Movie model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await movieRepository.Updatemovie(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetPost(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var movie = await movieRepository.GetMovie(id);

                if (movie == null)
                {
                    return NotFound();
                }

                return Ok(movie);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
