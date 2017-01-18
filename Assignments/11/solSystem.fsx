#r "planet.dll"
open System  
open System.Drawing   
open System.Windows.Forms
open planet


let earth = new Planet("Earth", 63.7101, 0.9833136452, 99.759, 0.9833061966, 100.7782, 0.01, Color.Green)
let jupiter = new Planet("Jupiter", 668.540, 5.415869378, 162.9198, 5.416060986, 162.9964, 0.01, Color.Black)

type solsystem (p : Planet [])=
  let mutable Plist = p
  let win = new Form()
  do win.Text <- "solsystem"
  do win.ClientSize <- Size (1500, 1000)
  do for i in p do
      win.Paint.Add i.Draw 
 
  member this.planets = Plist
  member this.AddPlanets (planet:Planet []) =
   for i in planet do
     win.Paint.Add i.Draw 
   Plist <- Array.append Plist planet
    
  member this.next() =
    for i in p do
     i.RunOrbit()
    win.Refresh()

  member this.kør2()=
   
   Application.Run win
   
type tid(sol:solsystem,n:int)=
 let mutable løkke = n
 let timer = new Timer()
 let next showtime=
  if løkke>0 then
    sol.next()
    løkke <- løkke-1
 
 do timer.Interval <- 3
 do timer.Enabled <- false
 
 do timer.Tick.Add (next)

 member this.kør() =
  timer.Enabled <- true
  sol.kør2()
 member this.setN(N:int)=
  løkke <- N
let b = solsystem([|earth; jupiter|])
let t = tid(b,3650)
t.kør()

let simulationEarth = earth.GetComp