/// <summary> Denne fil indeholder alle delspørgsmål i 3i1 </summary>

/// <c> Delopgave a </c>

let table x y = x * y
let mul n =
    for i = 1 to 10 do
        printf "%i     " i
        printfn ""
        for j = 1 to n do
            printf "%i     " (table i j)
    printfn ""
mul 5
