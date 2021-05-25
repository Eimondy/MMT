using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MMT.Data.Classes.Character
{
    enum MONSTER {
        ORDINARY,
        ELITE,
        BOSS 
    }
    public class MEnemy : MCharacter
    {
        internal MONSTER monstertype; //敌人类型
        public string description; //描述

        public string Description { get { return Description; }set { description = value; } }
        internal MONSTER MonsterType { get { return MonsterType; }set { monstertype = value; } }
    }

}