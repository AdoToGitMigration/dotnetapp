using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EmployeeApp.Controllers
{
    /// <summary>
    /// Handles HTTP requests related to employees, including listing all
    /// employees and updating an employee’s salary. This controller relies on
    /// dependency injection to obtain an instance of the
    /// <see cref="AppDbContext"/> for data access.
    /// </summary>
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Displays the list of employees. The view uses a strongly typed
        /// model to render each employee and provide an inline form for
        /// updating the salary.
        /// </summary>
        /// <returns>The index view with the list of employees.</returns>
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        /// <summary>
        /// Processes a salary update for a given employee. The method expects
        /// an employee identifier and the new salary value. If the employee
        /// exists, their salary is updated and the changes are persisted.
        /// </summary>
        /// <param name="id">The primary key of the employee to update.</param>
        /// <param name="salary">The new salary value.</param>
        /// <returns>A redirection back to the index action.</returns>
        [HttpPost]
        public IActionResult UpdateSalary(int id, decimal salary)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employee.Salary = salary;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}