using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Team_Spawn : MonoBehaviour
{
    public GameObject[] Team;//받을 적 캐릭터 프리펩
    public GameObject Spawns;//스폰포인트를 담을 변수

    public float spawn_cooltime;//쿨타임 기준 설정
    public float cooltime;//실제 쿨타임 연산

    bool is_Spawn = false;//무한소환이 되면 안되므로, 소환을 할때 약간의 쿨타임을 주기위한 변수
    // Start is called before the first frame update
    // Update is called once per frame
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
            GameObject team = (GameObject)Instantiate(Team[0], new Vector2(Spawns.transform.position.x + 1.5f, -3.7f), Quaternion.identity);//임시로 0번을 소환
            cooltime = spawn_cooltime;//쿨 기준 초기화
            is_Spawn = false;
        }
    }
}
