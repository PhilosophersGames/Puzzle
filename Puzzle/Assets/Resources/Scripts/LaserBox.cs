using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBox : MonoBehaviour
{
    public int[] emissionPoints = new int[4];

    //public Rigidbody2D rb;

    private int point;
    void Start()
    {
        ActiveLasers();
    }
    void Update()
    {
      //  if (RoomTransition.isRotating == true)
        //    rb.velocity = new Vector2(0, 0);

    }
    public void ActiveLasers()
    {
        for (int i = 0; i < 4; i++)
        {
            if (emissionPoints[i] == 1)
                transform.GetChild(i).GetComponent<LaserEmitter>().activeLaser = true;
        }
    }
}
