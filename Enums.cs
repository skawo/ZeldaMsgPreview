using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeldaMsgPreview
{
    public enum TextboxType
    {
        Black = 0,
        Wooden = 1,
        Blue = 2,
        Ocarina = 3,
        None_White = 4,
        None_Black = 5,
        Majora_Black2 = 6,
        Majora_None = 7,
        Majora_Blue2 = 8,
        Majora_Red = 9,
        Majora_None2 = 10,
        Credits = 11,
        Majora_None3 = 12,
        Majora_Bombers_Notebook = 13,
        Majora_None4 = 14,
        Majora_Red2 = 15,
    }

    public enum TextboxPosition
    {
        Dynamic = 0,
        Top = 1,
        Center = 2,
        Bottom = 3,
    }

    public enum Game
    {
        Ocarina = 0,
        Majora = 1,
    }

    public enum OcarinaControlCode
    {
        LINE_BREAK = 0x01,
        END = 0x02,
        NEW_BOX = 0x04,
        COLOR = 0x05,
        SHIFT = 0x06,
        JUMP = 0x07,
        DI = 0x08,
        DC = 0x09,
        PERSISTENT = 0x0A,
        EVENT = 0x0B,
        DELAY = 0x0C,
        AWAIT_BUTTON = 0x0D,
        FADE = 0x0E,
        PLAYER = 0x0F,
        OCARINA = 0x10,
        FADE2 = 0x11,
        SOUND = 0x12,
        ICON = 0x13,
        SPEED = 0x14,
        BACKGROUND = 0x15,
        MARATHON_TIME = 0x16,
        RACE_TIME = 0x17,
        POINTS = 0x18,
        GOLD_SKULLTULAS = 0x19,
        NS = 0x1A,
        TWO_CHOICES = 0x1B,
        THREE_CHOICES = 0x1C,
        FISH_WEIGHT = 0x1D,
        HIGH_SCORE = 0x1E,
        TIME = 0x1F,

        DASH = 0x7F,
        À = 0x80,
        Î = 0x81,
        Â = 0x82,
        Ä = 0x83,
        Ç = 0x84,
        È = 0x85,
        É = 0x86,
        Ê = 0x87,
        Ë = 0x88,
        Ï = 0x89,
        Ô = 0x8A,
        Ö = 0x8B,
        Ù = 0x8C,
        Û = 0x8D,
        Ü = 0x8E,
        ß = 0x8F,
        à = 0x90,
        á = 0x91,
        â = 0x92,
        ä = 0x93,
        ç = 0x94,
        è = 0x95,
        é = 0x96,
        ê = 0x97,
        ë = 0x98,
        ï = 0x99,
        ô = 0x9A,
        ö = 0x9B,
        ù = 0x9C,
        û = 0x9D,
        ü = 0x9E,

        A_BUTTON = 0x9F,
        B_BUTTON = 0xA0,
        C_BUTTON = 0xA1,
        L_BUTTON = 0xA2,
        R_BUTTON = 0xA3,
        Z_BUTTON = 0xA4,
        C_UP = 0xA5,
        C_DOWN = 0xA6,
        C_LEFT = 0xA7,
        C_RIGHT = 0xA8,
        TRIANGLE = 0xA9,
        CONTROL_STICK = 0xAA,
        D_PAD = 0xAB
    }

    public enum MajoraControlCode
    {
        COLOR_DEFAULT = 0x00,
        COLOR_RED = 0x01,
        COLOR_GREEN = 0x02,
        COLOR_BLUE = 0x03,
        COLOR_YELLOW = 0x04,
        COLOR_NAVY = 0x05,
        COLOR_PINK = 0x06,
        COLOR_SILVER = 0x07,
        COLOR_ORANGE = 0x08,
        UNK_09 = 0x09,
        TEXT_SPEED = 0x0A,
        HS_BOAT_ARCHERY = 0x0B,
        STRAY_FAIRIES = 0x0C,
        GOLD_SKULLTULAS = 0x0D,
        POINTS_TENS = 0xE,
        POINTS_THOUSANDS = 0xF,
        NEW_BOX = 0x10,
        LINE_BREAK = 0x11,
        NEW_BOX_CENTER = 0x12,
        CR = 0x13,
        SHIFT = 0x14,
        CONTINUE = 0x15,
        PLAYER = 0x16,
        DI = 0x17,
        DC = 0x18,
        EVENT = 0x19,
        PERSISTENT = 0x1A,
        NEW_BOX_DELAY = 0x1B,
        FADE = 0x1C,
        FADE_SKIPPABLE = 0x1D,
        SOUND = 0x1E,
        DELAY = 0x1F,
        END = 0xBF,
        BACKGROUND = 0xC1,
        TWO_CHOICES = 0xC2,
        THREE_CHOICES = 0xC3,
        TIMER_POSTMAN = 0xC4,
        TIMER_MINIGAME1 = 0xC5,
        TIMER2 = 0xC6,
        TIMER_MOON_CRASH = 0xC7,
        TIMER_MINIGAME2 = 0xC8,
        TIMER_ENV_HAZARD = 0xC9,
        TIME = 0xCA,
        SHOOTING_GALLERY_RESULT = 0xCB,
        BANK_PROMPT = 0xCC,
        RUPEES_ENTERED = 0xCD,
        RUPEES_IN_BANK = 0xCE,
        MOON_CRASH_TIME_REMAINS = 0xCF,
        DOG_RACE_BET_PROMPT = 0xD0,
        BOMBER_CODE_PROMPT = 0xD1,
        ITEM_PROMPT = 0xD2,
        TIME_SPEED = 0xD3,
        SOARING_DESTINATION = 0xD4,
        LOTTERY_NUMBER_PROMPT = 0xD5,
        OCEANSIDE_HOUSE_ORDER = 0xD6,
        WOODFALL_FAIRIES_REMAIN = 0xD7,
        SNOWHEAD_FAIRIES_REMAIN = 0xD8,
        BAY_FAIRIES_REMAIN = 0xD9,
        IKANA_FAIRIES_REMAIN = 0xDA,
        BOAT_ARCHERY_RESULT = 0xDB,
        WINNING_LOTTERY_NUM = 0xDC,
        PLAYER_LOTTERY_NUM = 0xDD,
        ITEM_VALUE = 0xDE,
        BOMBER_CODE = 0xDF,
        EVENT_END = 0xE0,
        OCEANSIDE_HOUSE_ORDER_1 = 0xE1,
        OCEANSIDE_HOUSE_ORDER_2 = 0xE2,
        OCEANSIDE_HOUSE_ORDER_3 = 0xE3,
        OCEANSIDE_HOUSE_ORDER_4 = 0xE4,
        OCEANSIDE_HOUSE_ORDER_5 = 0xE5,
        OCEANSIDE_HOUSE_ORDER_6 = 0xE6,
        MOON_CRASH_HOURS_REMAIN = 0xE7,
        UNTIL_MORNING = 0xE8,
        UNK_E9 = 0xE9,
        UNK_EA = 0xEA,
        UNK_EB = 0xEB,
        UNK_EC = 0xEC,
        UNK_ED = 0xED,
        UNK_EE = 0xEE,
        UNK_EF = 0xEF,
        TOTAL_IN_BANK = 0xF0,
        HS_UNK = 0xF1,
        HS_FISHING = 0xF2,
        HS_TIME_BOAT_ARCHERY = 0xF3,
        HS_TIME_ROMANI_ARCHERY = 0xF4,
        HS_TIME_PLAYER_LOTTERY = 0xF5,
        HS_TOWN_SHOOTING_GALLERY = 0xF6,
        HS_UNK2 = 0xF7,
        HS_UNK3 = 0xF8,
        HS_ROMANI_ARCHERY = 0xF9,
        HS_DEKU_PLAYGROUND_DAY1 = 0xFA,
        HS_DEKU_PLAYGROUND_DAY2 = 0xFB,
        HS_DEKU_PLAYGROUND_DAY3 = 0xFC,
        DEKU_PLAYGROUND_PLAYER_DAY1 = 0xFD,
        DEKU_PLAYGROUND_PLAYER_DAY2 = 0xFE,
        DEKU_PLAYGROUND_PLAYER_DAY3 = 0xFF,


        DASH = 0x7F,
        À = 0x80,
        Á = 0x81,
        Â = 0x82,
        Ä = 0x83,
        Ç = 0x84,
        È = 0x85,
        É = 0x86,
        Ê = 0x87,
        Ë = 0x88,
        Ì = 0x89,
        Í = 0x8A,
        Î = 0x8B,
        Ï = 0x8C,
        Ñ = 0x8D,
        Ò = 0x8E,
        Ó = 0x8F,
        Ô = 0x90,
        Ö = 0x91,
        Ù = 0x92,
        Ú = 0x93,
        Û = 0x94,
        Ü = 0x95,
        ß = 0x96,
        à = 0x97,
        á = 0x98,
        â = 0x99,
        ä = 0x9A,
        ç = 0x9B,
        è = 0x9C,
        é = 0x9D,
        ê = 0x9E,
        ë = 0x9F,
        ì = 0xA0,
        í = 0xA1,
        î = 0xA2,
        ï = 0xA3,
        ñ = 0xA4,
        ò = 0xA5,
        ó = 0xA6,
        ô = 0xA7,
        ö = 0xA8,
        ù = 0xA9,
        ú = 0xAA,
        û = 0xAB,
        ü = 0xAC,
        ª = 0xAF,

        A_BUTTON = 0xB0,
        B_BUTTON = 0xB1,
        C_BUTTON = 0xB2,
        L_BUTTON = 0xB3,
        R_BUTTON = 0xB4,
        Z_BUTTON = 0xB5,
        C_UP = 0xB6,
        C_DOWN = 0xB7,
        C_LEFT = 0xB8,
        C_RIGHT = 0xB9,
        TRIANGLE = 0xBA,
        CONTROL_STICK = 0xBB,
        D_PAD = 0xBC
    }

    public enum MajoraIcon
    {
        GREEN_RUPEE = 1,
        BLUE_RUPEE = 2,
        WHITE_RUPEE = 3,
        RED_RUPEE = 4,
        PURPLE_RUPEE = 5,
        ORANGE_RUPEE = 7,
        ADULT_WALLET = 8,
        GIANTS_WALLET = 9,
        RECOVERY_HEART = 10,
        PIECE_OF_HEART = 12,
        HEART_CONTAINER = 13,
        SMALL_MAGIC_JAR = 14,
        LARGE_MAGIC_JAR = 15,
        STRAY_FAIRY = 17,
        BOMB = 20,
        BOMB_2 = 21,
        BOMB_3 = 22,
        BOMB_4 = 23,
        BOMB_5 = 24,
        DEKU_STICK = 25,
        BOMBCHU = 26,
        BOMB_BAG = 27,
        BIG_BOMB_BAG = 28,
        BIGGER_BOMB_BAG = 29,
        HEROS_BOW = 30,
        HEROS_BOW_1 = 31,
        HEROS_BOW_2 = 32,
        HEROS_BOW_3 = 33,
        QUIVER = 34,
        BIG_QUIVER = 35,
        BIGGEST_QUIVER = 36,
        FIRE_ARROW = 37,
        ICE_ARROW = 38,
        LIGHT_ARROW = 39,
        DEKU_NUT = 40,
        DEKU_NUT_1 = 41,
        DEKU_NUT_2 = 42,
        HEROS_SHIELD = 50,
        MIRROR_SHIELD = 51,
        POWDER_KEG = 52,
        MAGIC_BEAN = 53,
        KOKIRI_SWORD = 55,
        RAZOR_SWORD = 56,
        GILDED_SWORD = 57,
        FIERCE_DEITYS_SWORD = 58,
        GREAT_FAIRYS_SWORD = 59,
        SMALL_KEY = 60,
        BOSS_KEY = 61,
        DUNGEON_MAP = 62,
        COMPASS = 63,
        POWDER_KEG_2 = 64,
        HOOKSHOT = 65,
        LENS_OF_TRUTH = 66,
        PICTOGRAPH_BOX = 67,
        FISHING_ROD = 68,
        OCARINA_OF_TIME = 76,
        BOMBERS_NOTEBOOK = 80,
        GOLD_SKULLTULA_TOKEN = 82,
        ODOLWAS_REMAINS = 85,
        GOHTS_REMAINS = 86,
        GYORGS_REMAINS = 87,
        TWINMOLDS_REMAINS = 88,
        RED_POTION = 89,
        EMPTY_BOTTLE = 90,
        RED_POTION_2 = 91,
        GREEN_POTION = 92,
        BLUE_POTION = 93,
        FAIRYS_SPIRIT = 94,
        DEKU_PRINCESS = 95,
        MILK = 96,
        MILK_HALF = 97,
        FISH = 98,
        BUG = 99,
        BLUE_FIRE = 100,
        POE = 101,
        BIG_POE = 102,
        SPRING_WATER = 103,
        HOT_SPRING_WATER = 104,
        ZORA_EGG = 105,
        GOLD_DUST = 106,
        MUSHROOM = 107,
        SEAHORSE = 110,
        CHATEAU_ROMANI = 111,
        HYLIAN_LOACH = 112,
        DEKU_MASK = 120,
        GORON_MASK = 121,
        ZORA_MASK = 122,
        FIERCE_DEITY_MASK = 123,
        MASK_OF_TRUTH = 124,
        KAFEIS_MASK = 125,
        ALL_NIGHT_MASK = 126,
        BUNNY_HOOD = 127,
        KEATON_MASK = 128,
        GARO_MASK = 129,
        ROMANI_MASK = 130,
        CIRCUS_LEADERS_MASK = 131,
        POSTMANS_HAT = 132,
        COUPLES_MASK = 133,
        GREAT_FAIRYS_MASK = 134,
        GIBDO_MASK = 135,
        DON_GEROS_MASK = 136,
        KAMAROS_MASK = 137,
        CAPTAINS_HAT = 138,
        STONE_MASK = 139,
        BREMEN_MASK = 140,
        BLAST_MASK = 141,
        MASK_OF_SCENTS = 142,
        GIANTS_MASK = 143,
        GOLD_DUST_2 = 147,
        HYLIAN_LOACH_2 = 148,
        SEAHORSE_2 = 149,
        MOONS_TEAR = 150,
        TOWN_TITLE_DEED = 151,
        SWAMP_TITLE_DEED = 152,
        MOUNTAIN_TITLE_DEED = 153,
        OCEAN_TITLE_DEED = 154,
        ROOM_KEY = 160,
        SPECIAL_DELIVERY_TO_MAMA = 161,
        LETTER_TO_KAFEI = 170,
        PENDANT_OF_MEMORIES = 171,
        TINGLES_MAP = 179,
        TINGLES_MAP_2 = 180,
        TINGLES_MAP_3 = 181,
        TINGLES_MAP_4 = 182,
        TINGLES_MAP_5 = 183,
        TINGLES_MAP_6 = 184,
        TINGLES_MAP_7 = 185,
        ANJU = 220,
        KAFEI = 221,
        CURIOSITY_SHOP_OWNER = 222,
        BOMB_SHOP_OWNERS_MOTHER = 223,
        ROMANI = 224,
        CREMIA = 225,
        MAYOR_DOTOUR = 226,
        MADAME_AROMA = 227,
        TOTO = 228,
        GORMAN = 229,
        POSTMAN = 230,
        ROSA_SISTERS = 231,
        TOILET_HAND = 232,
        GRANNY = 233,
        KAMARO = 234,
        GROG = 235,
        GORMAN_BROTHERS = 236,
        SHIRO = 237,
        GURUGURU = 238,
        BOMBERS = 239,
        EXCLAMATION_MARK = 240,
        NO_ICON = 254,
    }

    public enum ItemId
    {
        /* 0x00 */
        ITEM_OCARINA_OF_TIME,
        /* 0x01 */
        ITEM_BOW,
        /* 0x02 */
        ITEM_ARROW_FIRE,
        /* 0x03 */
        ITEM_ARROW_ICE,
        /* 0x04 */
        ITEM_ARROW_LIGHT,
        /* 0x05 */
        ITEM_OCARINA_FAIRY,
        /* 0x06 */
        ITEM_BOMB,
        /* 0x07 */
        ITEM_BOMBCHU,
        /* 0x08 */
        ITEM_DEKU_STICK,
        /* 0x09 */
        ITEM_DEKU_NUT,
        /* 0x0A */
        ITEM_MAGIC_BEANS,
        /* 0x0B */
        ITEM_SLINGSHOT,
        /* 0x0C */
        ITEM_POWDER_KEG,
        /* 0x0D */
        ITEM_PICTOGRAPH_BOX,
        /* 0x0E */
        ITEM_LENS_OF_TRUTH,
        /* 0x0F */
        ITEM_HOOKSHOT,
        /* 0x10 */
        ITEM_SWORD_GREAT_FAIRY,
        /* 0x11 */
        ITEM_LONGSHOT, // OoT Leftover
        /* 0x12 */
        ITEM_BOTTLE,
        /* 0x13 */
        ITEM_POTION_RED,
        /* 0x14 */
        ITEM_POTION_GREEN,
        /* 0x15 */
        ITEM_POTION_BLUE,
        /* 0x16 */
        ITEM_FAIRY,
        /* 0x17 */
        ITEM_DEKU_PRINCESS,
        /* 0x18 */
        ITEM_MILK_BOTTLE,
        /* 0x19 */
        ITEM_MILK_HALF,
        /* 0x1A */
        ITEM_FISH,
        /* 0x1B */
        ITEM_BUG,
        /* 0x1C */
        ITEM_BLUE_FIRE,
        /* 0x1D */
        ITEM_POE,
        /* 0x1E */
        ITEM_BIG_POE,
        /* 0x1F */
        ITEM_SPRING_WATER,
        /* 0x20 */
        ITEM_HOT_SPRING_WATER,
        /* 0x21 */
        ITEM_ZORA_EGG,
        /* 0x22 */
        ITEM_GOLD_DUST,
        /* 0x23 */
        ITEM_MUSHROOM,
        /* 0x24 */
        ITEM_SEAHORSE,
        /* 0x25 */
        ITEM_CHATEAU,
        /* 0x26 */
        ITEM_HYLIAN_LOACH,
        /* 0x27 */
        ITEM_OBABA_DRINK,
        /* 0x28 */
        ITEM_MOONS_TEAR,
        /* 0x29 */
        ITEM_DEED_LAND,
        /* 0x2A */
        ITEM_DEED_SWAMP,
        /* 0x2B */
        ITEM_DEED_MOUNTAIN,
        /* 0x2C */
        ITEM_DEED_OCEAN,
        /* 0x2D */
        ITEM_ROOM_KEY,
        /* 0x2E */
        ITEM_LETTER_MAMA,
        /* 0x2F */
        ITEM_LETTER_TO_KAFEI,
        /* 0x30 */
        ITEM_PENDANT_OF_MEMORIES,
        /* 0x31 */
        ITEM_TINGLE_MAP,
        /* 0x32 */
        ITEM_MASK_DEKU,
        /* 0x33 */
        ITEM_MASK_GORON,
        /* 0x34 */
        ITEM_MASK_ZORA,
        /* 0x35 */
        ITEM_MASK_FIERCE_DEITY,
        /* 0x36 */
        ITEM_MASK_TRUTH,
        /* 0x37 */
        ITEM_MASK_KAFEIS_MASK,
        /* 0x38 */
        ITEM_MASK_ALL_NIGHT,
        /* 0x39 */
        ITEM_MASK_BUNNY,
        /* 0x3A */
        ITEM_MASK_KEATON,
        /* 0x3B */
        ITEM_MASK_GARO,
        /* 0x3C */
        ITEM_MASK_ROMANI,
        /* 0x3D */
        ITEM_MASK_CIRCUS_LEADER,
        /* 0x3E */
        ITEM_MASK_POSTMAN,
        /* 0x3F */
        ITEM_MASK_COUPLE,
        /* 0x40 */
        ITEM_MASK_GREAT_FAIRY,
        /* 0x41 */
        ITEM_MASK_GIBDO,
        /* 0x42 */
        ITEM_MASK_DON_GERO,
        /* 0x43 */
        ITEM_MASK_KAMARO,
        /* 0x44 */
        ITEM_MASK_CAPTAIN,
        /* 0x45 */
        ITEM_MASK_STONE,
        /* 0x46 */
        ITEM_MASK_BREMEN,
        /* 0x47 */
        ITEM_MASK_BLAST,
        /* 0x48 */
        ITEM_MASK_SCENTS,
        /* 0x49 */
        ITEM_MASK_GIANT,
        /* 0x4A */
        ITEM_BOW_FIRE,
        /* 0x4B */
        ITEM_BOW_ICE,
        /* 0x4C */
        ITEM_BOW_LIGHT,
        /* 0x4D */
        ITEM_SWORD_KOKIRI,
        /* 0x4E */
        ITEM_SWORD_RAZOR,
        /* 0x4F */
        ITEM_SWORD_GILDED,
        /* 0x50 */
        ITEM_SWORD_DEITY,
        /* 0x51 */
        ITEM_SHIELD_HERO,
        /* 0x52 */
        ITEM_SHIELD_MIRROR,
        /* 0x53 */
        ITEM_QUIVER_30,
        /* 0x54 */
        ITEM_QUIVER_40,
        /* 0x55 */
        ITEM_QUIVER_50,
        /* 0x56 */
        ITEM_BOMB_BAG_20,
        /* 0x57 */
        ITEM_BOMB_BAG_30,
        /* 0x58 */
        ITEM_BOMB_BAG_40,
        /* 0x59 */
        ITEM_WALLET_DEFAULT,
        /* 0x5A */
        ITEM_WALLET_ADULT,
        /* 0x5B */
        ITEM_WALLET_GIANT,
        /* 0x5C */
        ITEM_FISHING_ROD,
        /* 0x5D */
        ITEM_REMAINS_ODOLWA,
        /* 0x5E */
        ITEM_REMAINS_GOHT,
        /* 0x5F */
        ITEM_REMAINS_GYORG,
        /* 0x60 */
        ITEM_REMAINS_TWINMOLD,
        /* 0x61 */
        ITEM_SONG_SONATA,
        /* 0x62 */
        ITEM_SONG_LULLABY,
        /* 0x63 */
        ITEM_SONG_NOVA,
        /* 0x64 */
        ITEM_SONG_ELEGY,
        /* 0x65 */
        ITEM_SONG_OATH,
        /* 0x66 */
        ITEM_SONG_SARIA,
        /* 0x67 */
        ITEM_SONG_TIME,
        /* 0x68 */
        ITEM_SONG_HEALING,
        /* 0x69 */
        ITEM_SONG_EPONA,
        /* 0x6A */
        ITEM_SONG_SOARING,
        /* 0x6B */
        ITEM_SONG_STORMS,
        /* 0x6C */
        ITEM_SONG_SUN,
        /* 0x6D */
        ITEM_BOMBERS_NOTEBOOK,
        /* 0x6E */
        ITEM_SKULL_TOKEN,
        /* 0x6F */
        ITEM_HEART_CONTAINER,
        /* 0x70 */
        ITEM_HEART_PIECE,
        /* 0x71 */
        ITEM_71,
        /* 0x72 */
        ITEM_72,
        /* 0x73 */
        ITEM_SONG_LULLABY_INTRO,
        /* 0x74 */
        ITEM_KEY_BOSS,
        /* 0x75 */
        ITEM_COMPASS,
        /* 0x76 */
        ITEM_DUNGEON_MAP,
        /* 0x77 */
        ITEM_STRAY_FAIRIES,
        /* 0x78 */
        ITEM_KEY_SMALL,
        /* 0x79 */
        ITEM_MAGIC_JAR_SMALL,
        /* 0x7A */
        ITEM_MAGIC_JAR_BIG,
        /* 0x7B */
        ITEM_HEART_PIECE_2,
        /* 0x7C */
        ITEM_INVALID_1,
        /* 0x7D */
        ITEM_INVALID_2,
        /* 0x7E */
        ITEM_INVALID_3,
        /* 0x7F */
        ITEM_INVALID_4,
        /* 0x80 */
        ITEM_INVALID_5,
        /* 0x81 */
        ITEM_INVALID_6,
        /* 0x82 */
        ITEM_INVALID_7,
        /* 0x83 */
        ITEM_RECOVERY_HEART,
        /* 0x84 */
        ITEM_RUPEE_GREEN,
        /* 0x85 */
        ITEM_RUPEE_BLUE,
        /* 0x86 */
        ITEM_RUPEE_10,
        /* 0x87 */
        ITEM_RUPEE_RED,
        /* 0x88 */
        ITEM_RUPEE_PURPLE,
        /* 0x89 */
        ITEM_RUPEE_SILVER,
        /* 0x8A */
        ITEM_RUPEE_HUGE,
        /* 0x8B */
        ITEM_DEKU_STICKS_5,
        /* 0x8C */
        ITEM_DEKU_STICKS_10,
        /* 0x8D */
        ITEM_DEKU_NUTS_5,
        /* 0x8E */
        ITEM_DEKU_NUTS_10,
        /* 0x8F */
        ITEM_BOMBS_5,
        /* 0x90 */
        ITEM_BOMBS_10,
        /* 0x91 */
        ITEM_BOMBS_20,
        /* 0x92 */
        ITEM_BOMBS_30,
        /* 0x93 */
        ITEM_ARROWS_10,
        /* 0x94 */
        ITEM_ARROWS_30,
        /* 0x95 */
        ITEM_ARROWS_40,
        /* 0x96 */
        ITEM_ARROWS_50,
        /* 0x97 */
        ITEM_BOMBCHUS_20,
        /* 0x98 */
        ITEM_BOMBCHUS_10,
        /* 0x99 */
        ITEM_BOMBCHUS_1,
        /* 0x9A */
        ITEM_BOMBCHUS_5,
        /* 0x9B */
        ITEM_DEKU_STICK_UPGRADE_20,
        /* 0x9C */
        ITEM_DEKU_STICK_UPGRADE_30,
        /* 0x9D */
        ITEM_DEKU_NUT_UPGRADE_30,
        /* 0x9E */
        ITEM_DEKU_NUT_UPGRADE_40,
        /* 0x9F */
        ITEM_CHATEAU_2,
        /* 0xA0 */
        ITEM_MILK,
        /* 0xA1 */
        ITEM_GOLD_DUST_2,
        /* 0xA2 */
        ITEM_HYLIAN_LOACH_2,
        /* 0xA3 */
        ITEM_SEAHORSE_CAUGHT,

        // First entries of MAP_POINT must be contiguous with RegionId
        /* 0xA4 */
        ITEM_MAP_POINT_GREAT_BAY,
        /* 0xA5 */
        ITEM_MAP_POINT_ZORA_HALL,
        /* 0xA6 */
        ITEM_MAP_POINT_ROMANI_RANCH,
        /* 0xA7 */
        ITEM_MAP_POINT_DEKU_PALACE,
        /* 0xA8 */
        ITEM_MAP_POINT_WOODFALL,
        /* 0xA9 */
        ITEM_MAP_POINT_CLOCK_TOWN,
        /* 0xAA */
        ITEM_MAP_POINT_SNOWHEAD,
        /* 0xAB */
        ITEM_MAP_POINT_IKANA_GRAVEYARD,
        /* 0xAC */
        ITEM_MAP_POINT_IKANA_CANYON,
        /* 0xAD */
        ITEM_MAP_POINT_GORON_VILLAGE,
        /* 0xAE */
        ITEM_MAP_POINT_STONE_TOWER,
        // Remaining map points are unique to owl warps
        /* 0xAF */
        ITEM_MAP_POINT_GREAT_BAY_COAST,
        /* 0xB0 */
        ITEM_MAP_POINT_SOUTHERN_SWAMP,
        /* 0xB1 */
        ITEM_MAP_POINT_MOUNTAIN_VILLAGE,
        /* 0xB2 */
        ITEM_MAP_POINT_MILK_ROAD,
        /* 0xB3 */
        ITEM_MAP_POINT_ZORA_CAPE,

        /* 0xB8 */
        ITEM_B8 = 0xB8,
        /* 0xB9 */
        ITEM_B9,
        /* 0xBA */
        ITEM_BA,
        /* 0xBB */
        ITEM_BB,
        /* 0xBC */
        ITEM_BC,
        /* 0xBD */
        ITEM_BD,
        /* 0xBE */
        ITEM_BE,
        /* 0xBF */
        ITEM_BF,
        /* 0xC0 */
        ITEM_C0,
        /* 0xC1 */
        ITEM_C1,
        /* 0xC2 */
        ITEM_C2,
        /* 0xC3 */
        ITEM_C3,
        /* 0xC4 */
        ITEM_C4,
        /* 0xC5 */
        ITEM_C5,
        /* 0xC6 */
        ITEM_C6,
        /* 0xC7 */
        ITEM_C7,
        /* 0xC8 */
        ITEM_C8,
        /* 0xC9 */
        ITEM_C9,
        /* 0xCA */
        ITEM_CA,
        /* 0xCB */
        ITEM_CB,
        /* 0xCC */
        ITEM_CC,

        /* 0xF0 */
        ITEM_F0 = 0xF0, // PLAYER_MASK_BLAST
        /* 0xF1 */
        ITEM_F1,        // PLAYER_MASK_BREMEN
        /* 0xF2 */
        ITEM_F2,        // PLAYER_MASK_KAMARO
        /* 0xFC */
        ITEM_FC = 0xFC,
        /* 0xFD */
        ITEM_FD,
        /* 0xFE */
        ITEM_FE,
        /* 0xFF */
        ITEM_NONE = 0xFF,

        MESSAGE_ITEM_NONE = 9999
    }


    

    public enum OcarinaMsgColor
    {
        DEFAULT = 0x40,
        RED = 0x41,
        GREEN = 0x42,
        BLUE = 0x43,
        CYAN = 0x44,
        MAGENTA = 0x45,
        YELLOW = 0x46,
        BLACK = 0x47
    };

    public enum OcarinaHighScore
    {
        ARCHERY = 0x00,
        POE_POINTS = 0x01,
        FISHING = 0x02,
        HORSE_RACE = 0x03,
        MARATHON = 0x04,
        HS_UNK = 0x05,
        DAMPE_RACE = 0x06
    }

    public enum EndingGraphics
    {
        None,
        Triangle,
        Square,
        Choice
    }

}
