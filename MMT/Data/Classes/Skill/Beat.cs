using System;

namespace MMT.Data.Classes.Skill
{

    //角色技能
    //beat
    class Beat : MSkill
    {
        public Beat()
        {
            name = "Beat"; //技能名称
            points = 1.2f;//伤害倍数
            consumption = 20;//所消耗的对应属性的值
            type = ATTRIBUTE.POWER;//技能类型,仅POWER和MAGIC
            description = "普通b级物理技能，伤害倍数1.2";//技能描述
        }


        public override void Activate(MEnemy enemy)
        {

            //若角色体力不足，返回
            if (MMainCharacter.Instance.Power < consumption)
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
                Attack = MMainCharacter.Instance.Power * points * 2.4;
            }
            else //未命中
            {
                Attack = 0;
            }
            var TakeAttack = Attack - enemy.Armor;
            enemy.HP = enemy.HP - (int)TakeAttack; //这里把伤害转成整型了

            //没有加判断生命值是否小于0的判断
        }
    }

}