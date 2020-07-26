using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
    public GameObject doorTwo;
    public GameObject doorInversed;
    public GameObject doorInversedTwo;
    private SpriteRenderer spriteRenderer;
    public Sprite spriteOn;
    public Sprite spriteOff;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        {
            if (other.CompareTag("Object") || other.CompareTag("Player"))
            {
                spriteRenderer.sprite = spriteOn;
                if (door != null)
                    door.GetComponent<DoorAndKey>().OpenDoor();
                if (doorTwo != null)
                    doorTwo.GetComponent<DoorAndKey>().OpenDoor();
                if (doorInversed != null)
                    doorInversed.GetComponent<DoorAndKey>().CloseDoor();
                if (doorInversedTwo != null)
                    doorInversedTwo.GetComponent<DoorAndKey>().CloseDoor();
            }
         /*   else
            {
                spriteRenderer.sprite = spriteOff;
                door.GetComponent<DoorAndKey>().CloseDoor();
            }*/
        }
    }
        private void OnTriggerExit2D(Collider2D other) {
        {
            if ((other.CompareTag("Object") || other.CompareTag("Player")))
            {
                spriteRenderer.sprite = spriteOff;
                if (door != null)
                    door.GetComponent<DoorAndKey>().CloseDoor();
                if (doorTwo != null)
                    doorTwo.GetComponent<DoorAndKey>().CloseDoor();
                if (doorInversed != null)
                    doorInversed.GetComponent<DoorAndKey>().OpenDoor();
                if (doorInversedTwo != null)
                    doorInversedTwo.GetComponent<DoorAndKey>().OpenDoor();
            }
        }
    }
}
