/// <summary> Delopgave 7i.2 </summary>
/// <summary> Outline : 1) Request data stream from user-provided link, 2) Write stream to local file in current directory, 3) parse fil and count match occurences </summary>

/// <param name="filename"> Name of output file </param>
let filename = "webRequest.txt"
/// <remarks> Open the "System" namespace </remarks>
open System
/// <remarks> Ask user for url </remarks>
Console.WriteLine "Indtast et fuldt URL, du kunne tænke dig at vide mere om."
Console.WriteLine "URL skal være af typen https://google.com"
/// <param name="url"> Create string as provided by user. Should be of type URL </param>
let mutable url = string (Console.ReadLine())

let urlToStream url =
    let uri = Uri url
    let request = Net.WebRequest.Create uri
    let response = request.GetResponse ()
    response.GetResponseStream ()

let readURL url =
    let stream = urlToStream url
    let reader = new System.IO.StreamReader (stream)
    reader.ReadToEnd ()

let exampleLength = 25
let html = readURL url

open System.Net
open System.IO
File.WriteAllText(filename, html.[0..])
printfn "Downloaded from %A. \nWrote to file %A. \nFirst %d characters are: \n%A" url filename exampleLength html.[0..exampleLength]

let contentOfStream = html.[0..]

/// <summary> Make sure, that the file is actually created </summary>
/// <param name="file"> The parameter file is a filename. </param>
let checkExistence file =
    try
        System.IO.File.Exists file
    with
        _ -> false
printfn "\nIn order to proceed, we need to make sure, that the file: %A has been created \n" filename

/// <summary> Using the help-function checkExistence, we employ a new function, checkFile. This serves the purpose of assuring, that the file evaluates as true to the checkExistence-function and throws an error if not. </summary>
/// <param name="file"> The parameter file is a filename, as has been used previously. </param>
let checkFile file =
    match file with
    | false -> failwith "File does not exist!"
    | _ -> printfn "Does the file exist? : %A" (checkExistence filename)
checkFile (checkExistence filename)


let outputStream = IO.File.CreateText filename
IO.File.OpenWrite (filename, contentOfStream)


