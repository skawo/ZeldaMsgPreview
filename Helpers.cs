using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ZeldaMsgPreview
{
    public static class Helpers
    {
        public static byte GetByteFromList(List<byte> array, int i)
        {
            byte outB = 0;

            if (i <= array.Count - 1)
                outB = array[i];

            return outB;
        }
        public static Bitmap DrawImage(Bitmap destBmp, Bitmap srcBmp, Color colorizeColor, int xSize, int ySize, ref float xPos, ref float yPos, float moveXBy, bool revAlpha = true)
        {
            if (revAlpha)
                srcBmp = Helpers.ReverseAlphaMask(srcBmp);

            srcBmp = Helpers.Colorize(srcBmp, colorizeColor);

            using (Graphics g = Graphics.FromImage(destBmp))
            {
                srcBmp.SetResolution(g.DpiX, g.DpiY);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                g.DrawImage(srcBmp, new Rectangle((int)xPos, (int)yPos, xSize, ySize));
            }

            xPos += moveXBy;
            return destBmp;
        }

        public static Bitmap ReverseAlphaMask(Bitmap bmp, bool Brighten = false)
        {
            // Check if running under Mono
            if (GameData.RunningUnderMono)
            {
                // Mono: Use GetPixel/SetPixel approach (slower but more reliable)
                Bitmap result = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppArgb);

                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        Color pixel = bmp.GetPixel(x, y);
                        Color newPixel;

                        if (Brighten)
                        {
                            newPixel = Color.FromArgb(pixel.R, 255, 255, 255);
                        }
                        else
                        {
                            newPixel = Color.FromArgb(pixel.R, pixel.R, pixel.G, pixel.B);
                        }

                        result.SetPixel(x, y, newPixel);
                    }
                }

                return result;
            }
            else
            {
                // .NET Framework/Core: Use original fast approach
                bmp.MakeTransparent();

                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);

                int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
                byte[] rgbaValues = new byte[bytes];

                Marshal.Copy(bmpData.Scan0, rgbaValues, 0, bytes);

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

                Marshal.Copy(rgbaValues, 0, bmpData.Scan0, bytes);

                bmp.UnlockBits(bmpData);

                return bmp;
            }
        }

        public static Bitmap Resize(Bitmap bmp, float scale)
        {
            Bitmap result = new Bitmap((int)(bmp.Width * scale), (int)(bmp.Height * scale));

            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                g.DrawImage(bmp, 0, 0, (int)(bmp.Width * scale), (int)(bmp.Height * scale));
            }

            return result;
        }

        public static Bitmap Colorize(Bitmap bmp, Color cl)
        {
            float R = (float)((float)cl.R / (float)255);
            float G = (float)((float)cl.G / (float)255);
            float B = (float)((float)cl.B / (float)255);
            float A = 1;


            float[][] colorMatrixElements =
            {
                new float[] {R,  0,  0,  0,  0},
                new float[] {0,  G,  0,  0,  0},
                new float[] {0,  0,  B,  0,  0},
                new float[] {0,  0,  0,  A,  0},
                new float[] {0,  0,  0,  0,  0}
            };

            ColorMatrix cm = new ColorMatrix(colorMatrixElements);

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            Bitmap bm = new Bitmap(bmp.Width, bmp.Height);

            using (Graphics g = Graphics.FromImage(bm))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                g.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, imageAttributes);
            }

            return bm;
        }

        public static Bitmap FlipBitmapX_MonoSafe(Bitmap bmp)
        {
            if (GameData.RunningUnderMono)
            {
                Bitmap returnBitmap = new Bitmap(bmp.Width, bmp.Height);

                using (Graphics g = Graphics.FromImage(returnBitmap))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    g.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
                    g.ScaleTransform(-1, 1);
                    g.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
                    g.DrawImage(bmp, new Point(0, 0));
                }

                return returnBitmap;
            }
            else
            {
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                return bmp;
            }
        }

        public static Bitmap GetBitmapFromI4FontChar(byte[] bytes)
        {
            const int width = 16;
            const int height = 16;

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            unsafe
            {
                byte* ptr = (byte*)data.Scan0;

                int i = 0;
                foreach (byte b in bytes)
                {
                    // Extract upper and lower 4-bit values, expand to 8-bit grayscale
                    byte ab = (byte)((b >> 4) * 0x11);
                    byte bb = (byte)((b & 0x0F) * 0x11);

                    // Write first pixel (ARGB)
                    ptr[0] = ab;     // B
                    ptr[1] = ab;     // G
                    ptr[2] = ab;     // R
                    ptr[3] = 255;    // A
                    ptr += 4;

                    // Write second pixel (ARGB)
                    ptr[0] = bb;     // B
                    ptr[1] = bb;     // G
                    ptr[2] = bb;     // R
                    ptr[3] = 255;    // A
                    ptr += 4;

                    i += 2;
                }
            }

            bmp.UnlockBits(data);
            return bmp;
        }

    }
}
