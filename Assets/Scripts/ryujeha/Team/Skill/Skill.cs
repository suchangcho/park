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
    Team_Spawn team;
    void Start() {
        team = FindObjectOfType<Team_Spawn>();
        GameMgr.Input.key_action -= SkillS;
        GameMgr.Input.key_action += SkillS;
    }
    public GameObject boom;
    

    public void SkillS()
    {
        if(Input.GetKeyDown(KeyCode.Q)&& team.Cost >= 3)//1번 스킬이라면
        {
            For_Moon(1);
            team.Cost = team.Cost -3;
            for(int i =0; i<team.Cost_Img.Count;i++){
               Destroy(team.Cost_Img[i].gameObject);
            }
            team.Cost_Img.Clear();
        }
        else if(Input.GetKeyDown(KeyCode.W)&& team.Cost >= 2)//2번 스킬이라면
        {
            For_Moon(2);
            team.Cost = team.Cost -2;
            for(int i =0; i<2;i++){
               Destroy(team.Cost_Img[i].gameObject);
            }
            team.Cost_Img.RemoveRange(0,2);

        }
        else if(Input.GetKeyDown(KeyCode.E)&& team.Cost >= 1)//3번 스킬이라면
        {
            for(int i = 0; i< skill_Managers.Length; i++){
                if(skill_Managers[i].Skill_num == 3 ){
                    Debug.Log("스킬사용");
                    boom = Instantiate(skill_Managers[i].Skill.gameObject);
                    Ray();
                }
            }
            team.Cost = team.Cost -1;
            Destroy(team.Cost_Img[0]);
            team.Cost_Img.RemoveAt(0);
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
        SkillS();
    }

    public void Ray(){
            ray = new Vector3(0.5f, 0, 0);
            Debug.DrawRay(ray_start, ray * 35f, new Color(0, 1, 0));
            RaycastHit2D rayhit = Physics2D.Raycast(ray_start, ray, 35f, LayerMask.GetMask("Enemy"));
            if (rayhit.collider != null)
                {
                    if(rayhit.collider.gameObject.name != "Enemy_Tower"){
                        Mob_List.Add(rayhit.collider.gameObject);
                        Mob_List = Mob_List.Distinct().ToList();
                        for(int i =0; i<Mob_List.Count;i++){
                            if(Mob_List[i] == null){
                                Mob_List.RemoveAt(i);
                            }
                        } 
                    }
                            
                        
                }
            else
                {
                    Mob_List = null;
                }
            
        
    }
}
