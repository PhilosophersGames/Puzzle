using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStars : MonoBehaviour
{

    [SerializeField]
    private GameObject[] stars;

    public void StarManagement(int starScore)
    {
        if (starScore == 1)
        {
            stars[0].gameObject.SetActive(true);
            stars[1].gameObject.SetActive(false);
            stars[2].gameObject.SetActive(false);
        }
        if (starScore == 2)
        {
            stars[0].gameObject.SetActive(true);
            stars[1].gameObject.SetActive(true);
            stars[2].gameObject.SetActive(false);
        }
        if (starScore == 3)
        {
            stars[0].gameObject.SetActive(true);
            stars[1].gameObject.SetActive(true);
            stars[2].gameObject.SetActive(true);
        }
    }
}
