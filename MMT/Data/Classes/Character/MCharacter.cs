﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MMT.Data.Classes.Skill;

namespace MMT.Data.Classes.Character
{
    [Serializable]
    abstract class MCharacter
    {
        private String name;     //人物名称。
        private Bitmap image;    //人物使用的图片。
        private byte location_x; //人物所在行数。
        private byte location_y; //人物所在列数。
        private int maxhp;       //最大生命值。
        private int hp;          //当前生命值。
        private int maxmp;       //最大法力值。
        private int mp;          //当前法力值。
        private int maxpower;    //最大力量值
        private int power;       //当前力量值。
        private int armor;       //护甲值。
        private int magicarmor;  //魔抗值。
        private int speed;       //速度。
        private float hitrate;   //命中率。
        private float avoidrate; //闪避率。
        private byte level;      //等级。
        private byte exp;        //经验值。对主角而言，是当前获得的经验值，对敌人而言，是掉落的经验值。
        private List<MSkill> skills;   //技能。

        public String Name { get { return name; } set { name = value; } }
        public Bitmap Image { get { return image; } set { image = value; } }
        public byte Location_X { get { return location_x; } set { location_x = value; } }
        public byte Location_Y { get { return location_y; } set { location_y = value; } }
        public int MaxHP { get { return maxhp; } set { maxhp = value; } }
        public int HP { get { return hp; } set { hp = value; } }
        public int MaxMP { get { return maxmp; } set { maxmp = value; } }
        public int MP { get { return mp; } set { mp = value; } }
        public int MaxPower { get { return maxpower; } set { maxpower = value; } }
        public int Power { get { return power; } set { power = value; } }
        public int Armor { get { return armor; } set { armor = value; } }
        public int MagicArmor { get { return magicarmor; } set { magicarmor = value; } }
        public int Speed { get { return speed; } set { speed= value; } }
        public float HitRate { get { return hitrate; } set { hitrate = value; } }
        public float AvoidRate { get { return avoidrate; } set { avoidrate = value; } }
        public byte Level { get { return level; } set { level = value; } }
        public byte Exp { get { return exp; } set { exp = value; } }
        public List<MSkill> Skills { get { return skills; } }

        //计算攻击产生的伤害。主角可以使用技能攻击。
        public abstract int Attack(MEnemy e, MSkill skill);

        //交互操作。与主角相遇时调用。当主角与人物在同一位置时，才产生交互。
        public abstract void Iteract(MEnemy e);




    }
}
