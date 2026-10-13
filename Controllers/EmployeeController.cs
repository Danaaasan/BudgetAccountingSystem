using Microsoft.AspNetCore.Mvc;
using BudgetAccountingSystem.Models;

namespace BudgetAccountingSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private static readonly List<Employee> Employees = new()
        {
            new Employee { Id = 1, FullName = "Иванов Иван Иванович", Position = "Бухгалтер", Salary = 1200, Department = "Бухгалтерия", IsActive = true },
            new Employee { Id = 2, FullName = "Петрова Анна Сергеевна", Position = "Экономист", Salary = 1500, Department = "Плановый отдел", IsActive = true },
            new Employee { Id = 3, FullName = "Сидоров Пётр Алексеевич", Position = "Кассир", Salary = 900, Department = "Бухгалтерия", IsActive = false },
            new Employee { Id = 4, FullName = "Козлова Мария Дмитриевна", Position = "Главный бухгалтер", Salary = 2500, Department = "Бухгалтерия", IsActive = true },
            new Employee { Id = 5, FullName = "Николаев Олег Викторович", Position = "Специалист по закупкам", Salary = 1100, Department = "Снабжение", IsActive = true }
        };

        private static int _nextId = 6;

        public IActionResult Index() => View(Employees);

        public IActionResult Details(int id)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = _nextId++;
                Employees.Add(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var existing = Employees.FirstOrDefault(e => e.Id == employee.Id);
                if (existing == null) return NotFound();

                existing.FullName = employee.FullName;
                existing.Position = employee.Position;
                existing.Salary = employee.Salary;
                existing.Department = employee.Department;
                existing.IsActive = employee.IsActive;

                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}