using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCrate : MonoBehaviour
{
    public GameObject crate;
    public Transform resetPosition;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                crate.transform.position = new Vector3(resetPosition.position.x, resetPosition.position.y, 0);
            }
        }
    }
}
