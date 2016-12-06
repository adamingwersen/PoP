let aa = [|5; 4; 3; 2; 1|]
let aal = Array.fold (fun x _ -> x + 1) 0 aa
printfn "%d" aal

let swap indx (arr : 'a []) =
  let temp = arr.[indx]
  arr.[indx] <- arr.[indx + 1]
  arr.[indx + 1] <- temp

let arraySortD (arr : 'a []) =
    let rec loop (arr : 'a []) =
        let mutable swaps = 0
        for i = 0 to (aal - 2) do
            if arr.[i] > arr.[i + 1] then
              swap i arr
              swaps <- swaps + 1
        if swaps > 0 then loop arr else arr
    loop arr
arraySortD aa
printfn "%A" aa
