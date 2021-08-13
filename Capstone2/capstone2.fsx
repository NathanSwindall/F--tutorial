open System


type Owner = {
    Id: Guid
    FirstName: string
    LastName : string
}


type Account = {
    Balance: decimal
    AccountId: Guid
    Owner: Owner
}

type Statement = Withdraw | Deposit


// let deposit (amount: decimal) (account:Account): Account = 
//     { AccountId = Guid.Empty; Owner = { FirstName = "Nathan"; LastName = "Swindall"; Id = 1}; Balance=10M } //M is million

let myAccount = { AccountId = Guid.Empty; Owner = { FirstName = "Nathan"; LastName = "Swindall"; Id = Guid.Empty}; Balance=10M }

let myAccount_2 = let myId = Guid.NewGuid()
                  { AccountId = myId; Owner = { FirstName = "Nathan"; LastName = "Swindall"; Id = myId}; Balance=10M }

let deposit (amount: decimal) (account:Account): Account =
    { account with Balance= account.Balance + amount}

let withdraw (amount: decimal) (account: Account): Account = 
    if amount > account.Balance then account
    else { account with Balance = account.Balance + amount}


let statement (state: Statement) (amount: decimal) (account: Account) = 
    match state with 
        | Withdraw -> { account with Balance = account.Balance - amount}
        | Deposit -> { account with Balance = account.Balance + amount}

let easyDeposit = statement Deposit (100.00M: decimal) myAccount_2
let depo = statement Deposit

myAccount_2
|> depo 100M 
|> depo 10M 
|> depo 1000M 
|> depo 1234M 
|> depo (-123M)

myAccount_2
|> withdraw 10M 
|> depo 1000M 
|> withdraw 99.99999M
|> depo 10M


let console (account:Account) message = 
    printf "Account %s: %s. Balance is now $%s. " (account.AccountId.ToString()) message (account.Balance.ToString())

console myAccount_2 "made a withdraw of 50"

let depositMessage (amount: decimal) = sprintf "Performed operation 'Depoist for $%.2f"  amount
console myAccount_2 (depositMessage 10M)

let withdrawMessage (amount: decimal) = sprintf "Peformed opersation 'Withdraw for $%.2f" amount


// dependency operations: operationName audit operation
// None dependency operations: amount account
//operationName withdraw depoist

let auditAs operationName audit amount account = 
    match operationName with 
        | Deposit -> let account = deposit amount account
                     audit account (depositMessage amount)
                     account
        | Withdraw -> let account = withdraw amount account
                      audit account (withdrawMessage amount)
                      account
let _nathan = "Nathan"
//audit console audit function or other audit function

//operation operation function

//amount the amount to use

//account account

//deposit with console
//withdraw with console

