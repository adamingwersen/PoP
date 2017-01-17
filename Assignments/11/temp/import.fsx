/// <remarks> Load necessary namespaces </remarks>
open System
open System.Net
open System.IO

/// <remarks> The path to the "data" folder containing NASA data </remarks>
let basePath = "/home/adam/Documents/Uni/CompSci/PoP/Assignments/11/data"

/// <remarks> The names of the text-files </remarks>
let names = ["Earth";"Jupiter";"Mars";"Mercury";"Neptune";"Pluto";"Saturn";"Uranus";"Venus"]

/// <remarks> Placeholder list </remarks>
let mutable paths = []

/// <remarks> Concatenate strings contained in lists into interpretable paths</remarks>
for name in names do
 paths <- (Path.Combine(basePath, (name + ".txt"))) :: paths
printfn "%A" paths

/// <remarks> Open Regex namespace </remarks>
open System.Text.RegularExpressions

/// <summary> This function reads from the predefined list of paths, then parses the data given the regexpr and stores the parsed data in "out". From here, the data is written to the data destination with the subscript "_clean". The length of raw/parsed data as well as filename is written to the console. </summary>
/// <param = "path"> The ingoing predefined path </param>
/// <param = "name"> The read filename - as in path </param>
let readParseWrite (path: string) (name: string) =
 let corpus = File.ReadAllText(path)
 let regexpr = @"(?<=2457387.500000000).*?(?=[\$$EOE])"
 let out = Regex.Match(corpus, regexpr)
 File.WriteAllText(Path.Combine(basePath, (name + "_clean" + ".txt")), (out.ToString()))
 printfn "File Length :%A || Match Length: %A || Written to: %A" (String.length corpus) (String.length (out.ToString())) (name + "_clean" + ".txt")

/// <summary> Execute the function with sequential pairs of paths and filenames</summary>
for x = 0 to ((List.length names - 1)) do
 readParseWrite paths.[x] names.[x]
(*
let readConstants (path: string) =
 let corpus = File.ReadAllText(path)
 let regexpr = @"(?<=Volumetric mean radius=\s|Mean radius, km\t=\s).*?(?=[\+-])"
 let out = Regex.Match(corpus, regexpr)
 printfn "Match length: %A || Match: %A" (String.length (out.ToString())) (out.ToString())

printfn "%A" paths.[1]
readConstants paths.[1]
*)
