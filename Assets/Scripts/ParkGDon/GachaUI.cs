using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GachaUI : MonoBehaviour
{
    public Image cardImage;     // 카드 이미지 표시
    public Text cardGradeText;  // 카드 등급 표시
    public Text cardNameText;   // 카드 이름 표시

    public void SetCardInfo(GachaCard card)
    {
        cardImage.sprite = card.cardImage; // 이미지 설정
        cardGradeText.text = card.grade;   // 등급 설정
        cardNameText.text = card.cardName; // 이름 설정
    }
}
