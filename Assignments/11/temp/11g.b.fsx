open System.Windows.Forms
open System.Drawing
///open Graph

let gmSun = 0.0002959122082322128

type Vector (a:float,b:float)= class
   let mutable X=a
   let mutable Y=b

   member this.y =Y
   member this.x =X
   member this.xy = (this.x,this.y)

   member this.ToPoint ()=
     Point(int (this.x), int (this.y))

   member this.dis (v2:Vector) =
     sqrt((v2.x-this.x)*(v2.x-this.x)+(v2.y-this.y)*(v2.y-this.y))

   member this.dis ()=
     sqrt((this.x)*(this.x)+(this.y)*(this.y))

   member this.turn ()=
      Vector(-this.x,-this.y)

   static member (+) (v1:Vector,v2:Vector)=
     Vector(v1.x+v2.x,v1.y+v2.y)

   static member (-) (v1:Vector,v2:Vector)=
     Vector(v2.x-v1.x,v2.y-v1.y)

   static member (*) (v1:Vector,i:float)=
     Vector(v1.x*i,v1.y*i)

   override this.ToString()=
     sprintf"%A" this.xy
end


type Planet(name: string, radius: float, Rsol:float, long:float, Rsol1:float, long1:float, color: Color) = class
  let startPos = new Vector (cos(long) * Rsol , sin(long) * Rsol)
  let mutable currentPos = new Vector (cos(long1) * Rsol1 , sin(long1) * Rsol1)
  let mutable vt = currentPos - startPos
  let mutable points = Array.map (fun (a : float) ->
              (sin(a) * radius/10.0, cos(a) * radius/10.0)) [|0.0..1.0..360.0|]
  let mutable disToSun = Rsol
  let mutable (orbit:Point []) = [||]
  let mutable AT = Vector(0.0,0.0)

  member this.GetName = name
  member this.GetRadius = radius

  member this.RunOrbit() =
    orbit <- Array.append orbit ([|currentPos.ToPoint()|])
    AT <- (currentPos * ( gmSun / ( disToSun ** 3.0))).turn()
    vt <- vt + AT
    currentPos <- currentPos + vt
    disToSun <- (currentPos.dis())

  member this.getCurrentPos = currentPos
  member this.Pen = new Pen (color)
  member this.P = Array.map (fun (a) ->
         Point(int(currentPos.x + fst a), int(snd a + currentPos.y))) points
  member this.Tegn = Array.append orbit this.P
  member this.Draw (e:PaintEventArgs)= e.Graphics.DrawCurve (this.Pen, this.Tegn)
end

let earth = new Planet("Earth", 6371.01, 0.983295949009, 100.6001, 0.983281670434,101.6192, Color.White)
let jupiter = new Planet("Jupiter", 66854.0, 5.121965577530, 87.8848, 5.121965577530, 87.8848, Color.White)

for i=0 to 1000 do
 earth.RunOrbit()
 printfn "%A" earth.getCurrentPos



(*
printfn "%A" earth.RT
printfn "%A" earth.AT
printfn "vt1: %A" earth.VT1
printfn "vt2: %A" earth.VT2
printfn "%A" jupiter.RT
printfn "%A" jupiter.AT
*)
