using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MMT.Data.Classes;
using MMT.Data.Classes.Character;
using MMT.Data.Classes.Item;

namespace MMT
{
    public partial class Form_Status : Form
    {
        public Form_Status()
        {
            InitializeComponent();
        }

        public void Form_Status_Load(object sender, EventArgs e)
        {
            this.lbl_FloorNum.Text = "——" + MLevel.CurrentLevel.ToString() + "——";
            this.lbl_MpShow.Text = "法力值：" + MMainCharacter.Instance.MaxMP;
            this.lbl_HpShow.Text = "生命值：" + MMainCharacter.Instance.MaxHP;
            this.lbl_PowerShow.Text = "力量值：" + MMainCharacter.Instance.Power;
            this.lbl_ArmorShow.Text = "护甲：" + MMainCharacter.Instance.Armor;
            this.lbl_MagicArmorShow.Text = "魔抗：" + MMainCharacter.Instance.MagicArmor;
            this.lbl_SpeedShow.Text = "速度：" + MMainCharacter.Instance.Speed;
            this.lbl_HitRateShow.Text = "命中率：" + MMainCharacter.Instance.HitRate;
            this.lbl_LevelShow.Text = "等级：" + MMainCharacter.Instance.Level;
            this.lbl_Name.Text = "名称：" + MMainCharacter.Instance.Name;
        }
    }
}
