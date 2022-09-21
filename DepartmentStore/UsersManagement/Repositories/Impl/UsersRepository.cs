using System;
using UsersManagement.Models.dto;

namespace UsersManagement.Repositories.Impl;

public class UsersRepository : IUsersRepository
{
    private readonly employeesContext _context;

    public UsersRepository (employeesContext context)
    {
        _context = context;
    }

    public IEnumerable<User> GetAll ()
    {
        return _context.Users.ToList ();
    }
}

