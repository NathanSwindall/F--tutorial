open System.IO

type Customer = { Age : int}
let where filter customers = 
    seq {
            for customer in customers do 
                if filter customer then 
                    yield customer }
let customers = [ { Age = 21}; {Age = 35}; {Age = 36 }]
let isOver35 customer = customer.Age > 35 

customers |> where isOver35 
customers |> where (fun customer ->customer.Age > 35)




let printCustomerAge writer customer = 
    if customer.Age < 13 then writer "Child"
    elif customer.Age < 20 then writer "Teenager!"
    else writer "Adult!"

printCustomerAge System.Console.WriteLine {Age= 40}


let writeToFile text = File.WriteAllText(@"C:\Users\nswindall\Desktop", text)
let printToFile = printCustomerAge writeToFile

printToFile {Age = 21}


// make a function that uses the HTTP client to post something. Make something as the dependency for it. What is the dependency