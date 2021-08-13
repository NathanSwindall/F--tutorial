//**********************************************************************************
// Lesson 9
//*************************************************************************************
let parseName(name:string) = 
    let parts = name.Split(' ')
    let forename = parts.[0]
    let surname = parts.[1]
    forename, surname  // creates a tuple
let name = parseName("Isaac Abraham")
let forename, surname = name // you can deconstruct
let fname, sname = parseName("Isaac Abraham")


// create a tuple
let a = "Nathan", "Swindall", 34
let parse(person:string) = 
    let parts = person.Split(' ')
    let playername = parts.[0]
    let game = parts.[1]
    let score = parts.[2]
    playername, game, score 
let playername, game, score = parse("Nathan Ruddy_bagger 23")
let score_num = System.Int32.Parse(score)
let score_num_ = int(score)


// HOw to do you interop with C# and the tuple in F# ... using a struct maybe

// nested tuples
let nameAndAge = ("Joe", "Bloggs"), 28
let name_tuple, age = nameAndAge


// Lesson 10 Shapping records
type Address = 
    { Street: string 
      Town: string 
      City: string}


type Customer = 
    { Forename: string
      Surname: string
      Age: int 
      Address: Address 
      EmailAddress: string}


let customer = 
    { Forename = "Joe"
      Surname = "Bloggs"
      Age = 30 
      Address = 
       {Street = "The Stree"
        Town = "The Town"
        City = "The City"}
      EmailAddress = "joe@bloggs.com"}

let customer2 = {
    Address.Street = "The street"
    Address.City = "The City"
    Address.Town = "The Town"
}

// how to update a record
let updatedCustomer = 
    { customer with 
        Age = 31
        EmailAddress = "joejoe@bloggs.co.uk"}


// These are not equal
let address1 = {   
        Address.Street = "Street"
        Address.City = "City"
        Address.Town = "Town"
    }

 
let address2 = 
    {   Address.Street = "Street"
        Address.City = "City"
        Address.Town = "Town"
    }
  
let address3 = 
    {   Address.Street = "Street"
        Address.City = "Cityd"
        Address.Town = "Town"
    }

let areEqual = address3.Equals(address1)
let areEqual2 = address1.Equals(address2)

//references are equal
System.Object.ReferenceEquals(address1,address2)

// update age
let ChangeStuff cus = 
    { cus with 
        Age = 31
        EmailAddress = "Nathan@example"}


let ChangeAge cus age = 
    {cus with 
        Age = age}

// partial application
let tupledAdd(a,b) = a + b 
let answer = tupledAdd(5, 10) 
let curriedAdd a b = a + b 
let answer2 = curriedAdd 5 10


open System 
open System.IO

let writeToFile (date: DateTime) filename text = 
    let path = sprintf "%s-%s.txt" (date.ToString "yyMMdd") filename 
    File.WriteAllText(path, text)


let drive (petrol, distance) = 
    if distance = "far" then petrol - 40.0
    else if distance = "medium" then petrol - 20.0
    else petrol - 1.0

let drive2 distance petrol = 
    if distance = "far" then petrol - 40.0
    else if distance = "medium" then petrol - 20.0
    else petrol - 1.0

//pipelines
let startingPetrol = 100.0
let petrol1 = drive(startingPetrol, "far")
let petrol2 = drive(petrol1, "medium")
let petrol3 = drive(petrol2, "shor")

startingPetrol
|> drive2 "far"
|> drive2 "medium"
|> drive2 "shor"


// let checkCurrentDirectoryAge = 
//     Directory.GetCurrentDirectory
//     >> Directory.GetCreationTime
//     >> checkCreation
// let description = checkCurrentDirectoryAge()


let function1 name=   
  name + " FSharp"  
let function2 name =   
   name + " Programming"  
  
let programmingName = function1 >> function2  
let result = programmingName "Hello"  
printf "%s" result 

open System.Net.Http
// let httpClient = new HttpClient();
// let response = 
//     async {
//         let! response = 
//         httpClient.GetAsync("Http://www.contoso.com/") 
//         |> Async.AwaitTask 
//         response.EnsureSuccessStatusCode () |> ignor
        
//     }


let getAsync (client:HttpClient) (url:string) = 
    async {
        let! response = client.GetAsync(url) |> Async.AwaitTask
        response.EnsureSuccessStatusCode () |> ignore
        let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
        return content
    }


let response = getAsync (new HttpClient()) ("https://www.google.com/") |> Async.RunSynchronously


type Car = 
    { Brand: string
      Miles: float
      TopSpeed: float
    }


let myCar = {TopSpeed = 100.0
             Brand = "Honda"
             Miles = 10000.0}

let addMiles miles car = {car with Miles = car.Miles + miles}
let myOldCar = 
    myCar
    |> addMiles 101.0
    |> addMiles 200.0 
    |> addMiles 300.0

