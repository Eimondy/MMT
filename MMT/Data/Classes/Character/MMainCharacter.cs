using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;
using MMT.Data.Classes.Item;
using MMT.Data.Classes.Skill;
using MMT.Data.Classes;
using MMT;

namespace MMT.Data.Classes.Character
{
    [Serializable]
    public class MMainCharacter : MCharacter
    {
        private static MMainCharacter instance;
        private List<MEquipment> equipped = new List<MEquipment>();     //装备好的所有装备。根据装备的属性，为主角增加相应的属性。
        private List<MEquipment> equipment = new List<MEquipment>();    //收集到的装备。可以装备，可以卸载。
        private List<MKey> keys = new List<MKey>();     //收集到的钥匙。每收集一个钥匙，便放入Keys中，并在界面上显示；
                                                        //每使用一个钥匙，会从Keys中移除相应的钥匙。每进入新的关卡时，置空Keys。

        private int expToLevelUp;     //主角升级时所需要的经验
        private byte attackchoice = 255;     //表示主角攻击时的攻击方式

        public static MMainCharacter Instance
        {
            get
            {
                if (instance == null)
                    instance = new MMainCharacter();
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        public List<MEquipment> Equipped { get => equipped; }
        public List<MEquipment> Equipment { get => equipment; }
        public List<MKey> Keys { get => keys; }

        public int ExpToLevelUp { get => expToLevelUp; set => expToLevelUp = value; }
        public byte AttackChoice { get => attackchoice; set => attackchoice = value; }

        //初始化人物信息,默认构造方法
        public MMainCharacter()
        {
            this.Name = null;
            this.MaxHP = 50;
            this.HP = 50;
            this.MaxMP = 0;
            this.MP = 0;
            this.MaxPower = 15;
            this.Power = 15;
            this.Armor = 10;
            this.MagicArmor = 5;
            this.Speed = 1;
            this.HitRate = 0.8;
            this.AvoidRate = 1.0;
            this.Image = Properties.Resources.Img_char_down;     // 图片暂用
            this.LocationX = 0;
            this.LocationY = 0;
            this.Level = 1;
            this.Exp = 0;
            this.ExpToLevelUp = Convert.ToByte(this.Level + 10);

            // 主角技能的初始化包含所有技能
            this.Skills = new List<MSkill>()
            {
                new CBeat(), new CFrustrated(), new CTreat(), new CStrongAbsorption(),
                new CExtinctRoar(), new CFragmentImpact(), new CGodStrick(), new CGodShine()
            };
        }

        // 获取经验值
        public void GetExp(MEnemy e)
        {
            Exp += e.Exp;
            ExpToLevelUp = Convert.ToByte(Level + 10) - Exp;
            while (ExpToLevelUp <= 0)
            {
                LevelUp();
            }
        }

        //人物升级
        public void LevelUp()
        {
            int OldExpToLevelUp = ExpToLevelUp;
            Level++;
            Exp = Convert.ToByte(0 - OldExpToLevelUp);
            ExpToLevelUp = Convert.ToByte(Level + 10) - Exp;
            MaxHP += 10;                //数据测试后，将人物血量设置为+10
            MaxMP += 8;                //人物mp设置为+8
            MaxPower += 4;              //人物power设置为+4
            Armor += 3;                 
            MagicArmor += 8;
            Speed += 0.3f;              //人物速度设置为+0.3f
            //可以添加升级提示框

            //升级之后当前mp,hp回满
            HP = MaxHP;
            MP = MaxMP;
            Power = MaxPower;
        }

        //人物拾取装备之后对应属性增加
        public void PickUpEquipment(MEquipment equipment)
        {
            MaxPower += equipment.Power;
            MaxMP += equipment.Magic;
            Armor += equipment.Armor;
            MagicArmor += equipment.MagicArmor;
            Speed += equipment.Speed;
            HitRate += equipment.HitRate;
        }

        //人物卸下装备之后对应属性减少
        public void PickDownEquipment(MEquipment equipment)
        {
            MaxPower -= equipment.Power;
            MaxMP -= equipment.Magic;
            Armor -= equipment.Armor;
            MagicArmor -= equipment.MagicArmor;
            Speed -= equipment.Speed;
            HitRate -= equipment.HitRate;
        }

        //人物移动,1,2,3,4分别为上，下，左，右
        public void Move(byte direction)
        {
            // 转换为物理次序再访问Map.Content
            byte x = Convert.ToByte(LocationX - 1);
            byte y = Convert.ToByte(LocationY - 1);
            switch (direction)
            {
                case 1:
                    x -= 1;
                    if (x > 0 && MLevel.Levels[MLevel.CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        { LocationX -= 1; Image = Properties.Resources.Img_char_up; }
                    break;
                case 2:
                    x += 1;
                    if (x < MLevel.Levels[MLevel.CurrentLevel - 1].Map.Size && MLevel.Levels[MLevel.CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        { LocationX += 1; Image = Properties.Resources.Img_char_down; }
                    break;
                case 3:
                    y -= 1;
                    if (y > 0 && MLevel.Levels[MLevel.CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        { LocationY -= 1; Image = Properties.Resources.Img_char_left; }
                    break;
                case 4:
                    y += 1;
                    if (y < MLevel.Levels[MLevel.CurrentLevel - 1].Map.Size && MLevel.Levels[MLevel.CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        { LocationY += 1; Image = Properties.Resources.Img_char_right; }
                    break;
            }
            // 播放走路音效
            SoundPlayer sp = new SoundPlayer();
            switch((new Random()).Next(1, 7))
            {
                case 1:
                    sp.Stream = Properties.Resources.Walk1;
                    break;
                case 2:
                    sp.Stream = Properties.Resources.Walk2;
                    break;
                case 3:
                    sp.Stream = Properties.Resources.Walk3;
                    break;
                case 4:
                    sp.Stream = Properties.Resources.Walk4;
                    break;
                case 5:
                    sp.Stream = Properties.Resources.Walk5;
                    break;
                case 6:
                    sp.Stream = Properties.Resources.Walk6;
                    break;
            }
            sp.Play();
            //Shell.WriteLine(string.Format("玩家位于：({0},{1})", LocationX, LocationY), ConsoleColor.Green);
        }
    }
}
