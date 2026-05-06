using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace FoodShop.Data
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public DateOnly? DateBirth { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public int JobId { get; set; }
        public Jobs? Job { get; set; }

        public int RoleId { get; set; }
        public Roles? Role { get; set; }

        public string? Remark { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public List<Invoices> Invoices { get; set; } = new List<Invoices>();
    }
}
