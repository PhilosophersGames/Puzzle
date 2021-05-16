using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReceiver : MonoBehaviour
{
    public GameObject door;

    public void OpenDoorFromLaserReceiver(bool open)
    {
        if (open && door)
            door.GetComponent<DoorAndKey>().OpenDoor(0);
        else if (!open && door)
            door.GetComponent<DoorAndKey>().CloseDoor();
    }
}