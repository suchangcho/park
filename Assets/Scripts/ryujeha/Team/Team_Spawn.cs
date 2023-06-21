using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Team_Spawn : MonoBehaviour
{
    public GameObject Team;//���� ĳ���� ������
    public GameObject Spawns;//��������Ʈ�� ���� ����

    public float spawn_cooltime;//��Ÿ�� ���� ����
    public float cooltime;//���� ��Ÿ�� ����

    bool is_Spawn = false;//���Ѽ�ȯ�� �Ǹ� �ȵǹǷ�, ��ȯ�� �Ҷ� �ణ�� ��Ÿ���� �ֱ����� ����

    void Update()
    {
        SpawnCool();
    }
    public void SpawnCool()
    {
        cooltime -= Time.deltaTime;//���� ��Ÿ�� ����
        if (cooltime <= 0)//���� ��Ÿ���� ��ŸŸ�ӿ������� �� 0�ʰ� �Ǿ��ٸ�
        {
            is_Spawn = true;
            cooltime = 0;
        }
    }
    public void Spawn_Team()
    {
        if (is_Spawn)
        {
            GameObject team = (GameObject)Instantiate(Team, new Vector2(Spawns.transform.position.x + 1.5f,Team.GetComponent<Unit>().Unit_Ypotion), Quaternion.identity);//�ӽ÷� 0���� ��ȯ
            cooltime = spawn_cooltime;//�� ���� �ʱ�ȭ
            is_Spawn = false;
        }
    }
}