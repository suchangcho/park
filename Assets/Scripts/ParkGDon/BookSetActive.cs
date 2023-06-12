using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookSetActive : MonoBehaviour
{
    public string bookName;
    private void Start()
    {
        BookNameCheck();
    }
    public void BookNameCheck()
    {
        if (bookName == GameMgr.Instance.gachaName)
        {
            this.gameObject.SetActive(false);
            Debug.Log("叔楳喫かいしかいしかいしかいしかいしかいしかいしかいしかいしかいしかいしかいしかいしかいしかいしかいし");
        }
    }
}
