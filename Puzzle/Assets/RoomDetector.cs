using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetector : MonoBehaviour
{
    public GameObject room;
    public Collider2D col;

   void Awake()
    {
            col = GetComponentInChildren<BoxCollider2D>();
    }
    
    void Update() {
        if (!room && !col.enabled)
            col.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("AdjacentRooms"))
        {
            room = other.transform.parent.gameObject;
        }
    }
}
