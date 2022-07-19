using System.Drawing;

namespace GraphicLibrary
{
    public class ColorConversion
    {

        /// <summary>
        /// Сolor conversion by red channel (Rude).
        /// </summary>
        /// <param name="image">Image to be changed.</param>
        /// <returns></returns>
        public Bitmap ByRed(Bitmap image)
        {
            Bitmap newImage = (Bitmap)image.Clone();

            for (int x = 0; x < newImage.Width; x++)
            {
                for (int y = 0; y < newImage.Height; y++)
                {
                    Color pixelColor = newImage.GetPixel(x, y);

                    Color modifiedPixelColor = Color.FromArgb(pixelColor.R, pixelColor.R, pixelColor.R);

                    newImage.SetPixel(x, y, modifiedPixelColor);
                }
            }


            return newImage;
        }

        /// <summary>
        /// Сolor conversion by green channel (Rude).
        /// </summary>
        /// <param name="image">Image to be changed.</param>
        /// <returns></returns>
        public Bitmap ByGreen(Bitmap image)
        {
            Bitmap newImage = (Bitmap)image.Clone();

            for (int x = 0; x < newImage.Width; x++)
            {
                for (int y = 0; y < newImage.Height; y++)
                {
                    Color pixelColor = newImage.GetPixel(x, y);

                    Color modifiedPixelColor = Color.FromArgb(pixelColor.G, pixelColor.G, pixelColor.G);

                    newImage.SetPixel(x, y, modifiedPixelColor);
                }
            }


            return newImage;
        }

        /// <summary>
        /// Сolor conversion by blue channel (Rude).
        /// </summary>
        /// <param name="image">Image to be changed.</param>
        /// <returns></returns>
        public Bitmap ByBlue(Bitmap image)
        {
            Bitmap newImage = (Bitmap)image.Clone();

            for (int x = 0; x < newImage.Width; x++)
            {
                for (int y = 0; y < newImage.Height; y++)
                {
                    Color pixelColor = newImage.GetPixel(x, y);

                    Color modifiedPixelColor = Color.FromArgb(pixelColor.B, pixelColor.B, pixelColor.B);

                    newImage.SetPixel(x, y, modifiedPixelColor);
                }
            }


            return newImage;
        }

        /// <summary>
        /// Сolor conversion by averge channels.
        /// </summary>
        /// <param name="image">Image to be changed.</param>
        /// <returns></returns>
        public Bitmap Averge(Bitmap image)
        {
            Bitmap newImage = (Bitmap)image.Clone();

            for (int x = 0; x < newImage.Width; x++)
            {
                for (int y = 0; y < newImage.Height; y++)
                {
                    Color pixelColor = newImage.GetPixel(x, y);

                    var avergeColor = (pixelColor.B + pixelColor.B + pixelColor.B) / 3;

                    Color modifiedPixelColor = Color.FromArgb(avergeColor, avergeColor, avergeColor);

                    newImage.SetPixel(x, y, modifiedPixelColor);
                }
            }


            return newImage;
        }

        /// <summary>
        /// Сolor conversion by Luminance (Like in Photoshop).
        /// </summary>
        /// <param name="image">Image to be changed.</param>
        /// <returns></returns>
        public Bitmap Luminance(Bitmap image)
        {
            Bitmap newImage = (Bitmap)image.Clone();

            for (int x = 0; x < newImage.Width; x++)
            {
                for (int y = 0; y < newImage.Height; y++)
                {
                    Color pixelColor = newImage.GetPixel(x, y);

                    var luminanceColor = 0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B;
                    luminanceColor = Math.Ceiling(luminanceColor);

                    Color modifiedPixelColor = Color.FromArgb((int)luminanceColor, (int)luminanceColor, (int)luminanceColor);

                    newImage.SetPixel(x, y, modifiedPixelColor);
                }
            }


            return newImage;
        }
    }
}
