/// <summary> 7i.0 </summary>
open System
let arrayEx = [|1;2;4;9;10;9|]

printfn "Vi betragter array : %A  af længde %d \n" arrayEx arrayEx.Length

// SafeIndexIf
exception IfIndexInvalid of string

let SafeIndexIf (A : 'a[]) (x : int) =
    if x >= (Array.length A) then
        raise (IfIndexInvalid "Index is invalid")
    else
        A.[x]

Console.WriteLine "Vælg x af type int til 'IfIndexinvalid'"
let mutable indexValue = int (Console.ReadLine())
printfn "A.[%d]:  %A" indexValue (SafeIndexIf arrayEx indexValue)

// SafeIndexTry
let SafeIndexTry (A : 'a[]) (x : int) =
    try
        A.[x]
    with
        _ -> failwith "Index is invalid"

Console.WriteLine "Vælg x af type int til 'SafeIndexTry'"
indexValue <- int (Console.ReadLine())
printfn "A.[%d]:  %A" indexValue (SafeIndexTry arrayEx indexValue)


// SafeIndexOption
let SafeIndexOption (A : 'a[]) (x : int) =
    try
        Option.get (Some(A.[x]))
    with
        _ -> Option.get (None)

Console.WriteLine "Vælg x af type int til 'SafeIndexOption'"
indexValue <- int (Console.ReadLine())
printfn "A.[%d]:  %A" indexValue (SafeIndexOption arrayEx indexValue)
