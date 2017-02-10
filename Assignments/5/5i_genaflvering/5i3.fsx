/// <summary> 5i.3: Functional array sort</summary>
let testArr = [|2;9;6;4;21;93;4;1|]

/// <summary> arraySplit: Recursive function, which splits an array into two arrays </summary>
/// <param name = "arrIn"> The array we wish to split. </param>
/// <param name = "left"> One of the arrays, that a part of arrIn will be temporarily stored in. </param>
/// <param name = "right"> --||-- </right>
/// <returns> Two arrays consisting of the elements contained in arrIn </returns>
let rec arraySplit (arrIn: 'a []) (left: 'a []) (right: 'a []) = 
 match arrIn with
 | [||] -> (left, right)
 | _ -> (arraySplit (Array.tail arrIn) right (Array.append [|Array.head arrIn|] left)) 

/// <summary> arrayMerge: Stitches together to seperate array of even or uneven length. The merge i based on an evaluation, such that the sorting of the arrays will be conducted in this function.
/// <param name = "left"> An array. </param>
/// <param name = "right"> An array </param>
let rec arrayMerge ((left: 'a []), (right: 'a [])) =
 match (left, right) with 
 | (left, [||]) -> left
 | ([||], right) -> right
 | (_,_) -> if ((left.[0]) < (right.[0])) 
                      then Array.append [|left.[0]|] (arrayMerge (left.[1..], right)) 
              else Array.append [|right.[0]|] (arrayMerge (left, right.[1..]))

/// <summary> The utility functions defined above are incorporated into arraySort </summary>
/// <remarks> This is necessary due to the definition of arrayMerge </remarks>
/// <returns> A sorted array </remarks>
let rec arraySort = function
 | [||] -> [||]
 | [|x|] -> [|x|]
 | testArr -> 
  let (temp1, temp2) = arraySplit testArr [||] [||]
  arrayMerge ((arraySort temp1), arraySort temp2)

printfn "%A -> %A" testArr (arraySort testArr) 
