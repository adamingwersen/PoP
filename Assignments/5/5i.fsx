/// </summary> i5.1 </summary>
let listOfList = [[2];[6;4];[1];[12;99;1]]

let concat list =
    List.foldBack(fun x y -> x@y) list []

printfn "%A" (concat listOfList)

/// <summary> i5.2 </summary>
/// <summary> Her vil jeg anvende funktionerne tryFind og map </summary>
let floatList = 2.0::3.11::4.91::1.11::84.13::[]

let rec findFloat x = function
    | [] -> None
    | x::xs -> List.tryFind(fun x -> x = x) xs

printfn "%A" (findFloat floatList)

/// <summary> i5.3 </summary>

/// <summary> i5.4 </summary>







