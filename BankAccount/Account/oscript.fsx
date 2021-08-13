open System
open System.IO

type Customer = {Name : string}

type Account = { Owner: Customer
                 Balance: decimal 
                 AccountId: Guid}




// let deposit (amount: decimal) (account: Account) : Account = 
//     { AccountId = Guid.Empty; Owner = {Name = "Nathan"}; Balance = 10M }

let deposit (amount: decimal) (account: Account) : Account = 
    { account with Balance = account.Balance + amount}

let withdraw (amount: decimal) (account: Account): Account = 
    if amount > account.Balance then account
    else { account with Balance = account.Balance - amount} // need to put Balance here

let myAccount = {AccountId = Guid.Empty; Owner = {Name = "Nathan"}; Balance = 10M}
let firstWithdraw = withdraw (5M) myAccount

type latLong = {lat: float
                long: float}
let g1 = {lat=1.1; long=2.2}
let g2 = {g1 with lat=99.9}

let newAccount = {myAccount with Owner = {Name = "Johnson"}}

let customer = {Name = "Nathan"}
let account = { AccountId = Guid.Empty; Owner = customer; Balance = 90M}

// Test out withdraw
let newAccount2 = account |> withdraw 10M     

//
let console (account: Account) message = printfn "Account %A %s" account.AccountId message
console (newAccount2) "Hello"

type Transaction = 
            | Withdraw
            | Deposit
            | Exit

let auditAs (operationName: string) (audit: Account -> string -> unit)
    (operation: decimal -> Account -> Account) (amount: decimal) 
    (account: Account) : Account = 
        let newAccount = operation amount account
        if account.Balance = newAccount.Balance
        then audit newAccount "rejected"
        else audit newAccount operationName
        newAccount



auditAs "deposit" console deposit 10M account
auditAs "withdraw" console withdraw 100M account

let withdrawWithConsoleAudit = auditAs "withdraws" console withdraw
let depositWithConsoleAudit = auditAs "deposit" console deposit

// account
// |> withdrawWithConsoleAudit 10M 
// |> depositWithConsoleAudit 1000M

account
    |> withdrawWithConsoleAudit 10M
    |> depositWithConsoleAudit 1000M
    |> withdrawWithConsoleAudit 10M


depositWithConsoleAudit 1000M account


// let dirname = Path.GetDirectoryName("C:/Users/nswindall/Desktop/txt.txt")
// let textWriter = new System.IO.StringWriter()

// let file = System.IO.File.WriteAllText(dirname,"Hello, how are you doing right now")


// let account = 
//     let commands = ['d';'w'; 'z';'f';'d';'x';'w']

//     commands 
//     |> Seq.filter isValidCommand
//     |> Seq.takeWhile (not << isStopCommand)
//     |> Seq.map getAmount 
//     |> Seq.fold processdCommand openingAccount

let commands = ['d';'w'; 'z';'f';'d';'x';'w']
let validCommands = ['d';'w';'x'] |> Set.ofList
let isValidCommand command = Set.contains (Char.ToLower  command) validCommands 
let commandToTransaction command = match (Char.ToLower command) with 
                                    | 'd' -> Some Deposit 
                                    | 'w' -> Some Withdraw 
                                    | 'x' -> Some Exit 
                                    |  _  -> None 
let isStopCommand command = command = Exit
let valid_Commands commands = List.choose (commandToTransaction) commands // interesting function List.choose gets rid of the options and None


let processCommand account (command, amount) = 
                match command with 
                | Deposit  -> deposit amount account 
                | Withdraw -> withdraw amount account 
                | Exit     ->  account