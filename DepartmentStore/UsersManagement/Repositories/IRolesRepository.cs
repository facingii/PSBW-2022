namespace UsersManagement.Repositories
{
    public interface IRolesRepository
    {
        public IEnumerable<Models.dto.Role> GetAll ();
    }
}

