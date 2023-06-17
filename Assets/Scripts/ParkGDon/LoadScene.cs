using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    GachaCard card; 
    public string nextScene;
    private void Start()
    {
        Button btn = GetComponent<Button>();
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
    public void TenBtn()
    {
        if (GameMgr.Instance.GachaMoney >= 1600)
        {
            GameMgr.Instance.TenGachaCheck();
            LoadNextScene();
        }
        else
        {
            Debug.Log("10회 부족함");
        }
    }
    public void SingleBtn()
    {
        if (GameMgr.Instance.GachaMoney >= 160)
        {
            GameMgr.Instance.SingleGachaCheck();
            LoadNextScene();
        }
        else
        {
            Debug.Log("1회 부족함");
        }
    }
    public void PassBtn00()
    {
        GameMgr.Instance.PassBtn();
    }
    public void chestBtn()
    {
        GameMgr.Instance.chestBtn();
    }
}
