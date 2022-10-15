using FastBitmapLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkunGraphicLibrary.Base
{
    public class PaletteCaster
    {
        public List<Color> demoStringPalette = new List<Color>()
        {
            (Color)new ColorConverter().ConvertFromString("#1b2546"),
            (Color)new ColorConverter().ConvertFromString("#4b515d"),
            (Color)new ColorConverter().ConvertFromString("#787d87"),
            (Color)new ColorConverter().ConvertFromString("#8dacc8"),
            (Color)new ColorConverter().ConvertFromString("#bddeef")
        };

        public Bitmap Render(Bitmap bitmap, List<Color> _pallet)
        {
            Bitmap mbitmap = (Bitmap)bitmap.Fix();

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
