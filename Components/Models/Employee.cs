using System.ComponentModel.DataAnnotations;
public class Employee
    {
        [Key]
        public int EmployeeId { get; set; } = 0;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";
        public double Payrate { get; set; } = 0.0;
        public double Hours { get; set; } = 0.0;
    }