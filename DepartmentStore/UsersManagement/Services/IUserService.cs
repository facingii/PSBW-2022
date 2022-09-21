using System;
using UsersManagement.Models.dto;

namespace UsersManagement.Services;

public interface IUsersService
{
    User Authenticate(string username, string password);
    IEnumerable<User> GetAll();
}
