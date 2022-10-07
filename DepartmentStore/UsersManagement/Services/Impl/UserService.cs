using System;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UsersManagement.Models.dto;
using UsersManagement.Repositories;

namespace UsersManagement.Services.Impl;

public class UsersService : IUsersService
{    
    private readonly IUsersRepository _usersRepository;
    private readonly IRolesRepository _rolesRepository;
    private readonly JwtSettings _jwtSettings;

    public UsersService (IOptions<JwtSettings> options, IUsersRepository usersRepository, IRolesRepository rolesRepository)
    {
        _usersRepository = usersRepository;
        _rolesRepository = rolesRepository;
        _jwtSettings = options.Value;
    }

    public User Authenticate (string username, string password)
    {
        var users = _usersRepository.GetAll ();
        var user = users.SingleOrDefault (u => u.UserName == username && u.Password == password);
        if (user == null) return user;

        var roles = _rolesRepository.GetAll ();
        var role = roles.First (r => r.Id == user.IdRole);

        var tokenHandler = new JwtSecurityTokenHandler ();
        var key = System.Text.Encoding.ASCII.GetBytes (_jwtSettings.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor ()
        {
            Subject = new ClaimsIdentity ( 
                new Claim [] {
                        new Claim ("UserName", user.UserName),
                        new Claim ("DisplayName", $"{user.FirstName} {user.LastName}"),
                        new Claim ("CanRead", user.Canread.Value.ToString ()),
                        new Claim ("CanWrite", user.Canwrite.Value.ToString ()),
                        new Claim (ClaimTypes.Role, role.Name)
                }
            ),
            Expires = DateTime.Now.AddHours(1),
            NotBefore = DateTime.Now,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        user.Token = tokenHandler.WriteToken(token);
        user.Password = string.Empty;

        return user;
    }

    public IEnumerable<User> GetAll ()
    {
        var users = _usersRepository.GetAll ();
        return users.Select (u => {
            u.Password = "";
            u.Token = "";
            return u;
        });
    }
}

