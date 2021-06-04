using System;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Skill
{

    //角色技能
    //beat
    public class CFrustrated : MSkill
    {
        public CFrustrated()
        {
            Name = "Frustrated"; //技能名称
            Points = 1.0f;//伤害倍数
            Consumption = 20;//所消耗的对应属性的值
            Type = ATTRIBUTE.POWER;//技能类型,仅POWER和MAGIC
            Description = "命中敌人可降低敌人4点护甲";//技能描述
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
            if (p < MMainCharacter.Instance.HitRate) //命中，敌人护甲-4
            {
                MMainCharacter.Instance.Power -= 20;
                enemy.Armar = enemy.Armar - 4;
            }
            else //未命中
            {
                return
            }
            

            //没有加判断生命值是否小于0的判断
        }
    }

}