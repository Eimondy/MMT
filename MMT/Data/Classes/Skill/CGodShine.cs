using System;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Skill
{

    //角色技能
    //beat
    public class CGodShine : MSkill
    {
        public CGodShine()
        {
            Name = "GodShine"; //技能名称
            Points = 2.0f;//伤害倍数
            Consumption = 120;//所消耗的对应属性的值
            Type = ATTRIBUTE.MAGIC;//技能类型,仅POWER和MAGIC
            Description = "S级法术技能，对敌人造成2倍伤害，并降低对手40%魔抗";//技能描述
        }


        public override void Activate(MEnemy enemy)
        {

            //若角色法力不足，返回
            if (MMainCharacter.Instance.Magic < Consumption)
            {
                // Console.WriteLine("法力不够");
                return;
            }
            //生成0-1随机数
            Random rd = new Random();
            double p = rd.NextDouble();
            var Attack = 0.0;
            if (p < MMainCharacter.Instance.HitRate) //命中
            {
                MMainCharacter.Instance.Magic -= 120;
                Attack = MMainCharacter.Instance.Power * Points * 2.4;
                enemy.MagicArmor = enemy.MagicArmor * 60 %; //敌人法抗降低40%
                var TakeAttack = Attack - enemy.MagicArmor;
                enemy.HP = enemy.HP - (int)TakeAttack; //这里把伤害转成整型了
            }
            else //未命中
            {
                return;
            }

            //没有加判断生命值是否小于0的判断
        }
    }

}