using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GachaSystem : MonoBehaviour
{
    public List<GachaCard> cardPool = new List<GachaCard>(); //�̱⿡ ���� ī�� �̱�

    //�� �̱� ���� ��ġ
    public Transform singlePullCardSpawnPoint;               //1ȸ�� ��ġ
    public Transform[] tenPullCardSpawnPoint;                //10ȸ�� ��ġ

    //ī��� GachaUI ������
    public Transform UiCanvas;
    public GameObject cardPrefab;
    public GachaUI gachaUIprefab;

    private void Start()
    {
        if (GameMgr.Instance.tenGacha == true) //���� 10ȸ�� Ȱ��ȭ �Ǿ��ٸ�?
        {
            TenPool(); //10ȸ�� �Լ� ���
        }
        else if (GameMgr.Instance.singleGacha == true) //1ȸ���� üũ�Ͽ��ٸ�?
        {
            SinglePool(); //1ȸ�� �Լ� ���
        }
    }

    //�� �� �̱�
    public void SinglePool()
    {
        GachaCard card = SelectRandomCard(); //�����ϰ� ī�� ����
        GameMgr.Instance.AddGachaList(card); //GameMgr ����Ʈ �߰��ϴ� �Լ� �ҷ�����
        GameMgr.Instance.test11(card);
        SpawnCard(card, singlePullCardSpawnPoint.position); //�����ϱ�
    }
    //�� �� �̱�
    public void TenPool()
    {
        for (int i = 0; i < 10; i++)
        {
            GachaCard card = SelectRandomCard(); //�����ϰ� ī�� ����
            GameMgr.Instance.AddGachaList(card); //GameMgr ����Ʈ �߰��ϴ� �Լ� �ҷ�����
            GameMgr.Instance.test11(card); //�ӽ� �׽�Ʈ
            //���� ��ġ
            if (i < tenPullCardSpawnPoint.Length) //�迭�� ���� ������������
            {
                SpawnCard(card, tenPullCardSpawnPoint[i].position); //����
            }
        }
    }

    //ī�� �����ϱ�
    private void SpawnCard(GachaCard card, Vector3 spawnPosition) //spawnPosition�� �޾Ƽ� �־���
    {
        GameObject cardObject = Instantiate(cardPrefab, spawnPosition, Quaternion.identity); //��ġ ��������
        cardObject.transform.SetParent(UiCanvas,false);
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
