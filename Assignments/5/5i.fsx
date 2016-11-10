/// </summary> i5.1 </summary>
let listOfList = [[2];[6;4];[1];[12;99;1]]

let concat list =
    List.foldBack(fun x y -> x@y) list []

printfn "%A" (concat listOfList)





