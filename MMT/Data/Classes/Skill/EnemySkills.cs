using System;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Skill
{
    [Serializable]
    public class OAttack : MSkill
    {
        public OAttack():base("暗算")
        {
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
            else
            {
                Shell.WriteLine(string.Format("{0}的[{1}]未命中！", user.Name, Name));
            }
            return true;
        }
    }

    [Serializable]
    public class OPosion : MSkill
    {
        public OPosion():base("毒物")
        {
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
                enemy.HP -= Consumption;
                //每回合掉血还没写
            }
            else
            {
                Shell.WriteLine(string.Format("{0}的[{1}]未命中！", user.Name, Name));
            }
            return true;
        }
    }

    [Serializable]
    public class EEvilFluctuation : MSkill
    {
        public EEvilFluctuation():base("恶之波动")
        {
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
            else
            {
                Shell.WriteLine(string.Format("{0}的[{1}]未命中！", user.Name, Name));
            }
            return true;
        }
    }

    [Serializable]
    public class EDeadWinding:MSkill
    { 
        public EDeadWinding():base("死亡缠绕")
        {
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
            else
            {
                Shell.WriteLine(string.Format("{0}的[{1}]未命中！", user.Name, Name));
            }
            return true;
        }
    }

    //3个Boss的技能全都用B开头命名
    [Serializable]
    public class BDevilChopper:MSkill
    {
        public BDevilChopper():base("恶魔斩")
        {
            Type = ATTRIBUTE.POWER;
            Description = "骷髅将军专属物理技能，命中后有50%概率进行二次攻击，第二次攻击伤害倍数减为1.1";

        }
        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            Random rd = new Random();
            double p = rd.NextDouble();
            if (p > user.HitRate)
            {
                Shell.WriteLine(string.Format("{0}的[{1}]未命中！", user.Name, Name));
                return true;
            }
            //第一次攻击
            var Attack = user.MaxPower * Points * COMBAT.ATTACK;
            var TakeAttack = Attack - enemy.Armor * COMBAT.DEFENSE;
            enemy.HP -= (int)TakeAttack; //这里把伤害转成整型了
            // 1/2的概率进行第二次攻击
            p = rd.NextDouble();
            if (p <= 0.5) return true;
            //第二次攻击,新生成一个随机数
            p = rd.NextDouble();
            if (p > user.HitRate) return true;
            var SecondAttack = user.MaxPower  * Points * COMBAT.ATTACK;
            var SecondTakeAttack = SecondAttack - enemy.Armor * COMBAT.DEFENSE;
            enemy.HP -= (int)SecondTakeAttack; //这里把伤害转成整型了
            return true;

        }
    }

    [Serializable]
    public class BSarifice:MSkill
    {
        public BSarifice():base("献祭")
        {
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
            else
            {
                Shell.WriteLine(string.Format("{0}的[{1}]未命中！", user.Name, Name));
            }
            return true;
        }
    }

    [Serializable]
    public class BSoulKnife : MSkill
    {
        public BSoulKnife():base("切裂魂刀")
        {
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
            else
            {
                Shell.WriteLine(string.Format("{0}的[{1}]未命中！", user.Name, Name));
            }
            return true;

        }
    }

    [Serializable]
    public class BSoulGift : MSkill 
    {
        public BSoulGift():base("亡魂之赐")
        {
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
            else
            {
                Shell.WriteLine(string.Format("{0}的[{1}]未命中！", user.Name, Name));
            }
            return true;

        }
    }

    [Serializable]
    public class BSoulChop : MSkill
    {
        public BSoulChop():base("九魂灭天斩")
        {
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
            else
            {
                Shell.WriteLine(string.Format("{0}的[{1}]未命中！", user.Name, Name));
            }
            return true;
        }
    }

    [Serializable]
    public class BDarkCurse : MSkill
    {
        public BDarkCurse():base("暗灵寂灭咒")
        {
            Type = ATTRIBUTE.MAGIC;
            Description = "魔王专属法术技能，伤害倍数2，30%概率打出二次攻击，二次攻击伤害倍数减为1.3";

        }

        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            Random rd = new Random();
            double p = rd.NextDouble();
            if (p > user.HitRate)
            {
                Shell.WriteLine(string.Format("{0}的[{1}]未命中！", user.Name, Name));
                return true;
            }
            var Attack = user.MaxMP * Points * COMBAT.ATTACK;
            var TakeAttack = Attack - enemy.MagicArmor * COMBAT.DEFENSE;
            enemy.HP -= (int)TakeAttack; //这里把伤害转成整型了

            p= rd.NextDouble();
            if (p > 0.33) return true;
            //第二次攻击points变为1.3
            var SecondAttack = user.MaxMP * 1.3 * COMBAT.ATTACK;
            var SecondTakeAttack = Attack - enemy.MagicArmor * COMBAT.DEFENSE;
            enemy.HP -= (int)SecondTakeAttack; //这里把伤害转成整型了
            return true;
        }
    }
}
