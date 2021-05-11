using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoor : MonoBehaviour
{

    public Collider2D col;
    public void ShutDownDoor()
    {
        col.enabled = false;
    }
}
