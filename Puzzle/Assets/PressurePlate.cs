using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        {
            if (other.CompareTag("Object"))
            {
                door.GetComponent<DoorAndKey>().OpenDoor();
            }
        }
    }
        private void OnTriggerExit2D(Collider2D other) {
        {
            if (other.CompareTag("Object"))
            {
                door.GetComponent<DoorAndKey>().CloseDoor();
            }
        }
    }
}
