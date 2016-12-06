#r "makeBMP.dll"
/// <summary> Alle opgaverne 6g-2,3,4,5 </summary>
/// <summary> Definér typer for point, color og 4 figurer </summary>
/// <remarks> Vi kan anvende point- og color typerne, bestående af integers til at lave forskellige figurer  </remarks>
/// <typeparam name = "point"> En vektor bestående af to integers - specificerer et punkt </typeparam>
type point = int * int
/// <typeparam name = "colour"> En vektor bestående af tre integers - specificerer en farve ved at kombinere grader af RGB </typeparam>
type colour = int * int * int
/// <typeparam name = "figure"> En betinget type, der definerer 2 typer af ploygoner, cirkel & firkant, samt 2 kombinationer af disse. </typeparam>
type figure =
            Circle of point * int * colour
            // defined by center, radius, and colour
            | Rectangle of point * point * colour
            // defined by bottom-left corner, top-right corner, and colour
            | Mix of figure * figure
            // combine figures with mixed colour at overlap
            | Twice of figure * point
            // overlays figure with copy of self moved by vector

/// <summary> Definerer en rekursiv funktion, colourAt. Givet en figurtype, farver colourAt pixel-for-pixel. Hvilke farver, der skal anvendes, er givet i definitionerne af cirkel hhv. firkant nedenfor. ColourAt farver området for: 1) undertypen "Circle", 2) undertypen "Rectangle", 3) undertypen "Mix" - hvor de farvede polygoner (Circle og Rectangle) anvendes, 4) undertypen "Twice" for det farvede polygon Mixed. </summary>
/// <param name = "figure"> figure er en figur af typen "figure"</param>
/// <param name = "x"> x er input af typen "int" </param>
/// <param name = "y"> y er input af typen "int" </param>
/// <returns> None||some(colour)</returns>
let rec colourAt (x,y) figure =
  match figure with
  | Circle ((cx,cy), r, col) ->
    if (x-cx)*(x-cx)+(y-cy)*(y-cy) <= r*r
    /// <remarks> bruger Pythagoras sætning til at finde afstand til centrum </remarks>
    then Some col else None
  | Rectangle ((x0,y0), (x1,y1), col) ->
    if x0<=x && x <= x1 && y0 <= y && y <= y1
    /// <remarks> indenfor hjørnerne </remarks>
    then Some col else None
  | Mix (f1, f2) ->
    match (colourAt (x,y) f1, colourAt (x,y) f2) with
    | (None, c) -> c //// <remarks> overlapper ikke </remarks>
    | (c, None) -> c /// <remarks> ditto </remarks>
    | (Some (r1,g1,b1), Some (r2,g2,b2)) ->
            Some ((r1+r2)/2, (g1+g2)/2, (b1+b2)/2) /// <remarks> gennemsnitsfarve </remarks>
            /// <remarks> 6g.3 </remarks>
  | Twice (figure, (x1, y1)) ->
      match (colourAt (x, y) figure, colourAt ((x - x1), (y - y1)) figure) with
      | (None, c) -> c /// <remarks> overlapper ikke </remarks>
      | (c, None) -> c /// <remarks> ditto </remarks>
      | (Some (r1,g1,b1), Some (r2,g2,b2)) ->
            Some (r2,g2,b2) /// <remarks> øverste figur har præcedens ifht. farve </remarks>

let o61 =
  let cirkel = Circle ((50,50), 45, (255, 0, 0))
  let firkant = Rectangle ((40, 40), (90, 110), (0, 0, 250))
  Mix (cirkel, firkant)

/// <summary> 6g.2 - Konstruér et forskudt duplikat af Mix [o61] </remarks>
let g63 =
    Twice (o61, (50, 70))

/// <summary> Her tegnes figurerne - dog skal der kaldes via fsharpi og makeBMP.dll-modulet skal være tilknyttet for at undgå fejl </summary>
let makePicture navn figur b h =
  makeBMP.makeBMP navn b h (fun (x,y) ->
      match colourAt (x,y) figur with
      | None -> (125, 125, 125)
      | Some (c) -> c)
makePicture "g63" g63 150 200

/// <summary> Opgave 6g.5: Her konstrueres funktionerne checkFigure samt BoundBox. </summary>

