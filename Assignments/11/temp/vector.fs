module vector

type vector =
   |Vector of float*float

   static member (+) (Vector(s1,t1):vector,Vector(s2,t2):vector)=
     Vector(s1+s2,t1+t2)
     
   static member (*) (Vector(s1,t1):vector,i:float)=
     Vector(s1*i,t1*i)


   static member (-) (Vector(s1,t1),Vector(s2,t2)) =
      sqrt((s2-s1)*(s2-s1)+(t2-t1)*(t2-t1))  