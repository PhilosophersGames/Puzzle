using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenGoldValue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt($"RewardLevel{SceneManager.GetActiveScene().buildIndex.ToString()}") == 1)
        {
            GetComponent<TextMeshProUGUI>().text = 0.ToString();
        }
        else
            GetComponent<TextMeshProUGUI>().text = 100.ToString();
    }
}