/// <summary> checkFigure tager typen "figure" som input og sikrer, at konstruktionen af typen er valid. Dvs. En Circle skal have positiv radius og farverne skal eksistere i RGB-spektrummet, 0-255. For Rectangle, må differensen mellem det øverste og nederste punkt ikke være negativ. Ligeledes må differensen mellem højre og venstre ikke være negativ. </summmary>
/// <param name = "figure"> Parametren figure er af typen "figure".</param>
/// <returns> TRUE hvis figur opfylder kriterier - FALSE ellers </returns>
let rec checkFigure figure =
  match figure with
  | Circle ((cx, cy), rad, (r, g, b)) when (rad > 0 && 0 <= r && r <= 255 && 0 <= g && g <= 255 && 0 <= b && b <= 255) -> true
  | Rectangle ((x0, y0), (x1, y1), (r, g, b)) when (x0 <= x1 && y0 <= y1 && 0 <= r && r <= 255 && 0 <= g && g <= 255 && 0 <= b && b <= 255) -> true
  | Mix (f1, f2) -> (checkFigure f1) && (checkFigure f2)
  | Twice (f3, (_, _)) -> (checkFigure f3)
  | _ -> false

/// <summary> Black-box testing: Lav figurer </summary>
/// <remarks> Korrekt brug af Mix - bør resultere i, at der bliver lavet en figur efter instruktionerne, hvilke er ens med "o61". </remarks>
let bbt1 =
  let cirkel = Circle ((50,50), 45, (255, 0, 0))
  let firkant = Rectangle ((40, 40), (90, 110), (0, 0, 250))
  Mix (cirkel, firkant)
/// <remarks> Korrekt brug af Twice - bør resultere i, at der bliver lavet en figur efter instruktionerne, hvilke er ens med "g61". </remarks>
let bbt2 =
  Twice (bbt1, (50, 70))
/// <remarks> Inkorrekt brug af Mix - bør fejle eftersom radius ikke kan være negativ </remarks>
let bbf1 =
  let cirkel = Circle ((50,50), -10, (255, 0, 0)) // regner med en fejl ved kørsel af checkFigure
  let firkant = Rectangle ((40, 40), (90, 110), (0, 0, 250))
  Mix (cirkel, firkant)
/// <remarks> Inkorrekt brug af Mix - green = 500 findes ikke </remarks>
let bbf2 =
  let cirkel = Circle ((50,50), 45, (255, 0, 0))
  let firkant = Rectangle ((40, 40), (90, 110), (0, 500, 250)) // regner med en fejl ved kørsel af checkFigure
  Mix (cirkel, firkant)

printfn "%s" "checkFigure:"
/// <returns> TRUE </returns>
printfn "Blackboxtesting forventer true: %A" (checkFigure bbt1)
/// <returns> TRUE </returns>
printfn "Blackboxtesting forventer true: %A" (checkFigure bbt2)
/// <returns> FALSE </returns>
printfn "Blackboxtesting forventer false: %A" (checkFigure bbf1)
/// <returns> FALSE </returns>
printfn "Blackboxtesting forventer false: %A" (checkFigure bbf2)

/// <summary>funktionen finder det øverste højre hjørne og det nederste venstre hjørne af den mindste rectangel i fig1</summary>
/// <param name = "fig1">fig1 er en figur af typen "figure"</param>
/// <returns>(point,point)</return>
let rec boundBox fig1=
  match fig1 with
  | Circle(a,b,c)->((0,0),(0,0))
  | Rectangle(point1,point2,_) -> (point1,point2)
  | Mix(f1,f2)-> match ((boundBox f1),(boundBox f2)) with
                 |(((0,0),(0,0)),c) -> c
                 |(c,((0,0),(0,0))) -> c
                 |((x1,y1),(x2,y2)),((z1,v1),(z2,v2)) when ((y2-y1)*(x2-x1))<((z2-z1)*(v2-v1))->((x1,y1),(x2,y2))
                 |(_,c)->c
  | Twice(f1,(a,b)) -> match (boundBox f1) with
                       |((x1,y1),(x2,y2))-> ((x1+a,y1+b),(x2+a,y2+b))

printfn "%s" "\nboundBox:"
printfn "Blackboxtesting forventer ((40,40),(90,110)): %A" (boundBox bbt1)
printfn "Blackboxtesting forventer ((90,110),(140,180)): %A" (boundBox bbt2)
