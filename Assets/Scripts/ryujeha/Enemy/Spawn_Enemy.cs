using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    public GameObject Enemy;//���� �� �� ĳ���� ������
    public GameObject Spawns;//��������Ʈ���� ���� �迭����

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
            GameObject enemy = (GameObject)Instantiate(Enemy, new Vector2(Spawns.transform.position.x-1.5f,-3), Quaternion.identity);
            //���͸� Ÿ�� �տ��� ��ȯ�ϰ� Ÿ���� �Ʒ��ʿ��� ������ �ϱ����� ������� ������.
    }
}
