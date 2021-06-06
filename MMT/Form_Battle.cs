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
        private List<Button> btns;
        public List<Button> Btns { get => btns; }
        public Form_Battle(object o)
        {
            InitializeComponent();
            // 获得按钮
            btns = new List<Button>()
            {
                btn_Battle_skill1, btn_Battle_skill2, btn_Battle_skill3, btn_Battle_skill4,
                btn_Battle_skill5, btn_Battle_skill6, btn_Battle_skill7, btn_Battle_skill8
            };
            // 按钮绑定事件
            foreach(var b in Btns)
            {
                b.Click += new EventHandler(BtnClick);
            }
            // 数值调整
            this.lbl_Battle_name1.Text = MMainCharacter.Instance.Name;
            this.lbl_Battle_Mp1.Text = "法力值：" + MMainCharacter.Instance.MP;
            this.lbl_Battle_Hp1.Text = "生命值：" + MMainCharacter.Instance.HP;
            this.lbl_Battle_Level1.Text = "等级：" + MMainCharacter.Instance.Level;
            this.lbl_Battle_Armor1.Text = "护甲：" + MMainCharacter.Instance.Armor;
            this.lbl_Battle_MagicArmor1.Text = "魔抗：" + MMainCharacter.Instance.MagicArmor;
            this.lbl_Battle_Speed1.Text = "速度：" + MMainCharacter.Instance.Speed;
            this.lbl_Battle_Hitrate1.Text = "命中率：" + MMainCharacter.Instance.HitRate;
            this.lbl_Battle_Power1.Text = "力量：" + MMainCharacter.Instance.Power;
            MEnemy enemy = o as MEnemy;
            this.lbl_Battle_name2.Text = enemy.Name;
            this.lbl_Battle_Mp2.Text = "法力值：" + enemy.MP;
            this.lbl_Battle_Hp2.Text = "生命值：" + enemy.HP;
            this.lbl_Battle_Level2.Text = "等级：" + enemy.Level;
            this.lbl_Battle_Armor2.Text = "护甲：" + enemy.Armor;
            this.lbl_Battle_MagicArmor2.Text = "魔抗：" + enemy.MagicArmor;
            this.lbl_Battle_Speed2.Text = "速度：" + enemy.Speed;
            this.lbl_Battle_Hitrate2.Text = "命中率：" + enemy.HitRate;
            this.lbl_Battle_Power2.Text = "力量：" + enemy.Power;
        }

        public void UpdateCombatMenu(object[] choice)
        {
            for (int i = 0; i < choice.Length; i++)
            {
                if (Convert.ToBoolean(choice[i]))
                    Btns[i].Enabled = true;
                else
                    Btns[i].Enabled = false;
            }
        }

        private void BtnClick(object sender, EventArgs e)
        {
            byte i = Convert.ToByte(Btns.IndexOf((sender as Button))+1);
            MMainCharacter.Instance.AttackChoice = i;
        }
    }
}
