using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public string nextScene;
    public bool tenGacha;
    public bool singleGacha;
    private void Start()
    {
        tenGacha = false;
        singleGacha = false;
        Button btn = GetComponent<Button>();
    }
    public void LoadNextScene()
    {
        SaveData();
        SceneManager.LoadScene(nextScene);
    }

    public void TenGachaCheck()
    {
        tenGacha = true;
    }
    public void SingleGachaCheck()
    {
        singleGacha = true;
    }
    void SaveData()
    {
        PlayerPrefs.SetInt("TenGacha", tenGacha ? 1 : 0);
        PlayerPrefs.SetInt("SingleGacha", singleGacha ? 1 : 0);
        PlayerPrefs.Save();
    }
}
