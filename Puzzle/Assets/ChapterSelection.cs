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
        chapterPrice[3] = 800;
        chapterPrice[4] = 1200;
        chapterPrice[4] = 1600;
    }
    void Update()
    {
        if (wallet != GameObject.Find("User").transform.GetComponent<User>().wallet)
            wallet = GameObject.Find("User").transform.GetComponent<User>().wallet;
    }

    public void BuyChapter(int i)
    {
        {
            if (wallet >= chapterPrice[i])
            {
                wallet -= chapterPrice[i];
                GameObject.Find("User").transform.GetComponent<User>().wallet = wallet;
                Debug.Log("User just buyed chapter");
                UnlockChapter(i);
            }
        }
    }
    public void UnlockChapter(int i)
    {
        unlockChapter[i] = true;
        transform.GetChild(i - 1).Find("BuyChapterButton").gameObject.SetActive(false);
        transform.GetChild(i - 1).Find("Buy confirmation").gameObject.SetActive(false);
        transform.GetChild(i - 1).GetComponent<Button>().interactable = true;
        transform.GetChild(i - 1).GetComponent<Image>().sprite = null;
    }
}