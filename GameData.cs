using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ZeldaMsgPreview
{
    public static class GameData
    {
        public static readonly Dictionary<OcarinaControlCode, string> OcarinaStringConstants = new Dictionary<OcarinaControlCode, string>
        {
            { OcarinaControlCode.PLAYER,          "Link" },
            { OcarinaControlCode.POINTS,          "1000" },
            { OcarinaControlCode.FISH_WEIGHT,     "10" },
            { OcarinaControlCode.GOLD_SKULLTULAS, "100" },
            { OcarinaControlCode.MARATHON_TIME,   "00\"00\"" },
            { OcarinaControlCode.RACE_TIME,       "00\"00\"" },
            { OcarinaControlCode.TIME,            "00:00" },
        };

        public static readonly Dictionary<OcarinaHighScore, string> OcarinaHighScoreStringConstants = new Dictionary<OcarinaHighScore, string>
        {
            { OcarinaHighScore.ARCHERY,      "1000" },
            { OcarinaHighScore.POE_POINTS,   "1000" },
            { OcarinaHighScore.FISHING,      "10" },
            { OcarinaHighScore.HORSE_RACE,   "00\"00\"" },
            { OcarinaHighScore.MARATHON,     "00\"00\"" },
            { OcarinaHighScore.HS_UNK,       "" },
            { OcarinaHighScore.DAMPE_RACE,   "00\"00\"" },
        };

        public static readonly Dictionary<TextboxType, Color> OcarinaTextboxColors = new Dictionary<TextboxType, Color>
        {
            {TextboxType.Black,   Color.FromArgb(170, 0, 0, 0) },
            {TextboxType.Wooden,  Color.FromArgb(230, 70, 50, 30) },
            {TextboxType.Blue,    Color.FromArgb(170, 0, 10, 50) },
            {TextboxType.Ocarina, Color.FromArgb(180, 255, 0, 0) },
        };

        public static readonly Color[] TextboxBackgroundForePrimColors = new Color[]
        {
            Color.FromArgb(255, 255, 255),
            Color.FromArgb(50, 20, 0),
            Color.FromArgb(255, 60, 0),
            Color.FromArgb(255, 255, 255),
            Color.FromArgb(255, 255, 255),
            Color.FromArgb(255, 255, 255),
            Color.FromArgb(255, 255, 255),
            Color.FromArgb(255, 255, 255)
        };

        public static readonly Color[] TextboxBackgroundBackPrimColors = new Color[]
        {
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(220, 150, 0),
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(0, 0, 0)
        };

        public static readonly int[] TextboxBackgroundYOffsets = new int[]
        {
            1,
            2
        };

        public static readonly int OcarinaCharWidth = 16;
        public static readonly int OcarinaCharHeight = 16;

        public static readonly int OcarinaTextboxXPosition = 34;
        public static readonly int[] OcarinaTextboxYPositionsCenter = new int[] { 142, 142, 142, 142, 174, 142, };
        public static readonly int[] OcarinaTextboxYPositionsTop = new int[] { 38, 38, 38, 38, 174, 38, };
        public static readonly int[] OcarinaTextboxYPositionsBottom = new int[] { 90, 90, 90, 90, 174, 90, };
        public static readonly int[] OcarinaTextboxEndIconOffsets = new int[] { 59, 59, 59, 59, 34, 59, };

        public static readonly int OcarinaTextXPosDefault = 60;
        public static readonly int OcarinaTextXPosOffset = 28;
        public static readonly int OcarinaTextXPosCredits = 20;
        public static readonly int OcarinaTextYPosDefault = 8;
        public static readonly int OcarinaTextYPosCredits = 63;
        public static readonly float OcarinaTextScaleDefault = 0.75f;
        public static readonly float OcarinaTextScaleCredits = 0.85f;

        public static readonly int OcarinaEndIconXPos = 158;
        public static readonly int OcarinaEndIconYPos = 102;
        public static readonly Color OcarinaEndIconColor = Color.FromArgb(0, 80, 200);

        public static readonly int OcarinaLinebreakSize = 12;
        public static readonly int OcarinaChoiceOffset = 0x20;

        public static readonly int ScreenWidth = 320;
        public static readonly int ScreenHeight = 240;

        public static readonly int TextboxWidth = 256;
        public static readonly int TextboxHeight = 64;

        public static bool RunningUnderMono = Type.GetType("Mono.Runtime") != null;

        public static byte[] FontData = null;

        public static float[] FontWidths =
        {
            /* */ 8.0f,
            /* !*/ 8.0f,
            /* "*/ 6.0f,
            /* #*/ 9.0f,
            /* $*/ 9.0f,
            /* %*/ 14.0f,
            /* &*/ 12.0f,
            /* '*/ 3.0f,
            /* (*/ 7.0f,
            /* )*/ 7.0f,
            /* **/ 7.0f,
            /* +*/ 9.0f,
            /* ,*/ 4.0f,
            /* -*/ 6.0f,
            /* .*/ 4.0f,
            /* /*/ 9.0f,
            /* 0*/ 10.0f,
            /* 1*/ 5.0f,
            /* 2*/ 9.0f,
            /* 3*/ 9.0f,
            /* 4*/ 10.0f,
            /* 5*/ 9.0f,
            /* 6*/ 9.0f,
            /* 7*/ 9.0f,
            /* 8*/ 9.0f,
            /* 9*/ 9.0f,
            /* :*/ 6.0f,
            /* ;*/ 6.0f,
            /* <*/ 9.0f,
            /* =*/ 11.0f,
            /* >*/ 9.0f,
            /* ?*/ 11.0f,
            /* @*/ 13.0f,
            /* A*/ 12.0f,
            /* B*/ 9.0f,
            /* C*/ 11.0f,
            /* D*/ 11.0f,
            /* E*/ 8.0f,
            /* F*/ 8.0f,
            /* G*/ 12.0f,
            /* H*/ 10.0f,
            /* I*/ 4.0f,
            /* J*/ 8.0f,
            /* K*/ 10.0f,
            /* L*/ 8.0f,
            /* M*/ 13.0f,
            /* N*/ 11.0f,
            /* O*/ 13.0f,
            /* P*/ 9.0f,
            /* Q*/ 13.0f,
            /* R*/ 10.0f,
            /* S*/ 10.0f,
            /* T*/ 9.0f,
            /* U*/ 10.0f,
            /* V*/ 11.0f,
            /* W*/ 15.0f,
            /* X*/ 11.0f,
            /* Y*/ 10.0f,
            /* Z*/ 10.0f,
            /* [*/ 7.0f,
            /* ¥*/ 10.0f,
            /* ]*/ 7.0f,
            /* ^*/ 10.0f,
            /* _*/ 9.0f,
            /* `*/ 5.0f,
            /* a*/ 8.0f,
            /* b*/ 9.0f,
            /* c*/ 8.0f,
            /* d*/ 9.0f,
            /* e*/ 9.0f,
            /* f*/ 6.0f,
            /* g*/ 9.0f,
            /* h*/ 8.0f,
            /* i*/ 4.0f,
            /* j*/ 6.0f,
            /* k*/ 8.0f,
            /* l*/ 4.0f,
            /* m*/ 12.0f,
            /* n*/ 9.0f,
            /* o*/ 9.0f,
            /* p*/ 9.0f,
            /* q*/ 9.0f,
            /* r*/ 7.0f,
            /* s*/ 8.0f,
            /* t*/ 7.0f,
            /* u*/ 8.0f,
            /* v*/ 9.0f,
            /* w*/ 12.0f,
            /* x*/ 8.0f,
            /* y*/ 9.0f,
            /* z*/ 8.0f,
            /* {*/ 7.0f,
            /* |*/ 5.0f,
            /* }*/ 7.0f,
            /* ~*/ 10.0f,
            /* ‾*/ 10.0f,
            /* À*/ 12.0f,
            /* î*/ 6.0f,
            /* Â*/ 12.0f,
            /* Ä*/ 12.0f,
            /* Ç*/ 11.0f,
            /* È*/ 8.0f,
            /* É*/ 8.0f,
            /* Ê*/ 8.0f,
            /* Ë*/ 6.0f,
            /* Ï*/ 6.0f,
            /* Ô*/ 13.0f,
            /* Ö*/ 13.0f,
            /* Ù*/ 10.0f,
            /* Û*/ 10.0f,
            /* Ü*/ 10.0f,
            /* ß*/ 9.0f,
            /* à*/ 8.0f,
            /* á*/ 8.0f,
            /* â*/ 8.0f,
            /* ä*/ 8.0f,
            /* ç*/ 8.0f,
            /* è*/ 9.0f,
            /* é*/ 9.0f,
            /* ê*/ 9.0f,
            /* ë*/ 9.0f,
            /* ï*/ 6.0f,
            /* ô*/ 9.0f,
            /* ö*/ 9.0f,
            /* ù*/ 9.0f,
            /* û*/ 9.0f,
            /* ü*/ 9.0f,
            /* [A] */ 14.0f,
            /* [B] */ 14.0f,
            /* [C] */ 14.0f,
            /* [L] */ 14.0f,
            /* [R] */ 14.0f,
            /* [Z] */ 14.0f,
            /* [C-Up] */ 14.0f,
            /* [C-Down] */ 14.0f,
            /* [C-Left] */ 14.0f,
            /* [C-Right] */ 14.0f,
            /* ▼*/ 14.0f,
            /* [Analog-Stick] */ 14.0f,
            /* [D-Pad] */ 14.0f,
            /* ?*/ 14.0f,
            /* ?*/ 14.0f,
            /* ?*/ 14.0f,
            /* ?*/ 14.0f,
        };

        public static readonly Dictionary<OcarinaMsgColor, Color[]> OcarinaMsgRGB = new Dictionary<OcarinaMsgColor, Color[]>
        {
            [OcarinaMsgColor.DEFAULT] = new[]
            {
                Color.FromArgb(225, 255, 255),   // Default
                Color.FromArgb(255, 255, 255)    // Wooden
            },

            [OcarinaMsgColor.RED] = new[]
            {
                Color.FromArgb(255, 60, 60),     // Default
                Color.FromArgb(255, 120, 0)      // Wooden
            },

            [OcarinaMsgColor.BLUE] = new[]
            {
                Color.FromArgb(80, 90, 255),     // Default
                Color.FromArgb(80, 110, 255)     // Wooden
            },

            [OcarinaMsgColor.CYAN] = new[]
            {
                Color.FromArgb(100, 180, 255),   // Default
                Color.FromArgb(90, 180, 255)     // Wooden
            },

            [OcarinaMsgColor.MAGENTA] = new[]
            {
                Color.FromArgb(255, 150, 180),   // Default
                Color.FromArgb(210, 100, 255)    // Wooden
            },

            [OcarinaMsgColor.YELLOW] = new[]
            {
                Color.FromArgb(225, 255, 50),    // Default
                Color.FromArgb(255, 255, 30)     // Wooden
            },

            [OcarinaMsgColor.BLACK] = new[]
            {
                Color.FromArgb(0, 0, 0),         // Default
                Color.FromArgb(0, 0, 0)          // Wooden
            },

            [OcarinaMsgColor.GREEN] = new[]
            {
                Color.FromArgb(70, 255, 80),     // Default
                Color.FromArgb(70, 255, 80)      // Wooden
            }
        };

    }
}
