/// <summary> Define class 'Animal' </summary>

type Animal(foodIntake: float, currentSpeed: float, maxSpeed: float) =
 
 let mutable cSpeed = 0 

 let rand = System.Random()
 let weight = rand.Next(70, 300)
 let foodPercentage = rand.Next(0, 100)
 
 let (anySpeed: float) = ((float foodPercentage)/100.0)*maxSpeed

 let newIntake = (float weight)/2.0

 member this.foodIntake = foodIntake
 member this.maxSpeed = maxSpeed
 member this.pWeight = weight
 member this.pSpeed = anySpeed
 member this.perc = foodPercentage
 member this.req = newIntake

let testAnimal = new Animal(100.0, 0.0, 25.0)
printfn "%A %A %A %A" testAnimal.pSpeed testAnimal.perc testAnimal.req testAnimal.pWeight

