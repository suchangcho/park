using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mon : MonoBehaviour
{
    public Text PowerUpMoneyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpMoneyText.text = GameMgr.Instance.PowerMoney.ToString() + "¿ø";
    }
}
