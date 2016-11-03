let thisFile = "filename_7i1.txt"     

open System
open System.IO
open System.Text.RegularExpressions

/// <summary> Build a recursive help-function for reading files </summary>
/// <param name="stream"> A stream </param>
let rec readFile (stream : StreamReader) =
    if not(stream.EndOfStream) then
        (stream.ReadLine ()) + (readFile stream)
    else
        ""
/// <summary> Build a fileReplace using readFile, regex and WriteAllText </summary>
/// <param name="filename"> A string - contains a filename </param>
/// <param name="needle"> A string - the word to be replaced </param>
/// <param name="replace"> A string - the replacement word </param>
let fileReplace (filename : string) (needle : string) (replace : string) =
    let inputStream = File.OpenText filename
    let corpus = readFile inputStream
    inputStream.Close()
    printfn "Filen ser indledningsvis således ud:\n%s" corpus
    let replacement = Regex.Replace(corpus, needle, replace)
    File.WriteAllText(filename, replacement)
    let inputStream = File.OpenText filename
    let newcorpus = readFile inputStream
    inputStream.Close()
    printfn "...og ser nu således ud:\n%s" newcorpus

fileReplace thisFile "PoP" "Programmering og Problemløsning"
Console.WriteLine "\nVi kan vende dette om - og dermed starte forfra\n"
fileReplace thisFile "Programmering og Problemløsning" "PoP"


