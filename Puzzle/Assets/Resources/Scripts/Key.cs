using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject LinkedDoor;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player"))
        {
           LinkedDoor.GetComponent<DoorAndKey>().OpenDoor();
        Destroy(this.gameObject);
        }
    }
}
