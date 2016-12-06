///<summary> Opgave i5.2 - Funktionen arraySort skal sortere en liste, dette skal gøres funktionelt. </summary>
///<param name = "arraySort"> gør brug af liste modulet: List.sort, der sorterer listen.  </param>
///<returns> En sorteret liste.   </returns>
let rec split aa xs ys=
  match aa with
  |[||] -> (xs, ys)
  |[|_|] -> split aa.tail ys (aa.head @ xs)

let rec merge = function
  | ([||], ys) -> ys
  | (xs, [||]) -> xs
  | ([|_|], [|_|]) -> if x.head < y.Head
                      then x.head @ merge (xs, y.head @ ys)
                      else y.head @ merge (x.head @ xs, ys)

let rec sortArray = function
    | [||] -> [||]
    | [|x|] -> [|x|]
    | arr1 -> let (xs, ys) =  split arr1 [||] [||]
              merge (sortArray xs, sortArray ys)


let aa = [|1;7;5;2;1|]
let bb = sortArray aa
printfn "%A sorteret: %A" aa bb
