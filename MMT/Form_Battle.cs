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
        private MEnemy curEnemy;
        public List<Button> Btns { get => btns; }
        public MEnemy CurEnemy { get => curEnemy; }
        public Form_Battle(object o)
        {
            InitializeComponent();
            // 获得按钮
            btns = new List<Button>()
            {
                btn_Battle_skill1, btn_Battle_skill2, btn_Battle_skill3, btn_Battle_skill4,
                btn_Battle_skill5, btn_Battle_skill6, btn_Battle_skill7, btn_Battle_skill8,
                btn_Battle_attack
            };
            // 按钮绑定事件，并设置外观
            for(int i=0; i<Btns.Count;i++)
            {
                Btns[i].Click += new EventHandler(BtnClick);
                Btns[i].BackgroundImage = Properties.Resources.Img_button;
                Btns[i].BackgroundImageLayout = ImageLayout.Stretch;
                Btns[i].FlatAppearance.BorderSize = 0;
                Btns[i].FlatStyle = FlatStyle.Flat;
                // 设置ToolTip
                if (i == 8) break;
                var s = MMainCharacter.Instance.Skills[i];
                ToolTip_.SetToolTip(Btns[i], string.Format("{0}\n类型 {1} 消耗 {2}\n{3}", s.Name, s.Type, s.Consumption, s.Description));
            }
            ToolTip_.SetToolTip(Btns[8], "普通攻击");
            // 设置位置
            this.Location = new Point((MMainForm.Instance.Width - Width) / 2, (MMainForm.Instance.Height - Height) / 2);
            // 数值调整
            curEnemy = o as MEnemy;
            SetLable(MMainCharacter.Instance);
            SetLable(CurEnemy);
        }

        public void SetLable(MCharacter character)
        {
            if (character is MMainCharacter)
            {
                this.lbl_Battle_name1.Text = character.Name;
                this.lbl_Battle_Mp1.Text = "法力值：" + character.MP;
                this.lbl_Battle_Hp1.Text = "生命值：" + character.HP;
                this.lbl_Battle_Level1.Text = "等级：" + character.Level;
                this.lbl_Battle_Armor1.Text = "护甲：" + character.Armor;
                this.lbl_Battle_MagicArmor1.Text = "魔抗：" + character.MagicArmor;
                this.lbl_Battle_Speed1.Text = "速度：" + character.Speed;
                this.lbl_Battle_Hitrate1.Text = string.Format("命中率：{0:F1}", character.HitRate);
                this.lbl_Battle_Power1.Text = "力量：" + character.Power;
            }
            else
            {
                this.lbl_Battle_name2.Text = character.Name;
                this.lbl_Battle_Mp2.Text = "法力值：" + character.MP;
                this.lbl_Battle_Hp2.Text = "生命值：" + character.HP;
                this.lbl_Battle_Level2.Text = "等级：" + character.Level;
                this.lbl_Battle_Armor2.Text = "护甲：" + character.Armor;
                this.lbl_Battle_MagicArmor2.Text = "魔抗：" + character.MagicArmor;
                this.lbl_Battle_Speed2.Text = "速度：" + character.Speed;
                this.lbl_Battle_Hitrate2.Text = string.Format("命中率：{0:F1}", character.HitRate);
                this.lbl_Battle_Power2.Text = "力量：" + character.Power;
            }
        }

        public void UpdateCombatMenu(object[] choice)
        {
            SetLable(MMainCharacter.Instance);
            SetLable(CurEnemy);
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
            if (i == 9)
                MMainCharacter.Instance.AttackChoice = 0;     // 普攻
            else
                MMainCharacter.Instance.AttackChoice = i;
        }
    }
}
