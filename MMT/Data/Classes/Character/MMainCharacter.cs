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
    public class MMainCharacter : MCharacter
    {
        internal List<MEquipment> Equipped;     //装备好的所有装备。根据装备的属性，为主角增加相应的属性。

        internal List<MEquipment> Equipment;    //收集到的装备。可以装备，可以卸载。

        internal List<MKey> Keys;               //收集到的钥匙。每收集一个钥匙，便放入Keys中，并在界面上显示；
                                                //每使用一个钥匙，会从Keys中移除相应的钥匙。每进入新的关卡时，置空Keys。

        new internal List<MSkill> Skills;        //拥有的技能。主角拥有固定的技能。采用new的形式

        public int ExpToLevelUp;


        public MMainCharacter()
        {

        }
        public MMainCharacter(MMainCharacter c)     // copy constructor
        {

        }

        public void Move() { }
    }
}
