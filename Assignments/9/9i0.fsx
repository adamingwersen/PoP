/// <summary> Assignment 9i.0 </summary>

/// <summary> Create a Car type explicitly </summary>
/// <param name = "yearOfModel"> Integer value for the model year of whatever Car is to be created </param>
/// <param name = "make"> String value containing the exact model and manufacturer of the Car </param>
/// <param name = "efficiency"> The cars efficiency; Km per liter of gas </param>
/// <param name = "fuel"> Initial ammount of gas in the tank </param>
type Car(yearOfModel: int, make: string, efficiency: float, fuelCap: float) =
/// <member> The cars initial speed is set to zero </member>
 let mutable speed = 0.0

/// <member> The cars initial amount of gas available
 let mutable gas = fuelCap

/// <member> Carry the input variables </member>
 member this.yearOfModel = yearOfModel
 member this.make = make
 member this.efficiency = efficiency

/// <method> Create a method available to the Car type. Add 5 to 'speed' </method>
/// <remarks> If there is no gas left - the car cannot accelerate anymore </remarks>
/// <remarks> When accelerating, gas is being used. Given the efficiency and new speed, subtract an amount of gas from the gas mutable </remarks>
/// <remarks> The amount of gas subrtracted increases with further acceleration </summary>
 member this.accelerate() =
  match gas with
  | gas when (((speed + 5.0)*efficiency)/500.0) >= gas -> failwith "There's no gas left - please refuel before proceeding"
  | _ -> (speed <- speed + 5.0); gas <- gas - ((speed*efficiency)/500.0)

/// <method> Create another method for Car. Subtract 5 from 'speed' </method>
/// <remarks> If the current speed is zero, the car cannot decelerate further </remarks>
/// <remarks> When decelerating, gas is still being used, but as you slow down, the gas consumption decreases </remarks>
 member this.brake() = 
  match gas with 
  | gas when (((speed + 5.0)*efficiency)/500.0) >= gas -> failwith "There's no gas left - you cannot brake! Put on seatbelt and brace for collision."
  | speed when speed = 0.0 -> printfn "You're not driving - slowing down further is not possible" 
  | _ -> (speed <- speed - 5.0); gas <- gas - ((speed*efficiency)/500.0)

/// <member> Retrieve the speed variables current value </member>
 member this.getSpeed = speed
 member this.getGas = gas

/// <summary> Create method for outputting current speed, make and model year of a Car object </summary>
/// <param name = "car"> A Car object to execute method on </param>
let printSpeedSimple(car: Car) = 
 printfn "Your %A from %i is currently driving \t %f Km/h" car.make car.yearOfModel car.getSpeed

/// <summary> Create Car-object </summary>
let dumbCar = new Car(2016, "Porsche Cayenne Turbo S", 6.3, 100.0) 

/// <summary> Accelerate and decelerate five times. Utilize printSpeed to ouput the current speed of Car after each iteration </summary>
printfn "Acceleration phase"
for i = 0 to 4 do
 dumbCar.accelerate()
 printSpeedSimple dumbCar
printfn "Ugh! A red light. Slowing down..."
for i = 0 to 4 do
 dumbCar.brake()
 printSpeedSimple dumbCar

/// <summary> Create same method - but with an added gas-status message </summary>
/// <param name = "car"> A Car object to execute method on </param>
let printSpeed(car: Car) = 
        printfn "Your %A from %i is currently driving \t %f Km/h with   %f litres of gas left" car.make car.yearOfModel car.getSpeed car.getGas

/// <summary> Create another Car-object </summary>
let efficientCar = new Car(2015, "VW Up!", 16.9, 35.0)

/// <summary> Accelerate and decelerate five times. Utilize printSpeed to ouput the current speed and amount of gas left for Car after each iteration </summary>
printfn "Acceleration phase"
for i = 0 to 4 do
 efficientCar.accelerate()
 printSpeed efficientCar
printfn "Ugh! A red light. Slowing down..."
for i = 0 to 4 do
 efficientCar.brake()
 printSpeed efficientCar

/// <summary> TESTING </summary>

/// <remarks> In the section below, both fails cannot be raised, and thus; one of these have been commented out. Uncomment for the test to throw the expected error on the test for accelerate </remarks>

(*
/// <summary> Creating instance, where the car will run out of gas </summary>
printfn "\n Letting the Porsche reach top-speed"
while dumbCar.getSpeed < 360.0 do
 dumbCar.accelerate()
 printSpeed dumbCar
*)

/// <summary> Creating instance, where the car will run out of gas while braking </summary>
printfn "\n Trying to brake without any gas left"
while dumbCar.getSpeed < 250.0 do
 dumbCar.accelerate()
 printSpeed dumbCar

while dumbCar.getSpeed > 0.0 do
 dumbCar.brake()
 printSpeed dumbCar





