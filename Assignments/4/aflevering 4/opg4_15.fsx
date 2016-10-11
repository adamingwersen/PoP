// opg 4.15
///<summary>vender listen ved at hente elementerne et af gangen fra det forreste og flytte dem til dem til en ny liste   </summary>
///<param name = "vend">vender lister   </param>
///<return> En liste hvor elementerne har fået omvendt rækkefølge  </return>

let rec vend list
  match list with
  |[] -> []  
  |l1::ls -> (vend ls) @ [l1]

///<summary> hver liste i listen vendes ved at køre funktionen "vend" for hver af listerne og sætte det sammen til en ny liste </summary>
///<param name = "revrev"> vender lister i en liste  </param>
///<return> En liste med lister hvor elementerne har fået omvendt rækkefølge  </return>

let rec revrev list=
  match list with
  |[] -> [] 
  |l1::ls -> (vend l1)::(revrev ls)