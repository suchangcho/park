using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    public GameObject[] Enemys;//���� �� ĳ���� ������
    public GameObject Spawns;//��������Ʈ�� ���� ����

    public float spawn_cooltime;//��Ÿ�� ���� ����
    public float cooltime;//���� ��Ÿ�� ����
    public void SpawnCool()
    {
        cooltime -= Time.deltaTime;//���� ��Ÿ�� ����
        if (cooltime <= 0)//���� ��Ÿ���� ��ŸŸ�ӿ������� �� 0�ʰ� �Ǿ��ٸ�
        {
            Spawn_Enemys();//�� ��ȯ
            cooltime = spawn_cooltime;//�� ���� �ʱ�ȭ <= �ٽ� 0�̵Ǹ� �� ����
        }
    }

    private void Update()
    {
        SpawnCool();
    }
    void Spawn_Enemys()
    {
        int mob_num = Random.Range(0,Enemys.Length);
        GameObject enemy = (GameObject)Instantiate(Enemys[mob_num], new Vector2(Spawns.transform.position.x-1.5f,Enemys[mob_num].GetComponent<Unit>().Unit_Ypotion), Quaternion.identity);
        //���͸� Ÿ�� �տ��� ��ȯ�ϰ� Ÿ���� �Ʒ��ʿ��� ������ �ϱ����� ������� ������.
    }
}
