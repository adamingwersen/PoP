open System.Windows.Forms
open System.Drawing

type column = Point []

let mutable columnList = [] : column List

let imageValues = Image.fromFile("cameraman.jpg")

let greyScale = Image.toGray(imageValues)

let xValues, yValues = Image.histogram(greyScale)(10)
printfn "%A" xValues
printfn "%A" yValues

let makeColumnList(xList : float [], yList : int [], bins : int) =
  for i in [0 .. bins - 1] do
    let tmp = [| Point (50 + (int) xList.[i], 350);
                 Point (50 + (int) xList.[i], 350 - yList.[i] / 100);
                 Point (50 + (int) xList.[i + 1], 350 - yList.[i] / 100);
                 Point (50 + (int) xList.[i + 1], 350);
                 Point (50 + (int) xList.[i], 350) |]
    columnList <- tmp :: columnList

let drawColumns(e : PaintEventArgs) =
  let penColor = Color.Black
  let pen = new Pen (penColor)
  for col in columnList do
    e.Graphics.DrawLines(pen, col)

makeColumnList(xValues, yValues, 10)
let win = new Form()
win.Text <- "HISTOGRAM"
win.Paint.Add drawColumns
win.ClientSize <- Size (400, 400)

let label1 = new Label(Text = "0", Location = Point(50, 375))

win.Controls.Add label1

Application.Run win
