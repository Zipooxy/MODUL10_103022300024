using Microsoft.AspNetCore.Mvc;x
using MODUL10_103022300024;
using System.Collections.Generic;



namespace MODUL10_103022300024.Controllers
{
    [Route("api/Movie")]
    [ApiController]

    public class MovieController : ControllerBase
    {
        private static List<Movie> movieList = new List<Movie>
        {
            new Movie("The Shawshank Redemption", "Frank Darabot", new List<string>{ "Tim RobbinsMorgan, FreemanBob, Gunton" } ,"A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
            new Movie("The Godfather", "Francis Ford Coppola", new List<string>{ "Marlon Brando, Al Pacino, James Caan" }, "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son."),
            new Movie("The Dark Knight", "Christopher Nolan", new List<string>{ "Christian Bale, Heath Ledger, Aaron Eckhart" }, "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice."),
        };

        //Get /api/Movies: mengembalikan outputtw berupa list/array dari semua objek Movies
        [HttpGet]
        public IEnumerable<Movie> GetAllMovies()
        {
            return movieList;
        }

        ////GET /api/Movies/{id}: mengembalikan output berupa objek Movie untuk index “id”
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            if (id < 0 || id >= movieList.Count)
            {
                return NotFound();
            }
            return Ok(movieList[id]);
        }

        //POST /api/Movies: menambahkan objek Movie baru
        [HttpPost]
        public ActionResult<Movie> CreateMovie([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }
            movieList.Add(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movieList.Count - 1 }, movie);
        }


        //DELETE /api/Movies/{id}: menghapus objek Movie pada index “id
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            if (id < 0 || id >= movieList.Count)
            {
                return NotFound();
            }
            movieList.RemoveAt(id);
            return NoContent();
        }
    }
}