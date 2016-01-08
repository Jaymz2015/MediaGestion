using System.Web.Mvc;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System;

namespace MediaGestion.Vues.Helper
{
    public class ImageResult : FileStreamResult
    {
        private static Bitmap bmp = null;

        public ImageResult(Image input) : this(input, input.Width, input.Height) { }

        public ImageResult(Image input, int width, int height)
            : base(GetMemoryStream(input, width, height, ImageFormat.Jpeg), "image/jpg")
        {

        }

        //public ImageResult(Image input, int width, int height)
        //    : base(GetMemoryStream2(input, width, height, ImageFormat.Jpeg), "image/jpg")
        //{

        //}

        public static MemoryStream GetMemoryStream(Image input, int width, int height, ImageFormat fmt)
        {
            // maintain aspect ratio 
            if (input.Width > input.Height)
                height = input.Height * width / input.Width;
            else
                width = input.Width * height / input.Height;

            bmp = new Bitmap(input, width, height);

            MemoryStream ms = new MemoryStream();

            bmp.Save(ms, fmt);

            ms.Position = 0;
            return ms;
        }

        public static MemoryStream GetMemoryStream2(Image input, int width, int height, ImageFormat fmt)
        {

            // Chargement de l'image
            //Image img = Image.FromFile(@"D:\Jaymz\Images\Pochettes\DVD\" + leFilm.Photo);
            // Resalisation de la miniature en 100x100
            // maintain aspect ratio 
            if (input.Width > input.Height)
                height = input.Height * width / input.Width;
            else
                width = input.Width * height / input.Height;
            
            input = input.GetThumbnailImage(width, height, null, IntPtr.Zero);
            
            // Envoie de l'image au client
            MemoryStream ms = new MemoryStream();

            input.Save(ms, fmt);
            ms.Position = 0;
            return ms;
        }
    }

}
