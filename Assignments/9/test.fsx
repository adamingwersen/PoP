open System
type Car(efficiency : float,  model : string) = class
 let mutable gas = 0.0
 let efficiency = efficiency
 
 member x.Efficiency = efficiency
 member x.Model = model
 member x.Gas = gas
 
 member x.addGas(value) = gas <- gas + value
 member x.gasLeft(gas) = gas
 member x.drive(distance) = function
  match vehicle.gasLeft with
  | 0 -> failwith "Shiet!"
  | _ -> gas <- gas - (distance/vehicle.Efficiency)
  
end


