module planet
open vectorClass

open System.Windows.Forms
open System.Drawing
let gmSun = 0.002959122082322128

type Planet(name: string, radius: float, rSol:float, long:float, rSol1:float, long1:float, timeFac, color: Color) = class
  let startPos = new Vector (cos(long) * rSol , sin(long) * rSol)
  do printfn "%A" startPos
  let mutable currentPos = new Vector (cos(long1) * rSol1 , sin(long1) * rSol1)
  do printfn "%A" currentPos
  let mutable vt = currentPos - startPos
  let mutable points = Array.map (fun (a : float) ->
              (sin(a) * radius/10.0, cos(a) * radius/10.0)) [|0.0..1.0..360.0|]
  let mutable disToSun = rSol
  let mutable (orbit:Point []) = [||]
  let mutable AT = Vector(0.0,0.0)
  let mutable comparison = [||]
  member this.GetName = name
  member this.GetRadius = radius

  member this.RunOrbit() =
    orbit <- Array.append orbit ([|(currentPos).ToPoint()|])
    AT <- ((currentPos * ( gmSun / ( disToSun ** 3.0)))).turn()
    vt <- vt + (AT*timeFac)
    currentPos <- (currentPos + (vt*timeFac))
    disToSun <- (currentPos.dis())
    comparison <- Array.append comparison [|currentPos|]

  member this.GetComp = comparison
  member this.Pen = new Pen (color)
  member this.P = Array.map (fun (a) ->
         Point(int(currentPos.x + fst a), int(snd a + currentPos.y))) points
  member this.Tegn = Array.append orbit this.P
  member this.Draw (e:PaintEventArgs)= e.Graphics.DrawCurve (this.Pen, this.Tegn)
end
