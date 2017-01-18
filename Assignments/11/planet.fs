module planet
open vectorClass



open System.Windows.Forms
open System.Drawing



let gmSun = 0.02959122082322128


type Planet(name: string, radius: float, Rsol:float, long:float, Rsol1:float, long1:float, color: Color) = class
  let startPos = new Vector (cos(long) * Rsol , sin(long) * Rsol)+Vector(500.0,500.0)
  let mutable currentPos = new Vector (cos(long1) * Rsol1 , sin(long1) * Rsol1)+Vector(500.0,500.0)
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

  member this.Pen = new Pen (color)
  member this.P = Array.map (fun (a) ->
         Point(int(currentPos.x + fst a), int(snd a + currentPos.y))) points
  member this.Tegn = Array.append orbit this.P
  member this.Draw (e:PaintEventArgs)= e.Graphics.DrawCurve (this.Pen, this.Tegn)
end


