/// <summary> Define class 'Animal' </summary>
(*
type Animal(animal: char, foodIntake: float, currentSpeed: float, maxSpeed: float) =

 let rand = System.Random()
 let (weight: float) = (float (rand.Next(70, 300)))
 let (foodPercentage: float) = (float (rand.Next(0, 100)))
 
 let (anySpeed: float) = (foodPercentage/100.0)*maxSpeed

 let newIntake = (float weight)/2.0
 abstract member specieSpeed: unit -> float
 default this.specieSpeed() = weight

 member this.foodIntake = foodIntake
 member this.maxSpeed = maxSpeed
 member this.pWeight = weight
 member this.pSpeed = anySpeed
 member this.perc = foodPercentage
 member this.req = newIntake

type Carnivore(animal: char, foodIntake:float, currentSpeed:float, maxSpeed:float) =
 inherit Animal()

 override this.specieSpeed() = base.specieSpeed()*0.08
*)

[<AbstractClass>]
type Animal(weight:float, maxSpeed: float) = 
 let rand = System.Random()  

 let mutable speed = 0.0
 let mutable food = 0.0

 let mutable foodPercentage = (float (rand.Next(0, 100)))
 let mutable weight = (float (rand.Next(70, 300)))
 
 member this.setSpeed() = speed <-((foodPercentage/100.0)*maxSpeed)
 
 abstract member foodNeeded: unit -> unit
 member this.foodNeeded() = this.food <- ((this.food)*(this.maxSpeed/100.0))

 member this.getSpeed = speed
 member this.getFood = food

type Carnivore(maxSpeed: float) =
 inherit Animal(maxSpeed: float)

 override this.foodNeeded() = this.food <- (this.weight*0.08)
 
type Herbivore(maxSpeed: float) =
 inherit Animal(maxSpeed: float)

 override this.foodNeeded() = this.food <- (this.weight*0.4)

let testAnimal = new Animal(0.0, 50.0)
testAnimal.setSpeed()
testAnimal.foodNeeded()
printfn "%A" testAnimal.getSpeed
printfn "%A" testAnimal.getFood
(*
let testCheetah = new Carnivore(100.0)
printfn "%A %A" testCheetah.foodNeeded testCheetah.currentSpeed
*)
