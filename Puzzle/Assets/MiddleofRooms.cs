using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleofRooms : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        this.transform.position = player.transform.parent.gameObject.transform.parent.gameObject.transform.position;
    }
}
