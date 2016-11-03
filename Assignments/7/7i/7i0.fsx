/// <summary> 7i.0 </summary>
/// <remarks> Opens the System namespace </remarks>
open System
let arrayEx = [|1;2;4;7;10;9|]

printfn "Vi betragter array : %A  af længde %d \n" arrayEx arrayEx.Length

/// <remarks> exception: Defines an exception </remarks>
exception IfIndexInvalid of string
/// </summary> SafeIndexIf : A function, which takes two inputs and evaluates with if/else structure. If the provided index (x) is not within the length of the array (A) an error is thrown. This function utilizes the raise(), which halts the program if encountered. </summary>
/// <param name="A"> A is an Array </param>
/// <param name="x"> x is an integer, which specifies the index of the array </param>
let SafeIndexIf (A : 'a[]) (x : int) =
    if x >= (Array.length A) then
        raise (IfIndexInvalid "Index is of invalid size")
    else
        A.[x]

Console.WriteLine "Vælg x af type int til 'IfIndexinvalid'"
/// <param name="indexvalue"> indexValue acts as input to (x) </param>
/// <remarks> Provide the user with an option of entering the desired index </remarks>
let mutable indexValue = int (Console.ReadLine())
printfn "A.[%d]:  %A" indexValue (SafeIndexIf arrayEx indexValue)

/// <summary> SafeIndexTry : A function, which takes two inputs and evaluates using the try/with structure. Here if index is out of bounds, the runtime error is thrown using the failwith-statement. This halts the execution of proceeding code. </summary>
/// <param name="A"> A is an Array </param>
/// <param name="x"> x is an integer, which specifies the index of the array </param>
let SafeIndexTry (A : 'a[]) x =
    try
        A.[x]
    with
        _ -> failwith "Index is of invalid size"

Console.WriteLine "Vælg x af type int til 'SafeIndexTry'"
/// <remarks> Because indexValue was defined as a mutable, it can be changed by using the '<-' operator for new value assignment </remarks>
indexValue <- int (Console.ReadLine())
printfn "A.[%d]:  %A" indexValue (SafeIndexTry arrayEx indexValue)


/// <summary> SafeIndexOption : A function, which takes two inputs and evaluates using try/with - but here using the option type. In order for the function to output an integer, the Some and None option have to be encapsulated within 'Option.get' - this returns an integer if Some, otherwise the encountered runtime error </summar> 
/// <param name="A"> A is an Array </param>
/// <param name="x"> x is an integer, which specifies the index of the array </param>
let SafeIndexOption (A : 'a[]) (x : int) =
    try
        Option.get (Some(A.[x]))
    with
        _ -> Option.get (None)

Console.WriteLine "Vælg x af type int til 'SafeIndexOption'"
indexValue <- int (Console.ReadLine())
printfn "A.[%d]:  %A" indexValue (SafeIndexOption arrayEx indexValue)
