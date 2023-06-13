using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GachaSystem : MonoBehaviour
{
    public List<GachaCard> cardPool = new List<GachaCard>(); //뽑기에 사용될 카드 뽑기

    //각 뽑기 스폰 위치
    public Transform singlePullCardSpawnPoint;               //1회뽑 위치
    public Transform[] tenPullCardSpawnPoint;                //10회뽑 위치

    //카드와 GachaUI 프리팹
    public Transform UiCanvas;
    public GameObject cardPrefab;
    public GachaUI gachaUIprefab;

    private void Start()
    {
        if (GameMgr.Instance.tenGacha == true) //만약 10회가 활성화 되었다면?
        {
            TenPool(); //10회뽑 함수 출력
        }
        else if (GameMgr.Instance.singleGacha == true) //1회뽑을 체크하였다면?
        {
            SinglePool(); //1회뽑 함수 출력
        }
    }

    //한 개 뽑기
    public void SinglePool()
    {
        GachaCard card = SelectRandomCard(); //랜덤하게 카드 선택
        GameMgr.Instance.AddGachaList(card); //GameMgr 리스트 추가하는 함수 불러오기
        GameMgr.Instance.test11(card);
        SpawnCard(card, singlePullCardSpawnPoint.position); //스폰하기
    }
    //열 개 뽑기
    public void TenPool()
    {
        for (int i = 0; i < 10; i++)
        {
            GachaCard card = SelectRandomCard(); //랜덤하게 카드 선택
            GameMgr.Instance.AddGachaList(card); //GameMgr 리스트 추가하는 함수 불러오기
            GameMgr.Instance.test11(card); //임시 테스트
            //스폰 위치
            if (i < tenPullCardSpawnPoint.Length) //배열을 넘지 않을때까지만
            {
                SpawnCard(card, tenPullCardSpawnPoint[i].position); //스폰
            }
        }
    }

    //카드 스폰하기
    private void SpawnCard(GachaCard card, Vector3 spawnPosition) //spawnPosition을 받아서 넣어줌
    {
        GameObject cardObject = Instantiate(cardPrefab, spawnPosition, Quaternion.identity); //위치 가져오기
        cardObject.transform.SetParent(UiCanvas,false);
        GachaUI gachaUI = cardObject.GetComponent<GachaUI>();
        if (gachaUI != null)
        {
            gachaUI.SetCardInfo(card);
        }
    }
    //랜덤하게 카드 뽑기.
    private GachaCard SelectRandomCard()

    {
        int totalWeight = 0;

        //전체 가중치 구하기
        foreach(GachaCard card in cardPool)
        {
            totalWeight += card.weight;
        }

        int randomWeight = Random.Range(0, totalWeight);
        int accumulatedWeight = 0;

        foreach(GachaCard card in cardPool)
        {
            accumulatedWeight += card.weight;
            if (randomWeight < accumulatedWeight)
            {
                return card;
            }
        }
        return null;
    }
 
}
