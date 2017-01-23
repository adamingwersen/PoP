/// <summary> Load the namespaces for drawing. </summary>
open System.Text.RegularExpressions
open System.Windows.Forms
open System.Drawing
open System.IO
open System
  
/// <remarks> Define the number of bins to be represented in the histogram chart. </remarks>
let mutable noBins = 0

/// <remarks> Define the scaling of the chart, between 1-2. </remarks> 
let mutable scales = 0

/// <summary> User interaction: lines 14-43 </summary>
Console.WriteLine "\n\n\t\t\t\t----- 12i_Histogram -----\nDette program lader brugeren visualisere fordelingen af gråtoner i et billede efter eget valg. \nBrugeren kan selv konfigurere antallet af bins i histogrammet - ligeledes billedet skaleres."
Console.WriteLine "\n\t\t\t\t----- VÆLG FIL -----\nDer ligger billedfiler i .jpg-format i denne mappe. Du kan nemt tilføje en fil til mappen, hvis denne ønskes visualiseret.\n"

/// <remarks> Get all .jpg files in the current directory and convert to string list </remarks>
let mutable jpgPath =  Directory.GetFiles(Environment.CurrentDirectory, "*.jpg") |> List.ofArray

/// <remarks> Create regex, which grabs only the filename without extension </remarks>
let regx = @"([^/]+(?=[\.]))"

Console.WriteLine "Disse filer ligger i denne mappe:\n"

/// <remarks> Apply the regex and print the files in console. </remarks>
for i=0 to jpgPath.Length-1 do
 let mutable folderContents = Regex.Match(jpgPath.[i].ToString(), regx)
 printfn "\t%A\n" folderContents

/// <remarks> Allow user to choose a file from the folder </remarks>
Console.WriteLine "Tast navnet på den fil, du øsnker at visualisere, undlad .jpg:"
let mutable (jpgIn: string) = string (Console.ReadLine()) 
let mutable (jpgInput: string) = jpgIn + ".jpg"

/// <remarks> Generate title for the bitmap to be shown. </remarks>
let histTitle = "Gråtone-Histogram : " + jpgInput

Console.WriteLine "\n\t\t\t\t------- BINS -------\nVælg venligst antal bins som heltal større end 1 og mindre end 1020:\n"
noBins <- int (Console.ReadLine())
noBins <- noBins - 1
Console.WriteLine "\t\t\t\t----- SKALERING -----\nDu kan skalere billedet i 2 størrelser, ml. 1-2 - vælg venligst skalering:\n"
scales <- int (Console.ReadLine())+1
printfn "Du vil få vist et histogram med %A bins skaleret med faktor %A" (noBins+1) (scales - 1)

/// <remarks> Define an offset for the x-axis to keep distance from edges and labels. </remarks>
let xOffset = 80 + 20*scales

/// <remarks> Define an offset for the y-axis to keep distance from edges and labels. </remarks>
let yOffset = 45

/// <remarks> Utilize the "scales" parameter to create a scaling parameter for the y-axis. </remarks>
let yScale = float(175*scales)

/// <summary> The following 3 lines are dependent on the image.fs module provided by Jon Sporring for this assignment. </summary>
/// <remarks> Load a color-image from the current directory, .jpg-format </remarks>
let thePic = Image.fromFile jpgInput

/// <remarks> Convert the image to a graytone image </remarks>
let grayPic = Image.toGray thePic 

/// <remarks> Write file for use in report </remarks>
let colPic = Image.toColor grayPic
let jpgOutput = Path.Combine(Environment.CurrentDirectory, (jpgIn + "_gray" + ".jpg"))
Image.toFile jpgOutput colPic

/// <remarks> Utilize the histogram function from the image-module </remarks>
let toX, toY = Image.histogram grayPic noBins

/// <remarks> xZero should be interpreted as the lowest value on the x-axis of the histogram chart </remarks>
let xZero = xOffset + int(toX.[0])

