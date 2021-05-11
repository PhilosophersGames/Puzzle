using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoor : MonoBehaviour
{
    public void ShutDownDoor()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
