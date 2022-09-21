using System.Text.Json.Serialization;

namespace EmployeesManagement.Models.entities
{
    public partial class Title
    {
        public int EmpNo { get; set; }

        [JsonPropertyName ("title")]
        public string Title1 { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public virtual Employee EmpNoNavigation { get; set; }
    }
}
