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

let fileWriteReplace (filename : string) =
    try
        let text =  System.IO.File.OpenText (filename)
        text.ReadToEnd()
        text.Close()
    with
        |_ -> failwith "Filen kunne ikke findes."




    let mutable mover = 0
    let mutable counter = 0
    while mover <= (corpus.Length - needle.Length) do
        match (corpus.[mover..(mover + needle.Length)]) with
            | q when q = corpus.[needle] -> 



let rec erstat (s:string) (n:string) (r:string) i=
    match n with
    |b when i >= (s.Length-n.Length) -> s
    |b when b = s.[i..(i+n.Length-1)] -> (erstat (s.[..(i-1)]+r+s.[(i+n.Length)..]) n r (i+r.Length))
    |_-> (erstat s n r (i+1))

 