/// <remarks> Set the width of bins </remarks>
let mutable spacing = int(float(1020)/float(noBins))

/// <remarks> When creating dynamic spacing, it's necessary to set an upper bound for the binsize - this ensures more aestethically charts </remarks>
if spacing > 300 
then spacing <- 300

/// <remarks> Create a new type using Point()'s. </remarks>
type column = Point []

/// <remarks> Create a list of column-types. </remarks>
let mutable columnList = [] : column List

/// <remarks> From the histogram array toY, store the largest y-value. This proves useful in scaling the chart. </remarks>
let mutable yMax = float(Array.max toY)

/// <summary> makeColumnList: This function creates coordianates for drawing the bins of a histogram. </summary>
/// <param name = "xList"> The x-values provided by the graytone histogram function. These will always be 0-255. </param>
/// <param name = "yList"> The y-values provided by the graytone histogram function. These are nominal values, and counts the number of pixels within a span of the graytone colorspectrum. The data provided are count values, and as such, the sum of these will be determined by the image size / number of pixels. </param>
/// <param name = "bins"> The number of bins, that we wish to visualize. </param>
/// <param name = "scale"> The scaling to be applied to the histogram, the scale parameter will increase the distance between points according to the integer provided. </param>
/// <remarks> The makeColumnList-function determines the coordinates via a for-loop and an if/else  statement. The if-statement should be interpreted as follows: If the value-set provided is the first, then it is necessary to establish a coordinate base for the graph. If not, it is necessary to set the points relative to the previos points. This ensures, that the bins will be directly adjacent to each other. </remarks>
/// <remarks> In defining the height of the graph, and thus the height of the bins, the points illustrating the height of the bin is calulated as the relative size of the i'th observation relative to the highest y-value, yMax. </remarks>
/// <remarks> The reason for creating 4 coordinates per input data-point is that in order to draw the bins, a rectangle shape is necessary: Here, the points for an inverse cup-shape are created. The bottom is provided by the x-axis defined below. </remarks>
/// <remarks> For each iteration, append the set of points to columnList. </remarks>
let makeColumnList(xList: float [], yList: int [], bins: int, scale: int) =
 for i in [0 .. bins] do
  if i = 0 then
   let temp = [| Point (xZero, int(yScale)+yOffset);
                 Point (xZero, yOffset + int(yScale) - int(yScale*float(float(yList.[i])/(yMax))));
                 Point (xZero + spacing, yOffset + int(yScale) - int(yScale*float(float(yList.[i])/(yMax))));
                 Point (xZero + spacing, yOffset + int(yScale))|]
   columnList <- temp :: columnList
  else 
   let temp = [| Point (xZero + (spacing*i), yOffset+ int(yScale));
                 Point (xZero + (spacing*i), yOffset+ int(yScale) - int(yScale*float(float(yList.[i])/(yMax))));
                 Point (xZero + (spacing*(i+1)), yOffset+ int(yScale) - int(yScale*float(float(yList.[i])/(yMax))));
                 Point (xZero + (spacing*(i+1)), yOffset+ int(yScale))|]
   columnList <- temp :: columnList

/// <summary> Define the coordinates of the y- and x axes. </summary>
/// <remarks> The y-axis is stationary in x, and should be represented from min to max in the histogram. </remarks>
/// <remarks> Define a list containing the "column" type. </remarks>
let mutable yAxis = [] : column List

/// <remarks> Create a set of y coordinates. </remarks>
let yCoord = [| Point (xZero, yOffset); Point (xZero, yOffset + int(yScale))|]
/// <remarks> Append the set of coordinates to the empty yAxis list. </remarks>  
yAxis <- yCoord :: yAxis
/// <remarks> Here, a similar line of reasoning goes for the x-axis. As the grey-tone conversion will always have a highest value in 255, this is stated as the relative maximum value here </remarks>
let mutable xAxis = [] : column List
let xCoord = [| Point (xZero, yOffset + int(yScale)); Point (xZero + spacing*(noBins+1), yOffset + int(yScale))|]  
xAxis <- xCoord :: xAxis

