using System;
using System.Linq;
using System.Collections.Generic;
using MMT.Data.Classes.Skill;
using MMT.Data.Classes;


namespace MMT.Data.Classes.Character
{
    [Serializable]
    public class MEnemy : MCharacter
    {
        private MONSTER monstertype; //敌人类型
        private string description; //描述
        public string Description { get { return description; } set { description = value; } }
        public MONSTER MonsterType { get { return monstertype; } set { monstertype = value; } }
        //敌人位置的初始化
        public MEnemy(byte x,byte y, string n="")
        {
            LocationX = x;
            LocationY = y;
            Name = n;
            
            var info = MMainLogic.Instance.Data["Character"].Where(s => s.Split(',')[0] == Name);

            foreach (var i in info)
            {
                var s = i.Split(',');
                MaxHP = HP = Convert.ToInt32(s[1]);
                MaxMP = MP = Convert.ToInt32(s[2]);
                MaxPower = Power = Convert.ToInt32(s[3]);
                Armor = Convert.ToInt32(s[4]);
                MagicArmor = Convert.ToInt32(s[5]);
                Speed = Convert.ToDouble(s[6]);
                HitRate = Convert.ToDouble(s[7]);
                AvoidRate = Convert.ToDouble(s[8]);
                Exp = Convert.ToByte(s[9]);
            }
        }
    }

    [Serializable]
    public class GreenSlim : MEnemy
    {
        //构造函数

        public GreenSlim(byte x,byte y) : base(x, y, "绿色史莱姆")
        {
            Image = Properties.Resources.Img_char_GreenSlim;     
            MonsterType = MONSTER.ORDINARY;
            Description = "迷宫中随处可见的小型生物，只有低级智能";

            //绿色史莱姆只装备了Oattack;
            Skills = new List<MSkill>()
            {
                new OAttack()
            };
        }
    }

    [Serializable]
    public class RedSlim : MEnemy
    {
        //构造函数
        public RedSlim(byte x,byte y) : base(x, y,"红色史莱姆")
        {

            Image = Properties.Resources.Img_char_RedSlim;     
            MonsterType = MONSTER.ORDINARY;
            Description = "小型生物在魔塔魔气影响下发生的变异，比原来更强大";

            //红色史莱姆添加了OAttack和OPosion;
            Skills = new List<MSkill>()
            {
                new OAttack(), new OPosion()
            };
        }
    }

    [Serializable]
    public class Bat : MEnemy
    {
        //构造函数
        public Bat(byte x,byte y) : base(x, y, "蝙蝠怪")
        {

            Image = Properties.Resources.Img_char_Bat;     
            MonsterType = MONSTER.ORDINARY;
            Description = "倒悬在魔塔层顶的魔化生物，具有较快的敏捷，较难被击中";

            //蝙蝠怪添加了OAttack和OPosion;
            Skills = new List<MSkill>()
            {
                new OAttack(), new OPosion()
            };
        }
    }

    [Serializable]
    public class Zombie : MEnemy
    {
        //构造函数
        public Zombie(byte x,byte y) : base(x, y,"丧尸怪")
        {

            Image = Properties.Resources.Img_char_Zombie;    
            MonsterType = MONSTER.ORDINARY;
            Description = "游荡在魔塔中的类人型魔物，具有高防御，在获得强力武器之前，主角难以抗衡";

            //僵尸怪添加了OAttack和OPosion;
            Skills = new List<MSkill>()
            {
                new OAttack(), new OPosion()
            };
        }
    }

    [Serializable]
    public class Skeleton : MEnemy
    {
        //构造函数
        public Skeleton(byte x,byte y) : base(x, y, "骷髅怪")
        {

            Image = Properties.Resources.Img_char_Skeleton;     
            MonsterType = MONSTER.ORDINARY;
            Description = "游荡在魔塔中的类人型魔物，具有极高的攻击，在获得强力防具之前，主角难以抗衡";

            //骷髅怪只添加了OAttack
            Skills = new List<MSkill>()
            {
                new OAttack()
            };
        }
    }

    [Serializable]
    public class Magician : MEnemy
    {
        //构造函数
        public Magician(byte x ,byte y) : base(x, y, "魔法师")
        {

            Image = Properties.Resources.Img_char_Magician;     
            MonsterType = MONSTER.ELITE;
            Description = "曾经是进入魔塔挑战的法师，失败之后，被魔气魔化，成为邪恶的魔法恶鬼";

            //魔法师添加了OAttack，OPosion，EEvilFluctuation
            Skills = new List<MSkill>()
            {
                new OAttack(), new OPosion(), new EEvilFluctuation()
            };
        }
    }

