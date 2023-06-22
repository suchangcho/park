using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterUnit : MonoBehaviour
{
    public MonsterBase _base;
    public int level;
    public int PowerM = 100; //강화에 필요한 머니
    
    public void PowerUp()
    {
        
        if(GameMgr.Instance.PowerMoney >= PowerM)
        {
            level += 1; //레벨업
            Debug.Log(level);
            Debug.Log(Attack);
            Debug.Log(MaxHP);
            GameMgr.Instance.PowerMoney -= PowerM;
            PowerM += 10;
        }
        else
        {
            Debug.Log("돈이 부족해요");
        }
        //sGameMgr.Instance.PowerMoney = GameMgr.Instance.PowerMoney * 1.1;
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
        get { return _base.MaxHp + (level * 20); }
    }

}
