
///<summary> funktionen sammenligner de 2 forreste elementer af 2 lister hvis de er ens sættes tallet ind på en ny liste ellers fjernes det laveste element. processen fortsættes undtil en af listerne er tomme    </summary>
///<param name = "intersect"> Rekursiv funktion, der matcher elementerne i to lister - alle matches returneres i output-liste.  </param>
///<returns> En liste med tal der var i begge lister   </returns>

let rec intersect list1 list2 =
  match (list1,list2) with
  |(_,[]) -> []
  |([],_) -> []
  |(l1::ls,x1::xs) when l1 < x1 -> (intersect ls list2)
  |(l1::ls,x1::xs) when l1 > x1 -> (intersect list1 xs)
  |(l1::ls,x1::xs)  -> l1::(intersect ls xs) 

/// <remarks> Her forsøges med nedenstående 2 lister, her forventes outputtet: [2;4;5] </remarks>
let m1 = [1;2;3;4;5] 
let m2 = [2;4;5]
printfn " Intersect af %A og  %A -> %A" m1 m2 (intersect m1 m2)


