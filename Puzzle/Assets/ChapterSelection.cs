using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterSelection : MonoBehaviour
{
    private int[] chapterPrice = new int[5];
    private bool[] unlockChapter = new bool[5];

    private GameObject[] chapters;
    private int wallet;

    void Start()
    { 
        chapters = GameObject.FindGameObjectsWithTag("Chapters");
        chapterPrice[1] = 0;
        chapterPrice[2] = 400;
        chapterPrice[3] = 400;
        chapterPrice[4] = 400;
    }

    void Update()
    {
        if (wallet != GameObject.Find("User").transform.GetComponent<User>().wallet)
            wallet = GameObject.Find("User").transform.GetComponent<User>().wallet;
    }

    public void UnlockChapter(int i)
    {
        unlockChapter[i] = true;
        transform.GetChild(i - 1).Find("BuyChapterButton").gameObject.SetActive(false);
        transform.GetChild(i - 1).Find("Buy confirmation").gameObject.SetActive(false);
        transform.GetChild(i - 1).GetComponent<Button>().interactable = true;
    }

    public void BuyChapter2()
    {
        {
            if(wallet >= chapterPrice[2])
            {
                wallet -= chapterPrice[2];
                GameObject.Find("User").transform.GetComponent<User>().wallet = wallet;
                Debug.Log("User just buyed chapter 2");
                UnlockChapter(2);
            }
        }
    }

        public void BuyChapter3()
    {
        {
            if(wallet >= chapterPrice[3])
            {
                wallet -= chapterPrice[3];
                GameObject.Find("User").transform.GetComponent<User>().wallet = wallet;
                Debug.Log("User just buyed chapter 3");
                UnlockChapter(3);
            }
        }
    }

        public void BuyChapter4()
    {
        {
            if(wallet >= chapterPrice[4])
            {
                wallet -= chapterPrice[4];
                GameObject.Find("User").transform.GetComponent<User>().wallet = wallet;
                Debug.Log("User just buyed chapter 4");
                UnlockChapter(4);
            }
        }
    }

        public void BuyChapter5()
    {
        {
            if(wallet >= chapterPrice[5])
            {
                wallet -= chapterPrice[5];
                GameObject.Find("User").transform.GetComponent<User>().wallet = wallet;
                Debug.Log("User just buyed chapter 2");
                UnlockChapter(5);
            }
        }
    }

    public void GotoChapter1()
    {
            if(unlockChapter[1] = true)
            {
                chapters[1].SetActive(true);
            }
    }


    public void GotoChapter2()
    {
        
    }


    public void GotoChapter3()
    {
        
    }


    public void GotoChapter4()
    {
        
    }


    public void GotoChapter5()
    {
        
    }
}