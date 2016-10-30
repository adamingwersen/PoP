/// </summary> i5.1 </summary>
let listOfList = [[2];[6;4];[1];[12;99;1]]

let concat list =
    List.foldBack(fun x y -> x@y) list []

printfn "%A" (concat listOfList)

/// <summary> i5.2 </summary>
/// <summary> Her vil jeg anvende funktionerne tryFind og map </summary>
let floatList = 2.0::3.11::4.91::1.11::84.13::[]

let gennemsnit list =
    (List.fold (fun acc elem -> acc + float elem) 0.0 list / float list.Length)

let gnst list =
    match list with
    | [] -> None
    | l::ls -> ((fun acc elem -> acc + float elem) 0.0 list / float list.Length)::ls
    | _ -> None

let rec rex list =
    match list with
    | list::slist -> 

printfn "%A" (List.average floatList)

/// <summary> i5.3 </summary>

/// <summary> i5.4 </summary>







