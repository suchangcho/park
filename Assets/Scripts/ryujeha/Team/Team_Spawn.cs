using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Team_Spawn : MonoBehaviour
{
    public GameObject Team;//받을 캐릭터 프리펩
    public GameObject Spawns;//스폰포인트를 담을 변수

    public float spawn_cooltime;//쿨타임 기준 설정
    public float cooltime;//실제 쿨타임 연산

    bool is_Spawn = false;//무한소환이 되면 안되므로, 소환을 할때 약간의 쿨타임을 주기위한 변수
    Team_Tower Team_Tower;

    private void Start() {
        Team_Tower = FindObjectOfType<Team_Tower>();
    }

    void Update()
    {
        SpawnCool();
    }
    public void SpawnCool()
    {
        cooltime -= Time.deltaTime;//실제 쿨타임 연산
        if (cooltime <= 0)//만약 쿨타임이 델타타임에서부터 깎여 0초가 되었다면
        {
            is_Spawn = true;
            cooltime = 0;
        }
    }
    public void Spawn_Team()
    {
        if (is_Spawn)
        {
            if(Team_Tower.Cost >= Team.GetComponent<Unit>().Base.Cost){
                GameObject team = (GameObject)Instantiate(Team, new Vector2(Spawns.transform.position.x + 1.5f,Team.GetComponent<Unit>().Unit_Ypotion), Quaternion.identity);//임시로 0번을 소환
                Team_Tower.Cost = (Team_Tower.Cost - Team.GetComponent<Unit>().Base.Cost);
                cooltime = spawn_cooltime;//쿨 기준 초기화
                is_Spawn = false;
            }
         
        }
    }
}