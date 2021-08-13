type Disk = { SizeGb : int}
type Computer = 
    { Manufacturer: string 
      Disks: Disk list }

let myPc = 
    { Manufacturer = "Clmputers Inc."
      Disks = 
        [ { SizeGb = 100}
          { SizeGb = 250}
          { SizeGb = 500}]}

type Disk_ = 
    | HardDisk of RPM: int * Platters:int // tuple
    | SolidState 
    | MMC of NumberOfPins:int

let myHardDisk = HardDisk(RPM = 250, Platters = 7)
let myHardDiskShort = HardDisk(250, 7)
let args = 250, 7 
let myHardDiskShortTupled = HardDisk args 
let myMMC = MMC 5 
let mySsd = SolidState

let seek disk = 
    match disk with 
    | HardDisk (5400, 5) -> "Seeking very slowly"
    | HardDisk _ -> "Seeking loudly at a reasonable speed!"
    | MMC 3 -> "Seeking. I have 3 pins"
    | MMC _ -> "Seeking quietly but slowly"
    | SolidState -> "Already found it!"
seek mySsd
seek (MMC 3)
seek (HardDisk (5400, 5))

let describe disk = 
    match disk with
    | SolidState -> "I'm a newfangled SSD."
    | MMC 1 -> "I have only 1 pin"
    | MMC t when t < 5 -> "I'm an MMc with few pins"
    | MMC p -> sprintf "I'm an MMC with %d" p
    | HardDisk (5400, t ) when t <> 7 -> "I'm a slow hard disk"
    | HardDisk (_, 7) -> "I'm"

let getCreditLimit customer = 
  match customer with 
  | "medium", 1 -> 500 
  | "good", years when years < 2 -> 750 
  | _ -> 1000

//nested DUS
type MMCDisk = 
  | RsMmc 
  | MmcPlus 
  | SecureMMC 

type DiskT = 
  | MMC of MMCDisk * NumberOfPins:int 


// match disk with 
// | MMC (MmcPlus, 3)  -> "Seeking quietly but slowly"
// | MMC (SecureMMC, 6) -> "Seeking quietly with 6 pins"

// What about creating common fields

type DiskInfo = 
  { Manufacturer : string 
    SizeGb : int 
    DiskData : Disk_ } 

type Computer_ = { Manufacturer : string; Disks : DiskInfo list}

let myPc_ = 
  { Manufacturer = "Computers Inc."
    Disks = 
      [ { Manufacturer = "HardDisks Inc."
          SizeGb = 100 
          DiskData = HardDisk (5400, 7)}]}


// pretty print a DU 
sprintf "%A" myPc_


// Creating enums 
type Printer = 
  | Inkjet = 0 
  | Laserjet = 1 
  | DotMatrix = 2

let a: Printer = enum<Printer>(0)


// Let myMainDisk = 
//   { Manufacturer = "HardDisks Inc."
//     SizeGb = 500 
//     DiskData = null}

let aNumber : int = 10 
let maybeANUmber : int option = Some 10 
let calculateAnnualPremiumUsd score = 
  match score with 
    | Some 0 -> 250 
    | Some score when score < 0 -> 400 
    | Some score when score > 0 -> 150 
    | None -> 
        printfn "No score supplied! using temporary premium"
        300 

calculateAnnualPremiumUsd (Some 250)
calculateAnnualPremiumUsd None


type customer = {fristName: string 
                 lastName: string 
                 cash: decimal
                 customerId: int option}

type 'a MyOption = 
  | MySome of 'a 
  | MyNone


type customer_ = {name: string 
                  money: decimal
                  SafetyScore: int option}



let describe_cust score = 
  sprintf "The score is %i" score

let description customer= 
  match customer.SafetyScore with 
    | Some score -> Some (describe_cust score)
    | None -> None 

let myCustomer: customer_ = { name = "Nathan"
                              money = 45M
                              SafetyScore = Some 500}



let descriptionTwo = 
  myCustomer.SafetyScore
  |> Option.map(fun score -> describe_cust score)


let shorthand = myCustomer.SafetyScore |> Option.map describe_cust
let optionalDescribe = Option.map describe_cust


type customerF = { Name : string 
                   SafetyScore: int option
                   cId: int}

//using Option.bind
let Nathan : customerF = {Name= "Nathan"
                          SafetyScore= Some 10 
                          cId= 500}

let Thomas : customerF = { Name = "Thomas"
                           SafetyScore = Some 10
                           cId = 201 
                           }

let drivers = [Nathan; Thomas]

let tryFindCustomer cId = if cId = 10 then Some drivers.[0] else None 
let getSafetyScore customer = customer.SafetyScore
let score = tryFindCustomer 10 |> Option.bind getSafetyScore