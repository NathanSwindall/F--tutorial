module Operations

open Domain

let getInitials customer = customer.FirstName.[0], customer.LastName.[0]
let isOlderThan age customer = customer.Age > age

let myCar = {TopSpeed = 100.0
             Brand = "Honda"
             Miles = 10000.0}

let addMiles miles car = {car with Miles = car.Miles + miles}
let myOldCar = 
    myCar
    |> addMiles 101.0
    |> addMiles 200.0 
    |> addMiles 300.0


