using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UsersManagement.Models.dto
{
    public partial class User
    {
        [NotMapped]
        [JsonIgnore]
        public string Token { get; set; }
    }
}
