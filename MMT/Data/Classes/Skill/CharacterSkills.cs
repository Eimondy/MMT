using System;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Skill
{
    [Serializable]
    public class CBeat : MSkill
    {
        public CBeat():base("拍打")
        {
            Type = ATTRIBUTE.POWER;//技能类型,仅POWER和MAGIC
            Description = "普通b级物理技能，伤害倍数1.2";//技能描述
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
    public class CExtinctRoar : MSkill
    {
        public CExtinctRoar():base("灭生啸")
        {
            Type = ATTRIBUTE.MAGIC;//技能类型,仅POWER和MAGIC
            Description = "普通A级法术技能，对敌人造成1.5倍伤害";//技能描述
        }
        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            Random rd = new Random();
            double p = rd.NextDouble();
            if (p < user.HitRate) //命中
            {
                var Attack = user.MaxMP * Points * COMBAT.ATTACK;
                var TakeAttack = Attack - enemy.MagicArmor * COMBAT.DEFENSE;
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
    public class CFragmentImpact : MSkill
    {
        public CFragmentImpact():base("碎裂撞击")
        {
            Type = ATTRIBUTE.POWER;//技能类型,仅POWER和MAGIC
            Description = "普通A级物理技能，对敌人造成1.5倍伤害";//技能描述
        }
        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
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
    public class CFrustrated : MSkill
    {
        public CFrustrated():base("挫锐")
        {
            Type = ATTRIBUTE.POWER;//技能类型,仅POWER和MAGIC
            Description = "命中敌人可降低敌人4点护甲";//技能描述
        }

        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            //生成0-1随机数
            Random rd = new Random();
            double p = rd.NextDouble();
            if (p < user.HitRate) //命中，敌人护甲-4
            {
                enemy.Armor = enemy.Armor - 4;
                if (enemy.Armor < 0) enemy.Armor = 0;
            }
            else
            {
                Shell.WriteLine(string.Format("{0}的[{1}]未命中！", user.Name, Name));
            }
            return true;
        }
    }

    [Serializable]
    public class CGodShine : MSkill
    {
        public CGodShine():base("千烈虚光闪")
        {
            Type = ATTRIBUTE.MAGIC;//技能类型,仅POWER和MAGIC
            Description = "S级法术技能，对敌人造成2倍伤害，并降低对手40%魔抗";//技能描述
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
                enemy.MagicArmor = Convert.ToInt32(enemy.MagicArmor * 0.6); //敌人法抗降低40%
                var TakeAttack = Attack - enemy.MagicArmor * COMBAT.DEFENSE;
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
    public class CGodStrick : MSkill
    {
        public CGodStrick():base("神谕灭魔击")
        {
            Type = ATTRIBUTE.POWER;//技能类型,仅POWER和MAGIC
            Description = "S级物理技能，对敌人造成2倍伤害，并降低对手40%护甲";//技能描述
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
                enemy.Armor = Convert.ToInt32(enemy.Armor * 0.6); //敌人护甲降低40%
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
    public class CStrongAbsorption : MSkill
    {
        public CStrongAbsorption():base("强力汲取")
        {
            Type = ATTRIBUTE.MAGIC;//技能类型,仅POWER和MAGIC
            Description = "对敌人造成伤害倍数为1.3倍的伤害，同时回复所造成伤害的30%为自己的血量";//技能描述
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
                var Hp = Attack * 0.3;
                var TakeAttack = Attack - enemy.Armor * COMBAT.DEFENSE;
                enemy.HP = enemy.HP - (int)TakeAttack; //这里把伤害转成整型了
                user.HP += Convert.ToInt32(Hp);
                if (user.HP > user.MaxHP)
                    user.HP = user.MaxHP;
            }
            else
            {
                Shell.WriteLine(string.Format("{0}的[{1}]未命中！", user.Name, Name));
            }
            return true;
        }
    }

    [Serializable]
    public class CTreat : MSkill
    {
        public CTreat():base("自愈")
        {
            Type = ATTRIBUTE.MAGIC;//技能类型,仅POWER和MAGIC
            Description = "使用后不对敌方造成伤害，回复自身血量50点";//技能描述
        }

        public override bool Activate(MCharacter user, MCharacter enemy)
        {
            if (!base.Activate(user, enemy)) return false;
            //这边没设置概率值，应该是直接就回复生命，没有概率
            user.HP += 50;
            if (user.HP > user.MaxHP)
                user.HP = user.MaxHP;
            return true;
        }
    }

}
