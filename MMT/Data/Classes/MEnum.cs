using System;

namespace MMT.Data.Classes
{
    public enum BLOCKS { WALL = -1, EARTH = 1 }
    public enum ATTRIBUTE { HEALTH, MAGIC, POWER, ARMOR, MAGICARMOR, SPEED, HITRATE }
    public enum EQUIPMENT { WEAPON, GEM, UPPER, SHOES }
    public enum MONSTER { ORDINARY, ELITE, BOSS }
    public enum MAP
    {
        // basics
        ENTER = 0,
        EXIT = 1,
        PATH = 2,
        WALL = 3,
        WIN = 4,

        // enemies 11-50
        GREEN_SLIM = 11,
        RED_SLIM = 12,
        BAT = 13,
        ZOMBIE = 14,
        SKELETON = 15,
        MAGICIAN = 16,
        SKELETON_KNIGHT = 17,
        GARGOYLE = 18,
        SCYTHE_SPIDER = 19,
        SKELETON_GENERAL = 20,
        GRAND_MASTER = 21,
        THE_DEVIL = 22,

        // properties 51-100
        HEALTH_POTION = 51,
        MAGIC_POTION = 52,
        HIT_POTION = 53,
        POWER_POTION = 54,
        ARMOR_POTION = 55,
        MAGIC_ANTIDOTE = 56,
        SPEED_POTION = 57,

        // treasure
        STRAW_SANDALS = 61,
        RUSTY_SWORD = 62,
        ROBE = 63,
        RED_GEM = 64,
        ROTTEN_STAFF = 65,
        SHARP_SWORD = 66,
        ARMOR = 67,
        POWERFUL_STAFF = 68,
        BLUE_GEM = 69,
        LONG_SHOES = 70,
        OVERLORD_ARMOR = 71,
        MERLIN_STAFF = 72,
        EXCALIBUR = 73,
        LEGEND = 74,

        // keys 101-150
        KEY1 = 101,
        KEY2 = 102,
        KEY3 = 103,
        KEY4 = 104,
        KEY5 = 105,
        KEY6 = 106,
        KEY7 = 107,
        KEY8 = 108,
        KEY9 = 109,
        KEY10 = 110,
        KEY11 = 111,
        KEY12 = 112,
        KEY13 = 113,
        KEY14 = 114,

        // doors 151-200
        DOOR1 = 151,
        DOOR2 = 152,
        DOOR3 = 153,
        DOOR4 = 154,
        DOOR5 = 155,
        DOOR6 = 156,
        DOOR7 = 157,
        DOOR8 = 158,
        DOOR9 = 159,
        DOOR10 = 160,
        DOOR11 = 161,
        DOOR12 = 162,
        DOOR13 = 163,
        DOOR14 = 164
    };
    // 判断特殊方块类型
    public static class ConstJudge
    {
        public static bool IsExit(this MAP mapConst)
        {
            return (byte)mapConst == 1 || (byte)mapConst == 0;
        }

        public static bool IsWall(this MAP mapConst)
        {
            return (byte)mapConst == 3;
        }

        public static bool IsEnemy(this MAP mapConst)
        {
            return (byte)mapConst >= 11 && (byte)mapConst <= 50;
        }

        public static bool IsProperty(this MAP mapConst)
        {
            return (byte)mapConst >= 51 && (byte)mapConst <= 100;
        }

        public static bool IsKey(this MAP mapConst)
        {
            return (byte)mapConst >= 101 && (byte)mapConst <= 150;
        }

        public static bool IsDoor(this MAP mapConst)
        {
            return (byte)mapConst >= 151 && (byte)mapConst <= 200;
        }
    }
}
