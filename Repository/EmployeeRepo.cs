using movie_api.Interface;
using movie_api.Models;
using Microsoft.EntityFrameworkCore;
using movie_api.Data;

namespace movie_api.Repository
{
    public class MovieRepo : IMovies
    {
        readonly DatabaseContext _dbContext = new();

        public MovieRepo(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Movies> ListMovies()
        {
            try
            {
                return _dbContext.Movies.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Movies GetMoviesById(int id)
        {
            try
            {
                Movies? Movies = _dbContext.Movies.Find(id);
                if (Movies != null)
                {
                    return Movies;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddMovie(Movies Movies)
        {
            try
            {
                _dbContext.Movies.Add(Movies);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateMovie(Movies Movies)
        {
            try
            {
                _dbContext.Entry(Movies).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Movies DeleteMovie(int id)
        {
            try
            {
                Movies? Movies = _dbContext.Movies.Find(id);

                if (Movies != null)
                {
                    _dbContext.Movies.Remove(Movies);
                    _dbContext.SaveChanges();
                    return Movies;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckMovie(int id)
        {
            return _dbContext.Movies.Any(e => e.Id == id);
        }
    }
}