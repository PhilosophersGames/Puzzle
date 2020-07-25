using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
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
                door.GetComponent<DoorAndKey>().OpenDoor();
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
                door.GetComponent<DoorAndKey>().CloseDoor();
            }
        }
    }
}
