using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BookManager : MonoBehaviour
{
    List<BookSetActive> words = new List<BookSetActive>(); //bookSetActive의 정보를 담을 리스트
    private void Start()
    {
        BookSetActive bookName = GameObject.Find("Set").GetComponent<BookSetActive>();
        words.Add(bookName);
        Debug.Log(words);
    }

    public void BookLinq()
    {/*
        IEnumerable<string> bName = from word in words
                                    where word.bookName == GameMgr.Instance.gachaName
                                    select word;

        foreach (string str in bName)
        {

        }
        */
        

    }
}
