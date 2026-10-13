using System.ComponentModel.DataAnnotations;

namespace BudgetAccountingSystem.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Display(Name = "ID счёта")]
        public int AccountId { get; set; }

        [Display(Name = "Сумма")]
        [Range(0.01, 1000000, ErrorMessage = "Сумма должна быть больше 0")]
        public decimal Amount { get; set; }

        [Display(Name = "Тип операции")]
        public string Type { get; set; } = string.Empty;

        [Display(Name = "Дебет")]
        public string DebitAccount { get; set; } = string.Empty;

        [Display(Name = "Кредит")]
        public string CreditAccount { get; set; } = string.Empty;

        [Display(Name = "Назначение")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Дата")]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}