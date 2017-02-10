/// <summary> 5i.4 : Imperative sorting </summary>
let arrIn = [|1;4;91;33;26;11;8|]

/// <summary> swap: Utility function for switching the index/position of any element in an array and the following element. </summary>
/// <param name = "index"> The index at which the element should be swapped with the next element </param>
/// <param name = "arr"> An (unsorted) array </param>
/// <remarks> If there's a mismatch between index and array-length, an error occurs. </remarks>
let swap index (arr: 'a []) = 
 let tmp = arr.[index]
 arr.[index] <- arr.[index + 1]
 arr.[index + 1] <- tmp

/// <summary> arraySortD: An imperative take on sorting. </summary>
/// <param name = "arri"> An array to be sorted. </summary>
/// <summary> arraySortD:: loop : A recursive loop with multiple conditions</summary>
let arraySortD (arr: 'a []) = 
  let rec loop(arr: 'a []) = 
    let mutable check = 0 
    for i = 0 to ((Array.length arr) - 2) do
      if arr.[i] > arr.[i+1] then 
        swap i arr 
        check <- check + 1
    if check > 0 then loop arr else arr
  loop arr

/// <summary> See the results </summary>
printfn "%A" (arrIn)
(arraySortD arrIn)
printfn "%A" (arrIn)

