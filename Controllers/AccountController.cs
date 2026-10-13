using Microsoft.AspNetCore.Mvc;
using BudgetAccountingSystem.Models;

namespace BudgetAccountingSystem.Controllers
{
    public class AccountController : Controller
    {
        private static readonly List<Account> Accounts = new()
        {
            new Account { Id = 1, AccountNumber = "101.01", EmployeeId = 1, Balance = 15000, Currency = "BYN", AccountType = "Лицевой", IsActive = true },
            new Account { Id = 2, AccountNumber = "101.02", EmployeeId = 2, Balance = 27500, Currency = "BYN", AccountType = "Лицевой", IsActive = true },
            new Account { Id = 3, AccountNumber = "302.11", EmployeeId = 3, Balance = 5200, Currency = "BYN", AccountType = "Расчётный", IsActive = false },
            new Account { Id = 4, AccountNumber = "401.20", EmployeeId = 4, Balance = 98000, Currency = "BYN", AccountType = "Бюджетный", IsActive = true },
            new Account { Id = 5, AccountNumber = "105.36", EmployeeId = 5, Balance = 300, Currency = "BYN", AccountType = "Материальный", IsActive = true }
        };

        private static int _nextId = 6;

        public IActionResult Index() => View(Accounts);

        public IActionResult Details(int id)
        {
            var account = Accounts.FirstOrDefault(a => a.Id == id);
            if (account == null) return NotFound();
            return View(account);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                account.Id = _nextId++;
                Accounts.Add(account);
                return RedirectToAction("Index");
            }
            return View(account);
        }

        public IActionResult Edit(int id)
        {
            var account = Accounts.FirstOrDefault(a => a.Id == id);
            if (account == null) return NotFound();
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                var existing = Accounts.FirstOrDefault(a => a.Id == account.Id);
                if (existing == null) return NotFound();

                existing.AccountNumber = account.AccountNumber;
                existing.EmployeeId = account.EmployeeId;
                existing.Balance = account.Balance;
                existing.Currency = account.Currency;
                existing.AccountType = account.AccountType;
                existing.IsActive = account.IsActive;

                return RedirectToAction("Index");
            }
            return View(account);
        }
    }
}