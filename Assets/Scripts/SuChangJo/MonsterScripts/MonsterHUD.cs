using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHUD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text nameText;
    public Text levelText;
    public MonsterUnit monsterUnit;
    //public Text PowerUpMoneyText;

    public void Update()
    {
        SetData(monsterUnit);
        //PowerUpMoneyText.text = GameMgr.Instance.PowerMoney.ToString();
    }

    // Update is called once per frame
    public void SetData(MonsterUnit monsterUnit)
    {
        nameText.text = monsterUnit._base.name; //¸ð´ÏÅÍ
        levelText.text = "Lvl " + monsterUnit.level;
    }

}
