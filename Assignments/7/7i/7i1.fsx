let thisFile = "afile.txt"     

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
/// <summary> Build a help-function which writes a file </summmary>
/// <param name="filename"> A string - contains a filename </param>
/// <param name="text"> A string - a text corpus to write </param>
let writeFile (filename : string) (text : string) =
    let stream = File.CreateText filename
    let writer = stream.WriteLine text
    stream.Close ()

/// <summary> Build a fileReplace using readFile, regex and WriteAllText </summary>
/// <param name="filename"> A string - contains a filename </param>
/// <param name="needle"> A string - the word to be replaced </param>
/// <param name="replace"> A string - the replacement word </param>
/// <remarks> This function will prompt the user with a before/after display of the textfile </remarks>
let fileReplace (filename : string) (needle : string) (replace : string) =
    let inputStream = File.OpenText filename
    let corpus = readFile inputStream
    inputStream.Close()

    printfn "Filen ser indledningsvis således ud:\n%s" corpus
    let replacement = Regex.Replace(corpus, needle, replace)
    
    writeFile filename replacement
    let inputStream = File.OpenText filename
    let newcorpus = readFile inputStream
    inputStream.Close()
    
    printfn "...og ser nu således ud:\n%s" newcorpus

/// <remarks> Run the fileReplace-function two times to ensure, that the function works both ways </remarks>
fileReplace thisFile "PoP" "Programmering og Problemløsning"
Console.WriteLine "\nVi kan vende dette om - og dermed starte forfra\n"
fileReplace thisFile "Programmering og Problemløsning" "PoP"


