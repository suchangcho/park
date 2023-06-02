using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GachaUI : MonoBehaviour
{
    public Image cardImage;     // ī�� �̹��� ǥ��
    public Text cardGradeText;  // ī�� ��� ǥ��
    public Text cardNameText;   // ī�� �̸� ǥ��

    public void SetCardInfo(GachaCard card)
    {
        cardImage.sprite = card.cardImage; // �̹��� ����
        cardGradeText.text = card.grade;   // ��� ����
        cardNameText.text = card.cardName; // �̸� ����
    }
}
