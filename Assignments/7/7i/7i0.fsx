/// <summary> 7i.0 </summary>
/// <remarks> Opens the System namespace </remarks>
open System
let arrayEx = [|1;2;4;7;10;9|]

printfn "Vi betragter array : %A  af længde %d \n" arrayEx arrayEx.Length


/// </summary> SafeIndexIf : A function, which takes two inputs and evaluates with if/else structure. If the provided index (x) is not within the length of the array (A) an error is not thrown. This function utilizes the default-value of an array if out-of-bounds. </summary>
/// <param name="A"> A is an Array </param>
/// <param name="x"> x is an integer, which specifies the index of the array </param>
let safeIndexIf (A : 'a[]) x =
    if ((x >= (Array.length A)) || (x < 0))  then
        Unchecked.defaultof<'a>
    else
        A.[x]
 
        
Console.WriteLine "Vælg x af type int til 'safeIndexIf'"
/// <param name="indexvalue"> indexValue acts as input to (x) </param>
/// <remarks> Provide the user with an option of entering the desired index </remarks>
let mutable indexValue = int (Console.ReadLine())
printfn "A.[%d]:  %A" indexValue (safeIndexIf arrayEx indexValue)

/// <summary> SafeIndexTry : A function, which takes two inputs and evaluates using the try/with structure. Here if index is out of bounds, the runtime error is thrown using the failwith-statement. This halts the execution of proceeding code. </summary>
/// <param name="A"> A is an Array </param>
/// <param name="x"> x is an integer, which specifies the index of the array </param>
let safeIndexTry (A : 'a[]) x =
    try
        A.[x]
    with
        _ -> failwith "Index is of invalid size"

Console.WriteLine "Vælg x af type int til 'safeIndexTry'"
/// <remarks> Because indexValue was defined as a mutable, it can be changed by using the '<-' operator for new value assignment </remarks>
indexValue <- int (Console.ReadLine())
printfn "A.[%d]:  %A" indexValue (safeIndexTry arrayEx indexValue)


/// <summary> SafeIndexOption : A function, which takes two inputs and evaluates using try/with - but here using the option type. In order for the function to output an integer, the Some and None option have to be encapsulated within 'Option.get' - this returns an integer if Some, otherwise the encountered runtime error </summar> 
/// <param name="A"> A is an Array </param>
/// <param name="x"> x is an integer, which specifies the index of the array </param>
let safeIndexOption (A : 'a[]) (x : int) =
    try
        Option.get (Some(A.[x]))
    with
        _ -> Option.get (None)

Console.WriteLine "Vælg x af type int til 'safeIndexOption'"
indexValue <- int (Console.ReadLine())
printfn "A.[%d]:  %A" indexValue (safeIndexOption arrayEx indexValue)