/// <summary> drawColumns: This function defines a Pen(), which is then used to "draw" lines between each successive point defined in the columnList, yAxis and xAxis </summary>
/// <param name = "evnt"> The PaintEventArgs Class from the System.Windows.Forms namespace </param>
/// <remarks> For each set of coordinates or Point() in columnList, yAxis and xAxis, respectively; draw a line between the [i]'th coordiante set and the [i+1]'th </remarks> 
let drawColumns(evnt: PaintEventArgs) = 
 let pen = new Pen (Color.Black)
 let brush = new SolidBrush (Color.Gray)
 for col in columnList do
  evnt.Graphics.DrawLines(pen, col)
  evnt.Graphics.FillPolygon(brush, col)  
 for pkt in yAxis do
  evnt.Graphics.DrawLines(pen, pkt)
 for pkt in xAxis do
  evnt.Graphics.DrawLines(pen, pkt)

/// <remarks> Instantiate the function with the parameters defined at the beginning of the program </remarks>
makeColumnList(toX, toY, noBins, scales)

/// <summary> Create a new instance of winform Form(), and draw the graph using the drawColumns function </summary>
let wForm = new Form()
wForm.Text <- histTitle 
wForm.Paint.Add drawColumns
wForm.ClientSize <- Size (xZero + spacing*(noBins + 1) + 35, xOffset + 200*scales)

/// <summary> Create Labels for Histogram Chart </summary>
/// <remarks> These labels have been created such that their position scale with the number of bins and the overall graph size </remarks>
let xMinLab = new Label(Text = "0", Location = Point(xZero, 195*scales+yOffset))
let xLowLab = new Label(Text = "50", Location = Point(int(0.20*float(spacing*(noBins+1)))+xZero, 195*scales+yOffset))
let xLoHLab = new Label(Text = "100", Location = Point(int(0.40*float(spacing*(noBins+1)))+xZero, 195*scales+yOffset))
let xMidLab = new Label(Text = "150", Location = Point(int(0.60*float(spacing*(noBins+1)))+xZero, 195*scales+yOffset))
let xHiLLab = new Label(Text = "200", Location = Point(int(0.80*float(spacing*(noBins+1)))+xZero, 195*scales+yOffset))
let xMaxLab = new Label(Text = "255", Location = Point(xZero + spacing*(noBins+1), 195*scales+yOffset))

/// <remarks> The y-axis' labels should be proportionate to the greytone-count in the largest bin </remarks>
let yMaxStr = string (int yMax)
let yLowStr = string (int (yMax*0.25))
let yMidStr = string (int (yMax*0.5))
let yHigStr = string (int (yMax*0.75))

let yMinLab = new Label(Text = "0", Location = Point(5*scales, int(yScale) + yOffset))
let yLowLab = new Label(Text = yLowStr, Location = Point(5*scales, int(0.75*yScale) + yOffset))
let yMidLab = new Label(Text = yMidStr, Location = Point(5*scales, int(0.5*yScale) + yOffset))
let yHigLab = new Label(Text = yHigStr, Location = Point(5*scales, int(0.25*yScale) + yOffset))
let yMaxLab = new Label(Text = yMaxStr, Location = Point(5*scales,yOffset))

/// <summary> Add the labels to the winforms object </remarks>
wForm.Controls.Add xMinLab 
wForm.Controls.Add xLowLab 
wForm.Controls.Add xLoHLab 
wForm.Controls.Add xMidLab
wForm.Controls.Add xHiLLab  
wForm.Controls.Add xMaxLab 
wForm.Controls.Add yMinLab
wForm.Controls.Add yLowLab
wForm.Controls.Add yMidLab
wForm.Controls.Add yHigLab
wForm.Controls.Add yMaxLab

/// <summary> Run Winforms application </summary>
Application.Run wForm
