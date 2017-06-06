using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuantIREnergy2.Data;
using QuantIREnergy2.Models;
using QuantIREnergy2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantIREnergy2.Controllers
{
  [Route("api/[controller]")]
  public class AccountController : Controller
  {
    private QuantContext _quantContext;

    public AccountController(QuantContext context)
    {
      _quantContext = context;
    }

    private static AccountSummary[] _accountSummaries = new AccountSummary[]
    {
        new AccountSummary { AccountNumber = "123-456-789", Balance = 1234.56, Name = "US CURRENT ACCOUNT", Type = AccountType.Checking },
        new AccountSummary { AccountNumber = "456-345-567", Balance = 3456.89, Name = "CAD CURRENT ACCOUNT", Type = AccountType.Savings },
        new AccountSummary { AccountNumber = "234-568-789", Balance = 2345.78, Name = "US INVESTMENT ACCOUNT", Type = AccountType.Investment },
    };

    [HttpGet("[action]")]
    public IActionResult GetAccountSummaries()
    {
        return new ObjectResult(_accountSummaries);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAccountSummariesFromDB()
    {
      var accountSummaries = await _quantContext.Accounts
        .Include(s => s.Transactions).ToListAsync();

      return new ObjectResult(_accountSummaries);
    }

    [HttpGet("[action]/{id}")]
    public IActionResult GetAccountDetail(string id)
    {
      var summary = _accountSummaries.FirstOrDefault(a => a.AccountNumber == id);
      if (summary == null)
        return NotFound();

      var random = new Random();
      var transactions = new List<AccountTransaction>();
      for (int i = 0; i < 15; i++)
      {
        transactions.Add(new AccountTransaction
        {
          TransactionDate = DateTimeOffset.Now - TimeSpan.FromDays(i),
          Description = $"Server transaction #{i}",
          Amount = random.NextDouble() * 500 - 250
        });
      }

      return new ObjectResult(new AccountDetail { AccountSummary = summary, AccountTransactions = transactions.ToArray() });
    }
  }
}
