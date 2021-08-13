module Auditing

open System.IO
open Domain

// contains the console and filesystem audit functions
let console (account: Account) message = printfn "Account %A %s and the new balance is %A" account.AccountId message account.Balance
 