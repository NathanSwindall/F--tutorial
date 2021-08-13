type FootballResult = 
    { HomeTeam : string 
      AwayTeam : string 
      HomeGoals : int 
      AwayGoals : int}

let create (ht, hg) (at, ag) = 
    { HomeTeam = ht; AwayTeam = at; HomeGoals = hg; AwayGoals = ag}
let results = 
    [ create ("Messiville", 1) ("Ronaldo City", 2)
      create ("Messiville", 1) ("Bale Town", 3)
      create ("Bale Town", 3) ("Ronaldo City", 1)
      create ("Bale Town", 2) ("Messiville", 1)
      create ("Ronaldo City", 4) ("Messiville", 2)
      create ("Ronaldo City", 1) ("Bale Town", 2)]

// won the most away teams
// imperative solution

open System.Collections.Generic
open System
type TeamSummary = {Name: string; mutable AwayWins: int}
let summary = ResizeArray() 

for result in results do 
    Console.WriteLine(result)
    if result.AwayGoals > result.HomeGoals then 
        Console.WriteLine("away goals bigger")
        let mutable found = false 
        for entry in summary do 
            if entry.Name = result.AwayTeam then 
                Console.WriteLine("found")
                found <- true
                entry.AwayWins <- entry.AwayWins + 1
        if not found then 
            Console.WriteLine("not found")
            summary.Add {Name = result.AwayTeam; AwayWins = 1}
            

let comparer = 
    { new IComparer<TeamSummary> with 
        member this.Compare(x, y) = 
            if x.AwayWins > y.AwayWins then -1
            elif x.AwayWins < y.AwayWins then 1 
            else 0}
summary.Sort(comparer)


// Higher order collection functions
let isAwayWin result = result.AwayGoals > result.HomeGoals

results 
|> List.filter isAwayWin 
|> List.countBy(fun result -> result.AwayTeam)
|> List.sortByDescending(fun (_, awayWins) -> awayWins)


//working with arrays in .net (mutalbe)
let numbersArray = [|1;2;3;4;6|]
let firstNumber = numbersArray.[0]
let firstThreeNumbers = numbersArray.[0..2]
numbersArray.[0] <- 99
let numbers = [1,2,3,4,3,4,5,6] // This is a tuple


// working with immutable lists
let numbersIM = [1;2;3;4;5;6]
let numbersQuick = [1 .. 6]
let head :: tail = numbersIM
head :: tail // becomes a list again. This is very similar to haskell
let moreNumbers = 0 :: numbersIM
let evenMoreNumbers = moreNumbers @ [7 .. 19]
[1;2;3;4;5] @ [1 ; 3;4;5;6] // concat operator

let mySequence = seq { 1;2;3;4;5}

let evens = 
    mySequence
    |> Seq.filter(fun number -> number % 2 = 0)

// useful collection functions
let numbers2 = [1 .. 10]
let timesTwo n = n * 2 
let ouputImperative = ResizeArray() 
for number in numbers2 do 
    ouputImperative.Add( number |> timesTwo)
let outputFunction = List.map timesTwo numbers2

let a = [1 .. 6]
let b = ['a', 'b', 'c', 'd', 'e', 'f']
let mpi i a = i + a
List.mapi mpi a
let myPrint a = printfn "%i" a
List.iter myPrint a


type Order = { OrderId : int}
type Customer = { CustomerId : int; Orders : Order List; Town: string }
let customers : Customer list = []
//let orders : Order list = customers |> List.collect(fun c -> c.Orders)

type CustomerId = CustomerId of int

let CustomerOrders : Map<int,Order list> = Map.empty.Add(1,[{OrderId = 1}])
                                                .Add(2,[{OrderId = 3}])
                                                .Add(3,[{OrderId= 4}])
                                                .Add(4, [{OrderId=5};{OrderId=6}])

let customer4 = CustomerOrders.[4]
let LoadOrder customerId : Order list= CustomerOrders.[customerId]
let customerIds = [1;2;3;4]
//let orders: Order List = customerIds |> List.collect(fun c -> (LoadOrder c))
CustomerOrders.[1]


//pariwise 
let pariwiseData = [1;2;3;4;5;56;6]
let pairs = List.pairwise(pariwiseData)


// example with pairwise
open System 
[ DateTime(2010,5,1)
  DateTime(2010,5,1)
  DateTime(2010,6,12)
  DateTime(2010,7,3)]
|> List.pairwise
|> List.map(fun (a,b) -> b - a)
|> List.map(fun time -> time.TotalDays)