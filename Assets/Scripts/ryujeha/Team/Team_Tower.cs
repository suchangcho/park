using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Team_Tower : MonoBehaviour
{
    public float Cost;
    public float Cost_price;
    public Text cost_TXT;//�ڽ�Ʈ �ؽ�Ʈ.
    public int Skill_Cost;//��ų�� ����� �ڽ�Ʈ;
    public Text Skill_cost_TXT;//�ڽ�Ʈ �ؽ�Ʈ.

    float spawn_cooltime = 1;//��Ÿ�� ���� ����
    public float cooltime;//���� ��Ÿ�� ����

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
        cost_TXT.text = Cost.ToString()+ " ��";
        Skill_cost_TXT.text = Skill_Cost.ToString() + "��ų �ڽ�Ʈ";
    }
    void Cool(){
        cooltime -= Time.deltaTime;//���� ��Ÿ�� ����
        if (cooltime <= 0)//���� ��Ÿ���� ��ŸŸ�ӿ������� �� 0�ʰ� �Ǿ��ٸ�
        {
            Cost = Cost + Cost_price;
            cooltime = spawn_cooltime;//�� ���� �ʱ�ȭ
        }
    }
}
