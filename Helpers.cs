using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ZeldaMsgPreview
{
    public static class Helpers
    {
        public static readonly SKSamplingOptions HighQualitySampling = new SKSamplingOptions(SKCubicResampler.Mitchell);

        public static byte GetByteFromList(List<byte> array, int i)
        {
            byte outB = 0;

            if (i <= array.Count - 1)
                outB = array[i];

            return outB;
        }

        public static SKBitmap DrawImage(SKBitmap destBmp, SKBitmap srcBmp, SKColor colorizeColor, int xSize, int ySize, 
                                         ref float xPos, ref float yPos, float moveXBy, bool revAlpha = true)
        {
            if (revAlpha)
                srcBmp = Helpers.ReverseAlphaMask(srcBmp);

            srcBmp = Helpers.Colorize(srcBmp, colorizeColor);

            using var canvas = new SKCanvas(destBmp);
            var destRect = new SKRect(xPos, yPos, xPos + xSize, yPos + ySize);

            canvas.DrawBitmap(srcBmp, destRect, HighQualitySampling, paint: null);

            xPos += moveXBy;

            return destBmp;
        }

        public static unsafe SKBitmap ReverseAlphaMask(SKBitmap bmp, bool brighten = false)
        {
            var result = bmp.Copy();

            byte* p = (byte*)result.GetPixels();
            int totalBytes = result.RowBytes * result.Height;

            for (int i = 0; i < totalBytes; i += 4)
            {
                byte a = p[i];
                p[i + 3] = p[i];
                p[i] = a;

                if (brighten)
                {
                    p[i] = 255;
                    p[i + 1] = 255;
                    p[i + 2] = 255;
                }
            }

            return result;
        }

        public static SKBitmap Colorize(SKBitmap bmp, SKColor cl)
        {
            float r = cl.Red / 255f;
            float g = cl.Green / 255f;
            float b = cl.Blue / 255f;

            const float a = 1f;

            float[] colorMatrix =
            {
                r, 0, 0, 0, 0,
                0, g, 0, 0, 0,
                0, 0, b, 0, 0,
                0, 0, 0, a, 0
            };

            var result = new SKBitmap(bmp.Width, bmp.Height);
            using var canvas = new SKCanvas(result);
            using var paint = new SKPaint { ColorFilter = SKColorFilter.CreateColorMatrix(colorMatrix) };

            var rect = new SKRect(0, 0, bmp.Width, bmp.Height);

            canvas.DrawBitmap(bmp, rect, HighQualitySampling, paint);

            return result;
        }

        public static unsafe SKBitmap GetBitmapFromI4FontChar(byte[] bytes)
        {
            const int width = 16;
            const int height = 16;

            var bmp = new SKBitmap(new SKImageInfo(width, height, SKColorType.Rgba8888, SKAlphaType.Unpremul));

            byte* p = (byte*)bmp.GetPixels();

            int offset = 0;

            foreach (byte b in bytes)
            {
                byte a = (byte)((b >> 4) * 0x11);
                byte c = (byte)((b & 0x0F) * 0x11);

                p[offset + 0] = a;
                p[offset + 1] = a;
                p[offset + 2] = a;
                p[offset + 3] = 255;
                offset += 4;

                p[offset + 0] = c;
                p[offset + 1] = c;
                p[offset + 2] = c;
                p[offset + 3] = 255;
                offset += 4;
            }

            return bmp;
        }
    }
}