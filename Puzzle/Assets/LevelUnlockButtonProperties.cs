using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelUnlockButtonProperties : MonoBehaviour
{

    private int i;
    public int startButtonIndex;
    public bool[] Unlocklevel;
    public Sprite lockedImage;
    public GameObject[] levels;
    private Sprite[] levelSprites;
    // Start is called before the first frame update

    private void Awake()
    {
        levelSprites = new Sprite[SceneManager.sceneCountInBuildSettings - 1];
        levels = GameObject.FindGameObjectsWithTag("LevelButton");
        Unlocklevel = new bool[SceneManager.sceneCountInBuildSettings - 1];
        WhichLevelsAreUnlocked();
    }
    void Start()
    {
        //  if (Unlocklevel[0] == true)
        UnlockImage();
    }
    // Update is called once per frame
    public void UnlockImage()
    {
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
    public void WhichLevelsAreUnlocked()
    {

        if (PlayerPrefs.HasKey("C2Level3"))
        {
            int chapterNumber = 1;
            int i = -1;
            for (int level = 0; level <= 27; level++)
            {
                i++;
                Unlocklevel[i] = (PlayerPrefs.GetInt(GetLevelName(chapterNumber, i + 1)) == 1 ? true : false);
                if (level == 6 || level == 10 || level == 16 || level == 20 || level == 27)
                {
                    i = -1;
                    chapterNumber++;
                }
            }
        }
        else
            Debug.Log("No Save");
    }
}