using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MMT.Data.Classes.Item;
using MMT.Data.Classes.Skill;

namespace MMT.Data.Classes.Character
{
    [Serializable]
    class MMainCharacter : MCharacter
    {
        private List<MEquipment> equipped;     //装备好的所有装备。根据装备的属性，为主角增加相应的属性。
        private List<MEquipment> equipment;    //收集到的装备。可以装备，可以卸载。
        private List<MKey> keys;               //收集到的钥匙。每收集一个钥匙，便放入Keys中，并在界面上显示；
                                               //每使用一个钥匙，会从Keys中移除相应的钥匙。每进入新的关卡时，置空Keys。
        private List<MSkill> skills;        //拥有的技能。主角拥有固定的技能。采用new的形式
        private int expToLevelUp;

        internal List<MEquipment> Equipped { get => equipped; }
        internal List<MEquipment> Equipment { get => equipment; }
        internal List<MKey> Keys { get => keys; }
        internal List<MSkill> Skills { get => skills; }
        internal int ExpToLevelUp;


        public MMainCharacter()
        {

        }
        public MMainCharacter(MMainCharacter c)     // 复制构造函数
        {

        }

        public void Move() { }

        public override int Attack(MEnemy e, MSkill skill)     // 实现Attack
        {
            throw new NotImplementedException();
        }

        public override void Iteract(MEnemy e)     // 实现Interact
        {
            throw new NotImplementedException();
        }
    }
}
