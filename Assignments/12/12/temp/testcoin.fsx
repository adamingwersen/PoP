open System.Windows.Forms
open System.Drawing
  
let noBins = 10

let coinPic = Image.fromFile "coins.jpg"
let grayCoinPic = Image.toGray coinPic

let toX, toY = Image.histogram grayCoinPic noBins
printfn "x: %A, y: %A" toX toY

type column = Point []
let mutable columnList = [] : column List

let makeColumnList(xList: float [], yList: int [], bins: int, scale: int) =
 let yScale = float(175*scale)
 printfn "yscale %A" yScale
 let yMax = float(Array.max toY)
 printfn "%A" yMax
 for i in [0 .. bins] do
  let temp = [| Point (25+(int)xList.[i]+bins,int(yScale));
                Point (25+(int)xList.[i]+bins,int(yScale) - int(yScale*float(float(yList.[i])/(yMax))));
                Point (25+(int)xList.[i]+255/bins,int(yScale) - int(yScale*float(float(yList.[i])/(yMax))));
                Point (25+(int)xList.[i] + 255/bins,int(yScale));
                Point (25+(int)xList.[i]+bins,int(yScale))|]
  columnList <- temp :: columnList
 printfn "%A" columnList
 printfn "%A %A" yList.[0] (float(yList.[0])/yMax)

let drawColumns(evnt: PaintEventArgs) = 
 let pen = new Pen (Color.Black)
 for col in columnList do
  evnt.Graphics.DrawLines(pen, col)

makeColumnList(toX, toY, noBins, 1)

let scales = 1

let wForm = new Form()
wForm.Text <- "Histogram" 
wForm.Paint.Add drawColumns
wForm.ClientSize <- Size (550*scales, 350*scales)

let label1 = new Label(Text = "0", Location = Point(30*scales, 195*scales))

wForm.Controls.Add label1

Application.Run wForm


