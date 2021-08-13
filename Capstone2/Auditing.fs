module Auditing

open Domain
open Operation




let auditAs operationName audit amount account = 
    match operationName with 
        | Deposit -> let account = _deposit amount account
                     audit account (depositMessage amount)
                     account
        | Withdraw -> let account = _withdraw amount account
                      audit account (withdrawMessage amount)
                      account

let withdraw= auditAs Withdraw console
let deposit = auditAs Deposit console


