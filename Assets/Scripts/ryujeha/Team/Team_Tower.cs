using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Team_Tower : MonoBehaviour
{
    public int Cost;//��ų�� ����� �ڽ�Ʈ;
    public Text cost_TXT;//�ڽ�Ʈ �ؽ�Ʈ.
    public List<GameObject> Cost_Img = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Cost = 3;
    }

    // Update is called once per frame
    void Update()
    {
        CostSet();
    }
    void CostSet(){
        cost_TXT.text = Cost.ToString() + "�ڽ�Ʈ ����";
    }
}
