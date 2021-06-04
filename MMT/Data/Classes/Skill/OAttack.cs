using System;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Skill
{

    //角色技能
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


        public override void Activate(MEnemy enemy)
        {

            //若敌人体力不足，返回
            if (enemy.Power < Consumption)
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
                enemy.Power -= Consumption;
                Attack = enemy.Power * Points * 2.4;
                var TakeAttack = Attack - MMainCharacter.Instance.Armor;
                MMainCharacter.Instance.HP = MMainCharacter.Instance.HP - (int)TakeAttack; //这里把伤害转成整型了
            }
            else //未命中
            {
                return;
            }

            //没有加判断生命值是否小于0的判断
        }
    }

}