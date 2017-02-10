/// <summary> i5.2 </summary>
/// <summary> Denne delopgave løses ved at bygge en hjælpefunktion, der tager et gennemsnit af en liste og bruge denne med try/find undtagelser. Herved returneres en option type. </summary>
/// <remarks> Liste bestående af floats </remarks>
let floatList = 2.0::3.11::4.91::1.11::84.13::[]

/// <summary> gennemsnitHelp anvender pipes og List.fold. Her tilskrives akkumulatoren, acc med + 1.0 for hvert element i listen. Elem summerer hvert element i listen til den hidtidige sum. Sluteligt divideres elem med acc for at finde gennemsnittet.
/// <param name = "liste"> En vilkårlig liste af floats </param>
let gennemsnitHelp liste =
 liste 
 |> List.fold (fun (elem, acc) x -> (elem + x, acc + 1.0)) (0.0, 0.0)
 |> (fun (elem, acc) -> elem / acc)

/// <summary> gennemsnit tager en liste og forsøger at anvende gennemsnitHelp på en vilkårlig liste bestående af floats. Hvis listen ikke indeholder floats, vil gennemsnitHelp smide en fejl. Hvis argumentet til gennemsnitHelp er gyldigt, returneres en option float.</summary>
/// <param name = "liste"> En vilkårlig liste af floats </param>
let gennemsnit liste = 
 try 
  let avg = gennemsnitHelp liste
  Some avg
 with _ -> None

let resultat = gennemsnit floatList 
printfn "gennemsnit(%A) returnerer: %A" floatList resultat
