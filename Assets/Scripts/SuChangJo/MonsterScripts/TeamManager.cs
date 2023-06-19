using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{
    public List<GameObject> monsterTeamData = new List<GameObject>();
    public Image myImages;
    public GameObject[] teamSlot;
    public void AddTeam()  //���� �߰�
    {
        
        
        monsterTeamData.Add(this.gameObject);//����Ʈ�� ������ �߰�
        int indexa = monsterTeamData.FindIndex(a => a == this.gameObject);
        myImages = this.gameObject.GetComponent<Image>();
        for (int i = 0; i < teamSlot.Length; i++)
        {
            if (teamSlot[i].GetComponent<teamSlot>().slotNumber == indexa)
            {
                teamSlot[i].GetComponent<teamSlot>().myImage = myImages;

            }
            else
            {
                Debug.Log("�̹� ����");
            }
        }

    }

}
