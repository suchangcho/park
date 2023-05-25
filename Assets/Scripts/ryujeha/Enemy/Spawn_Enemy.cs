using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    public GameObject Enemy;//받을 적 소 캐릭터 프리펩
    public GameObject Spawns;//스폰포인트들을 담을 배열변수

    public float spawn_cooltime;
    public float cooltime;
    private void Start()
    {
        cooltime = 1;
    }

    public void SpawnCool()
    {
        spawn_cooltime = 1;
        cooltime -= Time.deltaTime;
        if (cooltime <= 0)
        {
            cooltime -= Time.deltaTime;
            Spawn_Enemys();
            cooltime = spawn_cooltime;
        }
    }

    private void Update()
    {
        SpawnCool();
    }
    void Spawn_Enemys()
    {
            GameObject enemy = (GameObject)Instantiate(Enemy, new Vector2(Spawns.transform.position.x-1.5f,-3), Quaternion.identity);
    }
}
