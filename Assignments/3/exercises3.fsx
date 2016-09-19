// Uge 3 - Øvelser
 // 3ø.0
let a = 3
let b = 4
let x = 5
printfn "%A * %A + %A = %A" a x b (a * x + b)

let y = a*x+b;;
printfn "%A" y 

 // 3ø.1
let a = 3 in let x = 5 in let b = 4 in let y = a * x + b in  printfn "%A" y

 // 3ø.2
let firstName = "Jon" in let lastName = "Sporring" in let  name = firstName + " " + lastName in let greeting = "Hello" + " " + name in printfn "%A" greeting

 // 3ø.3
let a = 3 in let x = 5 in let b = 4 in let f y = a * x + b in  printfn "%A" (f y)

 // 3ø.4
  // 1) For-loop
let f x = a * x + b
    
for i=0 to x do
    printfn "%A" (f i)

  // 2) While-loop
let mutable i = 0
while i < 5 do
    i <- i + 1
    printfn "%A" (f i)


 // 3ø.5
 // 3ø.6
  // (a):





