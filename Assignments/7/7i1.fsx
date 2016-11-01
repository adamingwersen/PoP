/// <summary> 7i.1 </summary>

let filename = "filename_7i2.txt"

let fileReplace filename (needle : string) replace =
    let mutable (corpus : string) =
        try
            let (text : string) (filename : string) =
                System.IO.File.OpenText (filename)
            text.ReadToEnd ()
            text.Close()
        with
        | _ -> failwith "Could not locate file."
    let mutable mover = 0
    let mutable counter = 0
    while mover <= (corpus.Length - needle.Length) do
        match (corpus.[mover..(mover + needle.Length)]) with
            | q when q = corpus.[needle] -> 
