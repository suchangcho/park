using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator mob_anim;//���ʹ��� ���ϸ����� ���� �ٸ��� �־������.

    Transform target_tower;//������ �̵��� ���� ���� ��ǥ��ġ�ޱ�.

    public Rigidbody2D myrigid;//���ʹ� ��ü�� ������ٵ�.

    public int Mob_HP;//���� ü��.
    public float Speed;//�󸶸�ŭ �ӵ��� �̵���ų���� ���� ����.
    public int Mob_Atk;//���� ���ݷ�
    public float Mob_Atk_cool;//�� ���� ��ٿ�
    public int Mob_Atk_Speed;//���� ���ݼӵ�

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
        Dead();
        Ray_Judgement();
        Move();
        Attack_cool();
    }
    void Ray_Judgement()
    {
        ray = new Vector3(-1, 0, 0);
        Debug.DrawRay(myrigid.position, ray * 1f, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(myrigid.position, ray, 1f,LayerMask.GetMask("Team"));

        if (rayhit.collider != null)
        {
            Target = rayhit.collider.gameObject;
            Attack(Target);
            
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
            this.transform.position = Vector2.MoveTowards(transform.position,new Vector2(target_tower.position.x,-3.7f),this.Speed * Time.deltaTime);//��ǥ��ġ�� y���� �������� �������� ���ư��⿡ 0���� ����
            //MoveTowards��(������ġ,��ǥ��ġ,�ӵ�)�̰� Tranlates��(����,�ӵ�)
        }
    }

    void Attack(GameObject Team)
    {
        is_Attack = true;
        if (Mob_Atk_cool <= 0)//���� ��Ÿ���� ��ŸŸ�ӿ������� �� 0�ʰ� �Ǿ��ٸ�
        {
            if(Team.gameObject.tag == "Team_tower")
            {
                mob_anim.SetTrigger("Attack");//�ִϸ��̼� ȣ��.
                Team.GetComponent<Tower>().Tower_Current_Hp -= Mob_Atk;//�ε��� Ÿ������ Ÿ�� ��ũ��Ʈ�� ������ HP�� ���ݷ¸�ŭ �����.
                is_Attack = false;
                Mob_Atk_cool = Mob_Atk_Speed;//�� ���� �ʱ�ȭ <= �ٽ� 0�̵Ǹ� �� ����
                
            }
        else if (Team.gameObject.tag == "Team_Unit")
            {
                mob_anim.SetTrigger("Attack");//�ִϸ��̼� ȣ��.
                Team.GetComponent<Team_Unit>().Unit_HP -= Mob_Atk;//�ε��� Ÿ������ Ÿ�� ��ũ��Ʈ�� ������ HP�� ���ݷ¸�ŭ �����.
                is_Attack = false;
                Mob_Atk_cool = Mob_Atk_Speed;//�� ���� �ʱ�ȭ <= �ٽ� 0�̵Ǹ� �� ����
                
            }
        }
    }

    void Attack_cool()//��Ÿ�� ���� �Լ�.
    {
        Mob_Atk_cool -= Time.deltaTime;//���� ��Ÿ�� ����
        if(Mob_Atk_cool <= 0)//0���Ϸ� �������� 0���� ����
        {
            Mob_Atk_cool = 0;
        }
    }

    void Dead()
    {
        if(Mob_HP <= 0)//���� ü���� 0���� �������ԵǸ�.
        {
            //mob_anim.SetTrigger("Dead");
            Destroy(this.gameObject);
        }
    }
}
