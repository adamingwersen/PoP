let rec sammenligning x list=
  match (x,list) with
  |(c,[]) -> []
  |(c,p1::ps) when c<>p1 -> p1::(sammenligning c ps) 
  |(c,p1::ps) -> (sammenligning c ps) 

let rec liste list=
  match list with
  |[] -> []
  |x::xs -> x::(liste (sammenligning x xs)) 

printfn "%A" (liste [1;2;3;2;1;4;4;1])