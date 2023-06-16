using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Animator Unit_anim;//에너미의 에니메이터 각각 다르게 넣어줘야함.
    
   public Transform team_target_tower;//어디까지 이동할 지에 대한 목표위치받기.
   public Transform Mob_target_tower;
    public Rigidbody2D myrigid;// 객체의 리지드바디.

    public int Unit_HP;//적의 체력.
    public float Speed;//얼마만큼 속도로 이동시킬지에 대한 변수.
    public int Unit_Atk;//적의 공격력
    [SerializeField] float Unit_Atk_cool;//적 공속 쿨다운
    public int Unit_Atk_Speed;//적의 공격속도 기준

   public bool is_Attack;//공격 여부(공격을 해야하는 경우 제자리의 멈춰서 공격해야하기때문에)
   public bool is_stop;

   public bool is_Half;//맵의 반을 넘었는가를 판단하는 변수
    public GameObject Target;//레이캐스트에서 감지할 객체변수.
    Vector3 ray;//쏠 레이캐스트의 방향.
    Transform Half_Line;
    void Start()
    {
        team_target_tower = GameObject.FindWithTag("Enemy_Tower").transform;//적군은 팀타워까지 이동해야하므로 팀타워객체를 찾아서 타겟으로 지정.
        Mob_target_tower = GameObject.FindWithTag("Team_tower").transform;//적군은 팀타워까지 이동해야하므로 팀타워객체를 찾아서 타겟으로 지정.
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
        if(gameObject.transform.position.x <= 0){
            is_Half = true;
        }
        else if(gameObject.transform.position.x >= 0){
            is_Half = false;
        }
        if(!is_stop){
            is_Attack = false;
        }
        else{
            is_Attack = true;
        }
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
                    if(rayhit.collider.gameObject.tag == "Enemy"){
                        Target = rayhit.collider.gameObject;
                        Attack(Target);
                    }
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
                this.transform.position = Vector2.MoveTowards(transform.position, new Vector2(team_target_tower.position.x, -3.7f), this.Speed * Time.deltaTime);//목표위치에 y값은 가져오면 공중으로 날아가기에 0으로 고정
                //MoveTowards는(시작위치,목표위치,속도)이고 Tranlates는(방향,속도)
                }
           else if(this.gameObject.tag == "Enemy"){
                this.transform.position = Vector2.MoveTowards(transform.position, new Vector2(Mob_target_tower.position.x, -3.7f), this.Speed * Time.deltaTime);//목표위치에 y값은 가져오면 공중으로 날아가기에 0으로 고정
                //MoveTowards는(시작위치,목표위치,속도)이고 Tranlates는(방향,속도)
                }
        }
    }

    void Attack(GameObject Enemy)
    {
        is_Attack = true;
        if(this.gameObject.tag == "Enemy"){
              if (Unit_Atk_cool <= 0)//만약 쿨타임이 델타타임에서부터 깎여 0초가 되었다면
            {
                if (Enemy.gameObject.tag == "Team_tower")
                {
                    Unit_anim.SetTrigger("Attack");//애니매이션 호출.
                    Enemy.GetComponent<Tower>().Tower_Current_Hp -= Unit_Atk;//부딧힌 타워에서 타워 스크립트에 접근해 HP를 공격력만큼 깍아줌.
                    Unit_Atk_cool = Unit_Atk_Speed;//쿨 기준 초기화 <= 다시 0이되면 적 공격
                }
                else if (Enemy.gameObject.tag == "Team_Unit")
                {
                    Unit_anim.SetTrigger("Attack");//애니매이션 호출.
                    Enemy.GetComponent<Unit>().Unit_HP -= Unit_Atk;//부딧힌 타워에서 타워 스크립트에 접근해 HP를 공격력만큼 깍아줌.
                    Unit_Atk_cool = Unit_Atk_Speed;//쿨 기준 초기화 <= 다시 0이되면 적 공격
                }
            }
        }
        else if(this.gameObject.tag == "Team_Unit"){
             if (Unit_Atk_cool <= 0)//만약 쿨타임이 델타타임에서부터 깎여 0초가 되었다면
            {
                if (Enemy.gameObject.tag == "Enemy_Tower")
                {
                    Unit_anim.SetTrigger("Attack");//애니매이션 호출.
                    Enemy.GetComponent<Tower>().Tower_Current_Hp -= Unit_Atk;//부딧힌 타워에서 타워 스크립트에 접근해 HP를 공격력만큼 깍아줌.
                    Unit_Atk_cool = Unit_Atk_Speed;//쿨 기준 초기화 <= 다시 0이되면 적 공격
                }
                else if (Enemy.gameObject.tag == "Enemy")
                {
                Unit_anim.SetTrigger("Attack");//애니매이션 호출.
                Enemy.GetComponent<Unit>().Unit_HP -= Unit_Atk;//부딧힌 타워에서 타워 스크립트에 접근해 HP를 공격력만큼 깍아줌.
                Unit_Atk_cool = Unit_Atk_Speed;//쿨 기준 초기화 <= 다시 0이되면 적 공격
                }
            }
        }
       
    }

    void Attack_cool()//쿨타임 연산 함수.
    {
        Unit_Atk_cool -= Time.deltaTime;//실제 쿨타임 연산
        if (Unit_Atk_cool <= 0)//0이하로 내려가면 0으로 고정
        {
            Unit_Atk_cool = 0;
        }
    }

   public void Dead()
    {
        if (Unit_HP <= 0)//적의 체력이 0으로 내려가게되면.
        {
           //Unit_anim.SetTrigger("Dead");
            Destroy(this.gameObject);
        }
    }
}
