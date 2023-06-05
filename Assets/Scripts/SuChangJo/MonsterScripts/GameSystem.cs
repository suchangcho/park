using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] MonsterUnit monsterUnit;
    [SerializeField] MonsterHUD monsterHUD;

    private void Start()
    {
        SetupStart();
    }

    public void SetupStart()
    {
        monsterUnit.Setup();
        monsterHUD.SetData(monsterUnit.Monster);
    }
}
