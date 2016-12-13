/// <summary> Assignment 9i.0 </summary>

type Car(yearOfModel: int, make: string) =
        let mutable speed = 0.0
        member this.yearOfModel = yearOfModel
        member this.make = make
        
        member this.accelerate() = 
                speed <- speed + 5.0

        member this.brake() = speed <- speed - 5.0
 
        member this.getSpeed = speed


let myCar = new Car(2015, "Audi A5, 2.0 TDI")
let printSpeed(car: Car) = 
        printfn "Your %A from %i is currently driving \t %f Km/h" car.make car.yearOfModel car.getSpeed

printSpeed myCar

for i = 0 to 4 do
        myCar.accelerate()
        printSpeed myCar
for i = 0 to 4 do
        myCar.brake()
        printSpeed myCar
