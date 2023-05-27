using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target_tower;//어디까지 이동할 지에 대한 목표위치받기.

    public Rigidbody2D myrigid;//에너미 객체의 리지드바디.

    public float Speed;//얼마만큼 속도로 이동시킬지에 대한 변수.
    public int Enemy_Atk;//적의 공격력
    public float Enemy_Atk_cool;//적 공속 쿨다운
    public int Enemy_Atk_Speed;//적의 공격속도

    bool is_Attack;//공격 여부(공격을 해야하는 경우 제자리의 멈춰서 공격해야하기때문에)

    public GameObject Target;//레이캐스트에서 감지할 객체변수.
    Vector3 ray;//쏠 레이캐스트의 방향.
    void Start()
    {
        target_tower = GameObject.FindWithTag("Team_tower").transform;//적군은 팀타워까지 이동해야하므로 팀타워객체를 찾아서 타겟으로 지정.
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
            this.transform.position = Vector2.MoveTowards(transform.position,new Vector2(target_tower.position.x,-3),this.Speed * Time.deltaTime);//목표위치에 y값은 가져오면 공중으로 날아가기에 0으로 고정
            //MoveTowards는(시작위치,목표위치,속도)이고 Tranlates는(방향,속도)
        }
    }

    void Attack(GameObject Team_Tower)
    {
        is_Attack = true;
        if (Enemy_Atk_cool <= 0)//만약 쿨타임이 델타타임에서부터 깎여 0초가 되었다면
        {
            Team_Tower.GetComponent<Tower>().Tower_Current_Hp -= Enemy_Atk;
            Enemy_Atk_cool = Enemy_Atk_Speed;//쿨 기준 초기화 <= 다시 0이되면 적 공격
        }
    }

    void Attack_cool()//쿨타임 연산 함수.
    {
        Enemy_Atk_cool -= Time.deltaTime;//실제 쿨타임 연산
        if(Enemy_Atk_cool <= 0)//0이하로 내려가면 0으로 고정
        {
            Enemy_Atk_cool = 0;
        }
    }
}
