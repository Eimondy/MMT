using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Item
{
    [Serializable]
    public abstract class MPotion : MItem, MIPickable
    {
        private string description;//药剂效果描述
        private double promotePoints;//产生效用的数值
        private ATTRIBUTE type;   //药剂类型
        public string Description { get => description; set => description = value; }
        public double PromotePoints { get => promotePoints; set => promotePoints = value; }
        internal ATTRIBUTE Type { get => type; set => type = value; }

        //构造方法
        public MPotion(byte locationX, byte locationY, string name="") : base(locationX, locationY)
        {
            Name = name;
            var info = MMainLogic.Instance.Data["Item"].Where(i => i.Split(',')[0] == Name);
            foreach (var i in info)
            {
                var s = i.Split(',');
                PromotePoints = double.Parse(s[1]);
            }
        }
        public override void Interact()
        {
            base.Interact();
            Picked();
            Shell.WriteLine(string.Format("获取{0}，增加{1}{2}点", Name, Type.ToString(), PromotePoints), ConsoleColor.Yellow);
        }
        public void Picked()
        {
            switch (Type)
            {
                case ATTRIBUTE.HEALTH:
                    MMainCharacter.Instance.MaxHP += (int)PromotePoints;
                    break;
                case ATTRIBUTE.MAGIC:
                    MMainCharacter.Instance.MaxMP += (int)PromotePoints;
                    break;
                case ATTRIBUTE.POWER:
                    MMainCharacter.Instance.MaxPower += (int)PromotePoints;
                    break;
                case ATTRIBUTE.ARMOR:
                    MMainCharacter.Instance.Armor += (int)PromotePoints;
                    break;
                case ATTRIBUTE.MAGICARMOR:
                    MMainCharacter.Instance.MagicArmor += (int)PromotePoints;
                    break;
                case ATTRIBUTE.SPEED:
                    MMainCharacter.Instance.Speed += (int)PromotePoints;
                    break;
                case ATTRIBUTE.HITRATE:
                    MMainCharacter.Instance.HitRate += (float)PromotePoints;
                    break;
            }
            //将药剂从该地图中去除
            MLevel.Levels[MLevel.CurrentLevel - 1].Items.Remove(this);
        }
    }
    [Serializable]
    public class HealthPotion : MPotion
    {
        public HealthPotion(byte locationX, byte locationY) : base(locationX, locationY, "生命药剂")
        {
            Image = Properties.Resources.Img_item_HealthPotion;
            PromotePoints = 20;
            Type = ATTRIBUTE.HEALTH;
            Description = "使用后主角生命值+20";
        }
    }
    [Serializable]
    public class MagicPotion : MPotion
    {
        public MagicPotion(byte locationX, byte locationY) : base(locationX, locationY, "法力药剂")
        {
            Image = Properties.Resources.Img_item_MagicPotion;
            Type = ATTRIBUTE.MAGIC;
            Description = "使用后主角魔法值+10";
        }
    }
    [Serializable]
    public class PowerPotion : MPotion
    {
        public PowerPotion(byte locationX, byte locationY) : base(locationX, locationY, "力量药剂")
        {
            Image = Properties.Resources.Img_item_PowerPotion;
            Type = ATTRIBUTE.POWER;
            Description = "使用后主角力量值+8";
        }
    }
    [Serializable]
    public class ArmorPotion : MPotion
    {
        public ArmorPotion(byte locationX, byte locationY) : base(locationX, locationY, "护甲药剂")
        {
            Image = Properties.Resources.Img_item_ArmorPotion;
            Type = ATTRIBUTE.ARMOR;
            Description = "使用后主角护甲值+8";
        }
    }
    [Serializable]
    public class MagicArmorPotion : MPotion
    {
        public MagicArmorPotion(byte locationX, byte locationY) : base(locationX, locationY, "魔抗药剂")
        {
            Image=Properties.Resources.Img_item_MagicAntidote;
            Type = ATTRIBUTE.MAGICARMOR;
            Description = "使用后主角魔抗值+8";
        }
    }
    [Serializable]
    public class SpeedPotion : MPotion
    {
        public SpeedPotion(byte locationX, byte locationY) : base(locationX, locationY, "速度药剂")
        {
            Image=Properties.Resources.Img_item_SpeedPotion;
            Type = ATTRIBUTE.SPEED;
            Description = "使用后主角速度值+8";
        }
    }
    [Serializable]
    public class HitPotion : MPotion
    {
        public HitPotion(byte locationX, byte locationY) : base(locationX, locationY, "命中药剂")
        {
            Image=Properties.Resources.Img_item_HitPotion;
            Type = ATTRIBUTE.HITRATE;
            Description = "使用后主角命中率+0.1";
        }
    }
}
