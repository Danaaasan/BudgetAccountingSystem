using Microsoft.AspNetCore.Mvc;
using BudgetAccountingSystem.Models;

namespace BudgetAccountingSystem.Controllers
{
    public class TransactionController : Controller
    {
        private static readonly List<Transaction> Transactions = new()
        {
            new Transaction { Id = 1, AccountId = 1, Amount = 1500, Type = "Начисление", DebitAccount = "401.20", CreditAccount = "302.11", Description = "Начисление заработной платы", Date = new DateTime(2026, 10, 1) },
            new Transaction { Id = 2, AccountId = 1, Amount = 500, Type = "Списание", DebitAccount = "302.11", CreditAccount = "201.11", Description = "Выплата аванса", Date = new DateTime(2026, 10, 5) },
            new Transaction { Id = 3, AccountId = 2, Amount = 2000, Type = "Начисление", DebitAccount = "401.20", CreditAccount = "302.11", Description = "Начисление зарплаты", Date = new DateTime(2026, 10, 1) },
            new Transaction { Id = 4, AccountId = 4, Amount = 8500, Type = "Списание", DebitAccount = "302.21", CreditAccount = "201.11", Description = "Оплата услуг поставщика", Date = new DateTime(2026, 10, 3) },
            new Transaction { Id = 5, AccountId = 5, Amount = 2300, Type = "Списание", DebitAccount = "105.36", CreditAccount = "101.36", Description = "Списание материалов", Date = new DateTime(2026, 10, 7) }
        };

        private static int _nextId = 6;

        public IActionResult Index() => View(Transactions);

        public IActionResult Details(int id)
        {
            var transaction = Transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null) return NotFound();
            return View(transaction);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.Id = _nextId++;
                Transactions.Add(transaction);
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        public IActionResult Edit(int id)
        {
            var transaction = Transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null) return NotFound();
            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                var existing = Transactions.FirstOrDefault(t => t.Id == transaction.Id);
                if (existing == null) return NotFound();

                existing.AccountId = transaction.AccountId;
                existing.Amount = transaction.Amount;
                existing.Type = transaction.Type;
                existing.DebitAccount = transaction.DebitAccount;
                existing.CreditAccount = transaction.CreditAccount;
                existing.Description = transaction.Description;
                existing.Date = transaction.Date;

                return RedirectToAction("Index");
            }
            return View(transaction);
        }
    }
}