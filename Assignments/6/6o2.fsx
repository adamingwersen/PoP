/// <summary> Bitmaps </summary>
type point = int * int
type color = int * int * int

type fig =
    | Circle of point * int * color
    | Rectangle of point * point * color
    | Mix of fig * fig
    | Twice of fig * (int * int)


let rec colorAt (x,y) fig =
    match fig with
    | Circle ((cx, cy), r, col) ->
        if (x-cx)*(x-cx)+(y-cy)*(y-cy) <= r*r
        then Some col else None
    | Rectangle ((x0,y0), (x1,y1), col) ->
        if x0 <=x && x <= x1 && y0 <= y && y <= y1
        then Some col else None
    | Mix (f1, f2) ->
        match (colorAt (x,y) f1, colorAt (x,y) f2) with
        | (None, c) -> c
        | (c, None) -> c
        | (Some (r1,g1,b1), Some (r2,g2,b2)) -> Some ((r1+r2)/2, (g1+g2)/2, (b1+b2)/2)
    | Twice (m1, i1) ->
        match(colorAt (x,y) m1, colorAt (x,y)) with
        | None -> c
        | (c) -> c
        | (Some(r1, g1, b1), Some(r2, g2, b2)) -> Some (r2, g2, b2)

let cColor = (255,0,0)
let cPoint = (50,50)
let cInt = 45
let rColor = (0, 0, 255)
let rPoint1 = (40,40)
let rPoint2 = (90,110)

let enFig =
    let enCirkel = Circle (cPoint, cInt, cColor)
    let enFirkant = Rectangle (rPoint1, rPoint2, rColor)
    Mix(enCirkel, enFirkant)

let makePicture name pic b h =
    makeBMP.makeBMP name b h (fun (x,y) ->
                              match colorAt (x,y) pic with
                              |None -> (128, 128, 128)
                              |Some (c) -> c)

makePicture "hej" enFig 100 150

let pushVec = (50, 70)

let dblFig =
    let enCirkel = Circle (cPoint, cInt, cColor)
    let enFirkant = Rectangle (rPoint1, rPoint2, rColor)
    let mixed = Mix(enCirkel, enFirkant)
    Twice(mixed, (pushVec))

makePicture "dublet" dblFig 100 150




    
    

                              
    






