using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    private GameObject[] coins;
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
        if (coins.Length == 0)
        {
            if (SceneManager.GetActiveScene().buildIndex < Application.levelCount)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
