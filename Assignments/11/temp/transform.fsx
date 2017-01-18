open System
open System.Net
open System.IO
open System.Text.RegularExpressions

  // Define the location of the already cleaned files - see import.fsx
let basePath = "/home/adam/Documents/Uni/CompSci/PoP/Assignments/11/data"
let names = ["Earth";"Jupiter";"Mars";"Mercury";"Neptune";"Pluto";"Saturn";"Uranus";"Venus"]

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

let listofpoints = [earthpoints; jupiterpoints; marspoints; mercurypoints; neptunepoints; plutopoints; saturnpoints; uranuspoints; venuspoints]
for planet in listofpoints do
 printfn "%A" planet
