using System;
using System.Drawing;
namespace Task_11.PL
{
    public static class ImageHelper
    {
        public static Image Resize(this Image sourceImage, int newWidth, int maxHeight, bool reduceOnly)
        {
            sourceImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            sourceImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            if (reduceOnly && sourceImage.Width <= newWidth)
            {
                newWidth = sourceImage.Width;
            }
            int newHeight = sourceImage.Height * newWidth / sourceImage.Width;
            if (newHeight > maxHeight)
            {
                newWidth = sourceImage.Width * maxHeight / sourceImage.Height;
                newHeight = maxHeight;
            }
            Image newImage = sourceImage.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);
            return newImage;
        }
    }
}