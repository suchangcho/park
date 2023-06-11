using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] Skill_Manager[] skill_Managers;

    void Start() {
        GameMgr.Input.key_action -= SkillS;
        GameMgr.Input.key_action += SkillS;
    }

    public void SkillS()
    {
        for(int i = 0; i < skill_Managers.Length; i++){
            if(Input.GetKeyDown(KeyCode.Q)&& skill_Managers[i].Skill_num == 1  )//1번 스킬이라면
            {
                Debug.Log("스킬사용");
                skill_Managers[i].Skill.gameObject.SetActive(true);
                if(skill_Managers[i].anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f){
                    Destroy(skill_Managers[i].Skill);
                }
            }
            else if(skill_Managers[i].Skill_num == 2&& Input.GetKeyDown(KeyCode.W))//1번 스킬이라면
            {
                skill_Managers[i].Skill.gameObject.SetActive(true);
                if(skill_Managers[i].anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 4.0f){
                    Destroy(skill_Managers[i].Skill);
                }
            }
            else if(skill_Managers[i].Skill_num == 3&& Input.GetKeyDown(KeyCode.E))//1번 스킬이라면
            {
                skill_Managers[i].Skill.gameObject.SetActive(true);
            }
            
        }
    } 
}
