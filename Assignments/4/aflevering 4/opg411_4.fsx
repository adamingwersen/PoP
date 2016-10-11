///<summary> funkktionen er en recursiv funktion der sammenligniner de 2 første elementer af hver liste og flytter det laveste til en ny liste. denne process fortsættes til en af listerne er tom hvorefter resten af den anden liste flyttes til den nye.  </summary>
///<param name = "plus"> lægger 2 lister sammen til en ny i sortet rækkefølge </param>
///<return> Sorteret liste med tallene fra de 2 lister </return

let rec plus list1 list2 =
  match (list1,list2) with
  | ([],xs) -> []@xs
  | (ls,[]) -> []@ls
  | (l1::ls,x1::xs) when l1 > x1 -> x1::(plus list1 xs)
  | (l1::ls,_) -> l1::(plus ls list2)

let m1 = [1;2;3;4]
printfn "Plus af %A og %A -> %A" m1 m1 (plus m1 m1)
