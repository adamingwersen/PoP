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
