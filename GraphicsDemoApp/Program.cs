﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using GraphicLibrary;

namespace GraphicsApp
{
    public class GraphicsApp
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            PaletteCaster paletteCaster = new PaletteCaster();
            ColorConversion colorConversion = new ColorConversion();
            FloydSteinbergDither floydSteinbergDither = new FloydSteinbergDither();
            Kernel kernel = new Kernel();

            Console.WriteLine("Demonstratiom app started.");

            if (!Directory.Exists("img"))
            {
                Directory.CreateDirectory("img");
            }

            client.DownloadFile("https://camo.githubusercontent.com/770d494e2b69b16bf0aac8442fbe5e08804c47f19a747491fb04cf13cdf53990/687474703a2f2f696d616765732e76666c2e72752f69692f313633303836373536322f62383339346639302f33353734373537352e706e67", "img/image.png");

            Bitmap image = (Bitmap)Bitmap.FromFile("img/image.png");

            Bitmap tempimage;

            Console.ForegroundColor = ConsoleColor.Green;

            tempimage = paletteCaster.Render(image, paletteCaster.demoPalette);
            tempimage.Save("img/imagePaletted.png");

            Console.WriteLine("img/imagePaletted.png - saved");

            tempimage = colorConversion.ByRed(image);
            tempimage.Save("img/imageByRed.png");
            tempimage = colorConversion.ByGreen(image);
            tempimage.Save("img/imageByGreen.png");
            tempimage = colorConversion.ByBlue(image);
            tempimage.Save("img/imageByBlue.png");

            Console.WriteLine("img/imageByRed.png - saved \nimg/imageByGreen.png - saved \nimg/imageByBlue.png - saved");

            tempimage = colorConversion.Luminance(image);
            tempimage.Save("img/imageByLuminance.png");
            tempimage = colorConversion.Averge(image);
            tempimage.Save("img/imageByAverge.png");

            Console.WriteLine("img/imageByLuminance.png - saved \nimg/imageByAverge.png - saved");

            tempimage = floydSteinbergDither.Dither(image, 4);
            tempimage.Save("img/imageDithered (4).png");
            tempimage = floydSteinbergDither.Dither(image, 8);
            tempimage.Save("img/imageDithered (8).png");
            tempimage = floydSteinbergDither.Dither(image, 16);
            tempimage.Save("img/imageDithered (16).png");

            Console.WriteLine("img/imageDithered.png - saved | x4 x8 x16");

            Stopwatch stop1 = new Stopwatch();
            stop1.Start();

            tempimage = kernel.ByKernel(image, 1, Color.Black);
            tempimage.Save("img/1Kernel.png");

            stop1.Stop();

            Console.WriteLine($"img/Kernel.png - saved | x1 ({stop1.ElapsedMilliseconds} ms)");

            Stopwatch stop2 = new Stopwatch();
            stop2.Start();

            tempimage = kernel.ByKernel(image, 2, Color.Black);
            tempimage.Save("img/2Kernel.png");

            stop2.Stop();

            Console.WriteLine($"img/Kernel.png - saved | x2 ({stop2.ElapsedMilliseconds} ms)");

            Stopwatch stop3 = new Stopwatch();
            stop3.Start();

            tempimage = kernel.ByKernel(image, 10, Color.Black);
            tempimage.Save("img/10Kernel.png");

            stop3.Stop();

            Console.WriteLine($"img/Kernel.png - saved | x10 ({stop3.ElapsedMilliseconds} ms)");

            Stopwatch stop4 = new Stopwatch();
            stop3.Start();

            tempimage = kernel.ByKernel(image, 20, Color.Black);
            tempimage.Save("img/20Kernel.png");

            stop4.Stop();

            Console.WriteLine($"img/Kernel.png - saved | x20 ({stop4.ElapsedMilliseconds} ms)");

            Console.ForegroundColor = ConsoleColor.White;

            Process.Start("explorer.exe", "img");
        }
    }
}
