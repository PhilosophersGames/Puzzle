using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReceiver : MonoBehaviour
{
    public GameObject door;
    void Start()
    {
        
    }
    void Update()
    {
         door.GetComponent<DoorAndKey>().CloseDoor();
    }

    public void OpenDoor()
    {
        door.GetComponent<DoorAndKey>().OpenDoor();
    }
}
