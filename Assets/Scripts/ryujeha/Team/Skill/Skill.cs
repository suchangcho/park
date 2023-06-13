using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Skill : MonoBehaviour
{
    [SerializeField] Skill_Manager[] skill_Managers;

   [SerializeField] public List<GameObject> Mob_List= new List<GameObject>();//적들을 담을 정렬 후 리스트
     Vector2 ray_start =new Vector2(-8.7f,-3.7f);
    Vector3 ray;//쏠 레이캐스트의 방향.
    void Start() {
        GameMgr.Input.key_action -= SkillS;
        GameMgr.Input.key_action += SkillS;
    }

    

    public void SkillS()
    {
        if(Input.GetKeyDown(KeyCode.Q))//1번 스킬이라면
        {
            For_Moon(1);
        }
        else if(Input.GetKeyDown(KeyCode.W))//2번 스킬이라면
        {
            For_Moon(2);
        }
        else if(Input.GetKeyDown(KeyCode.E))//3번 스킬이라면
        {
               For_Moon(3);
        }
    } 
    public void For_Moon(int _i){
     for(int i = 0; i< skill_Managers.Length; i++){
        if(skill_Managers[i].Skill_num == _i ){
            Debug.Log("스킬사용");
            skill_Managers[i].Skill.gameObject.SetActive(true);
                }
            }
    }
    void Update(){
        Ray();
        SkillS();
    }

    void Ray(){
             ray = new Vector3(0.5f, 0, 0);
            Debug.DrawRay(ray_start, ray * 35f, new Color(0, 1, 0));
            RaycastHit2D rayhit = Physics2D.Raycast(ray_start, ray, 35f, LayerMask.GetMask("Enemy"));
            if (rayhit.collider != null)
                {
                    Mob_List.Add(rayhit.collider.gameObject);
                    Mob_List = Mob_List.Distinct().ToList();
                }
            else
                {
                    Mob_List = null;
                }
            
        
    }
}