    [Serializable]
    public class SkeletonKnight : MEnemy
    {
        //构造函数
        public SkeletonKnight(byte x,byte y) : base(x, y, "骷髅骑士")
        {

            Image = Properties.Resources.Img_char_SkeletonKnight;     
            MonsterType = MONSTER.ELITE;
            Description = "曾经是进入魔塔挑战的骑士，失败之后，被魔气魔化，成为凶残的骷髅骑士";

            //骷髅骑士添加了OAttack，OPosion，EEvilFluctuation,EDeadWinding
            Skills = new List<MSkill>()
            {
                new OAttack(), new OPosion(), new EEvilFluctuation(), new EDeadWinding()
            };
        }
    }

    [Serializable]
    public class Gargoyle : MEnemy
    {
        //构造函数
        public Gargoyle(byte x,byte y) : base(x, y, "石像鬼")
        {

            Image = Properties.Resources.Img_char_Gargoyle;     
            MonsterType = MONSTER.ELITE;
            Description = "常常出现在密室门口，具有很高的血量，护甲值，魔抗值。说不定在它身后的密室里存在着什么好东西……";

            //石像鬼添加了OAttack，EEvilFluctuation,EDeadWinding
            Skills = new List<MSkill>()
            {
                new OAttack(), new EEvilFluctuation(), new EDeadWinding()
            };
        }
    }

    [Serializable]
    public class ScytheSpider : MEnemy
    {
        //构造函数
        public ScytheSpider(byte x,byte y) : base(x, y, "镰刀蜘蛛怪")
        {

            Image = Properties.Resources.Img_char_ScytheSpider;     
            MonsterType = MONSTER.ELITE;
            Description = "出现在魔塔中的蜘蛛形怪物，具有很高的攻击力，敏捷值，使用魔法攻击说不定不是个好方法";

            //镰刀蜘蛛怪添加了OAttack，OPosion，EEvilFluctuation,EDeadWinding
            Skills = new List<MSkill>()
            {
                new OAttack(), new OPosion(), new EEvilFluctuation(), new EDeadWinding()
            };
        }
    }

    [Serializable]
    public class SkeletonGeneral : MEnemy
    {
        //构造函数
        public SkeletonGeneral(byte x, byte y) : base(x, y, "骷髅将军")
        {

            Image = Properties.Resources.Img_char_SkeletonGeneral;     
            MonsterType = MONSTER.BOSS;
            Description = "魔塔前几层的Boss,具有很强的综合属性，稍不注意就会葬送在它的魔刀下";

            //骷髅将军添加了OAttack，EEvilFluctuation,EDeadWinding，BDevilChopper，BSarifice
            Skills = new List<MSkill>()
            {
                new OAttack(), new EEvilFluctuation(), new EDeadWinding(), new BDevilChopper(), new BSarifice()
            };
        }
    }

    [Serializable]
    public class GrandMaster : MEnemy
    {
        //构造函数
        public GrandMaster(byte x, byte y) : base(x, y, "大魔法师")
        {
 
            Image = Properties.Resources.Img_char_GrandMaster;     
            MonsterType = MONSTER.BOSS;
            Description = "魔塔中层出现的Boss,精通魔法，具有很强的魔法攻击";

            //大魔法师添加了EEvilFluctuation,EDeadWinding，BSoulKnife，BSoulGift
            Skills = new List<MSkill>()
            {
                new EEvilFluctuation(), new EDeadWinding(), new BSoulKnife(), new BSoulGift()
            };
        }
    }

    [Serializable]
    public class TheDevil : MEnemy
    {
        //构造函数
        public TheDevil(byte x, byte y) : base(x, y, "魔王")
        {

            Image = Properties.Resources.Img_char_TheDevil;     
            MonsterType = MONSTER.BOSS;
            Description = "魔塔最终boss，曾是拯救世人的勇者，但是在魔塔中失去本性，最终化为黑暗的傀儡。魔塔的化身。";

            //魔王添加了OAttack,EEvilFluctuation,EDeadWinding，BSoulChop，BSoulGift
            Skills = new List<MSkill>()
            {
                new OAttack(), new EEvilFluctuation(), new EDeadWinding(), new BSoulChop(), new BDarkCurse()
            };
        }
    }
}