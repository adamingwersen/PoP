/// Opgave 7ø.0
let rec factorial n =
    match n with
    | b when b < 0 -> failwith "Negativ Værdi!"
    | 0 -> 0
    | 1 -> 1
    | b -> b * (factorial(n-1))


exception Negativ of string

let rec factorialesque n =
    if n < 0 then
        raise (Negativ "Værdien er negativ")
    else
        match n with
        | 0 -> 0
        | 1 -> 1
        | b -> b * (factorialesque(n-1))
        
/// User Input Part::
open System

Console.WriteLine "Test af Faktoriseringsfunktioner - Del 1"
Console.Write "Indtast et tal, du ønsker at faktorisere :"
let mutable factorialInput  = int (Console.ReadLine())
(*
   Console.WriteLine ("factorial af dit input:" + string  (factorial(factorialInput)))
*)
Console.WriteLine ("factorialesque af dit input:" + string  (factorialesque(factorialInput)))

/// Opgave 7ø.1
Console.WriteLine "Test af Faktoriseringsfunktioner - Del 2"
Console.Write "Indtast et tal, du ønsker at faktorisere :"
let factorialInput2 =  int (Console.ReadLine())


let factorialite =
    try
        Some(factorial(factorialInput2))
    with
        _ -> None
        
printfn "%A" (factorialite)

(*

Console.WriteLine "Test af Faktoriseringsfunktioner - Del 2"
Console.Write "Indtast et tal, du ønsker at faktorisere :"
factorialInput  <- int (Console.ReadLine())
if factorialite.IsSome then
    Console.WriteLine (option (facrotiralite(factorialInput))

    Console.Write(option (factorialite(factorialInput)))
*)
    
    
    




