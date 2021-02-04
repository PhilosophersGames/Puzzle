using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleofRooms : MonoBehaviour
{
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if (transform.parent != null && transform.parent.parent != null)
            this.transform.position = player.transform.parent.gameObject.transform.parent.gameObject.transform.position;
    }
}
