using System;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Skill
{
    public class CStrongAbsorption:MSkill
    {
        public CStrongAbsorption()
        {
            Name = "StrongAbsorption";
            Points =1.3f 
            Consumption = 60;//所消耗的对应属性的值
            Type = ATTRIBUTE.MAGIC;//技能类型,仅POWER和MAGIC
            Description = "对敌人造成伤害倍数为1.3倍的伤害，同时回复所造成伤害的30%为自己的血量";//技能描述
        }

        public override void Activate(MEnemy enemy)
        {
            if (MMainCharacter.Instance.Magic < Consumption)
            {
                // Console.WriteLine("体力不够");
                return;
            }
            //生成0-1随机数
            Random rd = new Random();
            double p = rd.NextDouble();
            var Attack = 0.0;
            var Hp = 0.0
            if (p < MMainCharacter.Instance.HitRate) //命中
            {
                MMainCharacter.Instance.Power -= 60;
                Attack = MMainCharacter.Instance.Power * Points * 2.4;
                Hp = Attack * 0.3
                var TakeAttack = Attack - enemy.Armor; //伤害-护甲
                enemy.HP = enemy.HP - (int)TakeAttack; //这里把伤害转成整型了
                MMainCharacter.Instance.HP += Hp;
            }
            else //未命中
            {
                Attack = 0;
                Hp = 0;
            }
        }
    }

}