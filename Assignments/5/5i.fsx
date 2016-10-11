/// </summary> i5.1 </summary>
let listOfList = [[2];[6;4];[1];[12;99;1]]

let concat list =
    List.foldBack(fun x y -> x@y) list []

printfn "%A" (concat listOfList)

/// <summary> i5.2 </summary>
let floatList = [2.0;3.11;4.91;1.11;84.13]

let rec avgFloat = function
    | (_,[]) -> "None"
    | (x, y::ys) -> k = x + y + avgFloat(x, ys) 






