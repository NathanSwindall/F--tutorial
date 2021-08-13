type CustomerId = CustomerId of string

type ContactDetails = 
    | Address of string 
    | Telephone of string 
    | Email of string 


type Customer = 
    { CustomerId : CustomerId 
      ContactDetails : ContactDetails}
let createCustomer id contact = 
    { CustomerId = id 
      ContactDetails = contact}


let customer = 
    createCustomer (CustomerId "Nicki") (Email "nicki@myemail.com")

type CustomerOption =
    { CustomerId : CustomerId 
      PrimaryContactDetails : ContactDetails 
      SecondaryContactDetails : ContactDetails option
      }

// let createCustomerOption id contact (contact2: ContactDetails) = 
//     { CustomerId = id
//       PrimaryContactDetails = contact
//       SecondaryContactDetails = contact2
//       }

// let customer2 = 
//     createCustomerOption (CustomerId "nathan") (Email "Nathan@Swindall.com")


type GenuineCustomer = GenuineCustomer of CustomerOption 

let validateCustomer customer = 
    match customer.PrimaryContactDetails with 
    | Email e when e.EndsWith "SuperCorp.com" -> Some (GenuineCustomer customer)
    | Address _ | Telephone _ -> Some (GenuineCustomer customer)
    | Email _ -> None

let sendWelcomeEmail ( GenuineCustomer customer ) = 
    printfn "Hello, %A, and welcome to our site!" customer.CustomerId



