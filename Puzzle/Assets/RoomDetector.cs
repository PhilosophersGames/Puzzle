﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetector : MonoBehaviour
{
    public GameObject room;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("AdjacentRooms"))
        {
            room = other.transform.parent.gameObject;
        }
    }
}