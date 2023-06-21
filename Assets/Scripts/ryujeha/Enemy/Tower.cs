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
    public int Tower_MaxHp;//Ÿ���� �ִ���
    public int Tower_Current_Hp;//Ÿ���� ������

    public Text Hp_Txt;//hp�� ǥ���� �ؽ�Ʈ 
    
    private void Start()
    {
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
            if(Tower_Current_Hp <= 0){//���� Ŭ�����������
                Time.timeScale = 0.001f;
                Clear_Screen.gameObject.SetActive(true);
            }  
        }
        else if(this.gameObject.tag =="Team_tower"){
            if(Tower_Current_Hp <= 0){//���� �����������
                Time.timeScale = 0.001f;
                Gameover_Screen.gameObject.SetActive(true);
            }  
        }
    }

    public void Next_Stage(){

    }
    public void Re_Start(){
        
    }

    public void Quit_Stage(){

    }
}
