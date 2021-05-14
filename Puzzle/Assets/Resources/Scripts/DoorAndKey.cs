using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAndKey : MonoBehaviour
{
    public bool DoorOpened;
    public bool hasKey;
    public Animator anim;

    // Update is called once per frame
    void Start()
    {
        if (DoorOpened == true)
            OpenDoor();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && hasKey == true)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void OpenDoor()
    {
            anim.SetTrigger("ShutDown");
            DoorOpened = true;
    }

    public void CloseDoor()
    {
            anim.SetTrigger("Open");
            this.gameObject.SetActive(true);
            DoorOpened = false;
    }
}
