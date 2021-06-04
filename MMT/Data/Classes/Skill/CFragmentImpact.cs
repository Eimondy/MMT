using System;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Skill

public class CFragmentImpact:MSkill
{
    public CFragmentImpact()
    {
        Name = "FragmentImpact"; //技能名称
        Points = 1.5f;//伤害倍数
        Consumption = 60;//所消耗的对应属性的值
        Type = ATTRIBUTE.POWER;//技能类型,仅POWER和MAGIC
        Description = "普通A级物理技能，对敌人造成1.5倍伤害";//技能描述
    }
    Random rd = new Random();
    double p = rd.NextDouble();
    var Attack = 0.0;
        if (p<MMainCharacter.Instance.HitRate) //命中
    {
        MMainCharacter.Instance.Power -= 20;
        Attack = MMainCharacter.Instance.Power* Points * 2.4;
        var TakeAttack = Attack - enemy.Armor;
        enemy.HP = enemy.HP - (int) TakeAttack; //这里把伤害转成整型了
    }
    else //未命中
    {
        return;
    }
}