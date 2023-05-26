using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target_tower;//������ �̵��� ���� ���� ��ǥ��ġ�ޱ�.

    public float Speed;//�󸶸�ŭ �ӵ��� �̵���ų���� ���� ����.
    public int Enemy_Atk;//���� ���ݷ�
    public float Enemy_Atk_cool;//�� ���� ��ٿ�
    public int Enemy_Atk_Speed;//���� ���ݼӵ�

    bool is_Attack;//���� ����(������ �ؾ��ϴ� ��� ���ڸ��� ���缭 �����ؾ��ϱ⶧����)

    Tower tower;

    

    void Start()
    {
        target_tower = GameObject.FindWithTag("Team_tower").transform;//������ ��Ÿ������ �̵��ؾ��ϹǷ� ��Ÿ����ü�� ã�Ƽ� Ÿ������ ����.
        tower = FindObjectOfType<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack_cool();
    }

    void Move()
    {
        if (!is_Attack)
        {
            this.transform.position = Vector2.MoveTowards(transform.position,new Vector2(target_tower.position.x,-3),this.Speed * Time.deltaTime);//��ǥ��ġ�� y���� �������� �������� ���ư��⿡ 0���� ����
            //MoveTowards��(������ġ,��ǥ��ġ,�ӵ�)�̰� Tranlates��(����,�ӵ�)
        }
    }

    private void OnTriggerStay2D(Collider2D collision)//�� �κ� ����ĳ��Ʈ�� ��°����� ��������.
    {
        if(collision.gameObject.tag == "Team_tower")
        {
            Attack(collision);
        }
    }


    void Attack(Collider2D Team_Tower)
    {
        is_Attack = true;
        if (Enemy_Atk_cool <= 0)//���� ��Ÿ���� ��ŸŸ�ӿ������� �� 0�ʰ� �Ǿ��ٸ�
        {
            Team_Tower.GetComponent<Tower>().Tower_Current_Hp -= Enemy_Atk;
            Enemy_Atk_cool = Enemy_Atk_Speed;//�� ���� �ʱ�ȭ <= �ٽ� 0�̵Ǹ� �� ����
        }
    }

    void Attack_cool()
    {
        Enemy_Atk_cool -= Time.deltaTime;//���� ��Ÿ�� ����
        if(Enemy_Atk_cool <= 0)
        {
            Enemy_Atk_cool = 0;
        }
    }
}
