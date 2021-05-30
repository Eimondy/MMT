using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Data.Classes.Skill
{
   

     abstract class MSkill
    {
        private string name; //技能名称
        private float points;//伤害倍数
        private int consumption;//所消耗的对应属性的值
        private ATTRIBUTE type;//技能类型,仅POWER和MAGIC
        private string description;//技能描述

        public string Name { get => name; set => name = value; }
        public float Points { get => points; set => points = value; }
        public int Consumption { get => consumption; set => consumption = value; }
        internal ATTRIBUTE Type { get => type; set => type = value; }
        public string Description { get => description; set => description = value; }

        //技能使用
       public abstract void Activate();


        //构造方法
        public MSkill()
        {

        }
    }


}
