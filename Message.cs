using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace ZeldaMsgPreview
{
    public class Textbox
    {
        public Game TargetGame { get; set; }
        public List<byte> DecodedData { get; set; }
        public int[] MajoraCenteringOffset { get; set; }
        public int StartPosX { get; set; }
        public int StartPosY { get; set; }
        public int MajoraIconPosX { get; set; }
        public int MajoraIconPosY { get; set; }
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        public int Icon { get; set; }
        public int NumLines { get; set; }
        public int BgId { get; set; }
        public int BgForeColorId { get; set; }
        public int BgBackColorId { get; set; }
        public int BgYPosOffsetId { get; set; }
        public int BgUnkData { get; set; }
        public bool IsCredits { get; set; }
        public int NumChoices { get; set; }
        public TextboxType Type { get; set; }
        public TextboxPosition Position { get; set; }
        public short MajoraFirstPrice { get; set; }
        public short MajoraSecondPrice { get; set; }
        public bool MajoraBoxCenter { get; set; }
        public EndingGraphics EndingGraphic { get; set; }
        public bool MajoraIsBomberNotebook { get; set; }
        public bool UseRealSpaceWidth { get; set; }
        public int MajoraPromptIndex { get; set; }
        public EndStyles EndStyle { get; set; }
        public Color? MajoraColor { get; set; }
        public bool IsLastMsg { get; set; }

        public Textbox()
        {
            MajoraCenteringOffset = new int[4] { 0, 0, 0, 0 };
            DecodedData = new List<byte>();
            MajoraFirstPrice = 500;
            MajoraSecondPrice = 500;
            MajoraColor = null;
            MajoraIsBomberNotebook = false;
            UseRealSpaceWidth = false;
            MajoraPromptIndex = -1;
            Icon = -1;
        }
        private int GetTextboxYPosition(bool IsFullscreen)
        {
            int posY = 0;

            if (MajoraIsBomberNotebook && IsFullscreen)
                return 350;
            else if (!IsCredits && IsFullscreen && Type <= TextboxType.None_Black)
            {
                switch (Position)
                {
                    case TextboxPosition.Top:
                        posY = TargetGame == Game.Majora ? GameData.MajoraTextboxYPositionsTop[(byte)Type] :
                                                           GameData.OcarinaTextboxYPositionsTop[(byte)Type]; break;
                    case TextboxPosition.Center:
                        posY = TargetGame == Game.Majora ? GameData.MajoraTextboxYPositionsCenter[(byte)Type] :
                                                           GameData.OcarinaTextboxYPositionsCenter[(byte)Type]; break;
                    default:
                        posY = TargetGame == Game.Majora ? GameData.MajoraTextboxYPositionsBottom[(byte)Type] :
                                                           GameData.OcarinaTextboxYPositionsBottom[(byte)Type]; break;
                }
            }

            return posY;
        }


        private Bitmap GetBaseImage(bool FullScreenForce)
        {
            int OutputX = GameData.ScreenWidth;
            int OutputY = GameData.ScreenHeight;

            if (MajoraIsBomberNotebook)
            {
                if (FullScreenForce)
                {
                    OutputX *= 2;
                    OutputY *= 2;
                }
                else
                {
                    OutputX = GameData.TextboxWidthBombers;
                    OutputY = GameData.TextboxHeightBombers;
                }
            }
            else if (!FullScreenForce && !IsCredits)
            {
                OutputX = GameData.TextboxWidth;
                OutputY = GameData.TextboxHeight + 8;
            }

            Bitmap bmp = new Bitmap(OutputX, OutputY);

            using (var g = Graphics.FromImage(bmp))
            {
                if ((Type == TextboxType.None_White || IsCredits || FullScreenForce) && (Type != TextboxType.None_Black))
                    g.FillRectangle(Brushes.Black, 0, 0, OutputX, OutputY);
                else
                    bmp.MakeTransparent();
            }

            return bmp;
        }

        private Bitmap DrawBox(Bitmap destBmp)
        {
            Bitmap tboxImage = null;
            Color colorizeColor = Color.White;
            bool reverseAlpha = false;

            if (MajoraIsBomberNotebook)
            {
                colorizeColor = Color.White;
                tboxImage = Properties.Resources.Box_Default;
                tboxImage = Helpers.ReverseAlphaMask(tboxImage);
                tboxImage = Helpers.Colorize(tboxImage, colorizeColor);

                using (Graphics g = Graphics.FromImage(destBmp))
                {
                    int posX = (destBmp.Width == GameData.ScreenWidth * 2 ? GameData.TextboxXPosition : 0);
                    int yPos = GetTextboxYPosition(destBmp.Height == GameData.ScreenHeight * 2);

                    tboxImage.SetResolution(g.DpiX, g.DpiY);
                    g.DrawImage(tboxImage, new Rectangle(posX, yPos, destBmp.Width / 2, destBmp.Height));
                    tboxImage = Helpers.FlipBitmapX_MonoSafe(tboxImage);
                    g.DrawImage(tboxImage, new Rectangle(posX + destBmp.Width / 2, yPos, destBmp.Width / 2, destBmp.Height));
                }

                return destBmp;
            }

            switch (Type)
            {
                case TextboxType.Black:
                case TextboxType.Majora_Black2:
                    {
                        tboxImage = Properties.Resources.Box_Default;
                        colorizeColor = Color.FromArgb(170, 0, 0, 0);
                        reverseAlpha = true;
                        break;
                    }
                case TextboxType.Ocarina:
                    {
                        tboxImage = Properties.Resources.Box_Staff;
                        colorizeColor = Color.FromArgb(180, 255, 0, 0);
                        reverseAlpha = false;
                        break;
                    }
                case TextboxType.Wooden:
                    {
                        tboxImage = Properties.Resources.Box_Wooden;
                        colorizeColor = Color.FromArgb(230, 70, 50, 30);
                        reverseAlpha = false;
                        break;
                    }
                case TextboxType.Blue:
                case TextboxType.Majora_Blue2:
                    {
                        tboxImage = Properties.Resources.Box_Blue;
                        colorizeColor = Color.FromArgb(170, 0, 10, 50);
                        reverseAlpha = true;
                        break;
                    }
                case TextboxType.Majora_Bombers_Notebook:
                    {
                        tboxImage = Properties.Resources.majora_Box_Bomber;
                        colorizeColor = Color.FromArgb(170, 250, 253, 213);
                        reverseAlpha = true;
                        break;
                    }
                case TextboxType.Majora_Red:
                case TextboxType.Majora_Red2:
                    {
                        tboxImage = Properties.Resources.Box_Default;
                        colorizeColor = Color.FromArgb(170, 255, 0, 0);
                        reverseAlpha = true;
                        break;
                    }
                case TextboxType.None_White:
                case TextboxType.None_Black:
                case TextboxType.Majora_None:
                case TextboxType.Majora_None2:
                case TextboxType.Majora_None3:
                case TextboxType.Majora_None4:
                default:
                    return destBmp;
            }

            return DrawBoxInternal(destBmp, tboxImage, colorizeColor, reverseAlpha);
        }

        private int GetTextboxEndMarkerPosition(bool IsFullscreen)
        {
            int posY = GetTextboxYPosition(IsFullscreen);

            if (TargetGame == Game.Majora)
                posY += GameData.MajoraTextboxEndIconOffsets[(byte)Type];
            else if (Type <= TextboxType.None_Black)
                posY += GameData.OcarinaTextboxEndIconOffsets[(byte)Type];

            return posY;
        }

        private Bitmap DrawBoxInternal(Bitmap destBmp, Bitmap srcBmp, Color cl, bool revAlpha = true)
        {
            if (revAlpha)
                srcBmp = Helpers.ReverseAlphaMask(srcBmp);

            srcBmp = Helpers.Colorize(srcBmp, cl);

            using (Graphics g = Graphics.FromImage(destBmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                int posY = GetTextboxYPosition(destBmp.Height == GameData.ScreenHeight);
                int posX = (destBmp.Width == GameData.ScreenWidth ? GameData.TextboxXPosition : 0);

                srcBmp.SetResolution(g.DpiX, g.DpiY);
                g.DrawImage(srcBmp, posX, posY);

                srcBmp = Helpers.FlipBitmapX_MonoSafe(srcBmp);

                g.DrawImage(srcBmp, posX + srcBmp.Width, posY);
            }

            return destBmp;
        }

        private OcarinaMsgColor GetDefaultColor()
        {
            return Type == TextboxType.None_Black ? OcarinaMsgColor.BLK : OcarinaMsgColor.D;
        }

        private Color GetMajoraColor(byte chr)
        {
            return GameData.MajoraMsgRGB[(MajoraControlCode)chr][MajoraIsBomberNotebook ? GameData.MajoraTypeColorIndexes[TextboxType.Majora_Bombers_Notebook] : GameData.MajoraTypeColorIndexes[Type]];
        }

        private Color GetMajoraButtonColor(byte chr)
        {
            return GameData.MajoraButtonRGB[GameData.MajoraButtonRGBIndexes[(MajoraControlCode)chr]];
        }

        private Bitmap DrawEndMarker(Bitmap destBmp)
        {
            if (!IsCredits && EndingGraphic != EndingGraphics.None && !MajoraIsBomberNotebook)
            {
                float xPosEnd = GameData.OcarinaEndIconXPos - (destBmp.Width == GameData.ScreenWidth ? 0 : 34);
                float yPosEnd = GetTextboxEndMarkerPosition(destBmp.Height == GameData.ScreenHeight);
                Bitmap endIcon = EndingGraphic == EndingGraphics.Square ? Properties.Resources.Box_End : Properties.Resources.Box_Triangle;
                Helpers.DrawImage(destBmp, endIcon, TargetGame == Game.Ocarina_Debug ? GameData.EndIconColorDebug : GameData.EndIconColor, 
                                 (int)(GameData.CharWidth * ScaleX), (int)(GameData.CharHeight * ScaleY), ref xPosEnd, ref yPosEnd, 0);
            }

            return destBmp;
        }

        private void DrawMajoraIcon(Bitmap destBmp, ref float textXPos)
        {
            int ItemID = Message.GetMajoraItemIdFromIcon(Icon);

            if (ItemID != (int)ItemId.MESSAGE_ITEM_NONE)
            {
                string iconResName = $"majora_icon_{Icon.ToString().ToLower()}";
                Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(iconResName);

                int drawOffsX = (destBmp.Width == GameData.ScreenWidth ? 0 : GameData.CroppedXPosOffset);
                float x = MajoraIconPosX - drawOffsX;
                float y = MajoraIconPosY;

                if (img != null)
                {
                    if (MajoraIsBomberNotebook)
                    {
                        drawOffsX = (destBmp.Width == GameData.ScreenWidth ? 0 : GameData.CroppedXPosOffset);
                        x = MajoraIconPosX - drawOffsX;
                        Helpers.DrawImage(destBmp, img, ItemID == (int)ItemId.ITEM_CC ? Color.Yellow : Color.White,
                                         (int)(img.Width * GameData.TextScaleBombers), (int)(img.Height * GameData.TextScaleBombers), ref x, ref y, 0, false);
                    }
                    else
                        Helpers.DrawImage(destBmp, img, ItemID == (int)ItemId.ITEM_CC ? Color.Yellow : Color.White,
                                          img.Width, img.Height, ref x, ref y, 0, false);
                }

                textXPos += MajoraIsBomberNotebook ? 50 : 16;
            }
        }

        public Bitmap DrawChoiceMajora(Bitmap destBmp)
        {
            if (NumChoices < 2 || EndStyle != EndStyles.Choice)
                return destBmp;

            GetDrawOffsMajora(destBmp, out float drawXOffs, out float drawYOffs);

            Bitmap imgArrow = EndingGraphic == EndingGraphics.Choice ? Properties.Resources.Box_Arrow : Properties.Resources.Box_Triangle;

            float xPosChoice = 48 - (destBmp.Width == GameData.ScreenWidth ? 0 : GameData.CroppedXPosOffset);
            float yPosChoice = (NumLines != 3) ? 14 : 20;

            if (NumChoices == 2)
                yPosChoice += GameData.LinebreakSize;

            yPosChoice += drawYOffs;

            if (MajoraIsBomberNotebook)
                return destBmp;

            for (int ch = 0; ch < NumChoices; ch++)
            {
                Helpers.DrawImage(destBmp, imgArrow, TargetGame == Game.Ocarina_Debug ? GameData.EndIconColorDebug : GameData.EndIconColor, 
                                 (int)(GameData.CharWidth * ScaleX), (int)(GameData.CharHeight * ScaleY), ref xPosChoice, ref yPosChoice, 0);
                yPosChoice += GameData.LinebreakSize;
            }

            return destBmp;
        }

        private void GetDrawOffsMajora(Bitmap destBmp, out float drawXOffs, out float drawYOffs)
        {
            if (MajoraIsBomberNotebook)
            {
                drawXOffs = (destBmp.Width == GameData.ScreenWidth * 2 ? 0 : GameData.CroppedXPosOffset);
                drawYOffs = GetTextboxYPosition(destBmp.Height == GameData.ScreenHeight * 2);
            }
            else
            {
                drawXOffs = (destBmp.Width == GameData.ScreenWidth ? 0 : GameData.CroppedXPosOffset);
                drawYOffs = GetTextboxYPosition(destBmp.Height == GameData.ScreenHeight);
            }
        }


        private Bitmap DrawText(Bitmap destBmp, bool brightenText)
        {
            return TargetGame <= Game.Ocarina_Debug ? DrawText_Ocarina(destBmp, brightenText) :
                                                      DrawText_Majora(destBmp, brightenText);
        }

        private Bitmap DrawText_Ocarina(Bitmap destBmp, bool brightenText)
        {
            float curTextPosX = StartPosX;
            float drawXOffs = (destBmp.Width == GameData.ScreenWidth ? 0 : GameData.CroppedXPosOffset);
            float drawYOffs = GetTextboxYPosition(destBmp.Height == GameData.ScreenHeight);
            float drawStartTextPosY = StartPosY + drawYOffs;
            float curTextPosY = drawStartTextPosY;
            float curScaleX = ScaleX;
            float curScaleY = ScaleY;
            OcarinaMsgColor defaultColor = GetDefaultColor();
            OcarinaMsgColor curColor = defaultColor;

            for (int i = 0; i < DecodedData.Count; i++)
            {
                byte curChar = DecodedData[i];

                switch (curChar)
                {
                    case (byte)OcarinaControlCode.NEW_BOX:
                    case (byte)OcarinaControlCode.JUMP:
                    case (byte)OcarinaControlCode.EVENT:
                        {
                            EndingGraphic = EndingGraphics.Triangle;
                            return destBmp;
                        }
                    case (byte)OcarinaControlCode.END:
                        {
                            EndingGraphic = EndingGraphics.Square;
                            return destBmp;
                        }
                    case (byte)OcarinaControlCode.FADE:
                    case (byte)OcarinaControlCode.FADE2:
                    case (byte)OcarinaControlCode.DELAY:
                    case (byte)OcarinaControlCode.PERSISTENT:
                        {
                            EndingGraphic = EndingGraphics.None;
                            return destBmp;
                        }
                    case (byte)OcarinaControlCode.ICON:
                        {
                            byte IconN = Helpers.GetByteFromList(DecodedData, ++i);

                            string iconResName = $"icon_{IconN.ToString().ToLower()}";
                            Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(iconResName);

                            if (img != null)
                            {
                                if (IconN < 102)
                                {
                                    float xPosIcon = curTextPosX + StartPosX + drawXOffs - 74;
                                    float yPosIcon = drawYOffs + 16;
                                    Helpers.DrawImage(destBmp, img, Color.White, 32, 32, ref xPosIcon, ref yPosIcon, 32, false);
                                }
                                else
                                {
                                    float xPosIcon = curTextPosX + StartPosX + drawXOffs - 72;
                                    float yPosIcon = drawYOffs + 20;
                                    Helpers.DrawImage(destBmp, img, Color.White, 24, 24, ref xPosIcon, ref yPosIcon, 32, false);
                                }
                            }

                            curTextPosX += 32;

                            break;
                        }
                    case (byte)OcarinaControlCode.BACKGROUND:
                        {
                            // There is only one message background, despite what the OoT code might indicate...
                            Bitmap left = Properties.Resources.xmes_left;
                            Bitmap right = Properties.Resources.xmes_right;

                            float xPosBg = curTextPosX;
                            float yPosBg = drawYOffs + 8;
                            float xPosBgShadow = xPosBg + 1;
                            float yPosBgShadow = yPosBg;

                            if (BgYPosOffsetId > 0 && BgYPosOffsetId < GameData.OcarinaTextboxBackgroundShadowOffsets.Length)
                                yPosBg += GameData.OcarinaTextboxBackgroundShadowOffsets[BgYPosOffsetId];

                            Color BackColor = GameData.OcarinaTextboxBackgroundBackPrimColors[0];

                            if (BgBackColorId > 0 && BgBackColorId < GameData.OcarinaTextboxBackgroundBackPrimColors.Length)
                                BackColor = GameData.OcarinaTextboxBackgroundBackPrimColors[BgBackColorId];

                            Color ForeColor = GameData.OcarinaTextboxBackgroundForePrimColors[0];

                            if (BgForeColorId > 0 && BgForeColorId < GameData.OcarinaTextboxBackgroundForePrimColors.Length)
                                ForeColor = GameData.OcarinaTextboxBackgroundForePrimColors[BgForeColorId];

                            Helpers.DrawImage(destBmp, left, BackColor, left.Width, left.Height, ref xPosBgShadow, ref yPosBgShadow, left.Width);
                            Helpers.DrawImage(destBmp, left, ForeColor, left.Width, left.Height, ref xPosBg, ref yPosBg, left.Width);

                            Helpers.DrawImage(destBmp, right, BackColor, left.Width, left.Height, ref xPosBgShadow, ref yPosBgShadow, 0);
                            Helpers.DrawImage(destBmp, right, ForeColor, left.Width, left.Height, ref xPosBg, ref yPosBg, 0);

                            i += 3;
                            break;
                        }
                    case (byte)OcarinaControlCode.COLOR:
                        {
                            byte colorId = Helpers.GetByteFromList(DecodedData, ++i);

                            if (Enum.IsDefined(typeof(OcarinaMsgColor), (int)colorId) && colorId != (byte)OcarinaMsgColor.D)
                                curColor = (OcarinaMsgColor)colorId;
                            else
                                curColor = defaultColor;
                            break;
                        }
                    case (byte)OcarinaControlCode.SHIFT:
                        {
                            curTextPosX += Helpers.GetByteFromList(DecodedData, ++i);
                            break;
                        }
                    case (byte)OcarinaControlCode.LINE_BREAK:
                        {
                            curTextPosX = StartPosX;

                            if (Icon != -1 || NumChoices == 1 || NumChoices == 3 || (NumChoices == 2 && curTextPosY != drawStartTextPosY))
                                curTextPosX += 32;

                            curTextPosY += IsCredits ? GameData.LinebreakSizeCredits : GameData.LinebreakSize;
                            break;
                        }
                    case (byte)OcarinaControlCode.TWO_CHOICES:
                    case (byte)OcarinaControlCode.THREE_CHOICES:
                        {
                            if (IsCredits)
                                break;

                            Bitmap imgArrow = Properties.Resources.Box_Arrow;
                            float xPosChoice = 48 - (destBmp.Width == GameData.ScreenWidth ? 0 : GameData.CroppedXPosOffset);
                            float yPosChoice = (curChar is (byte)OcarinaControlCode.THREE_CHOICES) ? 20 : 32;
                            yPosChoice += drawYOffs;

                            for (int ch = 0; ch < NumChoices; ch++)
                            {
                                Helpers.DrawImage(destBmp, imgArrow, TargetGame == Game.Ocarina_Debug ? GameData.EndIconColorDebug : GameData.EndIconColor, 
                                                 (int)(GameData.CharWidth * ScaleX), (int)(GameData.CharHeight * ScaleY), ref xPosChoice, ref yPosChoice, 0);
                                yPosChoice += IsCredits ? GameData.LinebreakSizeCredits : GameData.LinebreakSize;
                            }

                            break;
                        }
                    case (byte)OcarinaControlCode.SPEED:
                        {
                            i += 1;
                            break;
                        }
                    case (byte)OcarinaControlCode.SOUND:
                        {
                            i += 2;
                            break;
                        }
                    case (byte)OcarinaControlCode.DC:
                    case (byte)OcarinaControlCode.DI:
                    case (byte)OcarinaControlCode.OCARINA:
                    case (byte)OcarinaControlCode.AWAIT_BUTTON:
                    case (byte)OcarinaControlCode.NS:
                        {
                            break;
                        }
                    default:
                        DrawTextInternal(destBmp, curChar, GameData.OcarinaMsgRGB[curColor][Type == TextboxType.Wooden ? 1 : 0], brightenText,
                                         curScaleX, curScaleY, ref curTextPosX, ref curTextPosY); break;
                }
            }

            return destBmp;
        }

        private Bitmap DrawText_Majora(Bitmap destBmp, bool brightenText)
        {
            int curLine = 0;

            float curTextPosX = StartPosX + MajoraCenteringOffset[curLine];
            GetDrawOffsMajora(destBmp, out float drawXOffs, out float drawYOffs);

            float drawStartTextPosY = StartPosY + drawYOffs;
            float curTextPosY = drawStartTextPosY;
            float curScaleX = ScaleX;
            float curScaleY = ScaleY;

            if (MajoraColor == null)
                MajoraColor = (Color)GetMajoraColor((byte)MajoraControlCode.COLOR_DEFAULT);

            DrawMajoraIcon(destBmp, ref curTextPosX);

            for (int i = 0; i < DecodedData.Count; i++)
            {
                byte curChar = DecodedData[i];

                switch (curChar)
                {
                    case (byte)MajoraControlCode.COLOR_DEFAULT:
                    case (byte)MajoraControlCode.COLOR_RED:
                    case (byte)MajoraControlCode.COLOR_GREEN:
                    case (byte)MajoraControlCode.COLOR_BLUE:
                    case (byte)MajoraControlCode.COLOR_YELLOW:
                    case (byte)MajoraControlCode.COLOR_NAVY:
                    case (byte)MajoraControlCode.COLOR_PINK:
                    case (byte)MajoraControlCode.COLOR_SILVER:
                    case (byte)MajoraControlCode.COLOR_ORANGE:
                        {
                            MajoraColor = (Color)GetMajoraColor(curChar);
                            break;
                        }
                    case (byte)MajoraControlCode.LINE_BREAK:
                    case (byte)MajoraControlCode.CR:
                        {
                            if (curChar == (byte)MajoraControlCode.LINE_BREAK)
                                curTextPosY += MajoraIsBomberNotebook ? GameData.LinebreakSizeBombers : GameData.LinebreakSize;

                            curLine++;

                            if (curLine < 4)
                                curTextPosX = StartPosX + MajoraCenteringOffset[curLine];
                            else
                                curTextPosX = 2000;     // Actual game starts reading OoB...

                            if (NumChoices == 1)
                                curTextPosX += MajoraIsBomberNotebook ? 50 : 16;
                            else if (NumChoices == 2 && (NumLines != 3 || curLine >= 2))
                                curTextPosX += MajoraIsBomberNotebook ? 57 : 10;

                            break;
                        }

                    case (byte)MajoraControlCode.NEW_BOX_DELAY:
                        {
                            return destBmp;
                        }
                    case (byte)MajoraControlCode.PERSISTENT:
                        {
                            EndStyle = EndStyles.Persistent;
                            return destBmp;
                        }
                    case (byte)MajoraControlCode.NEW_BOX:
                    case (byte)MajoraControlCode.NEW_BOX_CENTER:
                        {
                            EndingGraphic = EndingGraphics.Triangle;
                            return destBmp;
                        }
                    case (byte)MajoraControlCode.FADE:
                    case (byte)MajoraControlCode.FADE_SKIPPABLE:
                        {
                            EndStyle = EndStyles.Fade;
                            return destBmp;
                        }
                    case (byte)MajoraControlCode.EVENT:
                        {
                            EndStyle = EndStyles.Event;
                            EndingGraphic = EndingGraphics.Triangle;
                            return destBmp;
                        }
                    case (byte)MajoraControlCode.EVENT_END:
                        {
                            EndStyle = EndStyles.Event;
                            EndingGraphic = EndingGraphics.Square;
                            return destBmp;
                        }
                    case (byte)MajoraControlCode.CONTINUE:
                        {
                            if (EndStyle == EndStyles.None)
                                EndingGraphic = EndingGraphics.Triangle;
                            return destBmp;
                        }
                    case (byte)MajoraControlCode.END:
                        {
                            if (EndStyle == EndStyles.None)
                                EndingGraphic = EndingGraphics.Square;
                            return destBmp;
                        }
                    case (byte)MajoraControlCode.BACKGROUND:
                        {
                            Bitmap left = Properties.Resources.xmes_left;
                            Bitmap right = Properties.Resources.xmes_right;

                            curTextPosX = 45 - drawXOffs;

                            float xPosBg = curTextPosX;
                            float yPosBg = drawYOffs + 8;
                            float xPosBgShadow = xPosBg;
                            float yPosBgShadow = yPosBg + 1;

                            Helpers.DrawImage(destBmp, left, Color.Black, left.Width, left.Height, ref xPosBgShadow, ref yPosBgShadow, left.Width);
                            Helpers.DrawImage(destBmp, left, GameData.MajoraBackgroundTagColor, left.Width, left.Height, ref xPosBg, ref yPosBg, left.Width);

                            Helpers.DrawImage(destBmp, right, Color.Black, left.Width, left.Height, ref xPosBgShadow, ref yPosBgShadow, 0);
                            Helpers.DrawImage(destBmp, right, GameData.MajoraBackgroundTagColor, left.Width, left.Height, ref xPosBg, ref yPosBg, 0);

                            curTextPosX += 32;
                            break;
                        }
                    case (byte)MajoraControlCode.TWO_CHOICES:
                    case (byte)MajoraControlCode.THREE_CHOICES:
                        {
                            EndStyle = EndStyles.Choice;
                            EndingGraphic = EndingGraphics.Choice;
                            break;
                        }
                    case (byte)MajoraControlCode.BANK_PROMPT:
                        {
                            EndStyle = EndStyles.Prompt_Bank;
                            EndingGraphic = EndingGraphics.Triangle;
                            break;
                        }
                    case (byte)MajoraControlCode.DOG_RACE_BET_PROMPT:
                        {
                            EndStyle = EndStyles.Prompt_Race;
                            EndingGraphic = EndingGraphics.Triangle;
                            break;
                        }
                    case (byte)MajoraControlCode.BOMBER_CODE_PROMPT:
                        {
                            EndStyle = EndStyles.Prompt_Bombers;
                            EndingGraphic = EndingGraphics.None;
                            break;
                        }
                    case (byte)MajoraControlCode.LOTTERY_NUMBER_PROMPT:
                        {
                            EndStyle = EndStyles.Prompt_Lottery;
                            EndingGraphic = EndingGraphics.Triangle;
                            break;
                        }
                    case (byte)MajoraControlCode.ITEM_PROMPT:
                        {
                            EndStyle = EndStyles.Prompt_Pause;
                            EndingGraphic = EndingGraphics.Square;
                            break;
                        }
                    case (byte)MajoraControlCode.SOUND:
                    case (byte)MajoraControlCode.DELAY:
                        {
                            i += 2;
                            break;
                        }
                    case (byte)MajoraControlCode.TEXT_SPEED:
                        {
                            i += 1;
                            break;
                        }
                    case (byte)MajoraControlCode.DC:
                    case (byte)MajoraControlCode.DI:
                        {
                            break;
                        }
                    default:
                        {
                            Color actualColor = (Color)MajoraColor;

                            if (curChar >= (byte)MajoraControlCode.A_BUTTON && curChar <= (byte)MajoraControlCode.D_PAD)
                                actualColor = GetMajoraButtonColor(curChar);

                            bool isFixedWidth = false;

                            switch (EndStyle)
                            {
                                case EndStyles.Prompt_Bombers:
                                    isFixedWidth = (i >= MajoraPromptIndex) && (i <= MajoraPromptIndex + 4);
                                    break;
                                case EndStyles.Prompt_Lottery:
                                case EndStyles.Prompt_Bank:
                                    isFixedWidth = (i >= MajoraPromptIndex) && (i <= MajoraPromptIndex + 2);
                                    break;
                                case EndStyles.Prompt_Race:
                                    isFixedWidth = (i >= MajoraPromptIndex) && (i <= MajoraPromptIndex + 1);
                                    break;
                            }

                            DrawTextInternal(destBmp, curChar, actualColor, brightenText,
                                            curScaleX, curScaleY, ref curTextPosX, ref curTextPosY, isFixedWidth ? 16 : -1);
                            break;
                        }
                }
            }



            return destBmp;
        }

        private Bitmap DrawTextInternal(Bitmap destBmp, byte character, Color charColor, bool brightenText,
                                        float scaleX, float scaleY, ref float posX, ref float posY, int fixedWidth = -1)
        {
            // Handle space character early
            if (character == ' ')
            {
                if (fixedWidth >= 0)
                    posX += (int)(fixedWidth * scaleX);
                else
                {
                    posX += UseRealSpaceWidth
                        ? Message.GetCharacterWidth(TargetGame, (byte)' ', MajoraIsBomberNotebook, scaleX)
                        : 6.0f;
                }

                return destBmp;
            }

            Bitmap charBmp = null;
            int startByte = (character - ' ') * 128;

            // Attempt to generate character from raw font data
            if (GameData.FontData != null && (startByte + 128 <= GameData.FontData.Length))
            {
                byte[] charData = new byte[128];
                Array.Copy(GameData.FontData, startByte, charData, 0, 128);
                charBmp = Helpers.GetBitmapFromI4FontChar(charData);
            }
            else
            {
                string resCharName = (TargetGame == Game.Majora
                                        ? $"majora_char_{character:X}"
                                        : $"char_{character:X}").ToLower();

                charBmp = Properties.Resources.ResourceManager.GetObject(resCharName) as Bitmap;

                if (charBmp == null)
                    return destBmp; // Fail silently if character not found
            }

            // Apply alpha manipulation and colorization
            charBmp = Helpers.ReverseAlphaMask(charBmp, brightenText);
            Bitmap shadowBmp = charBmp;
            charBmp = Helpers.Colorize(charBmp, charColor);

            using (Graphics g = Graphics.FromImage(destBmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                // Draw shadow
                if (Type != TextboxType.None_Black && Type != TextboxType.Majora_Bombers_Notebook && !MajoraIsBomberNotebook)
                {
                    shadowBmp = Helpers.Colorize(shadowBmp, Color.Black);
                    shadowBmp.SetResolution(g.DpiX, g.DpiY);
                    g.DrawImage(shadowBmp, new Rectangle((int)posX + 1, (int)posY + 1, (int)(GameData.CharWidth * scaleX), (int)(GameData.CharHeight * scaleY)));
                }

                // Draw character
                g.DrawImage(charBmp, new Rectangle((int)posX, (int)posY, (int)(GameData.CharWidth * scaleX), (int)(GameData.CharHeight * scaleY)));
            }

            // Advance position for next character
            try
            {
                if (fixedWidth >= 0)
                    posX += (int)(fixedWidth * scaleX);
                else
                    posX += (int)Message.GetCharacterWidth(TargetGame, (byte)character, MajoraIsBomberNotebook, scaleX);
            }
            catch
            {
                // Fallback width
                posX += (int)(GameData.CharWidth * scaleX);
            }

            return destBmp;
        }

        public Bitmap GetPreview(bool ForceFullScreenPreview = false, bool BrightenText = true)
        {
            Bitmap bmp;

            try
            {
                bmp = GetBaseImage(ForceFullScreenPreview);
                bmp = DrawBox(bmp);

                int drawOffsX = (bmp.Width == GameData.ScreenWidth ? 0 : GameData.CroppedXPosOffset);

                StartPosX -= drawOffsX;
                bmp = DrawText(bmp, BrightenText);
                StartPosX += drawOffsX;

                bmp = DrawEndMarker(bmp);
            }
            catch
            {
                bmp = null;
            }

            return bmp;
        }
    }

    public class Message
    {
        public Game TargetGame { get; set; }
        private byte[] Data { get; set; }
        public List<Textbox> Textboxes { get; set; }
        private TextboxType OcarinaType { get; set; }
        private TextboxPosition TextboxPosition { get; set; }
        private bool IsCredits { get; set; }
        private bool UseRealSpaceWidth { get; set; }
        private bool IsBomberNotebook { get; set; }

        public Message()
        {
            TargetGame = Game.Ocarina;
            Data = new byte[0];
            OcarinaType = TextboxType.Black;
            IsCredits = false;
            UseRealSpaceWidth = false;
            IsBomberNotebook = false;

            SetFontWidths();
            Decode();
        }

        public Message(Game _TargetGame, byte[] _Data, TextboxPosition _TextboxPosition = TextboxPosition.Dynamic, TextboxType _OcarinaTextboxType = TextboxType.Black,
                       byte[] Font = null, float[] Widths = null,
                       bool _IsCredits = false, bool _UseRealSpaceWidth = false, bool _IsBomberNotebook = false)
        {
            TargetGame = _TargetGame;
            Data = _Data;
            OcarinaType = _OcarinaTextboxType;
            IsCredits = _IsCredits;
            TextboxPosition = _TextboxPosition;
            UseRealSpaceWidth = _UseRealSpaceWidth;
            IsBomberNotebook = _IsBomberNotebook;

            if (Font != null)
            {
                GameData.FontData = Font;
            }

            if (Widths != null)
            {
                GameData.FontWidths = Widths;
            }
            else
                SetFontWidths();

            Decode();
        }

        public void SetFontWidths(byte[] widths = null)
        {
            if (widths == null)
            {
                if (TargetGame <= Game.Ocarina_Debug)
                    GameData.FontWidths = GameData.OcarinaFontWidths;
                else
                    GameData.FontWidths = GameData.MajoraFontWidths;
            }
        }

        public Bitmap GetPreview(bool ForceFullScreenPreview = false, bool BrightenText = true)
        {
            if (Textboxes == null || Textboxes.Count == 0)
                return null;

            Bitmap bmpOut = Textboxes[0].GetPreview(ForceFullScreenPreview, BrightenText);

            if (Textboxes.Count > 1)
            {
                SynchronizeTextBoxProperties(0, 1);

                bmpOut = new Bitmap(bmpOut.Width, Textboxes.Count * bmpOut.Height);
                bmpOut.MakeTransparent();

                using (Graphics g = Graphics.FromImage(bmpOut))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    g.DrawImage(Textboxes[0].GetPreview(ForceFullScreenPreview, BrightenText), 0, 0);

                    for (int i = 1; i < Textboxes.Count; i++)
                    {
                        Bitmap temp = Textboxes[i].GetPreview(ForceFullScreenPreview, BrightenText);

                        if (i + 1 < Textboxes.Count)
                            SynchronizeTextBoxProperties(i, i + 1);

                        if (temp != null)
                            g.DrawImage(temp, 0, temp.Height * i);
                    }

                    Bitmap lastChoicePreview = Textboxes[Textboxes.Count - 1].DrawChoiceMajora(null);

                    if (lastChoicePreview != null)
                        g.DrawImage(lastChoicePreview, 0, bmpOut.Height - lastChoicePreview.Height);
                }
            }

            return bmpOut;
        }

        private void SynchronizeTextBoxProperties(int fromIndex, int toIndex)
        {
            Textboxes[toIndex].MajoraColor = Textboxes[fromIndex].MajoraColor;
            Textboxes[toIndex].EndStyle = Textboxes[fromIndex].EndStyle;

            if (Textboxes[fromIndex].MajoraPromptIndex != -1)
                Textboxes[toIndex].MajoraPromptIndex = Textboxes[fromIndex].MajoraPromptIndex;
        }

        private void Decode()
        {
            if (TargetGame <= Game.Ocarina_Debug)
                DecodeOcarina();
            else
                DecodeMajora();
        }

        private void DecodeOcarina()
        {
            try
            {
                Textboxes = new List<Textbox>();

                Textbox CurTextbox = new Textbox()
                {
                    TargetGame = TargetGame,
                    Position = TextboxPosition,
                    Type = OcarinaType,
                    IsCredits = IsCredits,
                    UseRealSpaceWidth = UseRealSpaceWidth
                };

                for (int i = 0; i < Data.Length; i++)
                {
                    byte curChar = Data[i];

                    switch (curChar)
                    {
                        case (byte)OcarinaControlCode.NEW_BOX:
                        case (byte)OcarinaControlCode.JUMP:
                        case (byte)OcarinaControlCode.DELAY:
                        case (byte)OcarinaControlCode.EVENT:
                        case (byte)OcarinaControlCode.END:
                        case (byte)OcarinaControlCode.FADE:
                        case (byte)OcarinaControlCode.FADE2:
                        case (byte)OcarinaControlCode.PERSISTENT:
                            {
                                CurTextbox.IsCredits = IsCredits;
                                CurTextbox.StartPosX = IsCredits ? GameData.OcarinaTextXPosCredits : GameData.TextXPosDefault;
                                CurTextbox.StartPosY = IsCredits ? GameData.TextYPosCredits : GameData.TextYPosDefault;
                                CurTextbox.ScaleX = IsCredits ? GameData.TextScaleCredits : GameData.TextScaleDefault;
                                CurTextbox.ScaleY = IsCredits ? GameData.TextScaleCredits : GameData.TextScaleDefault;

                                if (OcarinaType != TextboxType.None_White && !IsCredits)
                                {
                                    switch (CurTextbox.NumLines)
                                    {
                                        case 0: CurTextbox.StartPosY = 26; break;
                                        case 1: CurTextbox.StartPosY = 20; break;
                                        case 2: CurTextbox.StartPosY = 16; break;
                                        default: break;
                                    }
                                }

                                CurTextbox.DecodedData.Add(curChar);

                                if (curChar is (byte)OcarinaControlCode.JUMP || curChar is (byte)OcarinaControlCode.FADE2)
                                {
                                    CurTextbox.DecodedData.Add(Data[++i]);
                                    CurTextbox.DecodedData.Add(Data[++i]);
                                }
                                else if (curChar is (byte)OcarinaControlCode.FADE || curChar is (byte)OcarinaControlCode.DELAY)
                                {
                                    CurTextbox.DecodedData.Add(Data[++i]);
                                }

                                Textboxes.Add(CurTextbox);

                                if (curChar != (byte)OcarinaControlCode.NEW_BOX && curChar != (byte)OcarinaControlCode.DELAY)
                                {
                                    CurTextbox.IsLastMsg = true;
                                    return;
                                }

                                CurTextbox = new Textbox()
                                {
                                    TargetGame = TargetGame,
                                    Position = TextboxPosition,
                                    Type = OcarinaType,
                                    IsCredits = IsCredits,
                                    UseRealSpaceWidth = UseRealSpaceWidth
                                };

                                break;
                            }
                        case (byte)OcarinaControlCode.PLAYER:
                        case (byte)OcarinaControlCode.POINTS:
                        case (byte)OcarinaControlCode.FISH_WEIGHT:
                        case (byte)OcarinaControlCode.GOLD_SKULLTULAS:
                        case (byte)OcarinaControlCode.MARATHON_TIME:
                        case (byte)OcarinaControlCode.RACE_TIME:
                        case (byte)OcarinaControlCode.TIME:
                            {
                                string str = GameData.OcarinaStringConstants[(OcarinaControlCode)curChar];
                                CurTextbox.DecodedData.AddRange(Encoding.ASCII.GetBytes(str));
                                break;
                            }
                        case (byte)OcarinaControlCode.HIGH_SCORE:
                            {
                                byte hsIndex = Data[++i];
                                string str = GameData.OcarinaHighScoreStringConstants[(OcarinaHighScore)hsIndex];
                                CurTextbox.DecodedData.AddRange(Encoding.ASCII.GetBytes(str));
                                break;
                            }
                        case (byte)OcarinaControlCode.ICON:
                            {
                                byte iconId = Data[++i];
                                CurTextbox.Icon = iconId;

                                CurTextbox.DecodedData.Add(curChar);
                                CurTextbox.DecodedData.Add(iconId);
                                break;
                            }
                        case (byte)OcarinaControlCode.BACKGROUND:
                            {
                                byte bgId = Data[++i];
                                byte colorIds = Data[++i];
                                byte yOffset = Data[++i];

                                CurTextbox.BgId = bgId * 2;
                                CurTextbox.BgForeColorId = (colorIds & 0xF0) >> 4;
                                CurTextbox.BgBackColorId = (colorIds & 0x0F);
                                CurTextbox.BgYPosOffsetId = (yOffset & 0xF0) >> 4;
                                CurTextbox.BgUnkData = (yOffset & 0x0F);
                                CurTextbox.NumLines = 2;

                                CurTextbox.DecodedData.AddRange(new[] { curChar, bgId, colorIds, yOffset });
                                break;
                            }
                        case (byte)OcarinaControlCode.COLOR:
                        case (byte)OcarinaControlCode.SHIFT:
                            {
                                CurTextbox.DecodedData.Add(curChar);
                                CurTextbox.DecodedData.Add(Data[++i]);
                                break;
                            }
                        case (byte)OcarinaControlCode.LINE_BREAK:
                            {
                                CurTextbox.NumLines++;
                                CurTextbox.DecodedData.Add(curChar);
                                break;
                            }
                        case (byte)OcarinaControlCode.TWO_CHOICES:
                            {
                                CurTextbox.NumChoices = 2;
                                CurTextbox.DecodedData.Add(curChar);
                                break;
                            }
                        case (byte)OcarinaControlCode.THREE_CHOICES:
                            {
                                CurTextbox.NumChoices = 3;
                                CurTextbox.DecodedData.Add(curChar);
                                break;
                            }
                        case (byte)OcarinaControlCode.SPEED:
                            {
                                CurTextbox.DecodedData.Add(curChar);
                                CurTextbox.DecodedData.Add(Data[++i]);
                                break;
                            }
                        case (byte)OcarinaControlCode.SOUND:
                            {
                                CurTextbox.DecodedData.Add(curChar);
                                CurTextbox.DecodedData.Add(Data[++i]);
                                CurTextbox.DecodedData.Add(Data[++i]);
                                break;
                            }
                        case (byte)OcarinaControlCode.DC:
                        case (byte)OcarinaControlCode.DI:
                        case (byte)OcarinaControlCode.OCARINA:
                        case (byte)OcarinaControlCode.NS:
                        case (byte)OcarinaControlCode.AWAIT_BUTTON:
                        default:
                            {
                                CurTextbox.DecodedData.Add(curChar);
                                break;
                            }
                    }
                }
            }
            catch
            {
                Textboxes = null;
            }
        }

        public static float GetCharacterWidth(Game TargetGame, byte c, bool UseRealSpaceWidth, float ScaleX)
        {
            float width = 0;
            int index = c - ' ';

            float[] Widths = TargetGame <= Game.Ocarina_Debug ? GameData.FontWidths : GameData.MajoraFontWidths;

            if (!UseRealSpaceWidth && index == 0)
                width += GameData.SpaceWidth;
            else
            {
                if (Widths.Length > index)
                    width += (Widths[index] * ScaleX);
                else
                    width += (GameData.CharWidth * ScaleX);
            }

            return width;
        }

        public static int GetStringPxLength(Game TargetGame, string str, bool IsBombernotebook, float ScaleX)
        {
            int len = 0;

            foreach (char c in str)
                GetCharacterWidth(TargetGame, (byte)c, IsBombernotebook, ScaleX);

            return len;
        }

        private void ProcessMajoraConstantString(byte curChar, Textbox CurTextbox, ref float curLineWidth, int hardcodedNumChars = -1, int hardcodedWidth = -1)
        {
            string str = GameData.MajoraStringConstants[(MajoraControlCode)curChar];
            CurTextbox.DecodedData.AddRange(Encoding.ASCII.GetBytes(str));

            if (hardcodedNumChars >= 0)
            {
                if (hardcodedWidth == -1)
                    hardcodedWidth = 16;

                curLineWidth += hardcodedNumChars * (hardcodedWidth * CurTextbox.ScaleX);
            }
            else if (hardcodedWidth >= 0)
                curLineWidth += str.Length * (hardcodedWidth * CurTextbox.ScaleX);
            else
                curLineWidth += GetStringPxLength(TargetGame, str, IsBomberNotebook, CurTextbox.ScaleX);
        }

        public static int GetMajoraItemIdFromIcon(int Icon)
        {
            int ItemID = (int)ItemId.MESSAGE_ITEM_NONE;

            if (Enum.IsDefined(typeof(MajoraIcon), Icon))
                if (GameData.IconToItem.ContainsKey(Icon))
                    ItemID = (int)GameData.IconToItem[Icon];

            return ItemID;
        }

        private void SetIconPositionMajora(Textbox Textbox, int xBase, int yBase)
        {
            int ItemID = GetMajoraItemIdFromIcon(Textbox.Icon);

            if (ItemID == (int)ItemId.ITEM_RECOVERY_HEART ||
                (ItemID >= (int)ItemId.ITEM_RUPEE_GREEN && ItemID <= (int)ItemId.ITEM_RUPEE_HUGE))
            {
                Textbox.MajoraIconPosX = xBase - 22;
                Textbox.MajoraIconPosY = yBase + 10;
            }
            else if (ItemID == (int)ItemId.ITEM_STRAY_FAIRIES)
            {
                Textbox.MajoraIconPosX = xBase - 18;
                Textbox.MajoraIconPosY = yBase + 10;
            }
            else if (ItemID == (int)ItemId.ITEM_BOMBERS_NOTEBOOK || ItemID <= (int)ItemId.ITEM_REMAINS_TWINMOLD)
            {
                Textbox.MajoraIconPosX = xBase - 18;
                Textbox.MajoraIconPosY = yBase + 6;
            }
            else if (ItemID == (int)ItemId.ITEM_CC || ItemID >= (int)ItemId.ITEM_B8)
            {
                Textbox.MajoraIconPosX = xBase - 18;
                Textbox.MajoraIconPosY = yBase + 8;
            }
            else if (ItemID >= (int)ItemId.ITEM_SKULL_TOKEN)
            {
                Textbox.MajoraIconPosX = xBase - 14;
                Textbox.MajoraIconPosY = yBase + 10;
            }

            if (Textbox.MajoraIsBomberNotebook)
                Textbox.MajoraIconPosX = (int)(Textbox.MajoraIconPosX * GameData.TextScaleBombers) + 2;
        }

        private void DecodeMajora()
        {
            try
            {
                Textboxes = new List<Textbox>();

                int i = 0;

                byte b1 = Data[i++];
                byte b2 = Data[i++];
                int settings = b1;
                settings <<= 8;
                settings |= b2;

                bool MajoraTextCenter = ((settings & 0xF000) >> 0xC) == 1;
                TextboxType BoxType = (TextboxType)((settings & 0xF00) >> 0x8);
                TextboxPosition BoxPosition = (TextboxPosition)((settings & 0xF0) >> 0x4);
                bool Unskippable = (settings & 0x1) == 1;
                bool MajoraDrawInstantly = (settings & 0x3) == 3;

                byte Icon = Data[i++];
                int NumChoices = 0;
                bool GlitchOutIcon = false;

                if (Icon != (byte)MajoraIcon.NO_ICON)
                {
                    MajoraTextCenter = false;
                    if (Icon >= 0xC8 && Icon < 0xD8)
                        Icon = (byte)MajoraIcon.NO_ICON;
                }

                if (Icon != (byte)MajoraIcon.NO_ICON)
                    NumChoices = 1;

                short MajoraNextMessage = (short)((Data[i++] << 8) | Data[i++]);
                short MajoraFirstItemPrice = (short)((Data[i++] << 8) | Data[i++]);
                short MajoraSecondItemPrice = (short)((Data[i++] << 8) | Data[i++]);
                short MajoraPadding = (short)((Data[i++] << 8) | Data[i++]);

                Textbox CurTextbox = new Textbox()
                {
                    TargetGame = TargetGame,
                    Position = BoxPosition,
                    Type = BoxType,
                    IsCredits = IsCredits,
                    MajoraFirstPrice = MajoraFirstItemPrice,
                    MajoraSecondPrice = MajoraSecondItemPrice,
                    MajoraBoxCenter = MajoraTextCenter,
                    Icon = Icon,
                    NumChoices = NumChoices,
                    MajoraIsBomberNotebook = IsBomberNotebook,
                    ScaleX = IsBomberNotebook ? GameData.TextScaleBombers : GameData.TextScaleDefault,
                    ScaleY = IsBomberNotebook ? GameData.TextScaleBombers : GameData.TextScaleDefault,
                };

                float curLineWidth = 0;
                int curLine = 0;

                for (; i < Data.Length; i++)
                {
                    byte curChar = Data[i];

                    switch (curChar)
                    {
                        case (byte)MajoraControlCode.NEW_BOX:
                        case (byte)MajoraControlCode.NEW_BOX_CENTER:
                        case (byte)MajoraControlCode.NEW_BOX_DELAY:
                        case (byte)MajoraControlCode.FADE:
                        case (byte)MajoraControlCode.FADE_SKIPPABLE:
                        case (byte)MajoraControlCode.EVENT:
                        case (byte)MajoraControlCode.EVENT_END:
                        case (byte)MajoraControlCode.END:
                        case (byte)MajoraControlCode.CONTINUE:
                        case (byte)MajoraControlCode.PERSISTENT:
                            {
                                CurTextbox.NumChoices = NumChoices;
                                CurTextbox.IsCredits = IsCredits;
                                CurTextbox.StartPosX = IsBomberNotebook ? GameData.MajoraTextXPosBombers : GameData.TextXPosDefault;

                                if (!GlitchOutIcon)
                                    SetIconPositionMajora(CurTextbox, CurTextbox.StartPosX, CurTextbox.StartPosY + 10);

                                if (CurTextbox.NumChoices == 3)
                                    CurTextbox.StartPosX += 22;

                                if (curLine < 4)
                                {
                                    CurTextbox.MajoraCenteringOffset[curLine] = 0;

                                    if (MajoraTextCenter)
                                        CurTextbox.MajoraCenteringOffset[curLine] = (int)(((CurTextbox.ScaleX * 16.0f * 16.0f) - curLineWidth) / 2);
                                }

                                curLine = 0;
                                curLineWidth = 0;

                                CurTextbox.StartPosY = CurTextbox.Type == TextboxType.Ocarina ? GameData.TextYPosMajoraOcarinaTextbox : GameData.TextYPosDefault;

                                if (CurTextbox.Type != TextboxType.Ocarina && CurTextbox.Type != TextboxType.None_White)
                                {
                                    if (curChar == (byte)MajoraControlCode.NEW_BOX_CENTER)
                                    {
                                        switch (CurTextbox.NumLines)
                                        {
                                            case 0:
                                            case 1: CurTextbox.StartPosY = 26; break;
                                            case 2: CurTextbox.StartPosY = 20; break;
                                            case 3: CurTextbox.StartPosY = 14; break;
                                            default: break;
                                        }
                                    }
                                    else
                                    {
                                        switch (CurTextbox.NumLines)
                                        {
                                            case 0: CurTextbox.StartPosY = 26; break;
                                            case 1: CurTextbox.StartPosY = 20; break;
                                            case 2: CurTextbox.StartPosY = 14; break;
                                            default: CurTextbox.StartPosY = 8; break;
                                        }
                                    }
                                }

                                CurTextbox.DecodedData.Add(curChar);

                                if (curChar is (byte)MajoraControlCode.FADE || curChar is (byte)MajoraControlCode.FADE_SKIPPABLE || curChar is (byte)MajoraControlCode.NEW_BOX_DELAY)
                                {
                                    CurTextbox.DecodedData.Add(Data[++i]);
                                    CurTextbox.DecodedData.Add(Data[++i]);
                                }

                                Textboxes.Add(CurTextbox);

                                if (curChar != (byte)MajoraControlCode.NEW_BOX &&
                                    curChar != (byte)MajoraControlCode.NEW_BOX_CENTER &&
                                    curChar != (byte)MajoraControlCode.NEW_BOX_DELAY &&
                                    curChar != (byte)MajoraControlCode.DELAY)
                                {
                                    CurTextbox.IsLastMsg = true;
                                    return;
                                }

                                CurTextbox = new Textbox()
                                {
                                    TargetGame = TargetGame,
                                    Position = BoxPosition,
                                    Type = BoxType,
                                    IsCredits = IsCredits,
                                    MajoraFirstPrice = MajoraFirstItemPrice,
                                    MajoraSecondPrice = MajoraSecondItemPrice,
                                    MajoraBoxCenter = MajoraTextCenter,
                                    MajoraIsBomberNotebook = IsBomberNotebook,
                                    Icon = Icon,
                                    NumChoices = NumChoices,
                                    ScaleX = IsBomberNotebook ? GameData.TextScaleBombers : GameData.TextScaleDefault,
                                    ScaleY = IsBomberNotebook ? GameData.TextScaleBombers : GameData.TextScaleDefault,
                                };

                                break;
                            }
                        case (byte)MajoraControlCode.PLAYER:
                        case (byte)MajoraControlCode.SHOOTING_GALLERY_RESULT:
                        case (byte)MajoraControlCode.RUPEES_ENTERED:
                        case (byte)MajoraControlCode.RUPEES_IN_BANK:
                        case (byte)MajoraControlCode.MOON_CRASH_TIME_REMAINS:
                        case (byte)MajoraControlCode.STRAY_FAIRIES:
                        case (byte)MajoraControlCode.GOLD_SKULLTULAS:
                        case (byte)MajoraControlCode.POINTS_TENS:
                        case (byte)MajoraControlCode.POINTS_THOUSANDS:
                        case (byte)MajoraControlCode.SOARING_DESTINATION:
                        case (byte)MajoraControlCode.WOODFALL_FAIRIES_REMAIN:
                        case (byte)MajoraControlCode.SNOWHEAD_FAIRIES_REMAIN:
                        case (byte)MajoraControlCode.BAY_FAIRIES_REMAIN:
                        case (byte)MajoraControlCode.IKANA_FAIRIES_REMAIN:
                        case (byte)MajoraControlCode.BOAT_ARCHERY_RESULT:
                        case (byte)MajoraControlCode.ITEM_VALUE:
                        case (byte)MajoraControlCode.MOON_CRASH_HOURS_REMAIN:
                        case (byte)MajoraControlCode.UNTIL_MORNING:
                        case (byte)MajoraControlCode.DEKU_PLAYGROUND_PLAYER_DAY1:
                        case (byte)MajoraControlCode.DEKU_PLAYGROUND_PLAYER_DAY2:
                        case (byte)MajoraControlCode.DEKU_PLAYGROUND_PLAYER_DAY3:
                            {
                                ProcessMajoraConstantString(curChar, CurTextbox, ref curLineWidth);
                                break;
                            }
                        case (byte)MajoraControlCode.HS_BOAT_ARCHERY:
                        case (byte)MajoraControlCode.HS_ROMANI_ARCHERY:
                        case (byte)MajoraControlCode.HS_TOWN_SHOOTING_GALLERY:
                        case (byte)MajoraControlCode.TIMER_POSTMAN:
                        case (byte)MajoraControlCode.TIMER_MINIGAME1:
                        case (byte)MajoraControlCode.TIMER2:
                        case (byte)MajoraControlCode.TIMER_MOON_CRASH:
                        case (byte)MajoraControlCode.TIMER_MINIGAME2:
                        case (byte)MajoraControlCode.TIMER_ENV_HAZARD:
                        case (byte)MajoraControlCode.HS_UNK2:
                        case (byte)MajoraControlCode.HS_UNK3:
                            {
                                ProcessMajoraConstantString(curChar, CurTextbox, ref curLineWidth, -1, 16);
                                break;
                            }
                        case (byte)MajoraControlCode.HS_TIME_BOAT_ARCHERY:
                        case (byte)MajoraControlCode.HS_TIME_ROMANI_ARCHERY:
                        case (byte)MajoraControlCode.HS_TIME_PLAYER_LOTTERY:
                            {
                                ProcessMajoraConstantString(curChar, CurTextbox, ref curLineWidth, 4);
                                break;
                            }
                        case (byte)MajoraControlCode.BANK_PROMPT:
                        case (byte)MajoraControlCode.DOG_RACE_BET_PROMPT:
                        case (byte)MajoraControlCode.BOMBER_CODE_PROMPT:
                            {
                                CurTextbox.MajoraPromptIndex = CurTextbox.DecodedData.Count + 1;
                                CurTextbox.DecodedData.Add(curChar);
                                ProcessMajoraConstantString(curChar, CurTextbox, ref curLineWidth, -1, 16);
                                break;
                            }
                        case (byte)MajoraControlCode.BOMBER_CODE:
                            {
                                ProcessMajoraConstantString(curChar, CurTextbox, ref curLineWidth, -1, 16);
                                CurTextbox.NumLines++; // Result of OoB read & write bug
                                break;
                            }
                        case (byte)MajoraControlCode.TIME:
                            {
                                ProcessMajoraConstantString(curChar, CurTextbox, ref curLineWidth, 6);  // Centering is wrong
                                break;
                            }
                        case (byte)MajoraControlCode.LOTTERY_NUMBER_PROMPT:
                            {
                                CurTextbox.MajoraPromptIndex = CurTextbox.DecodedData.Count + 1;
                                CurTextbox.DecodedData.Add(curChar);
                                ProcessMajoraConstantString(curChar, CurTextbox, ref curLineWidth, 3);
                                break;
                            }
                        case (byte)MajoraControlCode.TIME_SPEED:
                        case (byte)MajoraControlCode.PLAYER_LOTTERY_NUM:
                        case (byte)MajoraControlCode.WINNING_LOTTERY_NUM:
                            {
                                ProcessMajoraConstantString(curChar, CurTextbox, ref curLineWidth, 3);  // Centering is wrong
                                break;
                            }
                        case (byte)MajoraControlCode.OCEANSIDE_HOUSE_ORDER:
                            {
                                string str = GameData.MajoraStringConstants[(MajoraControlCode)curChar];
                                byte[] strb = Encoding.ASCII.GetBytes(str);

                                byte[] colors =
                                {
                                    (byte)MajoraControlCode.COLOR_YELLOW,
                                    (byte)MajoraControlCode.COLOR_RED,
                                    (byte)MajoraControlCode.COLOR_GREEN,
                                    (byte)MajoraControlCode.COLOR_YELLOW,
                                    (byte)MajoraControlCode.COLOR_BLUE,
                                    (byte)MajoraControlCode.COLOR_RED,
                                };

                                for (int c = 0; c < strb.Length; c++)
                                {
                                    byte color = colors[c % colors.Length];
                                    CurTextbox.DecodedData.Add(color);
                                    CurTextbox.DecodedData.Add(strb[c]);
                                }

                                CurTextbox.DecodedData.Add((byte)MajoraControlCode.COLOR_DEFAULT);
                                break;
                            }
                        case (byte)MajoraControlCode.OCEANSIDE_HOUSE_ORDER_1:
                        case (byte)MajoraControlCode.OCEANSIDE_HOUSE_ORDER_2:
                        case (byte)MajoraControlCode.OCEANSIDE_HOUSE_ORDER_3:
                        case (byte)MajoraControlCode.OCEANSIDE_HOUSE_ORDER_4:
                        case (byte)MajoraControlCode.OCEANSIDE_HOUSE_ORDER_5:
                        case (byte)MajoraControlCode.OCEANSIDE_HOUSE_ORDER_6:
                            {
                                CurTextbox.DecodedData.Add((byte)MajoraControlCode.COLOR_YELLOW);
                                ProcessMajoraConstantString(curChar, CurTextbox, ref curLineWidth);
                                CurTextbox.DecodedData.Add((byte)MajoraControlCode.COLOR_DEFAULT);
                                break;
                            }

                        case (byte)MajoraControlCode.BACKGROUND:
                            {
                                // Causes the icon to glitch out.
                                GlitchOutIcon = true;

                                CurTextbox.MajoraBoxCenter = true;
                                MajoraTextCenter = true;

                                curLine = 2;
                                CurTextbox.NumLines = 2;
                                CurTextbox.DecodedData.Add(curChar);
                                break;
                            }
                        case (byte)MajoraControlCode.TWO_CHOICES:
                            {
                                CurTextbox.MajoraBoxCenter = false;
                                NumChoices = 2;
                                CurTextbox.DecodedData.Add(curChar);
                                break;
                            }
                        case (byte)MajoraControlCode.THREE_CHOICES:
                            {
                                CurTextbox.MajoraBoxCenter = false;
                                NumChoices = 3;
                                CurTextbox.DecodedData.Add(curChar);
                                break;
                            }
                        case (byte)MajoraControlCode.CR:
                        case (byte)MajoraControlCode.LINE_BREAK:
                            {
                                CurTextbox.DecodedData.Add(curChar);
                                CurTextbox.StartPosX = IsBomberNotebook ? GameData.MajoraTextXPosBombers : GameData.TextXPosDefault;

                                if (curLine < 4)
                                {
                                    CurTextbox.MajoraCenteringOffset[curLine] = 0;

                                    if (MajoraTextCenter)
                                        CurTextbox.MajoraCenteringOffset[curLine] = (int)(((CurTextbox.ScaleX * 16.0f * 16.0f) - curLineWidth) / 2);
                                }

                                curLine++;
                                curLineWidth = 0;

                                if (curChar == (byte)MajoraControlCode.LINE_BREAK)
                                    CurTextbox.NumLines++;

                                break;
                            }
                        case (byte)MajoraControlCode.DC:
                        case (byte)MajoraControlCode.DI:
                            {
                                CurTextbox.DecodedData.Add(curChar);
                                break;
                            }
                        case (byte)MajoraControlCode.TEXT_SPEED:
                            {
                                CurTextbox.DecodedData.Add(curChar);
                                CurTextbox.DecodedData.Add(0);
                                i++;
                                break;
                            }
                        case (byte)MajoraControlCode.SOUND:
                        case (byte)MajoraControlCode.DELAY:
                            {
                                CurTextbox.DecodedData.Add(curChar);
                                CurTextbox.DecodedData.Add(Data[++i]);
                                CurTextbox.DecodedData.Add(Data[++i]);
                                break;
                            }
                        case (byte)MajoraControlCode.COLOR_DEFAULT:
                        case (byte)MajoraControlCode.COLOR_RED:
                        case (byte)MajoraControlCode.COLOR_GREEN:
                        case (byte)MajoraControlCode.COLOR_BLUE:
                        case (byte)MajoraControlCode.COLOR_YELLOW:
                        case (byte)MajoraControlCode.COLOR_NAVY:
                        case (byte)MajoraControlCode.COLOR_PINK:
                        case (byte)MajoraControlCode.COLOR_SILVER:
                        case (byte)MajoraControlCode.COLOR_ORANGE:
                            {
                                CurTextbox.DecodedData.Add(curChar);
                                break;
                            }
                        default:
                            {
                                CurTextbox.DecodedData.Add(curChar);
                                curLineWidth += GetCharacterWidth(TargetGame, curChar, UseRealSpaceWidth, CurTextbox.ScaleX);
                                break;
                            }

                    }
                }
            }
            catch
            {
                Textboxes = null;
            }
        }

    }
}
