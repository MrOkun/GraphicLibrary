using System;
using System.Net;

namespace GraphicLib.Test
{
    public class TestConsoleApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test App");

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/img"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/img");
            }

            HttpClient client = new HttpClient();
        }
    }
}