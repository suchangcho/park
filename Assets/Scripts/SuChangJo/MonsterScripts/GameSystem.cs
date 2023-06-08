using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] MonsterUnit monsterUnit;
    [SerializeField] MonsterHUD monsterHUD;

    public void Start()
    {
           
    }
    public void Update()
    {
        monsterHUD.SetData(monsterUnit);
    }
}
