using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    private GameObject[] slideArray;

    void Start()
    {
        slideArray = GameObject.FindGameObjectsWithTag("Slide");
        foreach(GameObject slide in slideArray)
        {
            slide.transform.parent = null;
        }
    }

    void Update()
    {
        
    }
}
