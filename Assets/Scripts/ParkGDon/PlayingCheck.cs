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
        DontDestroyOnLoad(gameObject);
        LoadSavedData();
        Debug.Log(tenGacha);
        Debug.Log(singleGacha);

    }
    private void Start()
    {
        TenOrSingle();
    }
    void LoadSavedData()
    {
        tenGacha = PlayerPrefs.GetInt("TenGacha", 0) == 1;
        singleGacha = PlayerPrefs.GetInt("SingleGacha", 0) == 1;
    }

    void TenOrSingle()
    {
        if (tenGacha)
        {
            Debug.Log("10È¸»Ì");
        }
        else if (singleGacha)
        {
            Debug.Log("1È¸»Ì");
        }
    }
}
