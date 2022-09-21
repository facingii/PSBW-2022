namespace EmployeesManagement.Models.entities
{
    public partial class CurrentDeptEmp
    {
        public int EmpNo { get; set; }
        public string DeptNo { get; set; }
        public DateOnly? FromDate { get; set; }
        public DateOnly? ToDate { get; set; }
    }
}
