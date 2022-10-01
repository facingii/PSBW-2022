using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UsersManagement.Models.dto
{
    public partial class User
    {
        [NotMapped]
        public string Token { get; set; }
    }
}
