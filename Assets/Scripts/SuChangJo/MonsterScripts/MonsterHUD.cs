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
    public Text hpText;
    public Text attackText;
    public Text powerMoney;
    //public Text PowerUpMoneyText;

    public void Update()
    {
        SetData(monsterUnit);
        //PowerUpMoneyText.text = GameMgr.Instance.PowerMoney.ToString();
    }

    // Update is called once per frame
    public void SetData(MonsterUnit monsterUnit)
    {
        nameText.text = monsterUnit._base.name; //모니터
        levelText.text = "Lvl " + monsterUnit.level;//레벨
        hpText.text = "HP :" + monsterUnit.MaxHP;//체력
        attackText.text = "Attack :" + monsterUnit.Attack;//공격
        powerMoney.text = "강화비용 :" + GameMgr.Instance.PowerMoney;//강화비용 
    }

}
