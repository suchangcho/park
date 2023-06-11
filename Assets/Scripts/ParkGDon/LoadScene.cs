using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
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
        GameMgr.Instance.TenGachaCheck();
    }
    public void SingleBtn()
    {
        GameMgr.Instance.SingleGachaCheck();
    }
    public void PassBtn00()
    {
        GameMgr.Instance.PassBtn();
    }
}
