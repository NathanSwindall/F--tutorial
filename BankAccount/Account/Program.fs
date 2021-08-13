// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open Operation
open Auditing
open Domain 
open System

let mutable account = {AccountId = Guid.Empty; Owner = {Name = "Nathan"}; Balance = 10M}

let withdrawWithAudit = withdraw |> auditAs "withdraw" Auditing.console
let depositWithAudit = deposit |> auditAs "deposit" Auditing.console

while true do
    System.Console.WriteLine("Please enter 'w' for withdraw 'd' for deposit or 'x' to quit")
    let action = (System.Console.ReadLine())
    if action = "x" then Environment.Exit 0 
    System.Console.WriteLine("Please enter the amount!")
    let amount = decimal(System.Console.ReadLine())

    account <- 
        if action = "d" then account |> depositWithAudit amount 
        elif action = "w" then account |> withdrawWithAudit amount 
        else account 


