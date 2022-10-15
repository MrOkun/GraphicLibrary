using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkunGraphicLibrary.Base;
using FastBitmapLib;

namespace OkunGraphicLibrary.Algorithm
{
    public class BoxBlur
    {
        public Bitmap Blur(Bitmap image)
        {
            image = (Bitmap)image.Fix();

            var fastImage = new FastBitmap(image);
            fastImage.Lock();

            for (int x = 0; x < fastImage.Width; x++)
            {
                for (int y = 0; y < fastImage.Height; y++)
                {
                    if (x >= 1 & y >= 1 & x + 1 < fastImage.Width & y + 1 < fastImage.Height)
                    {
                        float averageR = fastImage.GetPixel(x - 1, y + 1).R +
                                         fastImage.GetPixel(x + 0, y + 1).R +
                                         fastImage.GetPixel(x + 1, y + 1).R +
                                         fastImage.GetPixel(x - 1, y + 0).R +
                                         fastImage.GetPixel(x + 0, y + 0).R +
                                         fastImage.GetPixel(x + 1, y + 0).R +
                                         fastImage.GetPixel(x - 1, y - 1).R +
                                         fastImage.GetPixel(x + 0, y - 1).R +
                                         fastImage.GetPixel(x + 1, y - 1).R;

                        float averageG = fastImage.GetPixel(x - 1, y + 1).G +
                                         fastImage.GetPixel(x + 0, y + 1).G +
                                         fastImage.GetPixel(x + 1, y + 1).G +
                                         fastImage.GetPixel(x - 1, y + 0).G +
                                         fastImage.GetPixel(x + 0, y + 0).G +
                                         fastImage.GetPixel(x + 1, y + 0).G +
                                         fastImage.GetPixel(x - 1, y - 1).G +
                                         fastImage.GetPixel(x + 0, y - 1).G +
                                         fastImage.GetPixel(x + 1, y - 1).G;

                        float averageB = fastImage.GetPixel(x - 1, y + 1).B +
                                         fastImage.GetPixel(x + 0, y + 1).B +
                                         fastImage.GetPixel(x + 1, y + 1).B +
                                         fastImage.GetPixel(x - 1, y + 0).B +
                                         fastImage.GetPixel(x + 0, y + 0).B +
                                         fastImage.GetPixel(x + 1, y + 0).B +
                                         fastImage.GetPixel(x - 1, y - 1).B +
                                         fastImage.GetPixel(x + 0, y - 1).B +
                                         fastImage.GetPixel(x + 1, y - 1).B;

                        fastImage.SetPixel(x, y, Color.FromArgb((int)averageR / 9, (int)averageG / 9, (int)averageB / 9));
                    }
                }
            }


            fastImage.Unlock();

            return image;
        }

        public Bitmap Blur(Bitmap image, int iteration)
        {
            image = (Bitmap)image.Fix();

            var fastImage = new FastBitmap(image);
            fastImage.Lock();

            for (int i = 0; i < iteration; i++)
            {
                for (int x = 0; x < fastImage.Width; x++)
                {
                    for (int y = 0; y < fastImage.Height; y++)
                    {
                        if (x >= 1 & y >= 1 & x + 1 < fastImage.Width & y + 1 < fastImage.Height)
                        {
                            float averageR = fastImage.GetPixel(x - 1, y + 1).R +
                                             fastImage.GetPixel(x + 0, y + 1).R +
                                             fastImage.GetPixel(x + 1, y + 1).R +
                                             fastImage.GetPixel(x - 1, y + 0).R +
                                             fastImage.GetPixel(x + 0, y + 0).R +
                                             fastImage.GetPixel(x + 1, y + 0).R +
                                             fastImage.GetPixel(x - 1, y - 1).R +
                                             fastImage.GetPixel(x + 0, y - 1).R +
                                             fastImage.GetPixel(x + 1, y - 1).R;

                            float averageG = fastImage.GetPixel(x - 1, y + 1).G +
                                             fastImage.GetPixel(x + 0, y + 1).G +
                                             fastImage.GetPixel(x + 1, y + 1).G +
                                             fastImage.GetPixel(x - 1, y + 0).G +
                                             fastImage.GetPixel(x + 0, y + 0).G +
                                             fastImage.GetPixel(x + 1, y + 0).G +
                                             fastImage.GetPixel(x - 1, y - 1).G +
                                             fastImage.GetPixel(x + 0, y - 1).G +
                                             fastImage.GetPixel(x + 1, y - 1).G;

                            float averageB = fastImage.GetPixel(x - 1, y + 1).B +
                                             fastImage.GetPixel(x + 0, y + 1).B +
                                             fastImage.GetPixel(x + 1, y + 1).B +
                                             fastImage.GetPixel(x - 1, y + 0).B +
                                             fastImage.GetPixel(x + 0, y + 0).B +
                                             fastImage.GetPixel(x + 1, y + 0).B +
                                             fastImage.GetPixel(x - 1, y - 1).B +
                                             fastImage.GetPixel(x + 0, y - 1).B +
                                             fastImage.GetPixel(x + 1, y - 1).B;

                            fastImage.SetPixel(x, y, Color.FromArgb((int)averageR / 9, (int)averageG / 9, (int)averageB / 9));
                        }
                    }
                }
            }


            fastImage.Unlock();

            return image;
        }
    }
}
