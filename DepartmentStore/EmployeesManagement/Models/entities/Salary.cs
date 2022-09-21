using System.Text.Json.Serialization;

namespace EmployeesManagement.Models.entities
{
    public partial class Salary
    {
        public int EmpNo { get; set; }

        [JsonPropertyName ("salary")]
        public int Salary1 { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public virtual Employee EmpNoNavigation { get; set; }
    }
}
