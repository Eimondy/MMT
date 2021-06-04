using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Item
{
    public abstract class MEquipment : MItem , MIPickable
    {
        private string description;//装备描述
        private EQUIPMENT type;//装备类型
        private int power;//力量增值
        private int magic;//法力增值
        private int armor;//护甲增值
        private int magicArmor;//魔抗增值
        private int speed;//速度增值
        private float hitRate;//命中率增值
        public string Description { get => description; set => description = value; }
        public EQUIPMENT Type { get => type; set => type = value; }
        public int Power { get => power; set => power = value; }
        public int Magic { get => magic; set => magic = value; }
        public int Armor { get => armor; set => armor = value; }
        public int MagicArmor { get => magicArmor; set => magicArmor = value; }
        public int Speed { get => speed; set => speed = value; }
        public float HitRate { get => hitRate; set => hitRate = value; }
        // 穿戴装备，增加属性
        public void Equip()
        {
            // 若当前已装备相同类型的装备，则先卸下旧的，再换上新的
            foreach (MEquipment e in MMainCharacter.Instance.Equipped)
            {
                if (Type == e.Type)     // 找到相同装备
                {
                    e.Unequip();
                    break;
                }
            }
            MMainCharacter.Instance.Equipped.Add(this);     // 穿戴装备
            MMainCharacter.Instance.PickUpEquipment(this);     // 增加属性
        }
        // 卸下装备，减少属性
        public void Unequip()
        {
            MMainCharacter.Instance.Equipped.Remove(this);     // 卸下装备
            MMainCharacter.Instance.PickDownEquipment(this);     // 减少属性
        }
        public MEquipment(byte locationX, byte locationY) : base(locationX, locationY)
        {
        }
        public override void Interact()
        {
            base.Interact();
            Picked();
        }
        public void Picked()
        {
            // 若未装备相同类型的装备，则装备上当前装备
            bool equipped = false;
            foreach (MEquipment e in MMainCharacter.Instance.Equipped)
            {
                if (Type == e.Type)     // 找到相同装备
                {
                    equipped = true;
                    break;
                }
            }
            if (!equipped)
            {
                Equip();
            }
            //将拾取到的装备放入主角装备栏中
            MMainCharacter.Instance.Equipment.Add(this);
            // 将该装备从关卡中移除
            MLevel.Levels[MLevel.CurrentLevel - 1].Items.Remove(this);
        }
    }
    public class BlueGem : MEquipment
    {
        public BlueGem(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "蓝宝石";
            Type = EQUIPMENT.GEM;
            Image = Properties.Resources.Img_item_BlueGem;
            Armor = 4;
            MagicArmor = 4;
            Magic = 10;
            Description = "在魔塔中比较普遍的一种水晶，装备之后能在一定程度上增加主角法力值、护甲和魔抗";
        }       
    }
    public class RedGem : MEquipment
    {
        public RedGem(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "红宝石";
            Type = EQUIPMENT.GEM;
            Image = Properties.Resources.Img_item_RedGem;
            Power = 5;
            Speed = 1;
            HitRate = 0.1f;
            Description = "魔塔中蓝宝石变异而成，装备之后能在一定程度上增长主角力量，速度和命中率";
        }
    }
    public class RustySword : MEquipment
    {
        public RustySword(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "生锈的宝剑";
            Type = EQUIPMENT.WEAPON;
            Image = Properties.Resources.Img_item_RustySword;
            Power = 10;
            HitRate = 0.05f;
            Description = "曾经的冒险者遗失在魔塔中的宝剑，经过岁月的打磨，没有了往日的光辉";
        }
    }
    public class RottenStaff : MEquipment
    {
        public RottenStaff(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "腐朽的法杖";
            Type = EQUIPMENT.WEAPON;
            Image = Properties.Resources.Img_item_RottenStaff;
            Power = 1;
            Magic = 15;
            HitRate = 0.05f;
            Description = "曾经的冒险者遗失在魔塔中的法杖，经过岁月的淘洗，不复当年的威力";
        }
    }
    public class SharpSword : MEquipment
    {
        public SharpSword(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "锋利的宝剑";
            Type = EQUIPMENT.WEAPON;
            Image = Properties.Resources.Img_item_SharpSword;
            Power = 30;
            HitRate = 0.1f;
            Description = "一把完好锋利的宝剑，冷锋出鞘，刀光逼人";
        }
    }
    public class PowerfulStaff : MEquipment
    {
        public PowerfulStaff(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "强力的法杖";
            Type = EQUIPMENT.WEAPON;
            Image = Properties.Resources.Img_item_PowerfulStaff;
            Power = 1;
            Magic = 40;
            HitRate = 0.1f;
            Description = "一把完好的法杖，光彩焕发，法力依旧";
        }
    }
    public class Excalibur : MEquipment
    {
        public Excalibur(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "石中剑";
            Type = EQUIPMENT.WEAPON;
            Image = Properties.Resources.Img_item_Excalibur;
            Power = 50;
            Magic = 10;
            Speed = 2;
            HitRate = 0.2f;
            Description = "传说中为亚瑟王所佩戴的宝剑，不知道为什么出现在这里";
        }
    }
    public class MerlinStaff : MEquipment
    {
        public MerlinStaff(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "梅林的法杖";
            Type = EQUIPMENT.WEAPON;
            Image = Properties.Resources.Img_item_MerlinStaff;
            Power = 1;
            Magic = 55;
            Speed = 2;
            HitRate = 0.2f;
            Description = "梅林心爱的法杖，可能是在梅林的某次法术中被传送至此";
        }
    }
    public class Robe : MEquipment
    {
        public Robe(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "长袍";
            Type = EQUIPMENT.UPPER;
            Image=Properties.Resources.Img_item_Robe; 
            Armor = 10;
            MagicArmor = 8;
            Description = "随处可见的战士长袍，美观，耐用";
        }
    }
    public class Armor : MEquipment
    {
        public Armor(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "铠甲";
            Type = EQUIPMENT.UPPER;
            Image = Properties.Resources.Img_item_Armor;
            Armor = 30;
            MagicArmor = 25;
            Description = "具有很强实用性的盔甲，战士的必备用品";
        }
    }
    public class OverlordArmor : MEquipment
    {
        public OverlordArmor(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "霸王甲胄";
            Type = EQUIPMENT.UPPER;
            Image =Properties.Resources.Img_item_OverlordArmor ;
            Power = 5;
            Magic = 10;
            Armor = 50;
            MagicArmor = 40;
            Speed = 1;
            HitRate = 0.1f;
            Description = "不死王的铠甲，只存在于典籍之中";
        }
    }
    public class StrawSandals : MEquipment
    {
        public StrawSandals(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "草鞋";
            Type = EQUIPMENT.SHOES;
            Image = Properties.Resources.Img_item_StrawSandals;
            Speed = 1;
            HitRate = 0.05f;
            Description = "用最普通的芦苇编制的草鞋，方便耐磨";
        }
    }
    public class LongShoes : MEquipment
    {
        public LongShoes(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "长筒靴";
            Type = EQUIPMENT.SHOES;
            Image = Properties.Resources.Img_item_LongShoes;
            Speed = 2;
            HitRate = 0.1f;
            Description = "少见的昂贵的长筒鞋";
        }
    }
    public class Legend : MEquipment
    {
        public Legend(byte locationX, byte locationY) : base(locationX, locationY)
        {
            Name = "传说";
            Type = EQUIPMENT.WEAPON;
            Image =Properties.Resources.Img_item_Legend;
            Power = 999;
            Magic = 999;
            Speed = 99;
            HitRate = 1;
            Description = "这只不过是传说而已";
        }
    }
}
