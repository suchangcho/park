using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Team_Spawn : MonoBehaviour
{
    public GameObject[] Team;//���� �� ĳ���� ������
    public GameObject Spawns;//��������Ʈ�� ���� ����

    public float spawn_cooltime;//��Ÿ�� ���� ����
    public float cooltime;//���� ��Ÿ�� ����

    bool is_Spawn = false;//���Ѽ�ȯ�� �Ǹ� �ȵǹǷ�, ��ȯ�� �Ҷ� �ణ�� ��Ÿ���� �ֱ����� ����
    // Start is called before the first frame update
    // Update is called once per frame
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
            GameObject team = (GameObject)Instantiate(Team[0], new Vector2(Spawns.transform.position.x + 1.5f, -3.7f), Quaternion.identity);//�ӽ÷� 0���� ��ȯ
            cooltime = spawn_cooltime;//�� ���� �ʱ�ȭ
            is_Spawn = false;
        }
    }
}
