namespace Domain 

open System


type Owner = {
    Id: Guid
    FirstName: string
    LastName : string
}


type Account = {
    Balance: decimal
    AccountId: Guid
    Owner: Owner
}

type Statement = Withdraw | Deposit