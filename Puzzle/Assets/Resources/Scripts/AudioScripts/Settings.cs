using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Settings : MonoBehaviour
{

    public GameObject settings;

    private bool settingsActive;

    private bool ispressed;

    public GameObject bestScore;

    public int[] bestScores = { 2, 2, 5, 4, 4, 10, 9, 14,
                      2, 4, 4, 13, 7, 11, 12, 0,
                      2, 3, 11, 4, 12, 7, 25, 22,
                      1, 4, 6, 2, 5, 9, 7, 35,
                      3, 1, 2, 1, 1, 16, 9, 33,
                      2, 5, 4, 8, 9, 8, 0, 61,
                      1, 2, 3, 6, 4, 6, 16, 0,
                      3, 6, 8, 14, 15, 20, 0, 0 };

    public void Start()
    {
        bestScore.GetComponent<TextMeshProUGUI>().text = bestScores[SceneManager.GetActiveScene().buildIndex - 1].ToString();
    }

    void Update()
    {   
        // ENABLE SETTINGS
        if (Input.GetKeyDown("escape"))
        {
            AudioManager.Instance.PlaySFX(GameAssets.i.AshkanMouseClickSFX);
            if (settingsActive == false && ispressed == false)
            {
                //Pause here
                settings.SetActive(true);
                settingsActive = true;
                    ispressed = true;
             }
            if (settingsActive == true && ispressed == false)
            {
                // Resume here
                settings.SetActive(false);
                settingsActive = false;
                    ispressed = true;
            }
        }
        if (Input.GetKeyUp("escape"))
        {
            ispressed = false;
        }
    }


    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
