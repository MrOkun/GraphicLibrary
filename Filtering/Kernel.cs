using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtering
{
    public class Kernel
    {
        /*
        public struct KernelColor
        {
            public KernelColor(int red, int green, int blue)
            {

                if(red > 224){
                    Red = 255;
                }
                else if (red < 0)
                {
                    Red = 0;
                }
                else
                {
                    Red = red;
                }
                if (green > 224)
                {
                    Green = 255;
                }
                else if (green < 0)
                {
                    Green = 0;
                }
                else
                {
                    Green = green;
                }
                if (blue > 224)
                {
                    Blue = 255;
                }
                else if (blue < 0)
                {
                    Blue = 0;
                }
                else
                {
                    Blue = blue;
                }

            }

            public int Red { get; set; }
            public int Green { get; set; }
            public int Blue { get; set; }
        }
        */

        public Kernel(Color Am1p1, Color A_0p1, Color Ap1p1, Color Am10, Color A_00, Color Ap10, Color Am1m1, Color A_0m1, Color Ap1m1)
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
        
        public Color m1p1 { get; set; }
        public Color _0p1 { get; set; }
        public Color p1p1 { get; set; }
        public Color m10 { get; set; }
        public Color _00 { get; set; }
        public Color p10 { get; set; }
        public Color m1m1 { get; set; }
        public Color _0m1 { get; set; }
        public Color p1m1 { get; set; }

        public Color AvergeColor()
        {
            double Red = (m1p1.R + _0p1.R + p1p1.R + m10.R + _00.R + p10.R + m1m1.R + _0m1.R + p1m1.R) / 9; 
            double Green = (m1p1.G + _0p1.G + p1p1.G + m10.G + _00.G + p10.G + m1m1.G + _0m1.G + p1m1.G) / 9;
            double Blue = (m1p1.B + _0p1.B + p1p1.B + m10.B + _00.B + p10.B + m1m1.B + _0m1.B + p1m1.B) / 9;

            return Color.FromArgb((int)Math.Round(Red, 0), (int)Math.Round(Green, 0), (int)Math.Round(Blue, 0));
        }
    }
}
