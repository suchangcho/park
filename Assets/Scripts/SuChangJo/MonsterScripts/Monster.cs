using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    public MonsterBase Base { get; set; }
    public int level { get; set; }
    public int name;

    public Monster(MonsterBase mBase,int mLevel)
    {
        Base = mBase;
        level = mLevel;
    }
    public int Attack
    {
        get { return Base.Attack + (level * 5); }
    }
    public int AttackSpeed
    {
        get { return Base.AttackSpeed; }
    }
    public int Speed
    {
        get { return Base.Speed; }
    }
    public int MaxHP
    {
        get { return Base.MaxHp + (level * 200); }
    }

}
