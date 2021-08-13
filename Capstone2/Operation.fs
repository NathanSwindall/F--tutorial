module Operation

open Domain

let _deposit (amount: decimal) (account:Account): Account =
    { account with Balance= account.Balance + amount}

let _withdraw (amount: decimal) (account: Account): Account = 
    if amount > account.Balance then account
    else { account with Balance = account.Balance - amount}

let console (account:Account) message = 
    printfn "Account %s: %s. Balance is now $%s. " (account.AccountId.ToString()) message (account.Balance.ToString())


let depositMessage (amount: decimal) = sprintf "Performed operation 'Depoist for $%.2f"  amount

let withdrawMessage (amount: decimal) = sprintf "Peformed opersation 'Withdraw for $%.2f" amount

