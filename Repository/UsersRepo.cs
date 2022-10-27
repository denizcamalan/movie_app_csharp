using movie_api.Interface;
using movie_api.Models;
using Microsoft.EntityFrameworkCore;
using movie_api.Data;

namespace movie_api.Repository
{
    public class UsersRepo : IUser
    {
        readonly DatabaseContext _dbContext = new();

        public UsersRepo(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(Users User)
        {
            try
            {
                _dbContext.Users.Add(User);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

    }
}