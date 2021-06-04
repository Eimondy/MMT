using System;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Skill
{

    //角色技能
    public class OPosion : MSkill
    {
        public OPosion()
        {
            Name = "Posion"; //技能名称
            Points = 1.1f;//伤害倍数
            Consumption = 20;//所消耗的对应属性的值
            Type = ATTRIBUTE.MAGIC;//技能类型,仅POWER和MAGIC
            Description = "普通b级物理技能，伤害倍数1.1";//技能描述
        }


        public override void Activate(MEnemy enemy)
        {

            //若敌人体力不足，返回
            if (enemy.Magic < Consumption)
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
                enemy.Magic -= Consumption;
                //每回合掉血还没写
            }
            else //未命中
            {
                return;
            }

            //没有加判断生命值是否小于0的判断
        }
    }

}