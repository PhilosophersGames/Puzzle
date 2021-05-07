using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

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

    public GameObject rotateRightButton;

    public GameObject rotateLeftButton;

    public GameObject joystick;

    private Image image;

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
       // joystick.transform.GetChild(0).GetComponent<Image>().color.a = 0.7f;
    }
    public void ColorPathChanger(Color newColorID)
    {
        if (colorPathID != newColorID)
        {
            foreach (GameObject room in rooms)
            {
                room.GetComponent<RoomColorChanger>().path.color = newColorID;
            }
            joystick.GetComponent<Image>().color = newColorID;
            joystick.transform.GetChild(0).GetComponent<Image>().color = newColorID;
            var tempColor = joystick.transform.GetComponent<Image>().color;
            tempColor.a = 0.5f;
            joystick.transform.GetComponent<Image>().color = tempColor;
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
            rotateRightButton.GetComponent<Image>().color = newColorID;
            rotateRightButton.transform.GetChild(0).GetComponent<Image>().color = newColorID;
            image = rotateRightButton.transform.GetChild(0).GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.7f);
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
            rotateLeftButton.GetComponent<Image>().color = newColorID;
            rotateLeftButton.transform.GetChild(0).GetComponent<Image>().color = newColorID;
            image = rotateLeftButton.transform.GetChild(0).GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.7f);
            colorOneID = newColorID;
        }
        colorTwoID = newColorID;  
    }
}