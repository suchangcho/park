using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Team_Tower : MonoBehaviour
{
    public float Cost;
    public float Cost_price;
    public Text cost_TXT;//코스트 텍스트.
    public int Skill_Cost;//스킬을 사용할 코스트;
    public Text Skill_cost_TXT;//코스트 텍스트.

    float spawn_cooltime = 1;//쿨타임 기준 설정
    public float cooltime;//실제 쿨타임 연산

    public List<GameObject> Cost_Img = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Skill_Cost = 3;
    }

    // Update is called once per frame
    void Update()
    {
        CostSet();
    }
    void CostSet(){
        Cool();
        cost_TXT.text = Cost.ToString()+ " 원";
        Skill_cost_TXT.text = Skill_Cost.ToString() + "스킬 코스트";
    }
    void Cool(){
        cooltime -= Time.deltaTime;//실제 쿨타임 연산
        if (cooltime <= 0)//만약 쿨타임이 델타타임에서부터 깎여 0초가 되었다면
        {
            Cost = Cost + Cost_price;
            cooltime = spawn_cooltime;//쿨 기준 초기화
        }
    }
}
