using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuButtons : MonoBehaviour
{
    private int startButtonIndex;
    public GameObject MenuCanvas;
    public GameObject SettingsCanvas;
    public GameObject bestScore;

    private bool[] Unlocklevel;

    public AchievementManager achievementManager;

    void Start()
    {

    }
    public void StartButtonClick()
    {
        Unlocklevel = new bool[SceneManager.sceneCountInBuildSettings - 1];
        WhichLevelsAreUnlocked();
        StartLevel();
        SceneManager.LoadScene(startButtonIndex + 1);
    }

    public void RebootButtonClick()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OptionButtonClick()
    {
        MenuCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
    }

    public void MenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void EraseSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

private void StartLevel()
{
    while(startButtonIndex < SceneManager.sceneCountInBuildSettings - 1)
    {
        if(Unlocklevel[startButtonIndex] == true)
        startButtonIndex++;
        else
            break;
    }
}
        private void WhichLevelsAreUnlocked()
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
