/// <summary> Delopgave 7i.2 </summary>
/// <summary> Outline : 1) Request data stream from user-provided link, 2) Write stream to local file in current directory, 3) parse fil and count match occurences </summary>

/// <param name="filename"> Name of output file </param>
let filename = "webRequest.txt"
let exampleLength = 25
/// <remarks> Open the "System", "System.IO" & "System.NET" namespace </remarks>
open System
open System.Net
open System.IO
/// <remarks> Ask user for url </remarks>
Console.WriteLine "Indtast et fuldt URL, du kunne tænke dig at vide mere om."
Console.WriteLine "URL skal være af typen https://google.com"
/// <param name="url"> Create string as provided by user. Should be of type URL </param>
let mutable url = string (Console.ReadLine())

/// <summary> The function urlToStream has been borrowed from fsharpNotes11-12.pdf - Listing 12.4 </summary>
/// <param name="url"> A URL of type string. In order for request to be succesful, URL must abide the rules of a URL. </param>
let urlToStream url =
    let uri = Uri url
    let request = WebRequest.Create uri
    let response = request.GetResponse ()
    response.GetResponseStream ()
    
/// <summary> The function readURL has been borrowed from fsharpNotes11-12.pdf - Listing 12.4 </summary>
/// <param name="url"> A URL of type string. In order for request to be succesful, URL must abide the rules of a URL. </param>
let readURL url =
    let stream = urlToStream url
    let reader = new StreamReader (stream)
    reader.ReadToEnd ()

/// <remarks> This is partially copied from Listing 12.4 - however; an error message is provided, if the link is invalid. </remarks>
let html  =
    try
        readURL url
    with
        _ -> failwith "Sitet kan ikke findes. Indtast venligst gyldig URL"

/// <remarks> A quick solution for writing the html-string is to use the WriteAllText-function from the System.IO-namespace. </remarks>
File.WriteAllText(filename, html.[0..])
/// <remarks> The user is provided with a description of the process - and is given a sample of the html-string. </remarks>
printfn "Downloaded fra %A. \nSkrev til filen %A. \nDe første %d characters i sitets HTML er: \n%A" url filename exampleLength html.[0..exampleLength]

/// <summary> Make sure, that the file is actually created </summary>
/// <param name="file"> The parameter file is a string containing a filename within the current directory. </param>
let checkExistence file =
    try
        File.Exists file
    with
        _ -> false

printfn "\nSikrer, at filen: %A , er blevet skrevet til nuværende folder (directory)\n" filename

/// <summary> Using the help-function checkExistence, we employ a new function, checkFile. This serves the purpose of assuring, that the file evaluates as true to the checkExistence-function and throws an error if not. </summary>
/// <param name="file"> The parameter file is a filename, as has been used previously. </param>
let checkFile file =
    match file with
    | false -> failwith "Filen eksisterer ikke - husk at revidere write-permissions"
    | _ -> printfn "Eksisterer filen? : %A" (checkExistence filename)
checkFile (checkExistence filename)

/// <summary> Read File again </summary>
/// <param name="stream">
/// <remarks> The readFile-function is borrowed from Listing 12.6 in fsharpNotes11-12.pdf - however; it has been altered as to output a string instead of a string list </remarks>
let rec readFile  (stream : StreamReader) =
    if not(stream.EndOfStream) then
        (stream.ReadLine ()) +  (readFile stream)
    else
        ""
        
let inputStream = File.OpenText filename
let corpus = readFile inputStream

open System.Text.RegularExpressions
/// <summary> Construct function, which takes a text-corpus/file (string) as input and search for a string (pattern or regex) and tally the number of occurences. </summary>
/// <param name="text"> A string which is to be searched </param>
/// <param name="regex"> A string, which is to be matched with "text"</param>
/// <remarks> The Regex.Matches is contained in the System.Text.RegularExpressions namespace, and places each string-match in so-called "MatchCollection"-type, which is an Object. This may be outside the scope of the current curriculum. </remarks>
exception InvalidStringProvided of string
let countHtmlTag (text : string) (expression : string) =
    let matcher = Regex.Matches (text, expression)
    let counter = matcher.Count
    if counter <= 0 then
        raise (InvalidStringProvided "Matches")
    else
    counter

Console.WriteLine "Nu er filen indlæst, og vi kan søge efter antal forekomster af en bestemt streng"
Console.WriteLine "Indtast en streng eller et regular expression:"
/// <remarks> Let the user provide a search-expression as input into countHtmlTag
let (expression : string) = string (Console.ReadLine())
/// <remarks> Anvender try/with strukturen for at kaste en passende fejl (exception) til brugeren, hvis ingen matches findes </remarks>
try
    printfn "Strengen %A, du har indtastet, forekommer med frekvens: %A" expression (countHtmlTag corpus expression)
with
    | InvalidStringProvided msg -> printfn "Din søgning returnerede: ingen %s" msg





    









                   



