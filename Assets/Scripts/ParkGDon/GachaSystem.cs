using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    public List<GachaCard> cardPool = new List<GachaCard>(); //�̱⿡ ���� ī�� �̱�

    //�� �̱� ���� ��ġ
    public Transform singlePullCardSpawnPoint;
    public Transform[] tenPullCardSpawnPoint;

    //ī��� GachaUI ������
    public Transform UiCanvas;
    public GameObject cardPrefab;
    public GachaUI gachaUIprefab;

    private void Start()
    {
        GameMgr.Instance.GachaCheck(); //���������� üũ �Ǿ����� Ȯ�� (�ӽ���)
    }

    //�� �� �̱�
    public void SinglePool()
    {
        GachaCard card = SelectRandomCard(); //�����ϰ� ī�� ����
        SpawnCard(card, singlePullCardSpawnPoint.position); //�����ϱ�
    }
    //�� �� �̱�
    public void TenPool()
    {
        for (int i = 0; i < 10; i++)
        {
            GachaCard card = SelectRandomCard(); //�����ϰ� ī�� ����

            //���� ��ġ
            if (i < tenPullCardSpawnPoint.Length)
            {
                SpawnCard(card, tenPullCardSpawnPoint[i].position); //����
            }
        }
    }

    //ī�� �����ϱ�
    private void SpawnCard(GachaCard card, Vector3 spawnPosition) //spawnPosition�� �޾Ƽ� �־���
    {
        GameObject cardObject = Instantiate(cardPrefab, spawnPosition, Quaternion.identity); //��ġ ��������
        cardObject.transform.parent = UiCanvas;
        GachaUI gachaUI = cardObject.GetComponent<GachaUI>();
        if (gachaUI != null)
        {
            gachaUI.SetCardInfo(card);
        }
    }
    //�����ϰ� ī�� �̱�.
    private GachaCard SelectRandomCard()
    {
        int totalWeight = 0;

        //��ü ����ġ ���ϱ�
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
