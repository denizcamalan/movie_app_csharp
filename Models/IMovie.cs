using movie_api.Models;
namespace movie_api.Interface
{
    public interface IMovies
    {
        public List<Movies> ListMovies();
        public Movies GetMoviesById(int id);
        public void AddMovie(Movies employee);
        public void UpdateMovie(Movies employee);
        public Movies DeleteMovie(int id);
        public bool CheckMovie(int id);
    }
}