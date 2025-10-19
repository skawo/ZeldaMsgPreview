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
        Square
    }

}
