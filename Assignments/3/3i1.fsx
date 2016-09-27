/// <summary> Denne fil indeholder alle delspørgsmål i 3i1 </summary>

/// <c> Delopgave a </c>



let mutable g = ""
let mulTable n =
    let k = 10
    let f x y = x * y
    g <- sprintf "\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10"
    for i = 1 to n do
        g <- g + sprintf "\n %i\t" i
        for j = 1 to k do
            g <- g + sprintf "%i\t" (f i j)
    printfn "%s" g

mulTable 8



