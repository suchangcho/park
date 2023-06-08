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
        SceneManager.LoadScene(nextScene);
    }
    public void TenBtn()
    {
        GameMgr.Instance.TenGachaCheck();
    }
    public void SingleBtn()
    {
        GameMgr.Instance.SingleGachaCheck();
    }
}
