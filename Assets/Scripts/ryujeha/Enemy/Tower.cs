using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tower : MonoBehaviour
{
    public int Tower_MaxHp;//Ÿ���� �ִ���
    public int Tower_Current_Hp;//Ÿ���� ������

    public int hp;

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
        
    }
}
