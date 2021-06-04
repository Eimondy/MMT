using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Item
{
    public abstract class MPotion : MItem, MIPickable
    {
        private string description;//药剂效果描述
        private double promotePoints;//产生效用的数值
        private ATTRIBUTE type;   //药剂类型
        public string Description { get => description; set => description = value; }
        public double PromotePoints { get => promotePoints; set => promotePoints = value; }
        internal ATTRIBUTE Type { get => type; set => type = value; }

        //构造方法
        public MPotion(byte locationX, byte locationY) : base(locationX, locationY)
        {
        }
        public override void Interact()
        {
            base.Interact();
            Picked();
            Shell.WriteLine(string.Format("增加{0}{1}点", Type.ToString(), PromotePoints), ConsoleColor.Yellow);
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
    public class HealthPotion : MPotion
    {
        public HealthPotion(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "生命药剂";
            Image = Properties.Resources.Img_item_HealthPotion;
            PromotePoints = 20;
            Type = ATTRIBUTE.HEALTH;
            Description = "使用后主角生命值+20";
        }
    }
    public class MagicPotion : MPotion
    {
        public MagicPotion(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "法力药剂";
            Image = Properties.Resources.Img_item_MagicPotion;
            PromotePoints = 10;
            Type = ATTRIBUTE.MAGIC;
            Description = "使用后主角魔法值+10";
        }
    }
    public class PowerPotion : MPotion
    {
        public PowerPotion(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "力量药剂";
            Image = Properties.Resources.Img_item_PowerPotion;
            PromotePoints = 8;
            Type = ATTRIBUTE.POWER;
            Description = "使用后主角力量值+8";
        }
    }
    public class ArmorPotion : MPotion
    {
        public ArmorPotion(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "护甲药剂";
            Image = Properties.Resources.Img_item_ArmorPotion;
            PromotePoints = 8;
            Type = ATTRIBUTE.ARMOR;
            Description = "使用后主角护甲值+8";
        }
    }
    public class MagicArmorPotion : MPotion
    {
        public MagicArmorPotion(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "魔抗药剂";
            Image=Properties.Resources.Img_item_MagicAntidote;
            PromotePoints = 8;
            Type = ATTRIBUTE.MAGICARMOR;
            Description = "使用后主角魔抗值+8";
        }
    }
    public class SpeedPotion : MPotion
    {
        public SpeedPotion(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "速度药剂";
            Image=Properties.Resources.Img_item_SpeedPotion;
            PromotePoints = 5;
            Type = ATTRIBUTE.SPEED;
            Description = "使用后主角速度值+8";
        }
    }
    public class HitPotion : MPotion
    {
        public HitPotion(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "命中药剂";
            Image=Properties.Resources.Img_item_HitPotion;
            PromotePoints = 0.1;
            Type = ATTRIBUTE.HITRATE;
            Description = "使用后主角命中率+0.1";
        }
    }
}
