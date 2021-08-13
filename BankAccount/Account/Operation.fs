module Operation
// contains the deposit, withdraw, and auditAs function for the project

open Domain

/// Deposits an amount into an account
let deposit (amount: decimal) (account: Account) : Account = 
    { account with Balance = account.Balance + amount}

let withdraw (amount: decimal) (account: Account): Account = 
    if amount > account.Balance then account
    else { account with Balance = account.Balance - amount} // need to put Balance here

let auditAs (operationName: string) (audit: Account -> string -> unit)
    (operation: decimal -> Account -> Account) (amount: decimal) 
    (account: Account) : Account = 
        let newAccount = operation amount account
        if account.Balance = newAccount.Balance
        then audit newAccount "rejected"
        else audit newAccount operationName
        newAccount