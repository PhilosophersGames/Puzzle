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
            if(Unlocklevel[i - 1] == true)
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

    public void WhichLevelsAreUnlocked()
    {
                    if (PlayerPrefs.HasKey("C2Level3"))
        {
            Unlocklevel[0] = (PlayerPrefs.GetInt("C1Level1") == 1 ? true : false);
            Unlocklevel[1] = (PlayerPrefs.GetInt("C1Level2") == 1 ? true : false);
            Unlocklevel[2] = (PlayerPrefs.GetInt("C1Level3") == 1 ? true : false);
            Unlocklevel[3] = (PlayerPrefs.GetInt("C1Level4") == 1 ? true : false);
            Unlocklevel[4] = (PlayerPrefs.GetInt("C1Level5") == 1 ? true : false);
            Unlocklevel[5] = (PlayerPrefs.GetInt("C1Level6") == 1 ? true : false);
            Unlocklevel[6] = (PlayerPrefs.GetInt("C1Level7") == 1 ? true : false);

            Unlocklevel[7] = (PlayerPrefs.GetInt("C2Level1") == 1 ? true : false);
            Unlocklevel[8] = (PlayerPrefs.GetInt("C2Level2") == 1 ? true : false);
            Unlocklevel[9] = (PlayerPrefs.GetInt("C2Level3") == 1 ? true : false);
            Unlocklevel[10] = (PlayerPrefs.GetInt("C2Level4") == 1 ? true : false);

            Unlocklevel[11] = (PlayerPrefs.GetInt("C3Level1") == 1 ? true : false);
            Unlocklevel[12] = (PlayerPrefs.GetInt("C3Level2") == 1 ? true : false);
            Unlocklevel[13] = (PlayerPrefs.GetInt("C3Level3") == 1 ? true : false);
            Unlocklevel[14] = (PlayerPrefs.GetInt("C3Level4") == 1 ? true : false);
            Unlocklevel[15] = (PlayerPrefs.GetInt("C3Level5") == 1 ? true : false);
            Unlocklevel[16] = (PlayerPrefs.GetInt("C3Level6") == 1 ? true : false);

            Unlocklevel[17] = (PlayerPrefs.GetInt("C4Level1") == 1 ? true : false);
            Unlocklevel[18] = (PlayerPrefs.GetInt("C4Level2") == 1 ? true : false);
            Unlocklevel[19] = (PlayerPrefs.GetInt("C4Level3") == 1 ? true : false);
            Unlocklevel[20] = (PlayerPrefs.GetInt("C4Level4") == 1 ? true : false);
            Unlocklevel[21] = (PlayerPrefs.GetInt("C4Level5") == 1 ? true : false);
        }
        else
        {
            Debug.Log("No Save");
        }
    }
}
