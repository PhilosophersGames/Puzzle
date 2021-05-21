﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetector : MonoBehaviour
{
    public GameObject room;

    public GameObject roomDetector;

    public GameObject slidableRoom;

    public bool isSlidable;

    public Collider2D col;

    private GameObject[] bigRooms;

    private GameObject rooms;

    public float offset;

    public GameObject player;

    public GameObject[] phantoms;

    public GameObject[] laserBoxes;

    public GameObject[] mirrors;

    void Awake()
    {
        col = GetComponentInChildren<BoxCollider2D>();
        rooms = GameObject.FindGameObjectWithTag("RoomsContainer");
        player = GameObject.Find("Player");
        phantoms = GameObject.FindGameObjectsWithTag("Phantom");
        laserBoxes = GameObject.FindGameObjectsWithTag("LaserBox");
        mirrors = GameObject.FindGameObjectsWithTag("Mirror");
    }

    void Update()
    {
        if (rooms.GetComponent<SlideManager>().drawBorderCollider == false && IsPlayerHere())
        {
            CheckBorderLimit();
        }
        else
            col.enabled = false;
        if (slidableRoom)
            isSlidable = true;
        else
        {
            isSlidable = false;
        }
    }

    public bool IsPlayerHere()
    {
        if (this.gameObject.transform.parent.transform.parent == player.transform.parent.transform.parent)
            return (true);
        foreach (GameObject phantom in phantoms)
        {
            if (this.gameObject.transform.parent.transform.parent == phantom.transform.parent.transform.parent)
                return (true);
        }
        foreach (GameObject laserBox in laserBoxes)
        {
            if (this.gameObject.transform.parent.transform.parent == laserBox.transform.parent.transform.parent)
                return (true);
        }
        foreach (GameObject mirror in mirrors)
        {
            if (this.gameObject.transform.parent.transform.parent == mirror.transform.parent.transform.parent)
                return (true);
        }
        return (false);
    }

    public void CheckBorderLimit()
    {
        int count = 0;
        bigRooms = GameObject.FindGameObjectsWithTag("RoomSkin");
        foreach (GameObject room in bigRooms)
        {
            offset = Vector3.Distance(transform.position, room.transform.GetChild(1).transform.position);
            if (!(offset <= Mathf.Abs(1f)))
                count++;
        }
        if (count == bigRooms.Length)
            CreateBorderLimit();
    }
    public void CreateBorderLimit()
    {
        col.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AdjacentRooms"))
        {
            room = other.transform.parent.gameObject;
        }
        if (other.CompareTag("SlidableRoom"))
        {
            slidableRoom = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("AdjacentRooms"))
        {
            room = null;
        }
        if (other.CompareTag("SlidableRoom"))
        {
            slidableRoom = null;
        }
    }
}
