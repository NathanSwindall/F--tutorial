#r "nuget: FParsec"
open FParsec
open System

type Token = Hello | World

let a = pstring "hello" >>% Hello // This just disregards the result of the parser and gives the token
let b = pstring "world" >>% World
let c = pstring "myC" >>% "This is my C" // we look for myC and then return "This is my C if we find it

let p = a <|> b

let result = run p "hello"
let result2 = run p "goodbye"
let result3 = run c "myC"


printfn "%O" result






