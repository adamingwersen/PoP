open System.Drawing

// Loads and image file into an array of System.Drawing.Colors objects.
let load (img : string) =
  let bmp = new Bitmap(img)
  // alternatively Array2D.init (to save the dimensionality)
  [|for y in 0..bmp.Height-1 do for x in 0..bmp.Width-1 -> bmp.GetPixel(x,y)|]

// Averages the intensity over all three colour channels.
// (if you are working with a grayscale image these will be the same).
let averageIntensity =
  Array.map (fun (c : Color) -> (int c.R + int c.G + int c.B)/3)

// Here's a way to load an image
let image = (load >> averageIntensity) "./classic.jpeg"
