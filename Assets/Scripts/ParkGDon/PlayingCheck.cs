using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayingCheck : MonoBehaviour
{
    LoadScene load;

    private void Awake()
    {
        load = GetComponent<LoadScene>();
    }
    private void Start()
    {
        TenOrSingle();
        //���� �ִϸ��̼� �ֱ�
        load.LoadNextScene();
    }
    void TenOrSingle()
    {
        GameMgr.Instance.GachaCheck();
    }
}
