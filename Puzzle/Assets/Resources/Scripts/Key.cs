using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject LinkedDoor;
    public GameObject Stade2;
    public GameObject Stade1;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LinkedDoor.GetComponent<DoorAndKey>().OpenDoor();
            Stade1.gameObject.SetActive(false);
            Stade2.gameObject.SetActive(true);
        }
    }
}
