using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GachaCard
{
    public string grade;     //���
    public int weight;       //����ġ
    public int cardCount;    //ī�� �ߺ� ����
    public string cardName;  //�̸�
    public Sprite cardImage; //�̹���

    public override string ToString()
    {
        return cardName + " �ߺ� ���� : " + cardCount.ToString();
    } 
}
