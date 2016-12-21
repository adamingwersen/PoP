/// <summary> Define class 'Animal' </summary>

type Animal(foodIntake: float, currentSpeed: float, maxSpeed: float) =
 
 let mutable cSpeed = currentSpeed

 let rand = System.Random()
 let weight = rand.Next(70, 300)

 member this.foodIntake = foodIntake
 member this.maxSpeed = maxSpeed
 member this.currentSpeed = currentSpeed
 member this.pWeight = weight

let testAnimal = new Animal(100.0, 0.0, 25.0)
printfn "%A" testAnimal.pWeight

