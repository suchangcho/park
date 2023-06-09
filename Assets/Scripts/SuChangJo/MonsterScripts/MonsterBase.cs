using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster/Create new Monster")] //파일이름은 몬스터이고 스크립트 만드는 화면에서 생성가능
public class MonsterBase : ScriptableObject
{
    public string name;   //이름 선언 
    //[SerializeField]:외부 스크립트에서 수정을 못하게 할려고 사용
    
    [TextArea]
    public string description; //캐릭터 설명

    public Sprite monster; //몬스터 사진

    public int maxHp;//최대 체력
    public int attack;//공격력
    public int cost;
    public int attackSpeed; //공격속도
    public int speed; //스피드


    public string Name
    {
        get { return name; }
    }
    public string Description
    {
        get { return description; }
    }
    public int MaxHp
    {
        get { return maxHp; }
    }
    public int Attack
    {
        get { return attack; }
    }
    public int AttackSpeed
    {
        get { return attackSpeed; }
    }
    public int Speed
    {
        get { return speed; }
    }
    public int Cost
    {
        get { return cost; }
    }

}
