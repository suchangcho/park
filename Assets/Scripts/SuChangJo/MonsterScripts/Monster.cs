using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    public MonsterBase Base { get; set; }    
    public int level { get; set; }
    public int name { get; set; }

    public Monster(MonsterBase mBase,int mLevel)
    {
        Base = mBase;
        level = mLevel;
    }
}
