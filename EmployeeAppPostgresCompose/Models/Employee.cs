namespace EmployeeApp.Models
{
    /// <summary>
    /// Represents an employee record in the system. Each employee has a
    /// unique identifier, a name and a salary. The salary is stored as
    /// a decimal to accommodate currency values.
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}