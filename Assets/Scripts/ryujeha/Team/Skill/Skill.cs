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
        if(Input.GetKeyDown(KeyCode.Q))//1�� ��ų�̶��
        {
            For_Moon(1);
        }
        else if(Input.GetKeyDown(KeyCode.W))//2�� ��ų�̶��
        {
            For_Moon(2);
        }
        else if(Input.GetKeyDown(KeyCode.E))//3�� ��ų�̶��
        {
               For_Moon(3);
        }
    } 
    public void For_Moon(int _i){
     for(int i = 0; i< skill_Managers.Length; i++){
        if(skill_Managers[i].Skill_num == _i ){
            Debug.Log("��ų���");
            skill_Managers[i].Skill.gameObject.SetActive(true);
                }
            }
    }
    void Update(){
        SkillS();
    }
}
