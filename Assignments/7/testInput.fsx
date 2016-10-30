/// Testing DivByZero : Part 11.1
let div enum denom =
    try
        enum / denom
    with
        | :? System.DivideByZeroException -> System.Int32.MaxValue
printfn "3/1 = %d" (div 3 1)
printfn "3/0 = %d" (div 3 0)

/// Testing DontLikeFive : Part 11.4 + 11.5
exception Kanikkelide of string

let picky a =
    if a = 5 then
        raise (Kanikkelide "5 Sucks!")
    else
        a
try
    printfn "picky of %A = %A" 3 (picky 3)
    printfn "picky of %A = %A" 5 (picky 5)
with
    | Kanikkelide msg -> printfn "Exception caught w message: %s" msg
    
/// Testing failwith : Part 11.9
let _ =
    try
        failwith "Shieet"
    with
        Failure msg ->
            printfn "Fuck this %A" msg



/// Testing 

/// Testing Keyboard Input : Part 12.1

(*
System.Console.WriteLine "Multiply this"
System.Console.Write "Enter something: "
let something = float (System.Console.ReadLine())
System.Console.Write "Enter something else:"
let somethingelse = float (System.Console.ReadLine())
System.Console.WriteLine ("something * something else = " + string (something*somethingelse))
*)

/// Testing IO - openFile : Part 12.2
let filename = "afile.txt"

let reader =
    try
        Some (System.IO.File.Open ( filename, System.IO.FileMode.Open))
    with
        _ -> None

if reader.IsSome then
    printfn "The File %A was succesfully opened." filename
    reader.Value.Close()

/// Testing IO - readFile : Part 12.3
let printFile (inputreader : System.IO.StreamReader) =
    while not(inputreader.EndOfStream) do
        let line = inputreader.ReadLine ()
        printfn "%s" line
let inputreader = System.IO.File.OpenText filename
printFile inputreader

/// Testing IO - File.Exists : Part 12.(?)

let pathfile = "~/Documents/Uni/CompSci/PoP/Assignments/7/afile.txt"
let otherpathfile = "afile.txt"

let checkExistence file =
    try
        System.IO.File.Exists file
    with
        _ -> false
/// Ask T.A.
printfn "The file %s exists: %A" pathfile (checkExistence pathfile)
printfn "The file %s exists: %A" otherpathfile (checkExistence otherpathfile)

/// Testing reading from Internet : Part 12.4

/// URL ::Up:: Stream
let url2Stream url =
    let uri = System.Uri url
    let request = System.Net.WebRequest.Create uri
    let response = request.GetResponse ()
    response.GetResponseStream ()

/// URL ::Down:: Stream
let readURL url =
    let stream = url2Stream url
    let reader = new System.IO.StreamReader(stream)
    reader.ReadToEnd ()

let writeURLContent stream =
    let writer = new System.IO.StreamWriter(html.[0..])
    writer.WriteToEnd ()

let url = "https://google.com"
let a = 10
let newfilename = "httrGet.txt"
let html = readURL url

open System.Net
open System.IO
File.WriteAllText(newfilename, html.[0..])   
printfn "Downloaded from %A. Wrote file to %A. First %d chars are: \n  %A" url newfilename a html.[0..a]     


(*
let rec writeFile (stream : System.IO.StreamWriter) text =
    match text with
    | (l : string) :: ls ->
        stream.StreamWriter l
        writeFile stream ls
    | _ -> ()
let outputStream = System.IO.File.CreateText "secondhttr.txt"
writeFile outputStream html.[0..]
*)







    




    


