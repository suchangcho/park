using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public Animator Unit_anim;//���ʹ��� ���ϸ����� ���� �ٸ��� �־������.
    
    Transform team_target_tower;//������ �̵��� ���� ���� ��ǥ��ġ�ޱ�.
    Transform Mob_target_tower;
    public Rigidbody2D myrigid;//���ʹ� ��ü�� ������ٵ�.

    public int Unit_HP;//���� ü��.
    public float Speed;//�󸶸�ŭ �ӵ��� �̵���ų���� ���� ����.
    public int Unit_Atk;//���� ���ݷ�
    public float Unit_Atk_cool;//�� ���� ��ٿ�
    public int Unit_Atk_Speed;//���� ���ݼӵ� ����

    bool is_Attack;//���� ����(������ �ؾ��ϴ� ��� ���ڸ��� ���缭 �����ؾ��ϱ⶧����)

    public GameObject Target;//����ĳ��Ʈ���� ������ ��ü����.
    Vector3 ray;//�� ����ĳ��Ʈ�� ����.
    void Start()
    {
        team_target_tower = GameObject.FindWithTag("Enemy_Tower").transform;//������ ��Ÿ������ �̵��ؾ��ϹǷ� ��Ÿ����ü�� ã�Ƽ� Ÿ������ ����.
        Mob_target_tower = GameObject.FindWithTag("Team_tower").transform;//������ ��Ÿ������ �̵��ؾ��ϹǷ� ��Ÿ����ü�� ã�Ƽ� Ÿ������ ����.
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
            is_Attack = false;
            if(this.gameObject.tag == "Enemy"){
                ray = new Vector3(-0.5f, 0, 0);
                Debug.DrawRay(myrigid.position, ray * -0.5f, new Color(0, 1, 0));
                RaycastHit2D rayhit = Physics2D.Raycast(myrigid.position, ray, 0.5f,LayerMask.GetMask("Team"));
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
            else if(this.gameObject.tag == "Team_Unit"){
                ray = new Vector3(0.5f, 0, 0);
                Debug.DrawRay(myrigid.position, ray * 0.5f, new Color(0, 1, 0));
                RaycastHit2D rayhit = Physics2D.Raycast(myrigid.position, ray, 0.5f, LayerMask.GetMask("Enemy"));
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
    }
    void Move()
    {
        if (!is_Attack)
        {   if(this.gameObject.tag == "Team_Unit"){
                this.transform.position = Vector2.MoveTowards(transform.position, new Vector2(team_target_tower.position.x, -3.7f), this.Speed * Time.deltaTime);//��ǥ��ġ�� y���� �������� �������� ���ư��⿡ 0���� ����
                //MoveTowards��(������ġ,��ǥ��ġ,�ӵ�)�̰� Tranlates��(����,�ӵ�)
                }
           else if(this.gameObject.tag == "Enemy"){
                this.transform.position = Vector2.MoveTowards(transform.position, new Vector2(Mob_target_tower.position.x, -3.7f), this.Speed * Time.deltaTime);//��ǥ��ġ�� y���� �������� �������� ���ư��⿡ 0���� ����
                //MoveTowards��(������ġ,��ǥ��ġ,�ӵ�)�̰� Tranlates��(����,�ӵ�)
                }
        }
    }

    void Attack(GameObject Enemy)
    {
        is_Attack = true;
        if(this.gameObject.tag == "Enemy"){
              if (Unit_Atk_cool <= 0)//���� ��Ÿ���� ��ŸŸ�ӿ������� �� 0�ʰ� �Ǿ��ٸ�
            {
                if (Enemy.gameObject.tag == "Team_tower")
                {
                    Unit_anim.SetTrigger("Attack");//�ִϸ��̼� ȣ��.
                    Enemy.GetComponent<Tower>().Tower_Current_Hp -= Unit_Atk;//�ε��� Ÿ������ Ÿ�� ��ũ��Ʈ�� ������ HP�� ���ݷ¸�ŭ �����.
                    Unit_Atk_cool = Unit_Atk_Speed;//�� ���� �ʱ�ȭ <= �ٽ� 0�̵Ǹ� �� ����
                }
                else if (Enemy.gameObject.tag == "Team_Unit")
                {
                    Unit_anim.SetTrigger("Attack");//�ִϸ��̼� ȣ��.
                    Enemy.GetComponent<Unit>().Unit_HP -= Unit_Atk;//�ε��� Ÿ������ Ÿ�� ��ũ��Ʈ�� ������ HP�� ���ݷ¸�ŭ �����.
                    Unit_Atk_cool = Unit_Atk_Speed;//�� ���� �ʱ�ȭ <= �ٽ� 0�̵Ǹ� �� ����
                }
            }
        }
        else if(this.gameObject.tag == "Team_Unit"){
             if (Unit_Atk_cool <= 0)//���� ��Ÿ���� ��ŸŸ�ӿ������� �� 0�ʰ� �Ǿ��ٸ�
            {
                if (Enemy.gameObject.tag == "Enemy_Tower")
                {
                    Unit_anim.SetTrigger("Attack");//�ִϸ��̼� ȣ��.
                    Enemy.GetComponent<Tower>().Tower_Current_Hp -= Unit_Atk;//�ε��� Ÿ������ Ÿ�� ��ũ��Ʈ�� ������ HP�� ���ݷ¸�ŭ �����.
                    Unit_Atk_cool = Unit_Atk_Speed;//�� ���� �ʱ�ȭ <= �ٽ� 0�̵Ǹ� �� ����
                }
                else if (Enemy.gameObject.tag == "Enemy")
                {
                Unit_anim.SetTrigger("Attack");//�ִϸ��̼� ȣ��.
                Enemy.GetComponent<Unit>().Unit_HP -= Unit_Atk;//�ε��� Ÿ������ Ÿ�� ��ũ��Ʈ�� ������ HP�� ���ݷ¸�ŭ �����.
                Unit_Atk_cool = Unit_Atk_Speed;//�� ���� �ʱ�ȭ <= �ٽ� 0�̵Ǹ� �� ����
                }
            }
        }
       
    }

    void Attack_cool()//��Ÿ�� ���� �Լ�.
    {
        Unit_Atk_cool -= Time.deltaTime;//���� ��Ÿ�� ����
        if (Unit_Atk_cool <= 0)//0���Ϸ� �������� 0���� ����
        {
            Unit_Atk_cool = 0;
        }
    }

    void Dead()
    {
        if (Unit_HP <= 0)//���� ü���� 0���� �������ԵǸ�.
        {
           //Unit_anim.SetTrigger("Dead");
            Destroy(this.gameObject);
        }
    }
}
