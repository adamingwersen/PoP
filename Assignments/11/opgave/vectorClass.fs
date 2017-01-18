module vectorClass
open System.Windows.Forms
open System.Drawing

type Vector (a:float,b:float)= class
   let mutable X=a
   let mutable Y=b

   member this.y =Y
   member this.x =X
   member this.xy = (this.x,this.y)

   member this.ToPoint ()=
     Point((int (this.x)), (int (this.y)))

   //member this.dis (v2:Vector) =
   //sqrt((v2.x-this.x)*(v2.x-this.x)+(v2.y-this.y)*(v2.y-this.y))

   member this.dis ()=
     sqrt((this.x ** 2.0)+(this.y ** 2.0))

   member this.turn ()=
      Vector(-this.x,-this.y)

   static member (+) (v1:Vector,v2:Vector)=
     Vector(v1.x+v2.x,v1.y+v2.y)

   static member (-) (v1:Vector,v2:Vector)=
     Vector(v2.x-v1.x,v2.y-v1.y)

   static member (*) (v1:Vector,i:float)=
     Vector(v1.x*i,v1.y*i)

   override  this.ToString()=
    sprintf "%A" this.xy
end
