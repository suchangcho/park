using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayingCheck : MonoBehaviour
{
    public bool tenGacha;
    public bool singleGacha;
    private void Awake()
    {
        Debug.Log(tenGacha);
        Debug.Log(singleGacha);

    }
    private void Start()
    {
        TenOrSingle();
    }
    void TenOrSingle()
    {
        GameMgr.Instance.GachaCheck();
    }
}
