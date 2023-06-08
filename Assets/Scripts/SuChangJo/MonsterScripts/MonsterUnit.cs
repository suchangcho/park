using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterUnit : MonoBehaviour
{
    [SerializeField] MonsterBase _base;
    public int level;

    public Monster Monster { get; set; }

    public void Setup()
    {
        Monster = new Monster(_base, level);
    }

    public void PowerUp()
    {
        Debug.Log("1");
        level += 1;

    }

}
