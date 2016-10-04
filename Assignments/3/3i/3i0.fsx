/// <summary> Denne .fsx fil indeholder samtlige delopgaver i 3i0 </summary>

/// <c> Her defineres en arbitrær variabel n, før funktionskald </c>


let n = 10

printfn "\nVærdien af n er %i - dette kan ændres øverst i programmet" n
printfn ""
/// <c> Delopgave (a) </c>
/// <returns> Et while-loop, der summerer over 1-til-n </returns>

let sum n =
    let mutable i = 0
    let mutable s = 0
    while i < n do
        i <- i + 1
        s <- i + s
    s
printfn "sum n = %i: %i" n (sum n)

/// <c> Delopgave (b) </c>
/// <returns> En rekursiv funktion, der summerer over 1-til-n </returns>

let rec recSum n = 
    if n < 1 then 0
    else n + recSum(n-1)
printfn "recSum n = %i: %i" n (recSum n)

/// <c> Delopgave (c) </c>
/// <returns> En funktion, der i stedet for at iterere, benytter sumformel </returns>

let simpleSum n =
    n*(n+1)/2
printfn "simpleSum n = %i: %i" n (simpleSum n)

/// <c> Delopgave (d) </c>
/// <returns> Sammenligning af funktionerne i a, b, og c for vilkårlig værdi af n </returns>
        
let metaFct n =
    printfn ""
    printfn "n |\t sum n\t recSum n\tsimpleSum n"
    for j = 0 to n do
        printfn "%i |\t %i \t %i \t\t %i" j (sum j) (recSum j) (simpleSum j)
        printf ""
metaFct n

/// <c> Det ses, at for alle hidtige værdier af n for de funktionere sum, recSum og simpleSum, fåes det samme, korrekte resultat. </c>
/// <c> Det bør bemærkes at ingen af funktionerne er i stand til at håndtere negative værdier for n </c>

