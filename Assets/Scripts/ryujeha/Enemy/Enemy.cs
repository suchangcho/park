using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target_tower;//������ �̵��� ���� ���� ��ǥ��ġ�ޱ�.

    public Rigidbody2D myrigid;//���ʹ� ��ü�� ������ٵ�.

    public float Speed;//�󸶸�ŭ �ӵ��� �̵���ų���� ���� ����.
    public int Enemy_Atk;//���� ���ݷ�
    public float Enemy_Atk_cool;//�� ���� ��ٿ�
    public int Enemy_Atk_Speed;//���� ���ݼӵ�

    bool is_Attack;//���� ����(������ �ؾ��ϴ� ��� ���ڸ��� ���缭 �����ؾ��ϱ⶧����)

    public GameObject Target;//����ĳ��Ʈ���� ������ ��ü����.
    Vector3 ray;//�� ����ĳ��Ʈ�� ����.
    void Start()
    {
        target_tower = GameObject.FindWithTag("Team_tower").transform;//������ ��Ÿ������ �̵��ؾ��ϹǷ� ��Ÿ����ü�� ã�Ƽ� Ÿ������ ����.
    }

    // Update is called once per frame
    void Update()
    {
        Ray_Judgement();
        Move();
        Attack_cool();
    }
    void Ray_Judgement()
    {
        ray = new Vector3(-1, 0, 0);
        Debug.DrawRay(myrigid.position, ray * 2.5f, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(myrigid.position, ray, 2.5f,LayerMask.GetMask("Team"));

        if (rayhit.collider != null)
        {
            Target = rayhit.collider.gameObject;
            if (Target.gameObject.tag == "Team_tower")
            {
                Attack(Target);
            }
        }
        else
        {
            Target = null;
        }
    }
    void Move()
    {
        if (!is_Attack)
        {
            this.transform.position = Vector2.MoveTowards(transform.position,new Vector2(target_tower.position.x,-3),this.Speed * Time.deltaTime);//��ǥ��ġ�� y���� �������� �������� ���ư��⿡ 0���� ����
            //MoveTowards��(������ġ,��ǥ��ġ,�ӵ�)�̰� Tranlates��(����,�ӵ�)
        }
    }

    void Attack(GameObject Team_Tower)
    {
        is_Attack = true;
        if (Enemy_Atk_cool <= 0)//���� ��Ÿ���� ��ŸŸ�ӿ������� �� 0�ʰ� �Ǿ��ٸ�
        {
            Team_Tower.GetComponent<Tower>().Tower_Current_Hp -= Enemy_Atk;
            Enemy_Atk_cool = Enemy_Atk_Speed;//�� ���� �ʱ�ȭ <= �ٽ� 0�̵Ǹ� �� ����
        }
    }

    void Attack_cool()//��Ÿ�� ���� �Լ�.
    {
        Enemy_Atk_cool -= Time.deltaTime;//���� ��Ÿ�� ����
        if(Enemy_Atk_cool <= 0)//0���Ϸ� �������� 0���� ����
        {
            Enemy_Atk_cool = 0;
        }
    }
}
