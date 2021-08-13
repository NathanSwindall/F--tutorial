// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open MyQuery
open FParsec

//printfn "%O" result
let number = run expr "3.14"
let category = run expr "Category"
printfn "%O" number
printfn "%O" category