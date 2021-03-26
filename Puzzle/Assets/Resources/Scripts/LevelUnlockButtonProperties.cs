using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelUnlockButtonProperties : MonoBehaviour
{
    public GameObject chapterParent;
    private int i;
    public int startButtonIndex;
    public bool[] Unlocklevel;
    public Sprite lockedImage;
    public GameObject[] levels;
    public GameObject[] chapters;
    private Sprite[] levelSprites;
    // Start is called before the first frame update

    private void Awake()
    {
        chapterParent.SetActive(true);
        levelSprites = new Sprite[SceneManager.sceneCountInBuildSettings - 1];
        levels = GameObject.FindGameObjectsWithTag("LevelButton");
        Unlocklevel = new bool[SceneManager.sceneCountInBuildSettings - 1];
        chapters = GameObject.FindGameObjectsWithTag("Chapters");
    }

    void Start()
    {
        Unlocklevel = GetComponent<LevelSelection>().Unlocklevel;
        UnlockImage();
    }

    public void DisableChapters()
    {
        int i = 0;
        while (i < chapters.Length)
        {
            chapters[i].gameObject.SetActive(false);
            i++;
        }
    }

    public void EnableChapters()
    {
        int i = 0;
        while (i < chapters.Length)
        {
            chapters[i].gameObject.SetActive(true);
            i++;
        }
    }

    public void UnlockImage()
    {
        Unlocklevel = GetComponent<LevelSelection>().Unlocklevel;
        i = 1;
        while (i < SceneManager.sceneCountInBuildSettings - 1)
        {
            levelSprites[i - 1] = levels[i].GetComponent<Image>().sprite;

            if (Unlocklevel[i - 1] == true)
            {
                levels[i].GetComponent<Image>().sprite = levelSprites[i - 1];
                i++;
            }
            else if (Unlocklevel[i - 1] == false)
            {
                levels[i].GetComponent<Image>().sprite = lockedImage;
                i++;
            }
        }
    }

    private string GetLevelName(int chapterNumber, int i)
    {
        string tab = $"C{chapterNumber.ToString()}Level{i.ToString()}";
        return (tab);
    }
}