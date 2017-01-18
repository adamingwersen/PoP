#r "planet.dll"
open System
open System.Drawing
open System.Windows.Forms
open System.Net
open System.IO
open System.Text.RegularExpressions
open planet
open vectorClass

let earth = new Planet("Earth", 63.7101, 0.9833136452, 99.759, 0.9833061966, 100.7782, 1.0, Color.Green)
let jupiter = new Planet("Jupiter", 699.11, 5.415869378, 162.9198, 5.416060986, 162.9964, 1.0, Color.Black)
let mars = new Planet("Mars",  33.899, 1.657734803, 174.1074, 1.657327091, 174.5484, 1.0, Color.Red)
let mercury = new Planet("Mercury", 24.40, 0.3253043347, 30.379, 0.3212437213, 36.086, 1.0, Color.Yellow)
let neptune = new Planet("Neptune", 246.24, 29.95966118, 338.9131, 29.95963751, 338.9191, 1.0, Color.Orange)
let pluto = new Planet("Pluto", 11.95, 33.01349297, 284.9817, 33.01410806, 284.987, 1.0, Color.Blue)
let saturn = new Planet("Saturn", 582.32, 10.01070967, 248.2076, 10.01083937, 248.2379, 1.0, Color.Purple)
let uranus = new Planet("Uranus", 253.62, 19.97523398, 19.1521, 19.97514321, 19.1629, 1.0, Color.Brown)
let venus = new Planet("Venus",  60.518, 0.7203617998, 184.668, 0.720471891, 186.2854, 1.0, Color.Black)

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
let t = tid(b,365)
t.kør()

let simulationEarth = earth.GetComp
let simulationJupiter = jupiter.GetComp
let simulationMars = mars.GetComp
let simulationMercury = mercury.GetComp
let simulationNeptune = neptune.GetComp
let simulationPluto = pluto.GetComp
let simulationSaturn = saturn.GetComp
let simulationUranus = uranus.GetComp
let simulationVenus = venus.GetComp


  // Define the location of the already cleaned files - see import.fsx
let cd = Environment.CurrentDirectory
let basePath = Path.Combine(cd, "data")
let names = ["Earth";"Jupiter";"Mars";"Mercury";"Neptune";"Pluto";"Saturn";"Uranus";"Venus"]

let mutable dirs = []

for name in names do
 dirs <- (Path.Combine(basePath, (name + ".txt"))) :: dirs
printfn "%A" dirs

let readParseWrite (path: string) (name: string) =
 let corpus = File.ReadAllText(path)
 let regexpr = @"(?<=2457387.500000000).*?(?=[\$$EOE])"
 let out = Regex.Match(corpus, regexpr)
 File.WriteAllText(Path.Combine(basePath, (name + "_clean" + ".txt")), (out.ToString()))
 printfn "File Length :%A || Match Length: %A || Written to: %A" (String.length corpus) (String.length (out.ToString())) (name + "_clean" + ".txt")

/// <summary> Execute the function with sequential pairs of paths and filenames</summary>
for x = 0 to ((List.length names - 1)) do
 readParseWrite dirs.[x] names.[x]

let mutable paths = []
for name in names do
 paths <- (Path.Combine(basePath, (name + "_clean" + ".txt"))) :: paths

let parser(corpus) =
 let regexpr = @"[ |\t]+"
 let split = Regex.Split(corpus, regexpr)
 let time, hecllon, hecllat, r, rdot = split.[0], split.[1], split.[2], split.[3], split.[4]
 [|float time; float hecllon; float hecllat; float r; float rdot|]

let readLines (aPath: string) = seq {
    use stream = new StreamReader (aPath)
    while not stream.EndOfStream do
        yield stream.ReadLine ()
}
let writePoints(planet: float [] list) =
 let mutable temp = [||]
 for i=0 to ((planet).Length-1) do
  temp <- [|((planet).[i].[1], (planet).[i].[3])|] |> Array.append temp
 temp

let Earth = Seq.toList (readLines(paths.[0])
 |> Seq.skip 1
 |> Seq.map parser)
let earthpoints = writePoints Earth
let Jupiter = Seq.toList (readLines(paths.[1])
 |> Seq.skip 1
 |> Seq.map parser)
let jupiterpoints = writePoints Jupiter
let Mars = Seq.toList (readLines(paths.[2])
 |> Seq.skip 1
 |> Seq.map parser)
let marspoints = writePoints Mars
let Mercury = Seq.toList (readLines(paths.[3])
 |> Seq.skip 1
 |> Seq.map parser)
let mercurypoints = writePoints Mercury
let Neptune = Seq.toList (readLines(paths.[4])
 |> Seq.skip 1
 |> Seq.map parser)
let neptunepoints = writePoints Neptune
let Pluto = Seq.toList (readLines(paths.[5])
 |> Seq.skip 1
 |> Seq.map parser)
let plutopoints = writePoints Pluto
let Saturn = Seq.toList (readLines(paths.[6])
 |> Seq.skip 1
 |> Seq.map parser)
let saturnpoints = writePoints Saturn
let Uranus = Seq.toList (readLines(paths.[7])
 |> Seq.skip 1
 |> Seq.map parser)
let uranuspoints = writePoints Uranus
let Venus = Seq.toList (readLines(paths.[8])
 |> Seq.skip 1
 |> Seq.map parser)
let venuspoints = writePoints Venus


let compare (calculatedCoord: Vector [] , nasaData: (float*float) []) =
  let mutable nasaCoord = [||]
  let mutable diff = [||]
  for i=0 to 350 do
      nasaCoord <- Array.append nasaCoord [|Vector (cos(fst (nasaData.[i])) * (snd (nasaData.[i])), sin(fst (nasaData.[i])) * (snd (nasaData.[i])))|]
      diff <- Array.append diff [|((calculatedCoord.[i] - nasaCoord.[i]).dis())|]
      printfn "%A" calculatedCoord.[i]
      printfn "%A" nasaCoord.[i]
      printfn "%A" diff.[i]

compare (simulationEarth, earthpoints)
compare (simulationJupiter, jupiterpoints)
compare (simulationMars, marspoints)
compare (simulationMercury, mercurypoints)
compare (simulationNeptune, neptunepoints)
compare (simulationPluto, plutopoints)
compare (simulationSaturn, saturnpoints)
compare (simulationUranus, uranuspoints)
compare (simulationVenus, venuspoints)
