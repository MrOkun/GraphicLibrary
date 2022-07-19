using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLibrary
{
    public static class ToHexExtension
    {
        public static Color ToHex(this string hex)
        {
            char[] hexChar = hex.ToCharArray();

            string rawR = hexChar[1].ToString() + hexChar[2].ToString();
            string rawG = hexChar[3].ToString() + hexChar[4].ToString();
            string rawB = hexChar[5].ToString() + hexChar[6].ToString();

            int R = Convert.ToInt32(rawR, 16);
            int G = Convert.ToInt32(rawG, 16);
            int B = Convert.ToInt32(rawB, 16);

            return Color.FromArgb(R, G, B);
        }
    }
}
