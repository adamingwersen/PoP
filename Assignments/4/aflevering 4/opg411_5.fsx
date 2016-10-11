///<summary> Opgave 4.11.5: En funktion, der trækker to sorterede lister fra hinanden og gemmer 'differensen' i ny liste </summary>
///<param name = "minus"> En funktion, der tager og lister et element i en liste, der eksisterer 1 eller flere gange i en liste(venstre) - men ikke i en anden(højre) </param>
///<returns> En liste med alt, hvad der var indeholdt i A men ikke B - differensmængden, A \ B </returns>

  
let rec minus list1 list2=
  match (list1,list2) with
  |([],_) -> []
  |(ls,[]) -> [] 
  |(l1::ls,x1::xs) when l1 < x1 -> l1::(minus ls list2)
  |(l1::ls,x1::xs) when l1 > x1 -> (minus list1 xs)
  |(l1::ls,x1::xs)  -> (minus ls xs)

/// <remarks> Her anvendes de to nedenstående lister - her forventes [2;2;3] </remarks>
let m1 = [2;2;2;3;4]
let m2 = [1;2;4]
printfn "Minus af %A %A ->  %A" m1 m2 (minus m1 m2)
