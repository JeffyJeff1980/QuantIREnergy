using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantIREnergy2.ViewModels
{
  public class AccountDetail
  {
    public AccountSummary AccountSummary { get; set; }
    public AccountTransaction[] AccountTransactions { get; set; }
  }
}
