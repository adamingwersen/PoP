open System
Console.WriteLine "Indtast et fuldt URL, du kunne tænke dig at vide mere om."
Console.WriteLine "URL skal være af typen https://google.com"
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

let html = readURL url
Console.WriteLine html.[0..]
