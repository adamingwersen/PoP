(*

let rec arrayMerge = function
 | ([||], ay) -> ay
 | (ax, [||]) -> ax
 | ([|_|], [|_|]) -> match x.head < y.head with
                     | true -> x.head @ arrayMerge (ax, y.head @ ay)
                     | false -> y.head @ arrayMerge (x.head @ ax, ay)
*)
let rec arraySplit arr ax ay = 
 match arr with
 | [||] -> (ax, ay)
 | [|_|] -> arraySplit arr.[(arr.Length -1)]  ay (arr.[0] @ ax)

(*
let rec arraySort = function
 | [||] -> [||]
 | [|oneElem|] -> [|oneElem|]
 | anArray -> let(ax, ay) = arraySplit anArray [||] [||] arrayMerge (arraySort ax, arraySort ay)
*)



let aa = [|5;2;21;1;2;3;9;6|]


