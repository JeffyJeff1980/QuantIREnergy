using QuantIREnergy2.Models;
using QuantIREnergy2.ViewModels;

public class MappingProfile : AutoMapper.Profile
{
  public MappingProfile()
  {
    // Add as many of these lines as you need to map your objects
    CreateMap<Account, AccountSummary>();
    CreateMap<AccountSummary, Account>();
  }
}