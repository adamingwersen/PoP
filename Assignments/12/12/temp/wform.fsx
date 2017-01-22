open System
open System.Windows.Forms
open FSharp.Charting 
 [<EntryPoint>]
 [<STAThread>]
 let main argv = 
          
  Application.EnableVisualStyles()
  Application.SetCompatibleTextRenderingDefault false                
  use form = new Form()
  Application.Run (Chart.Line([ for x in 0 .. 10 -> x, x*x ]).ShowChart()) 
  0 
