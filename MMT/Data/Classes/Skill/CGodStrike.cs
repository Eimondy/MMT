using System;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Skill
{

    //角色技能
    //beat
    public class CGodStrick : MSkill
    {
        public CGodStrick()
        {
            Name = "GodStrick"; //技能名称
            Points = 2.0f;//伤害倍数
            Consumption = 120;//所消耗的对应属性的值
            Type = ATTRIBUTE.POWER;//技能类型,仅POWER和MAGIC
            Description = "S级物理技能，对敌人造成2倍伤害，并降低对手40%护甲";//技能描述
        }


        public override void Activate(MEnemy enemy)
        {

            //若角色体力不足，返回
            if (MMainCharacter.Instance.Power < Consumption)
            {
                // Console.WriteLine("体力不够");
                return;
            }
            //生成0-1随机数
            Random rd = new Random();
            double p = rd.NextDouble();
            var Attack = 0.0;
            if (p < MMainCharacter.Instance.HitRate) //命中
            {
                MMainCharacter.Instance.Power -= 120;
                Attack = MMainCharacter.Instance.Power * Points * 2.4;
                enemy.Armor = enemy.Armor * 60 %; //敌人护甲降低40%
                var TakeAttack = Attack - enemy.Armor;
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
