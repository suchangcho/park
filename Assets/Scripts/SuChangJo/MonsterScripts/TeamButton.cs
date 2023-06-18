using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TeamButton : MonoBehaviour
{
    public TeamManager TM;
    public Image myImages;
    public int indexa;
    private void Start()
    {
        TM = FindObjectOfType<TeamManager>();
    }
    public void AddTeam()  //���� �߰�
    {


        TM.monsterTeamData.Add(this.gameObject);//����Ʈ�� ������ �߰�
        indexa = TM.monsterTeamData.FindIndex(a => a == this.gameObject);
        myImages = this.gameObject.GetComponent<Image>();
        for (int i = 0; i < TM.teamSlot.Length; i++)
        {
            if (TM.teamSlot[i].GetComponent<teamSlot>().slotNumber == indexa)
            {
                TM.teamSlot[i].GetComponent<teamSlot>().myImage = myImages;

            }
            else
            {
                Debug.Log("�̹� ����");
            }
        }

    }
}
