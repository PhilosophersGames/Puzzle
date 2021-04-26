using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReceiver : MonoBehaviour
{
    public GameObject door;
    public void OpenDoor(bool open)
    {
        if (open)
            door.GetComponent<DoorAndKey>().OpenDoor();
        else
            door.GetComponent<DoorAndKey>().CloseDoor();
    }
}
