using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMT.Data.Classes.Skill;
using MMT.Data.Classes;


namespace MMT.Data.Classes.Character
{

    public class MEnemy : MCharacter
    {
        private MONSTER monstertype; //敌人类型
        private string description; //描述
        public string Description { get { return Description; } set { description = value; } }
        public MONSTER MonsterType { get { return monstertype; } set { monstertype = value; } }
        //敌人的攻击
        public override void Attack(MEnemy e, MSkill skill)
        {
            if (skill == null)     // 普攻
            {
                double Attack = Power * 2.4;
                int TakeAttack = Convert.ToInt32(Attack - MMainCharacter.Instance.Armor * 1.2);
                MMainCharacter.Instance.HP -= TakeAttack;

            }
            else     // 直接使用技能
            {
                skill.Activate(e);
            }
        }
    }
    class GreenSlim : MEnemy
    {
        //默认构造函数
        GreenSlim()
        {
            MonsterType = MONSTER.ORDINARY;
            MaxHP = HP = 24;
            MaxMP = MP = 0;
            MaxPower = Power = 16;
            Armor = 1;
            MagicArmor = 0;
            Speed = 0;
            HitRate = 0.6;
            AvoidRate = 0.9;
            Exp = 1;
            Description = "迷宫中随处可见的小型生物，只有低级智能";

            //暂时还未加入技能
        }
    }

    class RedSlim : MEnemy
    {
        //默认构造函数
        RedSlim()
        {
            MonsterType = MONSTER.ORDINARY;
            MaxHP = HP = 35;
            MaxMP = MP = 0;
            MaxPower = Power = 18;
            Armor = 4;
            MagicArmor = 0;
            Speed = 0;
            HitRate = 0.7;
            AvoidRate = 0.9;
            Exp = 2;
            Description = "小型生物在魔塔魔气影响下发生的变异，比原来更强大";

            //暂时还未加入技能
        }
    }

    class Bat : MEnemy
    {
        //默认构造函数
        Bat()
        {
            MonsterType = MONSTER.ORDINARY;
            MaxHP = HP = 49;
            MaxMP = MP = 10;
            MaxPower = Power = 28;
            Armor = 2;
            MagicArmor = 2;
            Speed = 4;
            HitRate = 0.75;
            AvoidRate = 0.8;
            Exp = 3;
            Description = "倒悬在魔塔层顶的魔化生物，具有较快的敏捷，较难被击中";

            //暂时还未加入技能
        }
    }

    class Zombie : MEnemy
    {
        //默认构造函数
        Zombie()
        {
            MonsterType = MONSTER.ORDINARY;
            MaxHP = HP = 100;
            MaxMP = MP = 50;
            MaxPower = Power = 68;
            Armor = 30;
            MagicArmor = 20;
            Speed = 2;
            HitRate = 0.8;
            AvoidRate = 0.85;
            Exp = 5;
            Description = "游荡在魔塔中的类人型魔物，具有高防御，在获得强力武器之前，主角难以抗衡";

            //暂时还未加入技能
        }
    }

    class Skeleton : MEnemy
    {
        //默认构造函数
        Skeleton()
        {
            MonsterType = MONSTER.ORDINARY;
            MaxHP = HP = 120;
            MaxMP = MP = 20;
            MaxPower = Power = 85;
            Armor = 0;
            MagicArmor = 0;
            Speed = 3;
            HitRate = 0.85;
            AvoidRate = 0.9;
            Exp = 5;
            Description = "游荡在魔塔中的类人型魔物，具有极高的攻击，在获得强力防具之前，主角难以抗衡";

            //暂时还未加入技能
        }
    }

