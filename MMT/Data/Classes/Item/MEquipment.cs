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
    public abstract class MEquipment : MItem , MIPickable
    {
        private string description;//装备描述
        private EQUIPMENT type;//装备类型
        private int power;//力量增值
        private int magic;//法力增值
        private int armor;//护甲增值
        private int magicArmor;//魔抗增值
        private double speed;//速度增值
        private double hitRate;//命中率增值
        public string Description { get => description; set => description = value; }
        public EQUIPMENT Type { get => type; set => type = value; }
        public int Power { get => power; set => power = value; }
        public int Magic { get => magic; set => magic = value; }
        public int Armor { get => armor; set => armor = value; }
        public int MagicArmor { get => magicArmor; set => magicArmor = value; }
        public double Speed { get => speed; set => speed = value; }
        public double HitRate { get => hitRate; set => hitRate = value; }
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
            Shell.WriteLine(string.Format("装备{0}", Name), ConsoleColor.Green);
            MMainCharacter.Instance.Equipped.Add(this);     // 穿戴装备
            MMainCharacter.Instance.PickUpEquipment(this);     // 增加属性
            if(System.Threading.Thread.CurrentThread.Name == "Logic")
                MMainForm.Instance.BeginInvoke(new Action(MMainForm.Instance.UpdateEquipped));
        }
        // 卸下装备，减少属性
        public void Unequip()
        {
            Shell.WriteLine(string.Format("卸下{0}", Name), ConsoleColor.Green);
            MMainCharacter.Instance.Equipped.Remove(this);     // 卸下装备
            MMainCharacter.Instance.PickDownEquipment(this);     // 减少属性
            if (System.Threading.Thread.CurrentThread.Name == "Logic")
                MMainForm.Instance.BeginInvoke(new Action(MMainForm.Instance.UpdateEquipped));
        }
        public MEquipment(byte locationX, byte locationY, string name = "") : base(locationX, locationY)
        {
            Name = name;
            var info = MMainLogic.Instance.Data["Item"].Where(i => i.Split(',')[0] == Name);
            foreach (var i in info)
            {
                var s = i.Split(',');
                Power = int.Parse(s[1]);
                Magic = int.Parse(s[2]);
                Armor = int.Parse(s[3]);
                MagicArmor = int.Parse(s[4]);
                Speed = double.Parse(s[5]);
                HitRate = double.Parse(s[6]);
            }
        }
        public override void Interact()
        {
            base.Interact();
            Picked();
        }
        public void Picked()
        {
            Shell.WriteLine(string.Format("获取{0}", Name), ConsoleColor.Green);
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
            // 与窗体通信更新装备栏
            MMainForm.Instance.BeginInvoke(new Action(MMainForm.Instance.UpdateEquipment));
        }

        public override string ToString()
        {
            return string.Format(string.Format("{0}\n力量 {1} 法力 {2}\n护甲 {3} 魔抗 {4}\n速度 {5} 命中率 {6}\n{7}", Name, Power, Magic, Armor, MagicArmor, Speed, HitRate, Description));
        }
    }
    [Serializable]
    public class BlueGem : MEquipment
    {
        public BlueGem(byte locationX, byte locationY) : base(locationX, locationY, "蓝宝石")
        {
            Type = EQUIPMENT.GEM;
            Image = Properties.Resources.Img_item_BlueGem;
            Description = "在魔塔中比较普遍的一种水晶，装备之后能在一定程度上增加主角法力值、护甲和魔抗";
        }       
    }
    [Serializable]
    public class RedGem : MEquipment
    {
        public RedGem(byte locationX, byte locationY) : base(locationX, locationY, "红宝石")
        {
            Type = EQUIPMENT.GEM;
            Image = Properties.Resources.Img_item_RedGem;
            Description = "魔塔中蓝宝石变异而成，装备之后能在一定程度上增长主角力量，速度和命中率";
        }
    }
    [Serializable]
    public class RustySword : MEquipment
    {
        public RustySword(byte locationX, byte locationY) : base(locationX, locationY, "生锈的宝剑")
        {
            Type = EQUIPMENT.WEAPON;
            Image = Properties.Resources.Img_item_RustySword;
            Description = "曾经的冒险者遗失在魔塔中的宝剑，经过岁月的打磨，没有了往日的光辉";
        }
    }
    [Serializable]
    public class RottenStaff : MEquipment
    {
        public RottenStaff(byte locationX, byte locationY) : base(locationX, locationY, "腐朽的法杖")
        {
            Type = EQUIPMENT.WEAPON;
            Image = Properties.Resources.Img_item_RottenStaff;
            Description = "曾经的冒险者遗失在魔塔中的法杖，经过岁月的淘洗，不复当年的威力";
        }
    }
    [Serializable]
    public class SharpSword : MEquipment
    {
        public SharpSword(byte locationX, byte locationY) : base(locationX, locationY, "锋利的宝剑")
        {
            Type = EQUIPMENT.WEAPON;
            Image = Properties.Resources.Img_item_SharpSword;
            Description = "一把完好锋利的宝剑，冷锋出鞘，刀光逼人";
        }
    }
    [Serializable]
    public class PowerfulStaff : MEquipment
    {
        public PowerfulStaff(byte locationX, byte locationY) : base(locationX, locationY, "强力的法杖")
        {
            Type = EQUIPMENT.WEAPON;
            Image = Properties.Resources.Img_item_PowerfulStaff;
            Description = "一把完好的法杖，光彩焕发，法力依旧";
        }
    }
    [Serializable]
    public class Excalibur : MEquipment
    {
        public Excalibur(byte locationX, byte locationY) : base(locationX, locationY, "石中剑")
        {
            Type = EQUIPMENT.WEAPON;
            Image = Properties.Resources.Img_item_Excalibur;
            Description = "传说中为亚瑟王所佩戴的宝剑，不知道为什么出现在这里";
        }
    }
    [Serializable]
    public class MerlinStaff : MEquipment
    {
        public MerlinStaff(byte locationX, byte locationY) : base(locationX, locationY, "梅林的法杖")
        {
            Type = EQUIPMENT.WEAPON;
            Image = Properties.Resources.Img_item_MerlinStaff;
            Description = "梅林心爱的法杖，可能是在梅林的某次法术中被传送至此";
        }
    }
    [Serializable]
    public class Robe : MEquipment
    {
        public Robe(byte locationX, byte locationY) : base(locationX, locationY, "长袍")
        {
            Type = EQUIPMENT.UPPER;
            Image=Properties.Resources.Img_item_Robe; 
            Description = "随处可见的战士长袍，美观，耐用";
        }
    }
    [Serializable]
    public class Armor : MEquipment
    {
        public Armor(byte locationX, byte locationY) : base(locationX, locationY, "铠甲")
        {
            Type = EQUIPMENT.UPPER;
            Image = Properties.Resources.Img_item_Armor;
            Description = "具有很强实用性的盔甲，战士的必备用品";
        }
    }
    [Serializable]
    public class OverlordArmor : MEquipment
    {
        public OverlordArmor(byte locationX, byte locationY) : base(locationX, locationY, "霸王甲胄")
        {
            Type = EQUIPMENT.UPPER;
            Image =Properties.Resources.Img_item_OverlordArmor ;
            Description = "不死王的铠甲，只存在于典籍之中";
        }
    }
    [Serializable]
    public class StrawSandals : MEquipment
    {
        public StrawSandals(byte locationX, byte locationY) : base(locationX, locationY, "草鞋")
        {
            Type = EQUIPMENT.SHOES;
            Image = Properties.Resources.Img_item_StrawSandals;
            Description = "用最普通的芦苇编制的草鞋，方便耐磨";
        }
    }
    [Serializable]
    public class LongShoes : MEquipment
    {
        public LongShoes(byte locationX, byte locationY) : base(locationX, locationY, "长筒靴")
        {
            Type = EQUIPMENT.SHOES;
            Image = Properties.Resources.Img_item_LongShoes;
            Description = "少见的昂贵的长筒鞋";
        }
    }
    [Serializable]
    public class Legend : MEquipment
    {
        public Legend(byte locationX, byte locationY) : base(locationX, locationY, "传说")
        {
            Type = EQUIPMENT.WEAPON;
            Image =Properties.Resources.Img_item_Legend;
            Description = "这只不过是传说而已";
        }
    }
}
