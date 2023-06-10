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
        //여기 애니메이션 넣기
        load.LoadNextScene();
    }
    void TenOrSingle()
    {
        GameMgr.Instance.GachaCheck();
    }
}
