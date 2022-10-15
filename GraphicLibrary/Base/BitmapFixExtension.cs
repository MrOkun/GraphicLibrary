using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkunGraphicLibrary.Base
{
    public static class BitmapFixExtension
    {
        public static Image Fix(this Bitmap oldbmp)
        {
            Bitmap clone = new Bitmap(oldbmp.Width, oldbmp.Height,
                System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            using (Graphics gr = Graphics.FromImage(clone))
            {
                gr.DrawImage(oldbmp, new Rectangle(0, 0, clone.Width, clone.Height));
            }

            return clone;
        }
    }
}
