using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSwap : MonoBehaviour
{

    [Header("START SKIN")]
    public TileBase[] startSkin;

    [Header("WHITE")]
    public TileBase[] colorZero;

    [Header("BLACK")]
    public TileBase[] colorOne;

    [Header("RED")]
    public TileBase[] colorTwo;

    [Header("ORANGE")]
    public TileBase[] colorThree;

    [Header("YELLOW")]
    public TileBase[] colorFour;

    [Header("GREEN")]
    public TileBase[] colorFive;

    [Header("BLUE")]
    public TileBase[] colorSix;

    [Header("PURPLE")]
    public TileBase[] colorSeven;
    private GameObject[] rooms;
    public int colorPathID;
    public int colorOneID;
    public int colorTwoID;
    private void Start()
    {
        rooms = GameObject.FindGameObjectsWithTag("RoomSkin");
        colorOneID = 0;
        colorTwoID = 1;
        colorPathID = 3;
        foreach (GameObject room in rooms)
        {
            room.GetComponent<RoomColorChanger>().path.SwapTile(startSkin[0], Swappedcolor(0, 3));
            room.GetComponent<RoomColorChanger>().path.SwapTile(startSkin[2], Swappedcolor(0, 3));
            if (room.GetComponent<RoomColorChanger>().roomID == 0)
                room.GetComponent<RoomColorChanger>().colider.SwapTile(startSkin[1], Swappedcolor(1, 0));
            else if (room.GetComponent<RoomColorChanger>().roomID == 1)
                room.GetComponent<RoomColorChanger>().colider.SwapTile(startSkin[1], Swappedcolor(1, 1));
            if (room.GetComponent<RoomColorChanger>().roomID == 0)
                room.GetComponent<RoomColorChanger>().colider.SwapTile(startSkin[3], Swappedcolor(1, 0));
            else if (room.GetComponent<RoomColorChanger>().roomID == 1)
                room.GetComponent<RoomColorChanger>().colider.SwapTile(startSkin[3], Swappedcolor(1, 1));
        }
    }
    public void ColorPathChanger(int newColorID)
    {
        if (colorPathID != newColorID)
        {
            foreach (GameObject room in rooms)
            {
                if (colorPathID == 0)
                    room.GetComponent<RoomColorChanger>().path.SwapTile(colorZero[0], Swappedcolor(0, newColorID));
                else if (colorPathID == 1)
                    room.GetComponent<RoomColorChanger>().path.SwapTile(colorOne[0], Swappedcolor(0, newColorID));
                else if (colorPathID == 2)
                    room.GetComponent<RoomColorChanger>().path.SwapTile(colorTwo[0], Swappedcolor(0, newColorID));
                else if (colorPathID == 3)
                    room.GetComponent<RoomColorChanger>().path.SwapTile(colorThree[0], Swappedcolor(0, newColorID));
                else if (colorPathID == 4)
                    room.GetComponent<RoomColorChanger>().path.SwapTile(colorFour[0], Swappedcolor(0, newColorID));
                else if (colorPathID == 5)
                    room.GetComponent<RoomColorChanger>().path.SwapTile(colorFive[0], Swappedcolor(0, newColorID));
                else if (colorPathID == 6)
                    room.GetComponent<RoomColorChanger>().path.SwapTile(colorSix[0], Swappedcolor(0, newColorID));
                else if (colorPathID == 7)
                    room.GetComponent<RoomColorChanger>().path.SwapTile(colorSeven[0], Swappedcolor(0, newColorID));
            }
            colorPathID = newColorID;
        }
    }
    public void ColorColliderOneChanger(int newColorID)
    {
        if (colorOneID != newColorID)
        {
            foreach (GameObject room in rooms)
            {
                if (colorOneID == 0)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorZero[1], Swappedcolor(1, newColorID));
                }
                else if (colorOneID == 1)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorOne[1], Swappedcolor(1, newColorID));
                }
                else if (colorOneID == 2)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorTwo[1], Swappedcolor(1, newColorID));
                }
                else if (colorOneID == 3)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorThree[1], Swappedcolor(1, newColorID));
                }
                else if (colorOneID == 4)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorFour[1], Swappedcolor(1, newColorID));
                }
                else if (colorOneID == 5)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorFive[1], Swappedcolor(1, newColorID));
                }
                else if (colorOneID == 6)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorSix[1], Swappedcolor(1, newColorID));
                }
                else if (colorOneID == 7)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorSeven[1], Swappedcolor(1, newColorID));
                }
            }
            colorOneID = newColorID;
        }
    }
    public void ColorColliderTwoChanger(int newColorID)
    {
        if (colorTwoID != newColorID)
        {
            foreach (GameObject room in rooms)
            {
                if (colorTwoID == 0)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 1)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorZero[1], Swappedcolor(1, newColorID));
                }
                else if (colorTwoID == 1)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 1)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorOne[1], Swappedcolor(1, newColorID));
                }
                else if (colorTwoID == 2)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 1)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorTwo[1], Swappedcolor(1, newColorID));
                }
                else if (colorTwoID == 3)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 1)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorThree[1], Swappedcolor(1, newColorID));
                }
                else if (colorTwoID == 4)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 1)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorFour[1], Swappedcolor(1, newColorID));
                }
                else if (colorTwoID == 5)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 1)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorFive[1], Swappedcolor(1, newColorID));
                }
                else if (colorTwoID == 6)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 1)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorSix[1], Swappedcolor(1, newColorID));
                }
                else if (colorTwoID == 7)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 1)
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(colorSeven[1], Swappedcolor(1, newColorID));
                }
            }
            colorTwoID = newColorID;
        }
    }
    TileBase Swappedcolor(int i, int newColorID)
    {
        if (newColorID == 0)
            return (colorZero[i]);
        if (newColorID == 1)
            return (colorOne[i]);
        if (newColorID == 2)
            return (colorTwo[i]);
        if (newColorID == 3)
            return (colorThree[i]);
        if (newColorID == 4)
            return (colorFour[i]);
        if (newColorID == 5)
            return (colorFive[i]);
        if (newColorID == 6)
            return (colorSix[i]);
        if (newColorID == 7)
            return (colorSeven[i]);
        return (null);
    }
}