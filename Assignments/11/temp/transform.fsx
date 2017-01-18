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
let Earth = Seq.toList (readLines(paths.[0]) |> Seq.skip 1 |> Seq.map parser)
printfn "%A" Earth

let mutable dates = [||]
for i=0 to (Earth.Length-1) do
 dates <- [|(Earth.[i].[0])|] |> Array.append dates
printfn "%A" dates
(*
let mutable dates = [||]
for date in Earth do
 dates <- Earth.[date]
printfn "%A" dates
*)
