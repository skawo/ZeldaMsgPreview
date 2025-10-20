using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ZeldaMsgPreview
{
    public class Textbox
    {
        public Game TargetGame { get; set; }
        public List<byte> DecodedData { get; set; }
        public int StartPosX { get; set; }
        public int StartPosY { get; set; }
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
        public EndingGraphics EndingGraphic { get; set; }

        public bool IsLastMsg { get; set; }

        public Textbox()
        {
            DecodedData = new List<byte>();
            MajoraFirstPrice = 500;
            MajoraSecondPrice = 500;
            Icon = -1;
        }

        private Bitmap GetBaseImage(bool FullScreenForce)
        {
            int OutputX = GameData.ScreenWidth;
            int OutputY = GameData.ScreenHeight;

            if (!FullScreenForce && !IsCredits)
            {
                OutputX = GameData.TextboxWidth;
                OutputY = GameData.TextboxHeight + 8;
            }

            Bitmap bmp = new Bitmap(OutputX, OutputY);

            using (var g = Graphics.FromImage(bmp))
            {
                if (Type == TextboxType.None_White)
                    g.FillRectangle(Brushes.Black, 0, 0, OutputX, OutputY);
                else
                    bmp.MakeTransparent();
            }

            return bmp;
        }

        private Bitmap DrawBox(Bitmap destBmp)
        {
            Bitmap tboxImage;
            Color colorizeColor;
            bool reverseAlpha;

            switch (Type)
            {
                case TextboxType.Black:
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
                    {
                        tboxImage = Properties.Resources.Box_Blue;
                        colorizeColor = Color.FromArgb(170, 0, 10, 50);
                        reverseAlpha = true;
                        break;
                    }
                case TextboxType.None_White:
                case TextboxType.None_Black:
                default:
                    return destBmp;
            }

            return DrawBoxInternal(destBmp, tboxImage, colorizeColor, reverseAlpha);
        }

        private int GetTextboxYPosition(bool IsFullscreen)
        {
            int posY = 0;

            if (IsFullscreen && Type <= TextboxType.None_Black)
            {
                switch (Position)
                {
                    case TextboxPosition.Top:
                        posY = GameData.OcarinaTextboxYPositionsTop[(byte)Type]; break;
                    case TextboxPosition.Center:
                        posY = GameData.OcarinaTextboxYPositionsCenter[(byte)Type]; break;
                    default:
                        posY = GameData.OcarinaTextboxYPositionsBottom[(byte)Type]; break;
                }
            }

            return posY;
        }

        private int GetTextboxEndMarkerPosition(bool IsFullscreen)
        {
            int posY = GetTextboxYPosition(IsFullscreen);

            if (Type <= TextboxType.None_Black)
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
                int posX = (destBmp.Width == GameData.ScreenWidth ? GameData.OcarinaTextboxXPosition : 0);

                srcBmp.SetResolution(g.DpiX, g.DpiY);
                g.DrawImage(srcBmp, posX, posY);

                srcBmp = Helpers.FlipBitmapX_MonoSafe(srcBmp);

                g.DrawImage(srcBmp, posX + srcBmp.Width, posY);
            }

            return destBmp;
        }

        private OcarinaMsgColor GetDefaultColor()
        {
            return Type == TextboxType.None_Black ? OcarinaMsgColor.BLACK : OcarinaMsgColor.DEFAULT;
        }

        private Bitmap DrawEndMarker(Bitmap destBmp)
        {
            if (!IsCredits && EndingGraphic != EndingGraphics.None)
            {
                float xPosEnd = GameData.OcarinaEndIconXPos - (destBmp.Width == GameData.ScreenWidth ? 0 : 28);
                float yPosEnd = GetTextboxEndMarkerPosition(destBmp.Height == GameData.ScreenHeight);
                Bitmap endIcon = EndingGraphic == EndingGraphics.Square ? Properties.Resources.Box_End : Properties.Resources.Box_Triangle;
                Helpers.DrawImage(destBmp, endIcon, GameData.OcarinaEndIconColor, (int)(GameData.OcarinaCharWidth * ScaleX), (int)(GameData.OcarinaCharHeight * ScaleY), ref xPosEnd, ref yPosEnd, 0);
            }

            return destBmp;
        }

        private Bitmap DrawText(Bitmap destBmp, bool realSpaceWidthForce, bool brightenText)
        {
            float curTextPosX = StartPosX;
            float drawXOffs = (destBmp.Width == GameData.ScreenWidth ? 0 : GameData.OcarinaTextXPosOffset);
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
                                    yPosIcon += drawYOffs;

                                    Helpers.DrawImage(destBmp, img, Color.White, 32, 32, ref xPosIcon, ref yPosIcon, 32, false);
                                }
                                else
                                {
                                    float xPosIcon = curTextPosX + StartPosX + drawXOffs - 72;
                                    float yPosIcon = drawYOffs + 20;
                                    yPosIcon += drawYOffs;

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
                            float yPosBgShadow = yPosBg + 1;

                            // This makes barely any difference, but~~
                            if (BgYPosOffsetId > 0 && BgYPosOffsetId < GameData.TextboxBackgroundYOffsets.Length)
                                yPosBg += GameData.TextboxBackgroundYOffsets[BgYPosOffsetId];

                            Color BackColor = GameData.TextboxBackgroundBackPrimColors[0];

                            if (BgBackColorId > 0 && BgBackColorId < GameData.TextboxBackgroundBackPrimColors.Length)
                                BackColor = GameData.TextboxBackgroundBackPrimColors[BgBackColorId];

                            Color ForeColor = GameData.TextboxBackgroundForePrimColors[0];

                            if (BgForeColorId > 0 && BgForeColorId < GameData.TextboxBackgroundForePrimColors.Length)
                                ForeColor = GameData.TextboxBackgroundForePrimColors[BgForeColorId];

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

                            if (Enum.IsDefined(typeof(OcarinaMsgColor), (int)colorId) && colorId != (byte)OcarinaMsgColor.DEFAULT)
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

                            curTextPosY += GameData.OcarinaLinebreakSize;
                            break;
                        }
                    case (byte)OcarinaControlCode.TWO_CHOICES:
                    case (byte)OcarinaControlCode.THREE_CHOICES:
                        {
                            if (IsCredits)
                                break;

                            Bitmap imgArrow = Properties.Resources.Box_Arrow;
                            float xPosChoice = 48 - (destBmp.Width == GameData.ScreenWidth ? 0 : GameData.OcarinaTextXPosOffset);
                            float yPosChoice = (curChar is (byte)OcarinaControlCode.THREE_CHOICES) ? 20 : 32;
                            yPosChoice += drawYOffs;

                            for (int ch = 0; ch < NumChoices; ch++)
                            {
                                Helpers.DrawImage(destBmp, imgArrow, Color.LimeGreen, (int)(16 * ScaleX), (int)(16 * ScaleY), ref xPosChoice, ref yPosChoice, 0);
                                yPosChoice += GameData.OcarinaLinebreakSize;
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
                        DrawTextInternal(destBmp, curChar, GameData.OcarinaMsgRGB[curColor][Type == TextboxType.Wooden ? 1 : 0], realSpaceWidthForce, brightenText,
                                         curScaleX, curScaleY, ref curTextPosX, ref curTextPosY); break;
                }
            }

            return destBmp;
        }

        private Bitmap DrawTextInternal(Bitmap destBmp, byte character, Color charColor, bool realSpaceWidthForce, bool brightenText,
                                        float scaleX, float scaleY, ref float posX, ref float posY)
        {
            // Handle space character early
            if (character == ' ')
            {
                posX += realSpaceWidthForce
                    ? GameData.FontWidths[0] * scaleX
                    : 6.0f;
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
                // Fallback: load from resources
                string resCharName = $"char_{character:X}".ToLower();
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
                if (Type != TextboxType.None_Black)
                {
                    shadowBmp = Helpers.Colorize(shadowBmp, Color.Black);
                    shadowBmp.SetResolution(g.DpiX, g.DpiY);
                    g.DrawImage(shadowBmp, new Rectangle((int)posX + 1, (int)posY + 1, (int)(GameData.OcarinaCharWidth * scaleX), (int)(GameData.OcarinaCharHeight * scaleY)));
                }

                // Draw character
                g.DrawImage(charBmp, new Rectangle((int)posX, (int)posY, (int)(GameData.OcarinaCharWidth * scaleX), (int)(GameData.OcarinaCharHeight * scaleY)));
            }

            // Advance position for next character
            try
            {
                posX += (int)(GameData.FontWidths[character - 0x20] * scaleX);
            }
            catch
            {
                // Fallback width
                posX += 16 * scaleX;
            }

            return destBmp;
        }

        public Bitmap GetPreview(bool UseRealSpaceWidth = false, bool ForceFullScreenPreview = false, bool BrightenText = true)
        {
            Bitmap bmp;

            try
            {
                bmp = GetBaseImage(ForceFullScreenPreview);
                bmp = DrawBox(bmp);

                int drawOffsX = (bmp.Width == GameData.ScreenWidth ? 0 : GameData.OcarinaTextXPosOffset);

                StartPosX -= drawOffsX;
                bmp = DrawText(bmp, UseRealSpaceWidth, BrightenText);
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

        public Message()
        {
            TargetGame = Game.Ocarina;
            Data = new byte[0];
            OcarinaType = TextboxType.Black;
            IsCredits = false;

            Decode();
        }

        public Message(Game _TargetGame, byte[] _Data, TextboxPosition _TextboxPosition = TextboxPosition.Dynamic, TextboxType _OcarinaTextboxType = TextboxType.Black, bool _IsCredits = false)
        {
            TargetGame = _TargetGame;
            Data = _Data;
            OcarinaType = _OcarinaTextboxType;
            IsCredits = _IsCredits;
            TextboxPosition = _TextboxPosition;

            Decode();
        }

        public Bitmap GetPreview(bool UseRealSpaceWidth = false, bool ForceFullScreenPreview = false, bool BrightenText = true)
        {
            if (Textboxes == null)
                return null;

            Bitmap temp = Textboxes[0].GetPreview(false, false, true);

            Bitmap bmpOut = new Bitmap(temp.Width, Textboxes.Count * temp.Height);
            bmpOut.MakeTransparent();

            using (Graphics g = Graphics.FromImage(bmpOut))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                g.DrawImage(temp, 0, 0);

                for (int i = 1; i < Textboxes.Count; i++)
                {
                    temp = Textboxes[i].GetPreview(UseRealSpaceWidth, ForceFullScreenPreview, BrightenText);

                    if (temp != null)
                        g.DrawImage(temp, 0, temp.Height * i);
                }
            }

            return bmpOut;
        }

        private void Decode()
        {
            if (TargetGame == Game.Ocarina)
                DecodeOcarina();
            else
                DecodeMajora();
        }

        private void DecodeOcarina()
        {
            try
            {
                Textboxes = new List<Textbox>();
                Textbox CurTextbox = new Textbox() { TargetGame = TargetGame, Position = TextboxPosition, Type = OcarinaType, IsCredits = IsCredits };

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
                                CurTextbox.StartPosX = IsCredits ? GameData.OcarinaTextXPosCredits : GameData.OcarinaTextXPosDefault;
                                CurTextbox.StartPosY = IsCredits ? GameData.OcarinaTextYPosCredits : GameData.OcarinaTextYPosDefault;
                                CurTextbox.ScaleX = IsCredits ? GameData.OcarinaTextScaleCredits : GameData.OcarinaTextScaleDefault;
                                CurTextbox.ScaleY = IsCredits ? GameData.OcarinaTextScaleCredits : GameData.OcarinaTextScaleDefault;

                                if (OcarinaType != TextboxType.None_White && !IsCredits)
                                {
                                    switch (CurTextbox.NumLines)
                                    {
                                        case 0: CurTextbox.StartPosY = 26; break;
                                        case 1: CurTextbox.StartPosY = 20; break;
                                        case 2: CurTextbox.StartPosY = 16; break;
                                        default: CurTextbox.StartPosY = 8; break;
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

                                CurTextbox = new Textbox() { TargetGame = TargetGame, Position = TextboxPosition, Type = OcarinaType, IsCredits = IsCredits };
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

        private void DecodeMajora()
        {

        }

    }
}
