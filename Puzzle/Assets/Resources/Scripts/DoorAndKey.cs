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
            OpenDoor(0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && hasKey == true)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void OpenDoor(int type)
    {
        anim.SetTrigger("ShutDown");
        if (type == 0)
            DoorOpened = true;
        else if (type == 1)
            Destroy(this.gameObject);
    }

    public void CloseDoor()
    {
            anim.SetTrigger("Open");
            this.gameObject.SetActive(true);
            DoorOpened = false;
    }
}
