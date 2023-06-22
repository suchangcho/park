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
    public Text powerM;
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
        powerM.text = "강화비용 :" + monsterUnit.PowerM;//강화비용
        powerMoney.text = "돈: " + GameMgr.Instance.PowerMoney;//가지고 있는 돈                                          
    }

}
