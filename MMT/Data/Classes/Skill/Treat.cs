using System;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Skill
{

    //角色技能
    //Treat
    public class Treat : MSkill
    {
        public Treat()
        {
            Name = "Treat"; //技能名称
            Points = 0.0f;//伤害倍数
            Consumption = 20;//所消耗的对应属性的值
            Type = ATTRIBUTE.MAGIC;//技能类型,仅POWER和MAGIC
            Description = "使用后不对敌方造成伤害，回复自身血量50点";//技能描述
        }


        public override void Activate(MEnemy enemy)
        {

            //若角色法力力不足，返回
            if (MMainCharacter.Instance.Magic < Consumption)
            {
                // Console.WriteLine("法力值不够");
                return;
            }

            MMainCharacter.Instance.Magic -= 20;
            MMainCharacter.Instance.HP += 50;
        }
    }

}