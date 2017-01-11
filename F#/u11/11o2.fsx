tyItem(name: string, price: float, qty: int) = 
 let mutable qty = qty
 member this.reduceQty() = 
         qty <- qty - 1
 
 member this.getName = name
 member this.getQty = qty
 member this.getPrice = price

 member this.printItem =
  printfn "[name : %A, price: %A, qty: %A]" name price qty 

type Cart(id: int, value: float) = 
 let rand = System.Random()

 let mutable (items: Item[]) = [||]
 let mutable value = 0.0

 member this.id = rand.Next(0,9999)

 member this.addItem(newItem: Item) = 
  items <- Array.append items [|newItem|]
 
 member this.removeItem(theItem : string) = 
  for i in items do
   if ((i.getName = theItem) && (i.getQty > 1)) then 
    i.reduceQty()
   else if ((i.getName = theItem) && (i.getQty = 1)) then
    //items |> Array.filter ((<>)i)
    items <- Array.filter ((<>)i) items

 member this.getItems = 
  for i in items do
   i.printItem
 

 member this.getCartValue =  
  let mutable cartVal = 0.0
  for i in items do
   cartVal <- i.getPrice * (float(i.getQty)) + cartVal
  cartVal
  let tmp = Array.fold (fun acc (i:Item) -> acc + i.getPrice*(float(i.getQty))) 0.0 items 
  tmp = cartVal

let drone = new Item("Drone", 1499.00, 1)
let gopro = new Item("Go Pro 4", 2499.00, 1)
let paper = new Item("A4 Paper x 500", 67.00, 1)

let cart1 = new Cart(0, 0.0)
cart1.addItem(drone)
cart1.addItem(gopro)
printfn "%A" cart1.getItems
printfn "%A" cart1.id
printfn "%A" cart1.getCartValue
