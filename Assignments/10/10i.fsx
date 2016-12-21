/// <summary> Define class 'Animal' </summary>

type Animal(animal: char, foodIntake: float, currentSpeed: float, maxSpeed: float) =

 let rand = System.Random()
 let (weight: float) = (float (rand.Next(70, 300)))
 let (foodPercentage: float) = (float (rand.Next(0, 100)))
 
 let (anySpeed: float) = (foodPercentage/100.0)*maxSpeed

 let newIntake = (float weight)/2.0

 member this.foodIntake = foodIntake
 member this.maxSpeed = maxSpeed
 member this.pWeight = weight
 member this.pSpeed = anySpeed
 member this.perc = foodPercentage
 member this.req = newIntake

type Carnivore(foodIntake:float, currentSpeed:float, maxSpeed:float) =
 inherit Animal()

 let relIntake = weight*0.08
 member this.relIntake = relIntake

let testAnimal = new Animal(100.0, 0.0, 25.0)
printfn "%A %A %A %A" testAnimal.pSpeed testAnimal.perc testAnimal.req testAnimal.pWeight

