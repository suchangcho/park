using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BookManager : MonoBehaviour
{
    List<BookSetActive> wordList = new List<BookSetActive>(); //bookSetActive의 정보를 담을 리스트
    private void Start()
    {
        wordList = FindObjectsOfType<BookSetActive>().ToList();
        foreach(BookSetActive bookItem in wordList)
        {
            if (GameMgr.Instance.gachaList.Find(x => x.cardName == bookItem.bookName) != null)
            {
                bookItem.gameObject.SetActive(true);
            }
            else
            {
                bookItem.gameObject.SetActive(false);
            }
        }
    }
    /*
    public void FindBook(string name)
    {
        wordList.Find(x => x.bookName == name);
    }
    */
}
