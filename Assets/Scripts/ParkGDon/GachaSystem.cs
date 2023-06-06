using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    public List<GachaCard> cardPool = new List<GachaCard>(); //뽑기에 사용될 카드 뽑기

    //각 뽑기 스폰 위치
    public Transform singlePullCardSpawnPoint;
    public Transform[] tenPullCardSpawnPoint;

    //카드와 GachaUI 프리팹
    public Transform UiCanvas;
    public GameObject cardPrefab;
    public GachaUI gachaUIprefab;

    //한 개 뽑기
    public void SinglePool()
    {
        GachaCard card = SelectRandomCard(); //랜덤하게 카드 선택
        SpawnCard(card, singlePullCardSpawnPoint.position); //스폰하기
        Debug.Log(singlePullCardSpawnPoint.position);
    }
    //열 개 뽑기
    public void TenPool()
    {
        for (int i = 0; i < 10; i++)
        {
            GachaCard card = SelectRandomCard(); //랜덤하게 카드 선택

            //스폰 위치
            if (i < tenPullCardSpawnPoint.Length)
            {
                SpawnCard(card, tenPullCardSpawnPoint[i].position); //스폰
                //Debug.Log(tenPullCardSpawnPoint[i].position);
            }
        }
    }

    private void SpawnCard(GachaCard card, Vector3 spawnPosition)
    {
        GameObject cardObject = Instantiate(cardPrefab, spawnPosition, Quaternion.identity);
        cardObject.transform.parent = UiCanvas;
        GachaUI gachaUI = cardObject.GetComponent<GachaUI>();
        //Debug.Log(spawnPosition);
        if (gachaUI != null)
        {
            gachaUI.SetCardInfo(card);
        }
    }
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
