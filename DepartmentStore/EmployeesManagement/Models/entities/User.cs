using System;
using System.Collections.Generic;

namespace EmployeesManagement.Models.entities
{
    public partial class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? Canread { get; set; }
        public bool? Canwrite { get; set; }
        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
    }
}
