using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    public GameObject Enemy;//받을 적 소 캐릭터 프리펩
    public GameObject Spawns;//스폰포인트들을 담을 배열변수

    public float spawn_cooltime;//쿨타임 기준 설정
    public float cooltime;//실제 쿨타임 연산
    public void SpawnCool()
    {
        cooltime -= Time.deltaTime;//실제 쿨타임 연산
        if (cooltime <= 0)//만약 쿨타임이 델타타임에서부터 깎여 0초가 되었다면
        {
            Spawn_Enemys();//적 소환
            cooltime = spawn_cooltime;//쿨 기준 초기화 <= 다시 0이되면 적 스폰
        }
    }

    private void Update()
    {
        SpawnCool();
    }
    void Spawn_Enemys()
    {
            GameObject enemy = (GameObject)Instantiate(Enemy, new Vector2(Spawns.transform.position.x-1.5f,-3), Quaternion.identity);
            //몬스터를 타워 앞에서 소환하고 타워의 아래쪽에서 나오게 하기위해 상수값을 더해줌.
    }
}
