using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateMovements : MonoBehaviour
{
    public Rigidbody2D rb;

    void Update()
    {
        if (RoomTransition.isRotating == true)
            rb.velocity = new Vector2(0, 0);
    }
}
