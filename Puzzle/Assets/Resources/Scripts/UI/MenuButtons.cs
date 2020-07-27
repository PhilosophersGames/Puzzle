using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuButtons : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject SettingsCanvas;

    public AchievementManager achievementManager;

    public void StartButtonClick()
    {
        SceneManager.LoadScene(1);
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
    }

    public void Quit()
    {
        Application.Quit();
    }
}
