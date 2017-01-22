
let RNG =  new System.Random()


///<summary> the class 'Animal' which is used as base for the other classes</summary>
///<param name = "weight"> weight is a float used in both metods and as a attribute</param>
///<param name = "maxSp" > maxSp is a float used in both metods and as a attribute</param>
type Animal(weight : float, maxSp : float)=

  let mutable speed = 0.0
  let mutable mad = 0.0

///<remarks> Class properties</remarks>
  member this.weight = weight
  member this.maxSp  = maxSp
  member this.curSp  = speed

///<remarks> Adding an abstract property to the Class </remarks> 
  abstract member food: float
  default this.food = mad

///<remarks> An abstract method which can be overridden</remarks>
  abstract member Hunger: unit-> unit 

///<summary>the method sets the value of the attribute 'food'</summary>
///<returns>the method returns unit (the equivalent of void)</returns>
  default this.Hunger() =
    mad  <- (weight/2.0)

///<summary>the method 'Eat' sets the value of the attribute 'curSp'</summary>
///<param name = "food">food is a Float </param>
///<returns>the method returns unit (the equivalent of void)</returns>
  member this.Eat food =
    speed <- ((food/this.food)*this.maxSp)

///<summary>the method 'Run' calls 'Eat' with a Random value 'temp' and prints both 'temp' and the time needed to travel 10 km</summary>
///<returns>the method returns unit (the equivalent of void)</returns>
  member this.Run =
    let pro  = RNG.Next (1,101)
    let temp = (( float(pro) ) / 100.0 )*this.food
    this.Eat temp
    printfn "%A procent" pro 
    printfn "der spises %A kg og løbes %A timer" temp (int(10000.0/this.curSp))
    
///<remarks> a new contructor useing only a single input</remarks>
  new (maxSp) = Animal((float(RNG.Next(70,301))) , maxSp)

///<summary> a Class extending 'Animal' with the same params</summary>
type Herbivore(weight : float, maxSp : float)=
  inherit Animal(weight,maxSp)
  
  let mutable mad = 0.0
  let temp = weight

///<remarks>overrideing a method and a Attribute </remarks>   
  override this.food = mad
  override this.Hunger() =
    mad <- (temp*0.4)


///<summary> a Class extending 'Animal' with the same params</summary>
type Carnevore(weight : float, maxSp : float)=
  inherit Animal(weight,maxSp)
  
  let mutable mad = 0.0
  let temp = weight
///<remarks>overrideing a method and a Attribute </remarks>  
  override this.food = mad
  override this.Hunger() =
    mad <- (temp*0.08)



///<remarks>testing with objects</remarks>
let kat = new Animal(100.0, 200.0)
kat.Hunger()
kat.Run

let cheetah = new Carnevore(50.0,114.0)
cheetah.Hunger()
cheetah.Run

let antelope = new Herbivore(50.0,95.0)
antelope.Hunger()
antelope.Run

let Wilderbeast = new Herbivore(200.0,80.0)
Wilderbeast.Hunger()
Wilderbeast.Run
