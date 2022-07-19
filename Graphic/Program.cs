using System;
using System.Net;
using GraphicLibrary;

namespace Graphic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demonstratiom app started.");

            WebClient client = new WebClient();

            client.DownloadFile("https://camo.githubusercontent.com/770d494e2b69b16bf0aac8442fbe5e08804c47f19a747491fb04cf13cdf53990/687474703a2f2f696d616765732e76666c2e72752f69692f313633303836373536322f62383339346639302f33353734373537352e706e67", "image.png");

        }
    }
}
