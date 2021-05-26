using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Data.Classes.Character
{
    public abstract class MEnemy : MCharacter
    {
        private MONSTER monstertype; //敌人类型
        private string description; //描述

        public string Description { get { return Description; }set { description = value; } }
        public MONSTER MonsterType { get { return MonsterType; }set { monstertype = value; } }
        
        public MEnemy()
        {

        }
    }
}