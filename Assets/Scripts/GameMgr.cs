using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr
{
    //게임매니저의 인스턴스를 담는 전역변수(static 변수이지만 이해하기 쉽게 전역변수라고 하겠다).
    //이 게임 내에서 게임매니저 인스턴스는 이 instance에 담긴 녀석만 존재하게 할 것이다.
    //보안을 위해 private으로.
    private static GameMgr instance;

    public bool tenGacha; //10회뽑
    public bool singleGacha; //1회뽑

    //재화
    public int BattleMoney = 0; //전투내에서 사용되는 재화
    public int PowerMoney = 0;  //업그레이드에 사용되는 재화
    public int GachaMoney = 0;  //뽑기에 사용되는 재화


    public List<GachaCard> gachaList = new List<GachaCard>(); //뽑기 결과 담는 리스트
    public string gachaName;                                  //뽑은 애 이름

    Input_Manager _input = new Input_Manager();
    public static Input_Manager Input { get { return Instance._input; } }



    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static GameMgr Instance
    {
        get
        {
            if (null == instance)
            {
                //게임 인스턴스가 없다면 하나 생성해서 넣어준다.
                instance = new GameMgr();
            }
            return instance;
        }
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    //GameMgr.Instance.함수명() 으로 어디서든 함수를 호출할 수 있다.
    public void TenGachaCheck() //가챠 10회뽑 체크
    {
        tenGacha = true;
        GachaMoney -= 1600;
    }
    public void SingleGachaCheck() //가챠 1회뽑 체크
    {
        singleGacha = true;
        GachaMoney -= 160;
    }
    public void GachaCheck() //10회냐 1회냐? 체크
    {
        if (tenGacha == true)
        {
            Debug.Log("10회뽑");
        }
        else if (singleGacha == true)
        {
            Debug.Log("1회뽑");
        }

}
public void chestBtn()
    {
        GachaMoney += 999;
    }
    public void PassBtn() //뽑기 False로 만들어줘서 다시 실행하는 함수
    {
        tenGacha = false;
        singleGacha = false;
    }
    public void AddGachaList(GachaCard card) //뽑기 기록 출력하기 테스트
    {
        gachaList.Add(card);
        Debug.Log("뽑기 결과 : " + card.cardName);
    }
    public void test11(GachaCard card)
    {
        gachaName = card.cardName;
    }
    private void Update() { //이거 무슨 코드인가요 제하씨 설명필요!!!
        _input.OnUpdate();
    }
}
