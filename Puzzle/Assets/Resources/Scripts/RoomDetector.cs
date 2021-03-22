using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetector : MonoBehaviour
{
    public GameObject room;
    public Collider2D col;

    private bool exist;

    void Awake()
    {
        col = GetComponentInChildren<BoxCollider2D>();
    }
    private void Start()
    {
        
    }
    void Update()
    {
        if (!exist)
        {
            CreateBorderLimit();
            exist = true;
        }
    }

    public void CreateBorderLimit()
    {
        if (!room)
            col.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AdjacentRooms"))
        {
            room = other.transform.parent.gameObject;
        }
    }
}
