using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr
{
    //���ӸŴ����� �ν��Ͻ��� ��� ��������(static ���������� �����ϱ� ���� ����������� �ϰڴ�).
    //�� ���� ������ ���ӸŴ��� �ν��Ͻ��� �� instance�� ��� �༮�� �����ϰ� �� ���̴�.
    //������ ���� private����.
    private static GameMgr instance;

    public bool tenGacha;
    public bool singleGacha;
    Input_Manager _input = new Input_Manager();
    public static Input_Manager Input{get{return Instance._input;}} 

   

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
    }
    public void SingleGachaCheck() //��í 1ȸ�� üũ
    {
        singleGacha = true;
    }
    public void GachaCheck() //10ȸ�� 1ȸ��? üũ
    {
        if (tenGacha == true)
        {
            Debug.Log("10ȸ��");
        }
        else if(singleGacha == true)
        {
            Debug.Log("1ȸ��");
        }
    }
    private void Update() {
        _input.OnUpdate();
    }
}
