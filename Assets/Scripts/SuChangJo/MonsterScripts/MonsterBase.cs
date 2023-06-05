using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster/Create new Monster")] //파일이름은 몬스터이고 스크립트 만드는 화면에서 생성가능
public class MonsterBase : ScriptableObject
{
    [SerializeField] string name;   //이름 선언 
    //[SerializeField]:외부 스크립트에서 수정을 못하게 할려고 사용
    
    [TextArea]
    [SerializeField] string description; //캐릭터 설명

    [SerializeField] Sprite monster; //몬스터 사진


    public int maxHp { get { return maxHp; }} //최대 체력
    public int curHP { get { return curHP; }}//현재 체력
    public int attack { get { return attack; } }//공격력
    public int attackSpeed { get { return attackSpeed; } } //공격속도
    public int speed { get { return speed; } } //스피드


}
