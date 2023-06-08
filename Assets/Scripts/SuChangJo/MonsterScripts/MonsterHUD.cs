using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHUD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text nameText;
    public Text levelText;

    // Update is called once per frame
    public void SetData(MonsterUnit monsterUnit)
    {
        nameText.text = monsterUnit._base.name;
        levelText.text = "Lvl " + monsterUnit.level;
    }

}
