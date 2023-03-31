using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;

namespace MISGroup_4.Helpers
{
    class ImageLoader
    {
        public static Image ResizeImage(string path, Size size)
        {
            Image img = new Bitmap(path);
            //Get the image current width  
            int sourceWidth = img.Width;
            //Get the image current height  
            int sourceHeight = img.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(img, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        public static byte[] ImageBuffer(Image img)
        {
            if (img == null)
                return null;
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.GetBuffer();
            }
        }

        public static Image ImageFromStream(byte[] img)
        {
            if (img == null)
                return null;
            using (var ms = new MemoryStream(img))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
