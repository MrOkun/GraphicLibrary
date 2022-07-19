using System;
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

            Console.WriteLine("Demonstratiom app started.");

            if (!Directory.Exists("img"))
            {
                Directory.CreateDirectory("img");
            }

            client.DownloadFile("https://avatars.githubusercontent.com/u/74727162?s=400&u=b422c7ea99bbb0d454eda41e398335e975f3ec3c&v=4", "img/image.png");

            Bitmap image = (Bitmap)Bitmap.FromFile("img/image.png");

            image = paletteCaster.Render(image, paletteCaster.demoPalette);

            image.Save("img/imageRedacted.png");

            Process.Start("explorer.exe", Directory.GetCurrentDirectory());

        }
    }
}
