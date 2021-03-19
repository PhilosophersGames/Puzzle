using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int[] emissionPoints = new int[4];

    private int point;
    void Start()
    {
        ActiveLasers();
    }
    void Update()
    {

    }
    public void ActiveLasers()
    {
        for (int i = 0; i < 4; i++)
        {
            if (emissionPoints[i] == 1)
                transform.GetChild(i).GetComponent<LaserCast>().activeLaser = true;
        }
    }
}
