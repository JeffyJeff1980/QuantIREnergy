import { Component, OnInit } from '@angular/core';
import { AccountSummary } from '../../shared/account-summary.type';
import { AccountService } from '../../shared/account.service';
import { AccountType } from '../../shared/account-type.enum';

@Component({
  selector: 'account-list',
  templateUrl: './account-list.component.html',
  styleUrls: ['./account-list.component.css']
})
export class AccountListComponent implements OnInit {
  bankAccounts: AccountSummary[];
  investAccounts: AccountSummary[];

  constructor(private accountService: AccountService) {
  }

  ngOnInit() {
    this.accountService.getAccountSummaries()
      .then(accounts => {
        this.bankAccounts = accounts.filter(
          o => o.type === AccountType.Checking || o.type === AccountType.Savings
        );
        this.investAccounts = accounts.filter(
          o => o.type === AccountType.Investment
        );
      });
  }
}
