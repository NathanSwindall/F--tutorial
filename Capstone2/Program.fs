// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open Domain
open Auditing
open System
// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    // let account = let myAccount_2 = let myId = Guid.NewGuid()
    //               { AccountId = myId; Owner = { FirstName = "Nathan"; LastName = "Swindall"; Id = myId}; Balance=10M }
    let myId = Guid.NewGuid()
    let account =  { AccountId = myId; Owner = { FirstName = "Nathan"; LastName = "Swindall"; Id = myId}; Balance=10M }
    account
    |> withdraw 10M 
    |> deposit 100M 
    |> withdraw 19.95M 
    |> withdraw 12.3M 
    |> deposit 10000M   
    0 // return an integer exit code