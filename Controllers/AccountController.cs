using AutoMapper;
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
    private readonly IMapper _mapper;

    public AccountController(QuantContext context, IMapper mapper)
    {
      _quantContext = context;
      _mapper = mapper;
    }

    private static AccountSummary[] _accountSummaries = new AccountSummary[]
    {
        new AccountSummary { AccountNumber = "123-456-789", Balance = 1234.56, Name = "US CURRENT ACCOUNT", Type = AccountType.Checking },
        new AccountSummary { AccountNumber = "456-345-567", Balance = 3456.89, Name = "CAD CURRENT ACCOUNT", Type = AccountType.Savings },
        new AccountSummary { AccountNumber = "234-568-789", Balance = 2345.78, Name = "US INVESTMENT ACCOUNT", Type = AccountType.Investment },
    };

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAccountSummaries()
    {
      var accounts = await _quantContext.Accounts.Include(s => s.Transactions).ToListAsync();
      var accountSummaries = new List<AccountSummary>();

      foreach (var account in accounts)
      {
        var model = _mapper.Map<Account, AccountSummary>(account);
        accountSummaries.Add(model);
      }

      return new ObjectResult(accountSummaries);
    }

    [HttpGet("[action]/{id}")]
    public IActionResult GetAccountDetail(string id)
    {
      Account accountDetail = null;

      try
      {
        accountDetail = _quantContext.Accounts.Where(a => a.Id == Int32.Parse(id)).SingleOrDefault();
      }
      catch (InvalidOperationException e) { }

      if (accountDetail == null)
        return NotFound();

      var model = _mapper.Map<Account, AccountSummary>(accountDetail);
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

      return new ObjectResult(new AccountDetail { AccountSummary = model, AccountTransactions = transactions.ToArray() });
    }
  }
}
