using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetector : MonoBehaviour
{
    public GameObject room;

    public GameObject roomDetector;

    public GameObject slidableRoom;

    public bool isSlidable;
    public Collider2D col;

    public bool exist;

    void Awake()
    {
        col = GetComponentInChildren<BoxCollider2D>();
    }

    void Update()
    {   if(!exist)
        {
            CreateBorderLimit();
            exist = true;
        }
        if (slidableRoom)
            isSlidable = true;
        else
        {
            isSlidable = false;
        }
    }

    public void CreateBorderLimit()
    {
        if(!room)
            col.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AdjacentRooms"))
        {
            room = other.transform.parent.gameObject;
        }
        if(other.CompareTag("SlidableRoom"))
        {
            Debug.Log("slidable");
            slidableRoom = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("AdjacentRooms"))
        {
            room = null;
        }
        if(other.CompareTag("SlidableRoom"))
        {
            slidableRoom = null;
        }
    }
}
