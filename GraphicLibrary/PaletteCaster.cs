using FastBitmapLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLibrary
{

    public class PaletteCaster
    {
        public List<Color>? demoPalette = new List<Color>()
        {
            "#1b2546".ToHex(),
            "#4b515d".ToHex(),
            "#787d87".ToHex(),
            "#8dacc8".ToHex(),
            "#bddeef".ToHex()
        };


        private List<Color[]>? _paletts;

        public Bitmap Render(Bitmap bitmap, List<Color> _pallet)
        {
            Bitmap mbitmap = BitmapFix(bitmap);

            FastBitmap fastBitmap = new FastBitmap(mbitmap);

            int x, y;

            fastBitmap.Lock();

            for (y = 0; y < fastBitmap.Height; y++)
            {
                for (x = 0; x < fastBitmap.Width; x++)
                {
                    Color clr = fastBitmap.GetPixel(x, y);

                    int cclr = FindNearestColor(_pallet, clr);

                    fastBitmap.SetPixel(x, y, _pallet[cclr]);
                }
            }

            fastBitmap.Unlock();

            return mbitmap;
        }

        private Bitmap BitmapFix(Bitmap image)
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            
            Graphics g = Graphics.FromImage(newImage);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            g.Save();

            return newImage;
        }

        private int GetDistance(Color current, Color match) //Euclidean sRGB
        {
            int redDifference;
            int greenDifference;
            int blueDifference;

            redDifference = current.R - match.R;
            greenDifference = current.G - match.G;
            blueDifference = current.B - match.B;

            return redDifference * redDifference + greenDifference * greenDifference + blueDifference * blueDifference;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map">Pallet of colors</param>
        /// <param name="current">Color to check parity</param>
        /// <returns></returns>
        public int FindNearestColor(Color[] map, Color current)
        {
            int shortestDistance;
            int index;

            index = -1;
            shortestDistance = int.MaxValue;

            for (int i = 0; i < map.Length; i++)
            {
                Color match;
                int distance;

                match = map[i];
                distance = GetDistance(current, match);

                if (distance < shortestDistance)
                {
                    index = i;
                    shortestDistance = distance;
                }
            }

            return index;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map">Pallet of colors</param>
        /// <param name="current">Color to check parity</param>
        /// <returns></returns>
        public int FindNearestColor(List<Color> map, Color current)
        {
            int shortestDistance;
            int index;

            index = -1;
            shortestDistance = int.MaxValue;

            for (int i = 0; i < map.Count; i++)
            {
                Color match;
                int distance;

                match = map[i];
                distance = GetDistance(current, match);

                if (distance < shortestDistance)
                {
                    index = i;
                    shortestDistance = distance;
                }
            }

            return index;
        }
    }
}
