using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr
{
    //���ӸŴ����� �ν��Ͻ��� ��� ��������(static ���������� �����ϱ� ���� ����������� �ϰڴ�).
    //�� ���� ������ ���ӸŴ��� �ν��Ͻ��� �� instance�� ��� �༮�� �����ϰ� �� ���̴�.
    //������ ���� private����.
    private static GameMgr instance;

    public bool tenGacha; //10ȸ��
    public bool singleGacha; //1ȸ��

    //��ȭ
    public int BattleMoney = 0; //���������� ���Ǵ� ��ȭ
    public int PowerMoney = 0;  //���׷��̵忡 ���Ǵ� ��ȭ
    public int GachaMoney = 0;  //�̱⿡ ���Ǵ� ��ȭ


    public List<GachaCard> gachaList = new List<GachaCard>(); //�̱� ��� ��� ����Ʈ
    public string gachaName;                                  //���� �� �̸�

    Input_Manager _input = new Input_Manager();
    public static Input_Manager Input { get { return Instance._input; } }



    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    public static GameMgr Instance
    {
        get
        {
            if (null == instance)
            {
                //���� �ν��Ͻ��� ���ٸ� �ϳ� �����ؼ� �־��ش�.
                instance = new GameMgr();
            }
            return instance;
        }
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    //GameMgr.Instance.�Լ���() ���� ��𼭵� �Լ��� ȣ���� �� �ִ�.
    public void TenGachaCheck() //��í 10ȸ�� üũ
    {
        tenGacha = true;
        GachaMoney -= 1600;
    }
    public void SingleGachaCheck() //��í 1ȸ�� üũ
    {
        singleGacha = true;
        GachaMoney -= 160;
    }
    public void GachaCheck() //10ȸ�� 1ȸ��? üũ
    {
        if (tenGacha == true)
        {
            Debug.Log("10ȸ��");
        }
        else if (singleGacha == true)
        {
            Debug.Log("1ȸ��");
        }

}
public void chestBtn()
    {
        GachaMoney += 999;
    }
    public void PassBtn() //�̱� False�� ������༭ �ٽ� �����ϴ� �Լ�
    {
        tenGacha = false;
        singleGacha = false;
    }
    public void AddGachaList(GachaCard card) //�̱� ��� ����ϱ� �׽�Ʈ
    {
        gachaList.Add(card);
        Debug.Log("�̱� ��� : " + card.cardName);
    }
    public void test11(GachaCard card)
    {
        gachaName = card.cardName;
    }
    private void Update() { //�̰� ���� �ڵ��ΰ��� ���Ͼ� �����ʿ�!!!
        _input.OnUpdate();
    }
}
