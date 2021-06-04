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
    public partial class Form_Battle : Form
    {
        public Form_Battle()
        {
            InitializeComponent();
            //数值调整
            this.lbl_Battle_Mp1.Text = "法力值：" + MMainCharacter.Instance.MP;
            this.lbl_Battle_Hp1.Text = "生命值：" + MMainCharacter.Instance.HP;
            this.lbl_Battle_Level1.Text = "等级：" + MMainCharacter.Instance.Level;
            this.lbl_Battle_Armor1.Text = "护甲：" + MMainCharacter.Instance.Armor;
            this.lbl_Battle_MagicArmor1.Text = "魔抗：" + MMainCharacter.Instance.MagicArmor;
            this.lbl_Battle_Speed1.Text = "速度：" + MMainCharacter.Instance.Speed;
            this.lbl_Battle_Hitrate1.Text = "命中率：" + MMainCharacter.Instance.HitRate;
            this.lbl_Battle_Power1.Text = "力量：" + MMainCharacter.Instance.Power;

            this.lbl_Battle_Mp2.Text = "法力值：" + MMT.MMainLogic.Instance.CurEnemy.MP;
            this.lbl_Battle_Hp2.Text = "生命值：" + MMT.MMainLogic.Instance.CurEnemy.HP;
            this.lbl_Battle_Level2.Text = "等级：" + MMT.MMainLogic.Instance.CurEnemy.Level;
            this.lbl_Battle_Armor2.Text = "护甲：" + MMT.MMainLogic.Instance.CurEnemy.Armor;
            this.lbl_Battle_MagicArmor2.Text = "魔抗：" + MMT.MMainLogic.Instance.CurEnemy.MagicArmor;
            this.lbl_Battle_Speed2.Text = "速度：" + MMT.MMainLogic.Instance.CurEnemy.Speed;
            this.lbl_Battle_Hitrate2.Text = "命中率：" + MMT.MMainLogic.Instance.CurEnemy.HitRate;
            this.lbl_Battle_Power2.Text = "力量：" + MMT.MMainLogic.Instance.CurEnemy.Power;
        }

        private void btn_Battle_skill1_Click(object sender, EventArgs e)
        {

        }
    }
}
