using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Drawing;

namespace GraphicsApp
{
    public class Filter
    {
        public Bitmap ByKernel(Bitmap image)
        {
            Bitmap newImage = (Bitmap)image.Clone();

            for (int x = 0; x < newImage.Width; x++)
            {
                for (int y = 0; y < newImage.Height; y++)
                {
                    Color pixelColor, Am1p1, A_0p1, Ap1p1, Am10, A_00, Ap10, Am1m1, A_0m1, Ap1m1;

                    try
                    {
                        pixelColor = newImage.GetPixel(x - 1, y + 1);
                        Am1p1 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    }
                    catch
                    {
                        Am1p1 = Color.FromArgb(0, 0, 0);
                    }

                    try
                    {
                        pixelColor = newImage.GetPixel(x, y + 1);
                        A_0p1 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    }
                    catch
                    {
                        A_0p1 = Color.FromArgb(0, 0, 0);
                    }

                    try
                    {
                        pixelColor = newImage.GetPixel(x + 1, y + 1);
                        Ap1p1 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    }
                    catch
                    {
                        Ap1p1 = Color.FromArgb(0, 0, 0);
                    }

                    try
                    {
                        pixelColor = newImage.GetPixel(x - 1, y);
                        Am10 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    }
                    catch
                    {
                        Am10 = Color.FromArgb(0, 0, 0);
                    }

                    try
                    {
                        pixelColor = newImage.GetPixel(x, y);
                        A_00 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    }
                    catch
                    {
                        A_00 = Color.FromArgb(0, 0, 0);
                    }

                    try
                    {
                        pixelColor = newImage.GetPixel(x + 1, y);
                        Ap10 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    }
                    catch
                    {
                        Ap10 = Color.FromArgb(0, 0, 0);
                    }

                    try
                    {
                        pixelColor = newImage.GetPixel(x - 1, y - 1);
                        Am1m1 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    }
                    catch
                    {
                        Am1m1 = Color.FromArgb(0, 0, 0);
                    }

                    try
                    {
                        pixelColor = newImage.GetPixel(x, y - 1);
                        A_0m1 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    }
                    catch
                    {
                        A_0m1 = Color.FromArgb(0, 0, 0);
                    }

                    try
                    {
                        pixelColor = newImage.GetPixel(x + 1, y - 1);
                        Ap1m1 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    }
                    catch
                    {
                        Ap1m1 = Color.FromArgb(0, 0, 0);
                    }


                    Kernel kernel = new Kernel(Am1p1, A_0p1, Ap1p1, Am10, A_00, Ap10, Am1m1, A_0m1, Ap1m1);

                    Color modifiedPixelColor = kernel.AvergeColor();

                    newImage.SetPixel(x, y, modifiedPixelColor);
                }
            }


            return newImage;
        }
    }
}