using System;
using UsersManagement.Models.dto;

namespace UsersManagement.Repositories.Impl
{
    public class RolesRepository : IRolesRepository
    {
        private readonly employeesContext _context;

        public RolesRepository (employeesContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAll ()
        {
            return _context.Roles;
        }
    }
}

