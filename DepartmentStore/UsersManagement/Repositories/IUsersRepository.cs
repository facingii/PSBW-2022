using UsersManagement.Models.dto;

namespace UsersManagement.Repositories
{
    public interface IUsersRepository
    {
        public IEnumerable<User> GetAll ();
    }
}

