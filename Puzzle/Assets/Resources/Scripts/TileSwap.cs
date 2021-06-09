using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TileSwap : MonoBehaviour
{

    [Header("START SKIN")]
    public TileBase[] startSkin;

    [Header("BASIC SKIN")]
    public TileBase[] basicSkin;

    [Header("STAR SKIN")]
    public TileBase[] skinOne;

    [Header("TEST SKIN")]
    public TileBase[] skinTwo;

    [Header("LIGHTNING SKIN")]
    public TileBase[] skinThree;

    private GameObject[] rooms;

    public Color colorPathID;

    public Color colorOneID;

    public Color colorTwoID;

    public Color colorHamsterID;

    public GameObject rotateRightButton;

    public GameObject rotateLeftButton;

    public GameObject joystick;

    public GameObject fakeJoystick;

    public GameObject pauseButton;

    private Image image;

    private GameObject hamsterBall;

    private GameObject[] trails;

    private GameObject backgroundVFX;

    private int actualSkinID = 0;

    void Start()
    {
        hamsterBall = GameObject.Find("HamsterBall");
        rooms = GameObject.FindGameObjectsWithTag("RoomSkin");
        backgroundVFX = GameObject.Find("BackGroundsVFX");
        foreach (GameObject room in rooms)
        {
            room.GetComponent<RoomColorChanger>().path.SwapTile(startSkin[0], basicSkin[0]);
            room.GetComponent<RoomColorChanger>().path.SwapTile(startSkin[2], basicSkin[0]);
            room.GetComponent<RoomColorChanger>().colider.SwapTile(startSkin[1], basicSkin[1]);
            room.GetComponent<RoomColorChanger>().colider.SwapTile(startSkin[3], basicSkin[1]);
            room.GetComponent<RoomColorChanger>().colider.gameObject.GetComponent<CompositeCollider2D>().GenerateGeometry();
        }
        for (int i = 0; i < backgroundVFX.transform.childCount; i++)
        {
            backgroundVFX.transform.GetChild(i).gameObject.SetActive(false);
        }
        if (backgroundVFX.transform.childCount > actualSkinID)
            backgroundVFX.transform.GetChild(actualSkinID).gameObject.SetActive(true);
    }

    public void GenerateSkinAndColliders(TileBase[] newSkin, int newSkinID)
    {
        foreach (GameObject room in rooms)
        {
            if (actualSkinID == 0)
            {
         //       room.GetComponent<RoomColorChanger>().path.SwapTile(basicSkin[0], newSkin[0]);
                room.GetComponent<RoomColorChanger>().colider.SwapTile(basicSkin[1], newSkin[1]);
            }
            else if (actualSkinID == 1)
            {
           //     room.GetComponent<RoomColorChanger>().path.SwapTile(skinOne[0], newSkin[0]);
                room.GetComponent<RoomColorChanger>().colider.SwapTile(skinOne[1], newSkin[1]);
            }
            else if (actualSkinID == 2)
            {
       //         room.GetComponent<RoomColorChanger>().path.SwapTile(skinTwo[0], newSkin[0]);
                room.GetComponent<RoomColorChanger>().colider.SwapTile(skinTwo[1], newSkin[1]);
            }
            else if (actualSkinID == 3)
            {
         //       room.GetComponent<RoomColorChanger>().path.SwapTile(skinThree[0], newSkin[0]);
                room.GetComponent<RoomColorChanger>().colider.SwapTile(skinThree[1], newSkin[1]);
            }
        }
        for (int i = 0; i < backgroundVFX.transform.childCount; i++)
        {
            backgroundVFX.transform.GetChild(i).gameObject.SetActive(false);
        }
        if (backgroundVFX.transform.childCount > newSkinID)
            backgroundVFX.transform.GetChild(newSkinID).gameObject.SetActive(true);
        actualSkinID = newSkinID;
    }

    public void SkinChanger(int newSkinID)
    {
       
        if (actualSkinID != newSkinID)
        {
            if (newSkinID == 0)
                GenerateSkinAndColliders(basicSkin, newSkinID);
            else if (newSkinID == 1)
                GenerateSkinAndColliders(skinOne, newSkinID);
            else if (newSkinID == 2)
                GenerateSkinAndColliders(skinTwo, newSkinID);
            else if (newSkinID == 3)
                GenerateSkinAndColliders(skinThree, newSkinID);
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
            pauseButton.GetComponent<Image>().color = newColorID; 
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
            image = rotateLeftButton.transform.GetChild(0).GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.7f);
            colorOneID = newColorID;
        }
        colorTwoID = newColorID; 
    }

    public void ColorHamsterChanger(Color newColorID)
    {
        if (colorHamsterID != newColorID)
        {
            rotateRightButton.GetComponent<Image>().color = newColorID;
            rotateRightButton.transform.GetChild(0).GetComponent<Image>().color = newColorID;
            rotateRightButton.transform.GetChild(2).GetComponent<Image>().color = newColorID;
            rotateLeftButton.GetComponent<Image>().color = newColorID;
            rotateLeftButton.transform.GetChild(0).GetComponent<Image>().color = newColorID;
            rotateLeftButton.transform.GetChild(2).GetComponent<Image>().color = newColorID;
            /// joystick
            joystick.GetComponent<Image>().color = newColorID;
            joystick.transform.GetChild(0).GetComponent<Image>().color = newColorID;
            var tempColor = joystick.transform.GetComponent<Image>().color;
            tempColor.a = 0.5f;
            joystick.transform.GetComponent<Image>().color = tempColor;
            //// fake joystick
            fakeJoystick.GetComponent<Image>().color = newColorID;
            fakeJoystick.transform.GetChild(0).GetComponent<Image>().color = newColorID;
            var tmpColor = fakeJoystick.transform.GetComponent<Image>().color;
            tmpColor.a = 0.5f;
            fakeJoystick.transform.GetComponent<Image>().color = tmpColor;
            ///

            hamsterBall.GetComponent<SpriteRenderer>().color = newColorID;
            if (GameObject.FindGameObjectWithTag("Trail"))
            {
                trails = GameObject.FindGameObjectsWithTag("Trail");
                trails[0].GetComponent<ParticleSystem>().startColor = newColorID;
                trails[1].GetComponent<ParticleSystem>().startColor = newColorID;
            /*    Gradient grad = new Gradient();
                grad.SetKeys(new GradientColorKey[] { new GradientColorKey(newColorID, 1.0f), new GradientColorKey(newColorID, 0.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
                var colorOverLifetime = GameObject.FindGameObjectWithTag("Trail").transform.GetComponent<ParticleSystem>().colorOverLifetime;
                colorOverLifetime.color = grad;
                for (int i = 0; i < GameObject.FindGameObjectWithTag("Trail").transform.childCount; i++)
                {
                    GameObject.FindGameObjectWithTag("Trail").transform.GetChild(i).GetComponent<ParticleSystem>().startColor = newColorID;
                    var col = GameObject.FindGameObjectWithTag("Trail").transform.GetChild(i).GetComponent<ParticleSystem>().colorOverLifetime;
                    if (GameObject.FindGameObjectWithTag("Trail").transform.GetChild(i).GetComponent<ParticleSystem>().colorOverLifetime.enabled == true)
                        col.color = grad;
                }*/
            }
            colorHamsterID = newColorID;
        }
    }
}