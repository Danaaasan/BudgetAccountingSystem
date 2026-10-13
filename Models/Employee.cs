using System.ComponentModel.DataAnnotations;

namespace BudgetAccountingSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите ФИО")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите должность")]
        [Display(Name = "Должность")]
        public string Position { get; set; } = string.Empty;

        [Display(Name = "Оклад")]
        [Range(0, 100000, ErrorMessage = "Оклад должен быть от 0 до 100000")]
        public decimal Salary { get; set; }

        [Display(Name = "Отдел")]
        public string Department { get; set; } = string.Empty;

        [Display(Name = "Активен")]
        public bool IsActive { get; set; } = true;
    }
}