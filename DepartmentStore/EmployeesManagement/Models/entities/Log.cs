using System;
using System.Collections.Generic;

namespace EmployeesManagement.Models.entities
{
    public partial class Log
    {
        public long Id { get; set; }
        public string Exception { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Properties { get; set; }
        public string Timestamp { get; set; }
    }
}
