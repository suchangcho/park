using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    Text gachaMoney;
    void Start()
    {
        gachaMoney = GetComponent<Text>();
    }

    void Update()
    {
        gachaMoney.text = GameMgr.Instance.GachaMoney.ToString();
    }
}
