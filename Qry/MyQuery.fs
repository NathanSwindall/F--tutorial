module MyQuery

open FParsec

type BinaryExprKind = 
    | Add
    | Subtract
    | Multiply
    | Divide
    | And 
    | Equals 
    | NotEquals 
    | GreaterThan
    | GreaterThanOrEquals 
    | LesserThan 
    | LesserThanOrEquals

type Expr = 
    | IntLiteral of int    // descriminated Union
    | FloatLiteral of float 
    | StringLiteral of string 
    | Identifier of string 
    | Binary of (Expr * Expr * BinaryExprKind)

type Stmt =
    | FilterBy of Expr 
    | OrderBy of int 
    | Skip of int
    | Take of int 

type Query = {
    Statements : Stmt list
}

//lets make the parser
let quote : Parser<_, unit> = skipChar '\''
//let ws = skipMany (skipChar ' ')

let stringLiteral = quote >>. manyCharsTill anyChar quote |>> Expr.StringLiteral // The |>> takes the resutl and changes it to what ever is on the other side
let intOrFloatLiteral = 
    numberLiteral (NumberLiteralOptions.DefaultFloat ||| NumberLiteralOptions.DefaultInteger) "number" /// In F# you use the ||| for enums
    |>> fun n -> 
        if n.IsInteger then Expr.IntLiteral (int n.String)
        else Expr.FloatLiteral (float n.String)


let identifier = many1Chars (letter <|> digit) |>> Expr.Identifier
//let expr = intOrFloatLiteral <|> stringLiteral
let expr = choice [ // choice is like have a bunch of parsers connected with <|>
    intOrFloatLiteral
    stringLiteral
    identifier
]

// testing
let a = Expr.IntLiteral 4
let b = Expr.Binary (Expr.FloatLiteral 3.14, Expr.IntLiteral 15, BinaryExprKind.GreaterThan)


let result = run stringLiteral "'hello world'" 
printfn "%O" result