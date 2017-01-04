type Coordinates() = 
 let rand = System.Random()
 member this.rlat = 
         rand.NextDouble() * 180.0 - 90.0
 member this.rlon =
         rand.NextDouble() * 360.0 - 180.0


let testCoord = new Coordinates()
for i = 0 to 10 do
 printfn "%A %A" testCoord.rlat testCoord.rlon

type Waypoint(name: string) =
 let coord = new Coordinates()
 member this.alat = coord.rlat
 member this.alon = coord.rlon
 member this.aname = name

let aPoint = new Waypoint("McDonalds")
//for i = 0 to 5 do
// printfn "%A %A %A" aPoint.aname aPoint.alat aPoint.alon

let tPoint = new Waypoint("Burger King")

let dlon = aPoint.alon - tPoint.alon
let dlat = aPoint.alat - tPoint.alat
let a = (sin(dlat/2))^2 + cos(aPoint.alat) * cos(tPoint.alat) * (sin(dlon/2))^2


