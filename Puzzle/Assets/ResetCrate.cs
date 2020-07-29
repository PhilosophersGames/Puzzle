using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCrate : MonoBehaviour
{
    public GameObject crate;
    public Transform resetPosition;
    private bool zoneEnter;
    
    void Update()
    {
        if (zoneEnter == true && Input.GetKeyDown("p"))
        {
            crate.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            crate.transform.position = new Vector3(resetPosition.position.x, resetPosition.position.y, 0);
        }
    /*    if (RoomTransition.isRotating == true)
        {

        }*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            zoneEnter = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            zoneEnter = false;
        }
    }
}
