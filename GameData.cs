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

        public static readonly Dictionary<MajoraControlCode, string> MajoraStringConstants = new Dictionary<MajoraControlCode, string>()
        {
            {MajoraControlCode.PLAYER,                              "Link"},
            {MajoraControlCode.HS_BOAT_ARCHERY,                     "20" },
            {MajoraControlCode.STRAY_FAIRIES,                       "20th" },
            {MajoraControlCode.GOLD_SKULLTULAS,                     "20th" },
            {MajoraControlCode.TIMER_POSTMAN,                       "0\"00" },
            {MajoraControlCode.TIMER_MINIGAME1,                     "0\"00" },
            {MajoraControlCode.TIMER2,                              "0\"00" },
            {MajoraControlCode.TIMER_MOON_CRASH,                    "0\"00" },
            {MajoraControlCode.TIMER_MINIGAME2,                     "0\"00" },
            {MajoraControlCode.TIMER_ENV_HAZARD,                    "0\"00" },
            {MajoraControlCode.TIME,                                "0\"00" },
            {MajoraControlCode.SHOOTING_GALLERY_RESULT,             "9999" },
            {MajoraControlCode.BANK_PROMPT,                         "000 Rupee(s)" },
            {MajoraControlCode.RUPEES_ENTERED,                      "500 Rupees" },
            {MajoraControlCode.RUPEES_IN_BANK,                      "5000 Rupees" },
            {MajoraControlCode.MOON_CRASH_TIME_REMAINS,             "72:00" },
            {MajoraControlCode.DOG_RACE_BET_PROMPT,                 "00  Rupees" },
            {MajoraControlCode.BOMBER_CODE_PROMPT,                  "00000" },
            {MajoraControlCode.SOARING_DESTINATION,                 "Great Bay Coast" },
            {MajoraControlCode.TIME_SPEED,                          "Slow" },
            {MajoraControlCode.LOTTERY_NUMBER_PROMPT,               "111" },
            {MajoraControlCode.OCEANSIDE_HOUSE_ORDER,               "123456" },
            {MajoraControlCode.WOODFALL_FAIRIES_REMAIN,             "15" },
            {MajoraControlCode.SNOWHEAD_FAIRIES_REMAIN,             "15" },
            {MajoraControlCode.BAY_FAIRIES_REMAIN,                  "15" },
            {MajoraControlCode.IKANA_FAIRIES_REMAIN,                "15" },
            {MajoraControlCode.BOAT_ARCHERY_RESULT,                 "45" },
            {MajoraControlCode.WINNING_LOTTERY_NUM,                 "000" },
            {MajoraControlCode.PLAYER_LOTTERY_NUM,                  "000" },
            {MajoraControlCode.ITEM_VALUE,                          "500 Rupees" },
            {MajoraControlCode.BOMBER_CODE,                         "12345" },
            {MajoraControlCode.OCEANSIDE_HOUSE_ORDER_1,             "YELLOW" },
            {MajoraControlCode.OCEANSIDE_HOUSE_ORDER_2,             "YELLOW" },
            {MajoraControlCode.OCEANSIDE_HOUSE_ORDER_3,             "YELLOW" },
            {MajoraControlCode.OCEANSIDE_HOUSE_ORDER_4,             "YELLOW" },
            {MajoraControlCode.OCEANSIDE_HOUSE_ORDER_5,             "YELLOW" },
            {MajoraControlCode.OCEANSIDE_HOUSE_ORDER_6,             "YELLOW" },
            {MajoraControlCode.MOON_CRASH_HOURS_REMAIN,             "72 hours" },
            {MajoraControlCode.UNTIL_MORNING,                       "23:59" },
            {MajoraControlCode.TOTAL_IN_BANK,                       "5000" },
            {MajoraControlCode.HS_TOWN_SHOOTING_GALLERY,            "50" },
            {MajoraControlCode.HS_ROMANI_ARCHERY,                   "99'99\"99" },
            {MajoraControlCode.HS_DEKU_PLAYGROUND_DAY1,             "99'99\"99" },
            {MajoraControlCode.HS_DEKU_PLAYGROUND_DAY2,             "99'99\"99" },
            {MajoraControlCode.HS_DEKU_PLAYGROUND_DAY3,             "99'99\"99" },
            {MajoraControlCode.HS_TIME_ROMANI_ARCHERY,              ":0\"00\'" },
            {MajoraControlCode.HS_TIME_BOAT_ARCHERY,                "0\"10\'" },
            {MajoraControlCode.HS_TIME_PLAYER_LOTTERY,              "0\"10\'" },
            {MajoraControlCode.HS_UNK,                              "0" },
            {MajoraControlCode.HS_FISHING,                          "0" },
            {MajoraControlCode.POINTS_TENS,                         "99" },
            {MajoraControlCode.POINTS_THOUSANDS,                    "9999" },
            {MajoraControlCode.DEKU_PLAYGROUND_PLAYER_DAY1,         "Link"},
            {MajoraControlCode.DEKU_PLAYGROUND_PLAYER_DAY2,         "Link"},
            {MajoraControlCode.DEKU_PLAYGROUND_PLAYER_DAY3,         "Link"},
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

        public static readonly Color[] OcarinaTextboxBackgroundForePrimColors = new Color[]
        {
            Color.FromArgb(255, 255, 255),
            Color.FromArgb(50, 20, 0),
            Color.FromArgb(255, 60, 0),
        };

        public static readonly Color[] OcarinaTextboxBackgroundBackPrimColors = new Color[]
        {
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(220, 150, 0),
        };

        public static readonly int[] OcarinaTextboxBackgroundShadowOffsets = new int[]
        {
            1,
            2
        };

        public static readonly int SpaceWidth = 6;
        public static readonly int CharWidth = 16;
        public static readonly int CharHeight = 16;

        public static readonly int TextboxXPosition = 34;
        public static readonly int[] OcarinaTextboxYPositionsBottom = new int[] { 142, 142, 142, 142, 174, 142, };
        public static readonly int[] OcarinaTextboxYPositionsTop = new int[] { 38, 38, 38, 38, 174, 38, };
        public static readonly int[] OcarinaTextboxYPositionsCenter = new int[] { 90, 90, 90, 90, 174, 90, };

        public static readonly int[] MajoraTextboxYPositionsBottom = new int[] { 142, 142, 142, 142, 174, 142, 142, 142, 142, 130, 174, 0, 142, 142, 142, 142 };
        public static readonly int[] MajoraTextboxYPositionsTop = new int[] { 38, 38, 38, 38, 174, 38, 38, 38, 38, 60, 174, 0, 38, 38, 38, 38 };
        public static readonly int[] MajoraTextboxYPositionsCenter = new int[] { 90, 90, 90, 90, 174, 90, 90, 90, 90, 90, 174, 0, 90, 90, 90, 90 };

        public static readonly int[] OcarinaTextboxEndIconOffsets = new int[] { 59, 59, 59, 59, 34, 59, };
        public static readonly int[] MajoraTextboxEndIconOffsets = new int[] { 59, 59, 59, 59, 34, 59, 59, 59, 59, 59, 59, 59, 59, 59, 59, 59 };

        public static readonly int TextXPosDefault = 65;
        public static readonly int MajoraTextXPosBombers = 50;
        public static readonly int CroppedXPosOffset = TextboxXPosition;
        public static readonly int OcarinaTextXPosCredits = 20;
        public static readonly int TextYPosDefault = 8;
        public static readonly int TextYPosMajoraOcarinaTextbox = 2;
        public static readonly int TextYPosCredits = 48;
        public static readonly float TextScaleDefault = 0.75f;
        public static readonly float TextScaleCredits = 0.85f;
        public static readonly float TextScaleBombers = 1.4f;

        public static readonly int OcarinaEndIconXPos = 158;
        public static readonly int OcarinaEndIconYPos = 102;
        public static readonly Color EndIconColor = Color.FromArgb(0, 80, 200);

        public static readonly Color MajoraBackgroundTagColor = Color.FromArgb(255, 60, 0);

        public static readonly int LinebreakSizeBombers = 22;
        public static readonly int LinebreakSize = 12;
        public static readonly int LinebreakSizeCredits = 6;
        public static readonly int OcarinaChoiceOffset = 0x20;

        public static readonly int ScreenWidth = 320;
        public static readonly int ScreenHeight = 240;

        public static readonly int TextboxWidth = 256;
        public static readonly int TextboxHeight = 64;
        public static readonly int TextboxWidthBombers = 512;
        public static readonly int TextboxHeightBombers = 89;

        public static bool RunningUnderMono = Type.GetType("Mono.Runtime") != null;

        public static byte[] FontData = null;

        public static float[] FontWidths;

        public static Dictionary<int, ItemId> IconToItem = new Dictionary<int, ItemId>()
        {
            { 0x00, ItemId.MESSAGE_ITEM_NONE },
            { 0x01, ItemId.ITEM_RUPEE_GREEN },
            { 0x02, ItemId.ITEM_RUPEE_BLUE },
            { 0x03, ItemId.ITEM_RUPEE_10 },
            { 0x04, ItemId.ITEM_RUPEE_RED },
            { 0x05, ItemId.ITEM_RUPEE_PURPLE },
            { 0x06, ItemId.ITEM_RUPEE_SILVER },
            { 0x07, ItemId.ITEM_RUPEE_HUGE },
            { 0x08, ItemId.ITEM_WALLET_ADULT },
            { 0x09, ItemId.ITEM_WALLET_GIANT },
            { 0x0A, ItemId.ITEM_RECOVERY_HEART },
            { 0x0B, ItemId.ITEM_RECOVERY_HEART },
            { 0x0C, ItemId.ITEM_HEART_PIECE },
            { 0x0D, ItemId.ITEM_HEART_CONTAINER },
            { 0x0E, ItemId.ITEM_MAGIC_JAR_SMALL },
            { 0x0F, ItemId.ITEM_MAGIC_JAR_BIG },
            { 0x10, ItemId.ITEM_RECOVERY_HEART },
            { 0x11, ItemId.ITEM_STRAY_FAIRIES },
            { 0x12, ItemId.ITEM_RECOVERY_HEART },
            { 0x13, ItemId.ITEM_RECOVERY_HEART },
            { 0x14, ItemId.ITEM_BOMB },
            { 0x15, ItemId.ITEM_BOMB },
            { 0x16, ItemId.ITEM_BOMB },
            { 0x17, ItemId.ITEM_BOMB },
            { 0x18, ItemId.ITEM_BOMB },
            { 0x19, ItemId.ITEM_DEKU_STICK },
            { 0x1A, ItemId.ITEM_BOMBCHU },
            { 0x1B, ItemId.ITEM_BOMB_BAG_20 },
            { 0x1C, ItemId.ITEM_BOMB_BAG_30 },
            { 0x1D, ItemId.ITEM_BOMB_BAG_40 },
            { 0x1E, ItemId.ITEM_BOW },
            { 0x1F, ItemId.ITEM_BOW },
            { 0x20, ItemId.ITEM_BOW },
            { 0x21, ItemId.ITEM_BOW },
            { 0x22, ItemId.ITEM_QUIVER_30 },
            { 0x23, ItemId.ITEM_QUIVER_40 },
            { 0x24, ItemId.ITEM_QUIVER_50 },
            { 0x25, ItemId.ITEM_ARROW_FIRE },
            { 0x26, ItemId.ITEM_ARROW_ICE },
            { 0x27, ItemId.ITEM_ARROW_LIGHT },
            { 0x28, ItemId.ITEM_DEKU_NUT },
            { 0x29, ItemId.ITEM_DEKU_NUT },
            { 0x2A, ItemId.ITEM_DEKU_NUT },
            { 0x2B, ItemId.MESSAGE_ITEM_NONE },
            { 0x2C, ItemId.MESSAGE_ITEM_NONE },
            { 0x2D, ItemId.MESSAGE_ITEM_NONE },
            { 0x2E, ItemId.MESSAGE_ITEM_NONE },
            { 0x2F, ItemId.ITEM_DEKU_STICK_UPGRADE_20 },
            { 0x30, ItemId.MESSAGE_ITEM_NONE },
            { 0x31, ItemId.MESSAGE_ITEM_NONE },
            { 0x32, ItemId.ITEM_SHIELD_HERO },
            { 0x33, ItemId.ITEM_SHIELD_MIRROR },
            { 0x34, ItemId.ITEM_POWDER_KEG },
            { 0x35, ItemId.ITEM_MAGIC_BEANS },
            { 0x36, ItemId.ITEM_PICTOGRAPH_BOX },
            { 0x37, ItemId.ITEM_SWORD_KOKIRI },
            { 0x38, ItemId.ITEM_SWORD_RAZOR },
            { 0x39, ItemId.ITEM_SWORD_GILDED },
            { 0x3A, ItemId.ITEM_SWORD_DEITY },
            { 0x3B, ItemId.ITEM_SWORD_GREAT_FAIRY },
            { 0x3C, ItemId.ITEM_KEY_SMALL },
            { 0x3D, ItemId.ITEM_KEY_BOSS },
            { 0x3E, ItemId.ITEM_DUNGEON_MAP },
            { 0x3F, ItemId.ITEM_COMPASS },
            { 0x40, ItemId.ITEM_POWDER_KEG },
            { 0x41, ItemId.ITEM_HOOKSHOT },
            { 0x42, ItemId.ITEM_LENS_OF_TRUTH },
            { 0x43, ItemId.ITEM_PICTOGRAPH_BOX },
            { 0x44, ItemId.ITEM_FISHING_ROD },
            { 0x45, ItemId.MESSAGE_ITEM_NONE },
            { 0x46, ItemId.MESSAGE_ITEM_NONE },
            { 0x47, ItemId.MESSAGE_ITEM_NONE },
            { 0x48, ItemId.MESSAGE_ITEM_NONE },
            { 0x49, ItemId.MESSAGE_ITEM_NONE },
            { 0x4A, ItemId.MESSAGE_ITEM_NONE },
            { 0x4B, ItemId.MESSAGE_ITEM_NONE },
            { 0x4C, ItemId.ITEM_OCARINA_OF_TIME },
            { 0x4D, ItemId.MESSAGE_ITEM_NONE },
            { 0x4E, ItemId.MESSAGE_ITEM_NONE },
            { 0x4F, ItemId.MESSAGE_ITEM_NONE },
            { 0x50, ItemId.ITEM_BOMBERS_NOTEBOOK },
            { 0x51, ItemId.MESSAGE_ITEM_NONE },
            { 0x52, ItemId.ITEM_SKULL_TOKEN },
            { 0x53, ItemId.MESSAGE_ITEM_NONE },
            { 0x54, ItemId.MESSAGE_ITEM_NONE },
            { 0x55, ItemId.ITEM_REMAINS_ODOLWA },
            { 0x56, ItemId.ITEM_REMAINS_GOHT },
            { 0x57, ItemId.ITEM_REMAINS_GYORG },
            { 0x58, ItemId.ITEM_REMAINS_TWINMOLD },
            { 0x59, ItemId.ITEM_POTION_RED },
            { 0x5A, ItemId.ITEM_BOTTLE },
            { 0x5B, ItemId.ITEM_POTION_RED },
            { 0x5C, ItemId.ITEM_POTION_GREEN },
            { 0x5D, ItemId.ITEM_POTION_BLUE },
            { 0x5E, ItemId.ITEM_FAIRY },
            { 0x5F, ItemId.ITEM_DEKU_PRINCESS },
            { 0x60, ItemId.ITEM_MILK_BOTTLE },
            { 0x61, ItemId.ITEM_MILK_HALF },
            { 0x62, ItemId.ITEM_FISH },
            { 0x63, ItemId.ITEM_BUG },
            { 0x64, ItemId.ITEM_BLUE_FIRE },
            { 0x65, ItemId.ITEM_POE },
            { 0x66, ItemId.ITEM_BIG_POE },
            { 0x67, ItemId.ITEM_SPRING_WATER },
            { 0x68, ItemId.ITEM_HOT_SPRING_WATER },
            { 0x69, ItemId.ITEM_ZORA_EGG },
            { 0x6A, ItemId.ITEM_GOLD_DUST },
            { 0x6B, ItemId.ITEM_MUSHROOM },
            { 0x6C, ItemId.MESSAGE_ITEM_NONE },
            { 0x6D, ItemId.MESSAGE_ITEM_NONE },
            { 0x6E, ItemId.ITEM_SEAHORSE },
            { 0x6F, ItemId.ITEM_CHATEAU },
            { 0x70, ItemId.ITEM_HYLIAN_LOACH },
            { 0x71, ItemId.MESSAGE_ITEM_NONE },
            { 0x72, ItemId.MESSAGE_ITEM_NONE },
            { 0x73, ItemId.MESSAGE_ITEM_NONE },
            { 0x74, ItemId.MESSAGE_ITEM_NONE },
            { 0x75, ItemId.MESSAGE_ITEM_NONE },
            { 0x76, ItemId.MESSAGE_ITEM_NONE },
            { 0x77, ItemId.MESSAGE_ITEM_NONE },
            { 0x78, ItemId.ITEM_MASK_DEKU },
            { 0x79, ItemId.ITEM_MASK_GORON },
            { 0x7A, ItemId.ITEM_MASK_ZORA },
            { 0x7B, ItemId.ITEM_MASK_FIERCE_DEITY },
            { 0x7C, ItemId.ITEM_MASK_TRUTH },
            { 0x7D, ItemId.ITEM_MASK_KAFEIS_MASK },
            { 0x7E, ItemId.ITEM_MASK_ALL_NIGHT },
            { 0x7F, ItemId.ITEM_MASK_BUNNY },
            { 0x80, ItemId.ITEM_MASK_KEATON },
            { 0x81, ItemId.ITEM_MASK_GARO },
            { 0x82, ItemId.ITEM_MASK_ROMANI },
            { 0x83, ItemId.ITEM_MASK_CIRCUS_LEADER },
            { 0x84, ItemId.ITEM_MASK_POSTMAN },
            { 0x85, ItemId.ITEM_MASK_COUPLE },
            { 0x86, ItemId.ITEM_MASK_GREAT_FAIRY },
            { 0x87, ItemId.ITEM_MASK_GIBDO },
            { 0x88, ItemId.ITEM_MASK_DON_GERO },
            { 0x89, ItemId.ITEM_MASK_KAMARO },
            { 0x8A, ItemId.ITEM_MASK_CAPTAIN },
            { 0x8B, ItemId.ITEM_MASK_STONE },
            { 0x8C, ItemId.ITEM_MASK_BREMEN },
            { 0x8D, ItemId.ITEM_MASK_BLAST },
            { 0x8E, ItemId.ITEM_MASK_SCENTS },
            { 0x8F, ItemId.ITEM_MASK_GIANT },
            { 0x90, ItemId.MESSAGE_ITEM_NONE },
            { 0x91, ItemId.ITEM_CHATEAU },
            { 0x92, ItemId.ITEM_MILK_BOTTLE },
            { 0x93, ItemId.ITEM_GOLD_DUST },
            { 0x94, ItemId.ITEM_HYLIAN_LOACH },
            { 0x95, ItemId.ITEM_SEAHORSE },
            { 0x96, ItemId.ITEM_MOONS_TEAR },
            { 0x97, ItemId.ITEM_DEED_LAND },
            { 0x98, ItemId.ITEM_DEED_SWAMP },
            { 0x99, ItemId.ITEM_DEED_MOUNTAIN },
            { 0x9A, ItemId.ITEM_DEED_OCEAN },
            { 0x9B, ItemId.MESSAGE_ITEM_NONE },
            { 0x9C, ItemId.MESSAGE_ITEM_NONE },
            { 0x9D, ItemId.MESSAGE_ITEM_NONE },
            { 0x9E, ItemId.MESSAGE_ITEM_NONE },
            { 0x9F, ItemId.MESSAGE_ITEM_NONE },
            { 0xA0, ItemId.ITEM_ROOM_KEY },
            { 0xA1, ItemId.ITEM_LETTER_MAMA },
            { 0xA2, ItemId.MESSAGE_ITEM_NONE },
            { 0xA3, ItemId.MESSAGE_ITEM_NONE },
            { 0xA4, ItemId.MESSAGE_ITEM_NONE },
            { 0xA5, ItemId.MESSAGE_ITEM_NONE },
            { 0xA6, ItemId.MESSAGE_ITEM_NONE },
            { 0xA7, ItemId.MESSAGE_ITEM_NONE },
            { 0xA8, ItemId.MESSAGE_ITEM_NONE },
            { 0xA9, ItemId.MESSAGE_ITEM_NONE },
            { 0xAA, ItemId.ITEM_LETTER_TO_KAFEI },
            { 0xAB, ItemId.ITEM_PENDANT_OF_MEMORIES },
            { 0xAC, ItemId.MESSAGE_ITEM_NONE },
            { 0xAD, ItemId.MESSAGE_ITEM_NONE },
            { 0xAE, ItemId.MESSAGE_ITEM_NONE },
            { 0xAF, ItemId.MESSAGE_ITEM_NONE },
            { 0xB0, ItemId.MESSAGE_ITEM_NONE },
            { 0xB1, ItemId.MESSAGE_ITEM_NONE },
            { 0xB2, ItemId.MESSAGE_ITEM_NONE },
            { 0xB3, ItemId.ITEM_TINGLE_MAP },
            { 0xB4, ItemId.ITEM_TINGLE_MAP },
            { 0xB5, ItemId.ITEM_TINGLE_MAP },
            { 0xB6, ItemId.ITEM_TINGLE_MAP },
            { 0xB7, ItemId.ITEM_TINGLE_MAP },
            { 0xB8, ItemId.ITEM_TINGLE_MAP },
            { 0xB9, ItemId.ITEM_TINGLE_MAP },
            { 0xBA, ItemId.MESSAGE_ITEM_NONE },
            { 0xBB, ItemId.MESSAGE_ITEM_NONE },
            { 0xBC, ItemId.MESSAGE_ITEM_NONE },
            { 0xBD, ItemId.MESSAGE_ITEM_NONE },
            { 0xBE, ItemId.MESSAGE_ITEM_NONE },
            { 0xBF, ItemId.MESSAGE_ITEM_NONE },
            { 0xC0, ItemId.MESSAGE_ITEM_NONE },
            { 0xC1, ItemId.MESSAGE_ITEM_NONE },
            { 0xC2, ItemId.MESSAGE_ITEM_NONE },
            { 0xC3, ItemId.MESSAGE_ITEM_NONE },
            { 0xC4, ItemId.MESSAGE_ITEM_NONE },
            { 0xC5, ItemId.MESSAGE_ITEM_NONE },
            { 0xC6, ItemId.MESSAGE_ITEM_NONE },
            { 0xC7, ItemId.MESSAGE_ITEM_NONE },
            { 0xC8, ItemId.ITEM_SONG_SONATA },
            { 0xC9, ItemId.ITEM_SONG_SONATA },
            { 0xCA, ItemId.ITEM_SONG_SONATA },
            { 0xCB, ItemId.ITEM_SONG_LULLABY },
            { 0xCC, ItemId.ITEM_SONG_NOVA },
            { 0xCD, ItemId.ITEM_SONG_ELEGY },
            { 0xCE, ItemId.ITEM_SONG_OATH },
            { 0xCF, ItemId.ITEM_SONG_SARIA },
            { 0xD0, ItemId.ITEM_SONG_TIME },
            { 0xD1, ItemId.ITEM_SONG_HEALING },
            { 0xD2, ItemId.ITEM_SONG_EPONA },
            { 0xD3, ItemId.ITEM_SONG_SOARING },
            { 0xD4, ItemId.ITEM_SONG_STORMS },
            { 0xD5, ItemId.ITEM_SONG_SUN },
            { 0xD6, ItemId.ITEM_SONG_LULLABY },
            { 0xD7, ItemId.ITEM_SONG_SONATA },
            { 0xD8, ItemId.ITEM_SONG_SONATA },
            { 0xD9, ItemId.ITEM_SONG_SONATA },
            { 0xDA, ItemId.ITEM_SONG_LULLABY },
            { 0xDB, ItemId.ITEM_SONG_NOVA },
            { 0xDC, ItemId.ITEM_B8 },
            { 0xDD, ItemId.ITEM_B9 },
            { 0xDE, ItemId.ITEM_BA },
            { 0xDF, ItemId.ITEM_BB },
            { 0xE0, ItemId.ITEM_BC },
            { 0xE1, ItemId.ITEM_BD },
            { 0xE2, ItemId.ITEM_BE },
            { 0xE3, ItemId.ITEM_BF },
            { 0xE4, ItemId.ITEM_C0 },
            { 0xE5, ItemId.ITEM_C1 },
            { 0xE6, ItemId.ITEM_C2 },
            { 0xE7, ItemId.ITEM_C3 },
            { 0xE8, ItemId.ITEM_C4 },
            { 0xE9, ItemId.ITEM_C5 },
            { 0xEA, ItemId.ITEM_C6 },
            { 0xEB, ItemId.ITEM_C7 },
            { 0xEC, ItemId.ITEM_C8 },
            { 0xED, ItemId.ITEM_C9 },
            { 0xEE, ItemId.ITEM_CA },
            { 0xEF, ItemId.ITEM_CB },
            { 0xF0, ItemId.ITEM_CC },
            { 0xF1, ItemId.MESSAGE_ITEM_NONE },
            { 0xF2, ItemId.MESSAGE_ITEM_NONE },
            { 0xF3, ItemId.MESSAGE_ITEM_NONE },
            { 0xF4, ItemId.MESSAGE_ITEM_NONE },
            { 0xF5, ItemId.MESSAGE_ITEM_NONE },
            { 0xF6, ItemId.MESSAGE_ITEM_NONE },
            { 0xF7, ItemId.MESSAGE_ITEM_NONE },
            { 0xF8, ItemId.MESSAGE_ITEM_NONE },
            { 0xF9, ItemId.MESSAGE_ITEM_NONE }
        };

        public static float[] OcarinaFontWidths =
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

        public static float[] MajoraFontWidths =
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
            /* Á*/ 12.0f,
            /* Â*/ 12.0f,
            /* Ä*/ 12.0f,
            /* Ç*/ 11.0f,
            /* È*/ 8.0f,
            /* É*/ 8.0f,
            /* Ê*/ 8.0f,
            /* Ë*/ 8.0f,
            /* Ï*/ 6.0f,
            /* Ì*/ 6.0f,
            /* Î*/ 6.0f,
            /* Ï*/ 6.0f,
            /* Ñ*/ 12.0f,
            /* Ò*/ 13.0f,
            /* Ó*/ 13.0f,
            /* Ô*/ 13.0f,
            /* Ö*/ 13.0f,
            /* Ù*/ 10.0f,
            /* Ú*/ 10.0f,
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
            /* ì*/ 6.0f,
            /* í*/ 6.0f,
            /* î*/ 5.0f,
            /* ï*/ 5.0f,
            /* ñ*/ 10.0f,
            /* ò*/ 9.0f,
            /* ó*/ 9.0f,
            /* ô*/ 9.0f,
            /* ö*/ 9.0f,
            /* ù*/ 9.0f,
            /* ú*/ 9.0f,
            /* û*/ 9.0f,
            /* ü*/ 9.0f,
            /* ¡*/ 6.0f,
            /* ¿*/ 11.0f,
            /* ª*/ 8.0f,

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
                Color.FromArgb(255, 255, 255),   // Default
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

        public static readonly Dictionary<MajoraControlCode, Color[]> MajoraMsgRGB = new Dictionary<MajoraControlCode, Color[]>
        {
            [MajoraControlCode.COLOR_DEFAULT] = new[]
            {
                Color.FromArgb(255, 255, 255),
                Color.FromArgb(255, 255, 255),
                Color.FromArgb(0, 0, 0),
                Color.FromArgb(0, 0, 0),
                Color.FromArgb(0, 0, 0),
            },

            [MajoraControlCode.COLOR_RED] = new[]
            {
                Color.FromArgb(255, 60, 60),
                Color.FromArgb(255, 120, 0),
                Color.FromArgb(255, 60, 60),
                Color.FromArgb(195, 0, 0),
                Color.FromArgb(255, 60, 60),
            },

            [MajoraControlCode.COLOR_GREEN] = new[]
            {
                Color.FromArgb(70, 255, 80),
                Color.FromArgb(70, 255, 80),
                Color.FromArgb(70, 255, 80),
                Color.FromArgb(70, 255, 80),
                Color.FromArgb(110, 170, 255),
            },

            [MajoraControlCode.COLOR_BLUE] = new[]
            {
                Color.FromArgb(80, 90, 255),
                Color.FromArgb(80, 110, 255),
                Color.FromArgb(80, 90, 255),
                Color.FromArgb(80, 90, 255),
                Color.FromArgb(80, 90, 255),
            },

            [MajoraControlCode.COLOR_YELLOW] = new[]
            {
                Color.FromArgb(255, 255, 50),
                Color.FromArgb(255, 255, 30),
                Color.FromArgb(255, 255, 50),
                Color.FromArgb(255, 255, 50),
                Color.FromArgb(255, 255, 50),
            },

            [MajoraControlCode.COLOR_NAVY] = new[]
            {
                Color.FromArgb(80, 150, 255),
                Color.FromArgb(90, 180, 255),
                Color.FromArgb(80, 150, 255),
                Color.FromArgb(80, 150, 255),
                Color.FromArgb(80, 150, 255),
            },

            [MajoraControlCode.COLOR_PINK] = new[]
            {
                Color.FromArgb(255, 150, 180),
                Color.FromArgb(210, 100, 255),
                Color.FromArgb(255, 150, 180),
                Color.FromArgb(255, 150, 180),
                Color.FromArgb(255, 150, 180),
            },

            [MajoraControlCode.COLOR_SILVER] = new[]
            {
                Color.FromArgb(170, 170, 170),
                Color.FromArgb(170, 170, 170),
                Color.FromArgb(170, 170, 170),
                Color.FromArgb(170, 170, 170),
                Color.FromArgb(170, 170, 170),
            },

            [MajoraControlCode.COLOR_ORANGE] = new[]
            {
                Color.FromArgb(255, 130, 30),
                Color.FromArgb(255, 130, 30),
                Color.FromArgb(255, 130, 30),
                Color.FromArgb(255, 130, 30),
                Color.FromArgb(255, 130, 30),
            },
        };

        public static readonly Dictionary<MajoraControlCode, Color> MajoraButtonRGB = new Dictionary<MajoraControlCode, Color>
        {
            [MajoraControlCode.COLOR_RED] = Color.FromArgb(255, 60, 60),
            [MajoraControlCode.COLOR_GREEN] = Color.FromArgb(70, 255, 80),
            [MajoraControlCode.COLOR_BLUE] = Color.FromArgb(80, 90, 255),
            [MajoraControlCode.COLOR_YELLOW] = Color.FromArgb(255, 255, 50),
            [MajoraControlCode.COLOR_NAVY] = Color.FromArgb(80, 150, 255),
            [MajoraControlCode.COLOR_PINK] = Color.FromArgb(255, 150, 180),
            [MajoraControlCode.COLOR_SILVER] = Color.FromArgb(180, 180, 200),
            [MajoraControlCode.COLOR_ORANGE] = Color.FromArgb(255, 130, 30),
        };

        public static readonly Dictionary<MajoraControlCode, MajoraControlCode> MajoraButtonRGBIndexes = new Dictionary<MajoraControlCode, MajoraControlCode>
        {
            [MajoraControlCode.A_BUTTON] = MajoraControlCode.COLOR_BLUE,
            [MajoraControlCode.B_BUTTON] = MajoraControlCode.COLOR_GREEN,
            [MajoraControlCode.C_BUTTON] = MajoraControlCode.COLOR_YELLOW,
            [MajoraControlCode.L_BUTTON] = MajoraControlCode.COLOR_SILVER,
            [MajoraControlCode.R_BUTTON] = MajoraControlCode.COLOR_SILVER,
            [MajoraControlCode.Z_BUTTON] = MajoraControlCode.COLOR_SILVER,
            [MajoraControlCode.C_UP] = MajoraControlCode.COLOR_YELLOW,
            [MajoraControlCode.C_RIGHT] = MajoraControlCode.COLOR_YELLOW,
            [MajoraControlCode.C_LEFT] = MajoraControlCode.COLOR_YELLOW,
            [MajoraControlCode.C_DOWN] = MajoraControlCode.COLOR_YELLOW,
            [MajoraControlCode.TRIANGLE] = MajoraControlCode.COLOR_GREEN,
            [MajoraControlCode.CONTROL_STICK] = MajoraControlCode.COLOR_SILVER,
            [MajoraControlCode.D_PAD] = MajoraControlCode.COLOR_SILVER,     // This does not actually exist in the game data, it's just here for crash prevention.
        };

        public static Dictionary<TextboxType, int> MajoraTypeColorIndexes = new Dictionary<TextboxType, int>()
        {
            {TextboxType.Black,                        0 },
            {TextboxType.Wooden,                       1 },
            {TextboxType.Blue,                         0 },
            {TextboxType.Ocarina,                      0 },
            {TextboxType.None_White,                   0 },
            {TextboxType.None_Black,                   2 },
            {TextboxType.Majora_Black2,                0 },
            {TextboxType.Majora_None,                  0 },
            {TextboxType.Majora_Blue2,                 0 },
            {TextboxType.Majora_Red,                   0 },
            {TextboxType.Majora_None2,                 0 },
            {TextboxType.Credits,                      0 },
            {TextboxType.Majora_None3,                 0 },
            {TextboxType.Majora_Bombers_Notebook,      4 },
            {TextboxType.Majora_None4,                 3 },
            {TextboxType.Majora_Red2,                  0 },

        };

    }
}
