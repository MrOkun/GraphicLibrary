using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLibrary
{
    public class Kernel
    {
        Color Am1p1 { get; set; }
        Color A_0p1 { get; set; }
        Color Ap1p1 { get; set; }
        Color Am10 { get; set; }
        Color A_00 { get; set; }
        Color Ap10 { get; set; }
        Color Am1m1 { get; set; }
        Color A_0m1 { get; set; }
        Color Ap1m1 { get; set; }

        public Kernel() {}

        public Kernel(Color m1p1, Color _0p1, Color p1p1, Color m10, Color _00, Color p10, Color m1m1, Color _0m1, Color p1m1)
        {
            Am1p1 = m1p1;
            A_0p1 = _0p1;
            Ap1p1 = p1p1;
            Am10 = m10;
            A_00 = _00;
            Ap10 = p10;
            Am1m1 = m1m1;
            A_0m1 = _0m1;
            Ap1m1 = p1m1;
        }

        public Color AvergeColor(Kernel kernel)
        {
            double Red = (kernel.Am1p1.R + kernel.A_0p1.R + kernel.Ap1p1.R + kernel.Am10.R + kernel.A_00.R + kernel.Ap10.R + kernel.Am1m1.R + kernel.A_0m1.R + kernel.Ap1m1.R) / 9;
            double Green = (kernel.Am1p1.G + kernel.A_0p1.G + kernel.Ap1p1.G + kernel.Am10.G + kernel.A_00.G + kernel.Ap10.G + kernel.Am1m1.G + kernel.A_0m1.G + kernel.Ap1m1.G) / 9;
            double Blue = (kernel.Am1p1.B + kernel.A_0p1.B + kernel.Ap1p1.B + kernel.Am10.B + kernel.A_00.B + kernel.Ap10.B + kernel.Am1m1.B + kernel.A_0m1.B + kernel.Ap1m1.B) / 9;

            return Color.FromArgb((int)Math.Round(Red, 0), (int)Math.Round(Green, 0), (int)Math.Round(Blue, 0));
        }

        /// <summary>
        /// Image blur.
        /// </summary>
        /// <param name="image">Image to be blured</param>
        /// <param name="step">Blur iterations</param>
        /// <param name="nullColor">Color that be used if some pixel will missed.</param>
        /// <returns></returns>

        public Bitmap ByKernel(Bitmap image, int step, Color nullColor)
        {
            Bitmap img = ByKernelDev(image, nullColor);
            step -= 1;

            for (int i = 0; i < step; i++)
            {
                img = ByKernelDev(img, nullColor);
            }

            return img;
        }

        private Bitmap ByKernelDev(Bitmap image, Color nullColor)
        {
            Bitmap newImage = (Bitmap)image.Clone();

            for (int x = 0; x < newImage.Width; x++)
            {
                for (int y = 0; y < newImage.Height; y++)
                {
                    Color pixelColor, Am1p1, A_0p1, Ap1p1, Am10, A_00, Ap10, Am1m1, A_0m1, Ap1m1;

                    int tempX, tempY;

                    tempX = x - 1;
                    tempY = y + 1;

                    if (tempX < newImage.Width & tempX > 0)
                    {
                        if (tempY<newImage.Height &tempY > 0)
                        {
                            pixelColor = newImage.GetPixel(tempX, tempY);
                            Am1p1 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                        }
                        else
                        {
                            Am1p1 = nullColor;
                        }
                    }
                    else
                    {
                        Am1p1 = nullColor;
                    }

                    tempX = x;
                    tempY = y + 1;

                    if (tempX < newImage.Width & tempX > 0)
                    {
                        if (tempY<newImage.Height &tempY > 0)
                        {
                            pixelColor = newImage.GetPixel(tempX, tempY);
                            A_0p1 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                        }
                        else
                        {
                            A_0p1 = nullColor;
                        }
                    }
                    else
                    {
                        A_0p1 = nullColor;
                    }


                    tempX = x + 1;
                    tempY = y + 1;

                    if (tempX < newImage.Width & tempX > 0)
                    {
                        if (tempY<newImage.Height &tempY > 0)
                        {
                            pixelColor = newImage.GetPixel(tempX, tempY);
                            Ap1p1 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                        }
                        else
                        {
                            Ap1p1 = nullColor;
                        }
                    }
                    else
                    {
                        Ap1p1 = nullColor;
                    }

                    tempX = x - 1;
                    tempY = y;

                    if (tempX < newImage.Width & tempX > 0)
                    {
                        if (tempY<newImage.Height &tempY > 0)
                        {
                            pixelColor = newImage.GetPixel(tempX, tempY);
                            Am10 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                        }
                        else
                        {
                            Am10 = nullColor;
                        }
                    }
                    else
                    {
                        Am10 = nullColor;
                    }

                    tempX = x;
                    tempY = y;

                    if (tempX < newImage.Width & tempX > 0)
                    {
                        if (tempY<newImage.Height &tempY > 0)
                        {
                            pixelColor = newImage.GetPixel(tempX, tempY);
                            A_00 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                        }
                        else
                        {
                            A_00 = nullColor;
                        }
                    }
                    else
                    {
                        A_00 = nullColor;
                    }

                    tempX = x + 1;
                    tempY = y;

                    if (tempX < newImage.Width & tempX > 0)
                    {
                        if (tempY<newImage.Height &tempY > 0)
                        {
                            pixelColor = newImage.GetPixel(tempX, tempY);
                            Ap10 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                        }
                        else
                        {
                            Ap10 = nullColor;
                        }
                    }
                    else
                    {
                        Ap10 = nullColor;
                    }

                    tempX = x - 1;
                    tempY = y - 1;

                    if (tempX < newImage.Width & tempX > 0)
                    {
                        if (tempY<newImage.Height &tempY > 0)
                        {
                            pixelColor = newImage.GetPixel(tempX, tempY);
                            Am1m1 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                        }
                        else
                        {
                            Am1m1 = nullColor;
                        }
                    }
                    else
                    {
                        Am1m1 = nullColor;
                    }

                    tempX = x;
                    tempY = y - 1;

                    if (tempX < newImage.Width & tempX > 0)
                    {
                        if (tempY<newImage.Height &tempY > 0)
                        {
                            pixelColor = newImage.GetPixel(tempX, tempY);

                            A_0m1 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                        }
                        else
                        {
                            A_0m1 = nullColor;
                        }
                    }
                    else
                    {
                        A_0m1 = nullColor;
                    }

                    tempX = x;
                    tempY = y - 1;

                    if (tempX < newImage.Width & tempX > 0)
                    {
                        if (tempY<newImage.Height &tempY > 0)
                        {
                            pixelColor = newImage.GetPixel(tempX, tempY);
                            Ap1m1 = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                        }
                        else
                        {
                            Ap1m1 = nullColor;
                        }
                    }
                    else
                    {
                        Ap1m1 = nullColor;
                    }

                    Kernel kernel = new Kernel(Am1p1, A_0p1, Ap1p1, Am10, A_00, Ap10, Am1m1, A_0m1, Ap1m1);

                    Color modifiedPixelColor = kernel.AvergeColor(kernel);

                    newImage.SetPixel(x, y, modifiedPixelColor);
                }
            }



            return newImage;
        }
    }
}
