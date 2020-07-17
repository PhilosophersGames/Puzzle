using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void RebootButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
