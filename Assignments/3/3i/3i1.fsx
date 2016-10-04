/// <summary> Denne fil indeholder alle delspørgsmål i 3i1 </summary>


/// <summary> Delopgave B : Denne delopgave løses før del A, eftersom det ses, at tabellen, der gen/// -ereres i B, med fordel kan anvendes i del A. Her anvendes to for-loops til at generere en 10-t/// abel med 'n' rækker ved brug af en mutérbar streng-variabel samt spritnf-funktionen, som muligg/// ør sammenslutning af strenge. </summary>

/// <param name = "g"> Mutérbar streng, der vil indeholde en \t og \n separaret tabel </param>
/// <param name = "n"> Input-variabel, der dikterer antallet af rækker i "g" </param>
/// <param name = "k"> Fixed variabel, der angiver antallet af kolonner i "g" </param>

/// <returns> Funktionen mulTableB tager et input, n, som angiver antallet af rækker og returnerer /// en streng indeholdende række- samt kolonnenummer og en titalstabel med n rækker. </returns>

let mutable g = ""
let loopMulTable n =
    let k = 10
    let f x y = x * y
    g <- sprintf "\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10"
    for i = 1 to n do
        g <- g + sprintf "\n %i\t" i
        for j = 1 to k do
            g <- g + sprintf "%i\t" (f i j)
    printfn "%s" g

/// <remarks> Dette loop viser tabel-outputtet for n = 1, 2, 3, 10 </remarks>

for i = 1 to 3 do
    printfn "\n loopMultable : n = %i" i
    loopMulTable i

printfn "\n loopMultable : n = %i" 10
loopMulTable 10

/// <summary> Delopgave A: Ved brug af streng-indicering, manipuleres med strengen, der konstrueres///  i delopgave B. Umiddelbart ville det have været smart at anvende regular expressions til denne///  opgave, men dette vill påkræve eksterne libraries - og det lader til, at det har været tanken /// , at de studerende skal anvende indicering. </summary>

/// <remarks> Tilgangen her, har været at finde en systematisk måde, at optælle længden af hver ræk/// ke i tabellen og anvende det som det sidste element i indiceringen. Denne fremgangsmåde er ikke/// skalérbar. </remarks>

/// <param name = "n"> Antallet af rækker der ønskes vist - input  </param>
/// <param name = "q"> En værdi der antager værdien for "n" og evalueres i control-flowet som anfør/// t i funktionen tabRows </param>
/// <param name = "g"> Strengen fra delopgave b, der indeholder hele tabellen </param>
/// <param name = "actString"> Indicerings-expression </param>



let mulTable n =
    let tabRows q =
        match q with
        | 1 -> 44
        | 2 -> 44 + 30
        | 3 -> 44 + 30 + 31
        | 4 -> 44 + 30 + 2*31 + 1
        | 5 -> 44 + 30 + 3*31 + 3
        | 6 -> 44 + 30 + 4*31 + 5
        | 7 -> 44 + 30 + 5*31 + 7
        | 8 -> 44 + 30 + 6*31 + 9
        | 9 -> 44 + 30 + 7*31 + 11
        | 10 -> 44 + 30 + 8*31 + 16
        | _ -> 0
    let actString  = g.[0..(tabRows n)]
    printfn "%s" actString

for i = 1 to 3 do
    printfn "\n mulTable : n = %i" i
    mulTable i

printfn "\n mulTable : n = %i" 10
mulTable 10


/// <summary> Delopgave C: Her forsøges det, at konstruere identisk streng som i A & B. 
/// Desværre, har jeg ikke haft succes med at implementere hale-rekursion eller vende strengen om..///  </summary>

let rec recMultable n =
  match n with
  | 0 -> string "\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10"
  | _ -> sprintf "%d\t" n +
         sprintf "%d\t" (n*1) +
         sprintf "%d\t" (n*2) +
         sprintf "%d\t" (n*3) +
         sprintf "%d\t" (n*4) +
         sprintf "%d\t" (n*5) +
         sprintf "%d\t" (n*6) +
         sprintf "%d\t" (n*7) +
         sprintf "%d\t" (n*8) +
         sprintf "%d\t" (n*9) +
         sprintf "%d\t" (n*10) +
         "\n" + (recMultable (n-1))

printfn "%A" (recMultable 5)

/// <summary> Delopgave D:  </summary>

/// <remarks> Jeg nåede det simpelthen ikke </remarks>

/// <summary> Delopgave E: Forskellen mellem de to argumenter i printf er, at "%A" returnerer strengen i quotes (""), mens "%s" returnerer strengen foruden quotes. </summary>

/// <c> printf "%s" g </c>
/// <c> printf "%A" g </c>










