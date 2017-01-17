module vector

type vector =
   |Vector of float*float

   static member (+) : vector * vector -> vector
     
   static member (*) : vector * float  -> vector 

   static member (-) : vector * vector -> float