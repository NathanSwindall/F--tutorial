namespace Domain
//Contains the Customer and Account record types


open System
type Customer = {Name : string}

type Account = { Owner: Customer
                 Balance: decimal 
                 AccountId: Guid}

