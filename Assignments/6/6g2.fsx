// Defining types
type point = int * int
type color = int * int * int

// Defining points, ints and colors:
let cColor = (255,0,0)
let cPoint = (50,50)
let cInt = 45
let rColor = (0, 0, 255)
let rPoint1 = (40,40)
let rPoint2 = (90,110)
let pushVec = (50, 70)

    // Defining type fig - which takes arguments according to instructions
type fig =
    | Circle of point * int * color
    | Rectangle of point * point * color
    | Mix of fig * fig
    | Twice of fig * (int * int)

// Defining colouring scheme: 
let rec colorAt (x,y) fig =
    match fig with
    | Circle ((cx, cy), r, color) ->
        if (x-cx)*(x-cx)+(y-cy)*(y-cy) <= r*r
        then Some color else None
    | Rectangle ((x0,y0), (x1,y1), color) ->
        if x0 <=x && x <= x1 && y0 <= y && y <= y1
        then Some color else None
    | Mix (f1, f2) ->
        match (colorAt (x,y) f1, colorAt (x,y) f2) with
        | (None, c) -> c
        | (c, None) -> c
        | (Some (r1,g1,b1), Some (r2,g2,b2)) -> Some ((r1+r2)/2, (g1+g2)/2, (b1+b2)/2)
    | Twice (m, (int1, int2)) ->
        match (colorAt (x, y) m, colorAt ((x-int1), (y-int2)) m) with
        | (c, None) -> c
        | (None, c) -> c
        | (b, c) -> c


// Define figure using Mix(fig, fig)
let enFig =
    let enCirkel = Circle (cPoint, cInt, cColor)
    let enFirkant = Rectangle (rPoint1, rPoint2, rColor)
    let enMix = Mix (enCirkel, enFirkant)
    Twice(enMix, (50, 70))

let makePicture name pic b h =
    makeBMP.makeBMP name b h (fun (x,y) ->
                              match colorAt (x,y) pic with
                              |None -> (128, 128, 128)
                              |Some (c) -> c)

makePicture "dublet" enFig 150 200 // Output - with "fsharpi -r makeBMP.dll FILENAME"