    class Magician : MEnemy
    {
        //默认构造函数
        Magician()
        {
            MonsterType = MONSTER.ELITE;
            MaxHP = HP = 70;
            MaxMP = MP = 100;
            MaxPower = Power = 20;
            Armor = 10;
            MagicArmor = 60;
            Speed = 1;
            HitRate = 0.9;
            AvoidRate = 0.8;
            Exp = 6;
            Description = "曾经是进入魔塔挑战的法师，失败之后，被魔气魔化，成为邪恶的魔法恶鬼";

            //暂时还未加入技能
        }
    }

    class SkeletonKnight : MEnemy
    {
        //默认构造函数
        SkeletonKnight()
        {
            MonsterType = MONSTER.ELITE;
            MaxHP = HP = 200;
            MaxMP = MP = 80;
            MaxPower = Power = 110;
            Armor = 40;
            MagicArmor = 30;
            Speed = 4;
            HitRate = 0.9;
            AvoidRate = 0.85;
            Exp = 7;
            Description = "曾经是进入魔塔挑战的骑士，失败之后，被魔气魔化，成为凶残的骷髅骑士";

            //暂时还未加入技能
        }
    }

    class Gargoyle : MEnemy
    {
        //默认构造函数
        Gargoyle()
        {
            MonsterType = MONSTER.ELITE;
            MaxHP = HP = 500;
            MaxMP = MP = 20;
            MaxPower = Power = 30;
            Armor = 50;
            MagicArmor = 30;
            Speed = 3;
            HitRate = 0.9;
            AvoidRate = 0.8;
            Exp = 5;
            Description = "常常出现在密室门口，具有很高的血量，护甲值，魔抗值。说不定在它身后的密室里存在着什么好东西……";

            //暂时还未加入技能
        }
    }

    class ScytheSpider : MEnemy
    {
        //默认构造函数
        ScytheSpider()
        {
            MonsterType = MONSTER.ELITE;
            MaxHP = HP = 150;
            MaxMP = MP = 50;
            MaxPower = Power = 95;
            Armor = 30;
            MagicArmor = 5;
            Speed = 7;
            HitRate = 0.95;
            AvoidRate = 0.75;
            Exp = 6;
            Description = "出现在魔塔中的蜘蛛形怪物，具有很高的攻击力，敏捷值，使用魔法攻击说不定不是个好方法";

            //暂时还未加入技能
        }
    }

    class SkeletonGeneral : MEnemy
    {
        //默认构造函数
        SkeletonGeneral()
        {
            MonsterType = MONSTER.BOSS;
            MaxHP = HP = 300;
            MaxMP = MP = 50;
            MaxPower = Power = 80;
            Armor = 40;
            MagicArmor = 30;
            Speed = 4;
            HitRate = 0.9;
            AvoidRate = 0.7;
            Exp = 10;
            Description = "魔塔前几层的Boss,具有很强的综合属性，稍不注意就会葬送在它的魔刀下";

            //暂时还未加入技能
        }
    }

    class GrandMaster : MEnemy
    {
        //默认构造函数
        GrandMaster()
        {
            MonsterType = MONSTER.BOSS;
            MaxHP = HP = 800;
            MaxMP = MP = 250;
            MaxPower = Power = 50;
            Armor = 30;
            MagicArmor = 40;
            Speed = 10;
            HitRate = 0.9;
            AvoidRate = 0.6;
            Exp = 20;
            Description = "魔塔中层出现的Boss,精通魔法，具有很强的魔法攻击";

            //暂时还未加入技能
        }
    }

    class TheDevil : MEnemy
    {
        //默认构造函数
        TheDevil()
        {
            MonsterType = MONSTER.BOSS;
            MaxHP = HP = 1500;
            MaxMP = MP = 200;
            MaxPower = Power = 200;
            Armor = 100;
            MagicArmor = 100;
            Speed = 15;
            HitRate = 1;
            AvoidRate = 0.5;
            Exp = 0;
            Description = "魔塔最终boss，曾是拯救世人的勇者，但是在魔塔中失去本性，最终化为黑暗的傀儡。魔塔的化身。";

            //暂时还未加入技能
        }
    }
}