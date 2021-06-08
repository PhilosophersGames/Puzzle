using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject LinkedDoor;
    public GameObject stade2;
    public GameObject stade1;
    public GameObject stade3;
    
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LinkedDoor.GetComponent<DoorAndKey>().OpenDoor(1);
            if(other.GetComponent<Rigidbody2D>().velocity.x > 0 || other.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                stade1.gameObject.SetActive(false);
                stade2.gameObject.SetActive(true);
                transform.GetComponent<Collider2D>().enabled = false;
            }
            if(other.GetComponent<Rigidbody2D>().velocity.x < 0 || other.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                stade1.gameObject.SetActive(false);
                stade3.gameObject.SetActive(true);
                transform.GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
