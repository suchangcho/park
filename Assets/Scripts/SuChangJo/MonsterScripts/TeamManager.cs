using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{
    public MonsterBase MB;
    public teamSlot tS;
    public Image TestImage; //������ �����ϴ� �̹���
    public void addTeam()
    {
        TestImage.sprite = MB.monster; 
    }





}
