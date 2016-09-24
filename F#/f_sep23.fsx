let n = 5
let rec countRec n =
    if n > 0 then
        printf "%d " n
        countRec(n-1)
    else
        printfn ""

printf countRec 5
