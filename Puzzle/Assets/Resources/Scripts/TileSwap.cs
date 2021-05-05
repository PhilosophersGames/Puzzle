using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSwap : MonoBehaviour
{

    [Header("START SKIN")]
    public TileBase[] startSkin;

    [Header("WHITE SKIN")]
    public TileBase[] newSkin;

    private GameObject[] rooms;

    public Color colorPathID;

    public Color colorOneID;

    public Color colorTwoID;

    private void Start()
    {
        rooms = GameObject.FindGameObjectsWithTag("RoomSkin");
        foreach (GameObject room in rooms)
        {
            room.GetComponent<RoomColorChanger>().path.SwapTile(startSkin[0], newSkin[0]); 
            room.GetComponent<RoomColorChanger>().path.SwapTile(startSkin[2], newSkin[0]);
            room.GetComponent<RoomColorChanger>().colider.SwapTile(startSkin[1], newSkin[1]);
            room.GetComponent<RoomColorChanger>().colider.SwapTile(startSkin[3], newSkin[1]);
        }
    }
    public void ColorPathChanger(Color newColorID)
    {
        if (colorPathID != newColorID)
        {
            foreach (GameObject room in rooms)
            {
                room.GetComponent<RoomColorChanger>().path.color = newColorID;
            }
            colorPathID = newColorID;
        }
    }
    public void ColorColliderOneChanger(Color newColorID)
    {
        if (colorOneID != newColorID)
        {
            foreach (GameObject room in rooms)
            {
                if (room.GetComponent<RoomColorChanger>().roomID == 0)
                    room.GetComponent<RoomColorChanger>().colider.color = newColorID;
            }
            colorOneID = newColorID;
        }
    }
    public void ColorColliderTwoChanger(Color newColorID)
    {
        if (colorOneID != newColorID)
        {
            foreach (GameObject room in rooms)
            {
                if (room.GetComponent<RoomColorChanger>().roomID == 1)
                    room.GetComponent<RoomColorChanger>().colider.color = newColorID;
            }
            colorOneID = newColorID;
        }
        colorTwoID = newColorID;  
    }
}