/// <summary> Denne .fsx fil indeholder samtlige delopgaver i 3i0 </summary>

<<<<<<< HEAD:Assignments/3/3i/3i0.fsx
/// <c> Her defineres en arbitrær variabel n, før funktionskald </c>


let n = 10

=======
/// <summary> Her angives værdien for n - denne værdi printes, som det første, når programmet køres. </summary>
let n = 9
>>>>>>> edad74fe26d0f6960879dd18e63cf8451185d2d8:Assignments/3/3i0.fsx
printfn "\nVærdien af n er %i - dette kan ændres øverst i programmet" n
printfn ""

/// <summary> Delopgave (a) </summary>
/// <remarks> Et while loop, der køres indtil i = n ved at lægge forrige værdi for den akkumulerende variabel s til s.</remarks>
/// <returns> Summen af alle tal i rækken 1..n </returns>
/// <param name = "i, s"> To mutérbare variable. i anvendes til iterationer fra 1..n, mens s lagrer summen af de hidtidige iterationer </summary>

let sum n =
    let mutable i = 0
    let mutable s = 0
    while i < n do
        i <- i + 1
        s <- i + s
    s
printfn "sum n = %i: %i" n (sum n)

/// <summary> Delopgave (b)  </summary>
/// <remarks> Ved brug af rekursion, kan funktionaliteten af et while-loop imiteres på færre linjer kode.  </remarks>
/// <returns> Summen af alle tal i rækken 1..n </returns>
let rec recSum n = 
    if n < 1 then 0
    else n + recSum(n-1)
    
printfn "recSum n = %i: %i" n (recSum n)

/// <summary> Delopgave (c) </summary>
/// <remarks> Her anvendes en sumformel til at udregne resultatet </remarks>
/// <returns> Summen af alle tal i rækken 1..n  </returns>
let simpleSum n =
    n*(n+1)/2

printfn "simpleSum n = %i: %i" n (simpleSum n)

/// <summary> Delopgave (d) </summary>
/// <returns> Sammenligning af funktionerne i a, b, og c for vilkårlig værdi af n </returns>     
let metaFct n =
    printfn ""
    printfn "n |\t sum n\t recSum n\tsimpleSum n"
    for j = 0 to n do
        printfn "%i |\t %i \t %i \t\t %i" j (sum j) (recSum j) (simpleSum j)
        printf ""
        
metaFct n

/// <remarks> Det ses, at for alle hidtige værdier af n for de funktionere sum, recSum og simpleSum, fåes det samme, korrekte resultat. </remarks>
/// <remarks> Det bør bemærkes at ingen af funktionerne er i stand til at håndtere negative værdier for n </remarks>

