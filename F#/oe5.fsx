/// <summary> Opgave 5.1 </summary>
let func x = x*2
let reverseApply x f = 
    (f x)

printfn "%A" (reverseApply 10 func)

/// <summary> Opgave 5.2 </summary>


/// <summary> Opgave 5.3 </summary>
let evenMod x = x % 2
let numbers = [1;2;3;4;5;6]

let evens numbers =
    List.filter(fun x -> (evenMod x) = 0) numbers
    
printfn "%A" (evens numbers)

/// <summary> Opgave 5.4 </summary>

let f1 x = x / 2
let f2 x = x * 2
let f3 x = x + 2
let f4 x = x - 2

let fctList = [f1; f2; f3; f4]
let liste = [5; 5; 5; 5]

let applyList f x =
    List.map (fun y -> (reverseApply (y))) x


printfn "%A" (applyList fctList liste)

/// <summary> Opgave 5.6 </summary>

let ssort xs = Set.toList(Set.ofList xs)

let a = [1; 1; 2; 9; 9; 9; 5; 11; 75; 23; 99]

printfn "%A" (ssort a)









 



