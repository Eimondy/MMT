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
                var Attack = user.MaxPower * Points * COMBAT.ATTACK;
                var TakeAttack = Attack - enemy.Armor * COMBAT.DEFENSE;
                enemy.HP = enemy.HP - (int)TakeAttack; //这里把伤害转成整型了
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

    public class EEvilFluctuation : MSkill
    {
        public EEvilFluctuation()
        {
            Name = "EvilFluctuation";
            Points = 1.2f;
            Consumption = 30;
            Type = ATTRIBUTE.POWER;
            Description = "物理技能，命中后使主角进入疲惫状态，虚弱主角20%力量";
        }
        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            Random rd = new Random();
            double p = rd.NextDouble();
            if (p < user.HitRate)
            {
                enemy.Power -= Convert.ToInt32(enemy.Power * 0.2);
            }
            return true;
        }
    }
    public class EDeadWinding:MSkill
    { 
        public EDeadWinding()
        {
            Name = "DeadWinding";
            Points = 1.2;
            Consumption = 40;
            Type = ATTRIBUTE.MAGIC;
            Description = "法术技能，伤害倍数1.2";
        }
        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            Random rd = new Random();
            double p = rd.NextDouble();
            if (p < user.HitRate)
            {
                var Attack = user.MaxMP * Points * COMBAT.ATTACK;
                var TakeAttack = Attack - enemy.MagicArmor * COMBAT.DEFENSE;
                enemy.HP -= (int)TakeAttack; //这里把伤害转成整型了
            }
            return true;
        }
    }

    //3个Boss的技能全都用B开头命名

    public class BDevilChopper:MSkill
    {
        public BDevilChopper()
        {
            Name = "DevilChopper";
            Points = 1.2;
            Consumption = 80;
            Type = ATTRIBUTE.POWER;
            Description = "骷髅将军专属物理技能，命中后有50%概率进行二次攻击，第二次攻击伤害倍数减为1.1";

        }
        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            Random rd = new Random();
            double p = rd.NextDouble();
            if (p > user.HitRate) return true; 
            //第一次攻击
            var Attack = user.MaxPower * Points * COMBAT.ATTACK;
            var TakeAttack = Attack - enemy.Armor * COMBAT.DEFENSE;
            enemy.HP -= (int)TakeAttack; //这里把伤害转成整型了
            // 1/2的概率进行第二次攻击
            if (p <= 0.5) return true;
            //第二次攻击,新生成一个随机数
            double p2 = rd.NextDouble();
            if (p2 > user.HitRate) return true;
            var SecondAttack = user.MaxPower  * Points * COMBAT.ATTACK;
            var SecondTakeAttack = SecondAttack - enemy.Armor * COMBAT.DEFENSE;
            enemy.HP -= (int)SecondTakeAttack; //这里把伤害转成整型了
            return true;

        }
    }
    public class BSarifice:MSkill
    {
        public BSarifice()
        {
            Name = "Sarifice";
            Points = 1.3;
            Consumption = 50;
            Type = ATTRIBUTE.MAGIC;
            Description = "骷髅将军专属法术技能，伤害倍数1.3";

        }
        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            Random rd = new Random();
            double p = rd.NextDouble();
            if (p < user.HitRate)
            {
                var Attack = user.MaxMP * Points * COMBAT.ATTACK;
                var TakeAttack = Attack - enemy.MagicArmor * COMBAT.DEFENSE;
                enemy.HP -= (int)TakeAttack; //这里把伤害转成整型了
            }
            return true;
        }
    }

    public class BSoulKnife : MSkill
    {
        public BSoulKnife()
        {
            Name = "SoulKnife";
            Points = 1.2;
            Consumption = 50;
            Type = ATTRIBUTE.POWER;
            Description = "大法师专属物理技能，伤害倍数1.2且降低主角40%魔抗";
        }
        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            Random rd = new Random();
            double p = rd.NextDouble();
            if (p < user.HitRate)
            {
                var Attack = user.MaxPower * Points * COMBAT.ATTACK;
                var TakeAttack = Attack - enemy.Armor * COMBAT.DEFENSE;
                enemy.MP -= Convert.ToInt32(enemy.MP * 0.4);
                enemy.HP -= (int)TakeAttack; //这里把伤害转成整型了
            }
            return true;

        }
    }
    public class BSoulGift : MSkill 
    {
        public BSoulGift()
        {
            Name = "SoulGift";
            Points = 1.4;
            Consumption = 125;
            Type = ATTRIBUTE.MAGIC;
            Description = "大法师专属法术技能，伤害倍数1.4，且提高自身100%护甲值";
        }
        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            Random rd = new Random();
            double p = rd.NextDouble();
            if (p < user.HitRate)
            {
                var Attack = user.MaxMP * Points * COMBAT.ATTACK;
                var TakeAttack = Attack - enemy.MagicArmor * COMBAT.DEFENSE;
                user.Armor *= 2;
                enemy.HP -= (int)TakeAttack; //这里把伤害转成整型了
            }
            return true;

        }
    }
    public class BSoulChop : MSkill
    {
        public BSoulChop()
        {
            Name = "SoulChop";
            Points = 1.5;
            Consumption = 200;
            Type = ATTRIBUTE.POWER;
            Description = "魔王专属物理技能，伤害倍数2，同时清楚自身一切负面效果，无视对方一切技能加成";

        }
        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            Random rd = new Random();
            double p = rd.NextDouble();
            if (p < user.HitRate)
            {
                var Attack = user.MaxPower * Points * COMBAT.ATTACK;
                var TakeAttack = Attack - enemy.Armor * COMBAT.DEFENSE;
                enemy.HP -= (int)TakeAttack; //这里把伤害转成整型了

                //无视一切技能加成还未完成
            }
            return true;
        }
    }
    public class BDarkCurse : MSkill
    {
        public BDarkCurse()
        {
            Name = "DarkCurse";
            Points = 1.5;
            Consumption = 200;
            Type = ATTRIBUTE.MAGIC;
            Description = "魔王专属法术技能，伤害倍数2，30%概率打出二次攻击，二次攻击伤害倍数减为1.3";

        }

        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            Random rd = new Random();
            double p = rd.NextDouble();
            if (p > user.HitRate) return true;
            var Attack = user.MaxMP * Points * COMBAT.ATTACK;
            var TakeAttack = Attack - enemy.MagicArmor * COMBAT.DEFENSE;
            enemy.HP -= (int)TakeAttack; //这里把伤害转成整型了

            double p2 = rd.NextDouble();
            if (p2 > 0.33) return true;
            //第二次攻击points变为1.3
            var SecondAttack = user.MaxMP * 1.3 * COMBAT.ATTACK;
            var SecondTakeAttack = Attack - enemy.MagicArmor * COMBAT.DEFENSE;
            enemy.HP -= (int)SecondTakeAttack; //这里把伤害转成整型了
            return true;
        }
    }


}
