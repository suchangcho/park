using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tower : MonoBehaviour
{
    public int Tower_MaxHp;//타워의 최대목숨
    public int Tower_Current_Hp;//타워의 현재목숨

    public int hp;

    public Text Hp_Txt;//hp를 표현할 텍스트 
    
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
        
    }
}
