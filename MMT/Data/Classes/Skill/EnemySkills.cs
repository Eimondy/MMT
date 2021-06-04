using System;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Skill
{
    public class OAttack : MSkill
    {
        public OAttack()
        {
            Name = "Attack"; //技能名称
            Points = 1.1f;//伤害倍数
            Consumption = 15;//所消耗的对应属性的值
            Type = ATTRIBUTE.POWER;//技能类型,仅POWER和MAGIC
            Description = "普通b级物理技能，伤害倍数1.1";//技能描述
        }

        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            //生成0-1随机数
            Random rd = new Random();
            double p = rd.NextDouble();
            if (p < user.HitRate) //命中
            {
                var Attack = enemy.Power * Points * COMBAT.ATTACK;
                var TakeAttack = Attack - user.Armor * COMBAT.DEFENSE;
                user.HP = user.HP - (int)TakeAttack; //这里把伤害转成整型了
            }
            return true;
        }
    }

    public class OPosion : MSkill
    {
        public OPosion()
        {
            Name = "Posion"; //技能名称
            Points = 1.1f;//伤害倍数
            Consumption = 20;//所消耗的对应属性的值
            Type = ATTRIBUTE.MAGIC;//技能类型,仅POWER和MAGIC
            Description = "法术技能，命中后使主角进入中毒状态，每回合持续掉血10点，持续两回合";//技能描述
        }


        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            //生成0-1随机数
            Random rd = new Random();
            double p = rd.NextDouble();
            if (p < user.HitRate) //命中
            {
                enemy.MP -= Consumption;
                //每回合掉血还没写
            }
            return true;
        }
    }
}
