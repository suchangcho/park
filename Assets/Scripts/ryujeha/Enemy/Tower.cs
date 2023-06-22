using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class Tower : MonoBehaviour
{
    public GameObject Clear_Screen;
    public GameObject Gameover_Screen;
    public int Tower_MaxHp;//타워의 최대목숨
    public int Tower_Current_Hp;//타워의 현재목숨

    public Text Hp_Txt;//hp를 표현할 텍스트 
    
    private void Start()
    {
        Time.timeScale = 1f;
        Tower_Current_Hp = Tower_MaxHp;
    }
    void Update()
    {
        Set_Hp();
    }
    void Set_Hp()
    {
        Hp_Txt.text = Tower_Current_Hp.ToString() + "/" + Tower_MaxHp.ToString();
        if(this.gameObject.tag =="Enemy_Tower"){
            if(Tower_Current_Hp <= 3000 && this.GetComponent<Spawn_Enemy>().boss_Spawning == false){
                this.GetComponent<Spawn_Enemy>().Boss_Spawn();
            }
            if(Tower_Current_Hp <= 0){//게임 클리어했을경우
                Time.timeScale = 0f;
                Clear_Screen.gameObject.SetActive(true);
                GameMgr.Instance.GachaMoney += 10000;
                GameMgr.Instance.PowerMoney += 10000;
            }  
        }
        else if(this.gameObject.tag =="Team_tower"){
            if(Tower_Current_Hp <= 0){//게임 오버했을경우
                Time.timeScale = 0f;
                Gameover_Screen.gameObject.SetActive(true);
            }  
        }
    }

    public void Next_Stage(int NEXT_SCENE_num){
        SceneManager.LoadScene(NEXT_SCENE_num);
    }
    public void Re_Start(int current_Scene_NUm){
        SceneManager.LoadScene(current_Scene_NUm);
    }

    public void Quit_Stage(){
        SceneManager.LoadScene("Main screen");
    }
}
