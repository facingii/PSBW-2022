using System.ComponentModel.DataAnnotations.Schema;

namespace UsersManagement.Models.dto
{
    public partial class User
    {
        [NotMapped]
        public string Token { get; set; }
    }
}

