using System.ComponentModel.DataAnnotations;

namespace BudgetAccountingSystem.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите номер счёта")]
        [Display(Name = "Номер счёта")]
        public string AccountNumber { get; set; } = string.Empty;

        [Display(Name = "ID владельца")]
        public int EmployeeId { get; set; }

        [Display(Name = "Баланс")]
        [Range(0, 10000000, ErrorMessage = "Баланс должен быть от 0 до 10 000 000")]
        public decimal Balance { get; set; }

        [Display(Name = "Валюта")]
        public string Currency { get; set; } = "BYN";

        [Display(Name = "Тип счёта")]
        public string AccountType { get; set; } = string.Empty;

        [Display(Name = "Дата открытия")]
        public DateTime OpenedAt { get; set; } = DateTime.Now;

        [Display(Name = "Активен")]
        public bool IsActive { get; set; } = true;
    }
}