using System.Drawing;
using FastBitmapLib;
using OkunGraphicLibrary.Base;

namespace OkunGraphicLibrary.Algorithm.Dithering
{
    public class FloydSteinbergDither
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image">Image to be dithered</param>
        /// <param name="steps">The number of steps by which the palette will be truncated</param>
        /// <returns></returns>
        public Bitmap Dither(Bitmap image, int steps)
        {
            image = (Bitmap)image.Fix();

            FastBitmap fastBitmap = new FastBitmap(image);

            fastBitmap.Lock();

            int x;
            int y;

            for (y = 0; y < fastBitmap.Height; y++)
            {
                for (x = 0; x < fastBitmap.Width; x++)
                {
                    var clr = fastBitmap.GetPixel(x, y);
                    var oldR = clr.R;
                    var oldG = clr.G;
                    var oldB = clr.B;
                    var newR = closestStep(255, steps, oldR);
                    var newG = closestStep(255, steps, oldG);
                    var newB = closestStep(255, steps, oldB);

                    var newClr = Color.FromArgb((int)newR, (int)newG, (int)newB);
                    fastBitmap.SetPixel(x, y, newClr);

                    var errR = oldR - newR;
                    var errG = oldG - newG;
                    var errB = oldB - newB;

                    distributeError(fastBitmap, x, y, errR, errG, errB);
                }

            }

            fastBitmap.Unlock();


            return image;
        }

        private double closestStep(int max, int steps, int value)
        {
            return Math.Round(steps * value / 255 * Math.Floor(255 / (double)steps));
        }

        private void distributeError(FastBitmap fastBitmap, int x, int y, double errR, double errG, double errB)
        {
            addError(fastBitmap, 7 / 16.0, x + 1, y, errR, errG, errB);
            addError(fastBitmap, 3 / 16.0, x - 1, y + 1, errR, errG, errB);
            addError(fastBitmap, 5 / 16.0, x, y + 1, errR, errG, errB);
            addError(fastBitmap, 1 / 16.0, x + 1, y + 1, errR, errG, errB);
        }

        private void addError(FastBitmap fastBitmap, double factor, int x, int y, double errR, double errG, double errB)
        {
            if (x < 0 || x >= fastBitmap.Width || y < 0 || y >= fastBitmap.Height) return;
            var clr = fastBitmap.GetPixel(x, y);
            var r = clr.R;
            var g = clr.G;
            var b = clr.B;

            int Red = (int)(r + errR * factor);
            int Green = (int)(g + errG * factor);
            int Blue = (int)(b + errB * factor);

            if (Red > 255)
            {
                Red = 255;
            }
            if (Green > 255)
            {
                Green = 255;
            }
            if (Blue > 255)
            {
                Blue = 255;
            }

            var newClr = Color.FromArgb(Red, Green, Blue);

            fastBitmap.SetPixel(x, y, newClr);
        }
    }
}