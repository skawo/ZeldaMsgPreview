using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ZeldaMsgPreview
{
    public static class Helpers
    {
        // SKPaint.FilterQuality / SKFilterQuality are obsolete - SKCanvas.DrawBitmap has no
        // overload that accepts SKSamplingOptions, so all drawing here goes through
        // DrawImage(SKImage, ...) instead, which does. Mitchell cubic resampling is the
        // closest equivalent to the old SKFilterQuality.High for general-purpose scaling.
        private static readonly SKSamplingOptions HighQualitySampling =
            new SKSamplingOptions(SKCubicResampler.Mitchell);

        public static byte GetByteFromList(List<byte> array, int i)
        {
            byte outB = 0;

            if (i <= array.Count - 1)
                outB = array[i];

            return outB;
        }

        public static SKBitmap DrawImage(SKBitmap destBmp, SKBitmap srcBmp, SKColor colorizeColor,
            int xSize, int ySize, ref float xPos, ref float yPos, float moveXBy, bool revAlpha = true)
        {
            if (revAlpha)
                srcBmp = Helpers.ReverseAlphaMask(srcBmp);

            srcBmp = Helpers.Colorize(srcBmp, colorizeColor);

            using (var canvas = new SKCanvas(destBmp))
            using (var image = SKImage.FromBitmap(srcBmp))
            {
                var destRect = new SKRect(xPos, yPos, xPos + xSize, yPos + ySize);
                canvas.DrawImage(image, destRect, HighQualitySampling);
            }

            xPos += moveXBy;
            return destBmp;
        }

        public static SKBitmap ReverseAlphaMask(SKBitmap bmp, bool Brighten = false)
        {
            var info = new SKImageInfo(bmp.Width, bmp.Height, SKColorType.Rgba8888, SKAlphaType.Unpremul);
            SKBitmap result = new SKBitmap(info);

            using (var canvas = new SKCanvas(result))
            {
                using (var image = SKImage.FromBitmap(bmp))
                {
                    canvas.DrawImage(image, 0, 0, new SKSamplingOptions(SKFilterMode.Nearest), paint: null);
                }
            }

            IntPtr pixelsAddr = result.GetPixels();
            int rowBytes = result.RowBytes;
            int totalBytes = rowBytes * result.Height;

            byte[] rgbaValues = new byte[totalBytes];
            Marshal.Copy(pixelsAddr, rgbaValues, 0, totalBytes);

            for (int i = 3; i < rgbaValues.Length; i += 4)
            {
                rgbaValues[i] = rgbaValues[i - 3];

                if (Brighten)
                {
                    rgbaValues[i - 1] = 255;
                    rgbaValues[i - 2] = 255;
                    rgbaValues[i - 3] = 255;
                }
            }

            Marshal.Copy(rgbaValues, 0, pixelsAddr, totalBytes);

            return result;
        }

        public static SKBitmap Resize(SKBitmap bmp, float scale)
        {
            int newWidth = (int)(bmp.Width * scale);
            int newHeight = (int)(bmp.Height * scale);

            var result = new SKBitmap(newWidth, newHeight);

            using (var canvas = new SKCanvas(result))
            using (var image = SKImage.FromBitmap(bmp))
            {
                canvas.DrawImage(image, new SKRect(0, 0, newWidth, newHeight), HighQualitySampling);
            }

            return result;
        }

        public static SKBitmap Colorize(SKBitmap bmp, SKColor cl)
        {
            float R = cl.Red / 255f;
            float G = cl.Green / 255f;
            float B = cl.Blue / 255f;
            const float A = 1f;

            float[] colorMatrix =
            {
                R, 0, 0, 0, 0,
                0, G, 0, 0, 0,
                0, 0, B, 0, 0,
                0, 0, 0, A, 0
            };

            var result = new SKBitmap(bmp.Width, bmp.Height);

            using (var canvas = new SKCanvas(result))
            using (var image = SKImage.FromBitmap(bmp))
            using (var paint = new SKPaint
            {
                ColorFilter = SKColorFilter.CreateColorMatrix(colorMatrix)
            })
            {
                canvas.DrawImage(image, new SKRect(0, 0, bmp.Width, bmp.Height), HighQualitySampling, paint);
            }

            return result;
        }

        public static SKBitmap FlipBitmapX(SKBitmap bmp)
        {
            var result = new SKBitmap(bmp.Width, bmp.Height);

            using (var canvas = new SKCanvas(result))
            {
                using (var image = SKImage.FromBitmap(bmp))
                {
                    canvas.Translate(bmp.Width / 2f, bmp.Height / 2f);
                    canvas.Scale(-1, 1);
                    canvas.Translate(-bmp.Width / 2f, -bmp.Height / 2f);
                    canvas.DrawImage(image, 0, 0, new SKSamplingOptions(SKFilterMode.Nearest), paint: null);
                }
            }

            return result;
        }

        public static SKBitmap GetBitmapFromI4FontChar(byte[] bytes)
        {
            const int width = 16;
            const int height = 16;

            var info = new SKImageInfo(width, height, SKColorType.Rgba8888, SKAlphaType.Unpremul);
            var bmp = new SKBitmap(info);

            IntPtr pixelsAddr = bmp.GetPixels();
            int rowBytes = bmp.RowBytes;
            int totalBytes = rowBytes * height;
            byte[] pixelData = new byte[totalBytes];

            int offset = 0;
            foreach (byte b in bytes)
            {
                byte ab = (byte)((b >> 4) * 0x11);
                byte bb = (byte)((b & 0x0F) * 0x11);

                pixelData[offset + 0] = ab;
                pixelData[offset + 1] = ab;
                pixelData[offset + 2] = ab;
                pixelData[offset + 3] = 255;
                offset += 4;

                pixelData[offset + 0] = bb;
                pixelData[offset + 1] = bb;
                pixelData[offset + 2] = bb;
                pixelData[offset + 3] = 255;
                offset += 4;
            }

            Marshal.Copy(pixelData, 0, pixelsAddr, totalBytes);

            return bmp;
        }
    }
}