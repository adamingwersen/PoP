let upto (n:int) = [1..n]

printfn "%A" (upto 5)

let rec lister = function
    | 0 -> []
    | x -> (lister (x-1)@[x])

printfn "%A" (lister)



