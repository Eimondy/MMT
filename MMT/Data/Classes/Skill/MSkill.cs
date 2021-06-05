using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Skill
{
    [Serializable]
    public static class COMBAT
    {
        public static double ATTACK = 2.4;
        public static double DEFENSE = 1.2;
    }
    [Serializable]
    public abstract class MSkill
    {
        private string name; //技能名称
        private double points;//伤害倍数
        private int consumption;//所消耗的对应属性的值
        private ATTRIBUTE type;//技能类型,仅POWER和MAGIC
        private string description;//技能描述

        public string Name { get => name; set => name = value; }
        public double Points { get => points; set => points = value; }
        public int Consumption { get => consumption; set => consumption = value; }
        internal ATTRIBUTE Type { get => type; set => type = value; }
        public string Description { get => description; set => description = value; }

        //技能使用
       public virtual bool Activate(MCharacter user, MCharacter enemy)
        {
            // 若可以使用技能，则减少相应的HP/Power
            if (Type == ATTRIBUTE.POWER)
                if (user.Power < Consumption)
                    return false;
                else
                {
                    user.Power -= Consumption;
                    return true;
                }
            else
                if (user.MP < Consumption)
                    return false;
                else
                {
                    user.MP -= Consumption;
                    return true;
                }
        }

        //构造方法
        public MSkill()
        {
        }
    }
}
