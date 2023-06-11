using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterUnit : MonoBehaviour
{
    public MonsterBase _base;
    public int level;
    public void PowerUp()
    {
        level += 1;
        Debug.Log(level);
        Debug.Log(Attack);
        Debug.Log(MaxHP);
    }
    

    public int Attack
    {
        get { return _base.Attack + (level * 5); }
    }
    public int AttackSpeed
    {
        get { return _base.AttackSpeed; }
    }
    public int Speed
    {
        get { return _base.Speed; }
    }
    public int MaxHP
    {
        get { return _base.MaxHp + (level * 200); }
    }

}
