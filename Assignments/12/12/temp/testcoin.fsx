open System.Windows.Forms
open System.Drawing
  
let noBins = 13
let xOffset = 25
let yOffset = 45
let scales = 2
let yScale = float(175*scales)


let coinPic = Image.fromFile "coins.jpg"
let grayCoinPic = Image.toGray coinPic

let toX, toY = Image.histogram grayCoinPic noBins
printfn "x: %A, y: %A" toX toY
let xZero = xOffset + int(toX.[0])+noBins

type column = Point []
let mutable columnList = [] : column List
let mutable yMax = 0.0
let makeColumnList(xList: float [], yList: int [], bins: int, scale: int) =
 yMax <- float(Array.max toY)
 for i in [0 .. bins] do
  if i = 0 then
   let temp = [| Point (25+(int)xList.[i]+bins,int(yScale)+yOffset);
                 Point (25+(int)xList.[i]+bins,yOffset + int(yScale) - int(yScale*float(float(yList.[i])/(yMax))));
                 Point (25+(int xList.[i])*scale+255/bins,yOffset + int(yScale) - int(yScale*float(float(yList.[i])/(yMax))));
                 Point (25+(int xList.[i])*scale + 255/bins,yOffset + int(yScale));
                 Point (25+(int)xList.[i]+bins,yOffset+int(yScale))|]
   columnList <- temp :: columnList 
  else 
   let temp = [| Point (25+(int xList.[i-1])*scale+255/bins,yOffset+ int(yScale));
                 Point (25+(int xList.[i-1])*scale+255/bins,yOffset+ int(yScale) - int(yScale*float(float(yList.[i])/(yMax))));
                 Point (25+(int xList.[i])*scale+255/bins,yOffset+ int(yScale) - int(yScale*float(float(yList.[i])/(yMax))));
                 Point (25+(int xList.[i])*scale + 255/bins,yOffset+ int(yScale));
                 Point (25+(int xList.[i-1])*scale+255/bins,yOffset+ int(yScale))|]
   columnList <- temp :: columnList

let mutable yAxis = [] : column List
let yCoord = [| Point (xZero, yOffset); Point (xZero, yOffset + int(yScale))|]  
printfn "%A" yCoord
yAxis <- yCoord :: yAxis

let drawColumns(evnt: PaintEventArgs) = 
 let pen = new Pen (Color.Black)
 for col in columnList do
  evnt.Graphics.DrawLines(pen, col)
 for pkt in yAxis do
  evnt.Graphics.DrawLines(pen, pkt)

makeColumnList(toX, toY, noBins, scales)

let wForm = new Form()
wForm.Text <- "Histogram" 
wForm.Paint.Add drawColumns
wForm.ClientSize <- Size (550*scales, 350*scales)

let xMinLab = new Label(Text = "0", Location = Point(30*scales+xOffset, 195*scales+yOffset))
let xMaxLab = new Label(Text = "255", Location = Point(255*scales+xOffset, 195*scales+yOffset))
let yMaxStr = string yMax
let yMaxLab = new Label(Text = yMaxStr, Location = Point(5*scales,yOffset)) 
wForm.Controls.Add xMinLab 
wForm.Controls.Add xMaxLab 
wForm.Controls.Add yMaxLab


Application.Run wForm


