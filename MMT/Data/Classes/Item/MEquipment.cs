﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Data.Classes.Item
{
    abstract class MEquipment
    {
        private EQUIPMENT type;//装备类型
        private int power;//力量增值
        private int magic;//法力增值
        private int armor;//护甲增值
        private int magicArmor;//魔抗增值
        private int speed;//速度增值
        private float hitRate;//命中率增值
        public EQUIPMENT Type { get => type; set => type = value; }
        public int Power { get => power; set => power = value; }
        public int Magic { get => magic; set => magic = value; }
        public int Armor { get => armor; set => armor = value; }
        public int MagicArmor { get => magicArmor; set => magicArmor = value; }
        public int Speed { get => speed; set => speed = value; }
        public float HitRate { get => hitRate; set => hitRate = value; }
        //安装装备，增加属性
        public abstract void Equip();
        //卸下装备，减少属性
        public abstract void Unequip();
        //构造方法
        public MEquipment(EQUIPMENT type,int power, int magic, int armor, int magicArmor, int speed, int hitRate)
        {
            Type = type;
            Power = power;
            Magic = magic;
            Armor = armor;
            MagicArmor = magicArmor;
            Speed = speed;
            HitRate = hitRate;
        }
    }
}