using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using OkunGraphicLibrary;
using OkunGraphicLibrary.Algorithm.Dithering;
using OkunGraphicLibrary.Algorithm;

namespace OkunGraphicLibrary
{
    public class GraphicsApp
    {
        static void Main(string[] args)
        {
            var bm = new BoxBlur();

            var img = bm.Blur(new Bitmap(@"C:\Users\User\source\repos\Graphic\GraphicsDemoApp\bin\Release\net6.0\img.png"), 4);

            img.Save(@"C:\Users\User\source\repos\Graphic\GraphicsDemoApp\bin\Release\net6.0\img1.png", ImageFormat.Png);

            Console.Write(img.PixelFormat);
        }
    }
}
