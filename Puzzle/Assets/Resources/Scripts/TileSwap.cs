using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSwap : MonoBehaviour
{
    public TileBase[] skinZero;
    public TileBase[] skinOne;

    public TileBase[] skinTwo;
    public TileBase[] skinThree;
    public TileBase[] skinFour;
    public TileBase[] skinFive;

    private GameObject[] rooms;

    public int skinPathID;
    public int skinOneID;
    public int skinTwoID;

    private GameObject[] LaserBox;


    private void Start()
    {
        rooms = GameObject.FindGameObjectsWithTag("RoomSkin");
        skinOneID = 0;
        skinTwoID = 1;
    }
    public void SkinChanger(int colorID)
    {
    }

    public void ColorPathChanger(int colorID)
    {
        if (skinPathID != colorID)
        {
            foreach (GameObject room in rooms)
            {
                if (skinPathID == 0)
                    room.GetComponent<RoomColorChanger>().path.SwapTile(skinZero[0], SwappedSkin(0, colorID));
                else if (skinPathID == 1)
                    room.GetComponent<RoomColorChanger>().path.SwapTile(skinOne[0], SwappedSkin(0, colorID));
                else if (skinPathID == 2)
                    room.GetComponent<RoomColorChanger>().path.SwapTile(skinTwo[0], SwappedSkin(0, colorID));
                else if (skinPathID == 3)
                    room.GetComponent<RoomColorChanger>().path.SwapTile(skinThree[0], SwappedSkin(0, colorID));
                else if (skinPathID == 4)
                    room.GetComponent<RoomColorChanger>().path.SwapTile(skinFour[0], SwappedSkin(0, colorID));
                else if (skinPathID == 5)
                    room.GetComponent<RoomColorChanger>().path.SwapTile(skinFive[0], SwappedSkin(0, colorID));
            }
            skinPathID = colorID;
        }
    }
    public void ColorColliderOneChanger(int colorID)
    {
        if (skinOneID != colorID)
        {
            foreach (GameObject room in rooms)
            {
                if (skinOneID == 0)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinZero[1], SwappedSkin(1, colorID));
                }
                else if (skinOneID == 1)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinOne[1], SwappedSkin(1, colorID));
                }
                else if (skinOneID == 2)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinTwo[1], SwappedSkin(1, colorID));
                }
                else if (skinOneID == 3)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinThree[1], SwappedSkin(1, colorID));
                }
                else if (skinOneID == 4)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinFour[1], SwappedSkin(1, colorID));
                }
                else if (skinOneID == 5)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinFive[1], SwappedSkin(1, colorID));
                }
            }
            skinOneID = colorID;
        }
    }

     public void ColorColliderTwoChanger(int colorID)
    {
        if (skinTwoID != colorID)
        {
            foreach (GameObject room in rooms)
            {
                if (skinTwoID == 0)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 1)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinZero[1], SwappedSkin(1, colorID));
                }
                else if (skinTwoID == 1)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 1)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinOne[1], SwappedSkin(1, colorID));
                }
                else if (skinTwoID == 2)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 1)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinTwo[1], SwappedSkin(1, colorID));
                }
                else if (skinTwoID == 3)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 1)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinThree[1], SwappedSkin(1, colorID));
                }
                else if (skinTwoID == 4)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 1)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinFour[1], SwappedSkin(1, colorID));
                }
                else if (skinTwoID == 5)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 1)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinFive[1], SwappedSkin(1, colorID));
                }
            }
            skinTwoID = colorID;
        }
    }
    TileBase SwappedSkin(int i, int colorID)
    {
        if (colorID == 0)
            return (skinZero[i]);
        if (colorID == 1)
            return (skinOne[i]);
        if (colorID == 2)
            return (skinTwo[i]);
        if (colorID == 3)
            return (skinThree[i]);
        if (colorID == 4)
            return (skinFour[i]);
        if (colorID == 5)
            return (skinFive[i]);
        return (null);
    }
}