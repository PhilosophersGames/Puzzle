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

    public Color colorHamsterID;

    public GameObject rotateRightButton;

    public GameObject rotateLeftButton;

    public GameObject joystick;

    public GameObject pauseButton;

    private Image image;

    private GameObject hamsterBall;

    private void Start()
    {
        hamsterBall = GameObject.Find("HamsterBall");
        rooms = GameObject.FindGameObjectsWithTag("RoomSkin");
        GenerateSkinAndColliders();  
    }

    public void GenerateSkinAndColliders()
    {
        foreach (GameObject room in rooms)
        {
           room.GetComponent<RoomColorChanger>().colider.gameObject.GetComponent<CompositeCollider2D>().GenerateGeometry();
           /* room.GetComponent<RoomColorChanger>().path.SwapTile(startSkin[0], newSkin[0]);
            room.GetComponent<RoomColorChanger>().path.SwapTile(startSkin[2], newSkin[0]);
            room.GetComponent<RoomColorChanger>().colider.SwapTile(startSkin[1], newSkin[1]);
            room.GetComponent<RoomColorChanger>().colider.SwapTile(startSkin[3], newSkin[1]);  */      
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

            // Joystick colors//
            joystick.GetComponent<Image>().color = newColorID;
            joystick.transform.GetChild(0).GetComponent<Image>().color = newColorID;
            var tempColor = joystick.transform.GetComponent<Image>().color;
            tempColor.a = 0.5f;
            joystick.transform.GetComponent<Image>().color = tempColor;
            colorPathID = newColorID;
            // Joystick colors

            // UI Pause Colors //
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
            rotateRightButton.GetComponent<Image>().color = newColorID;
           /* rotateRightButton.transform.GetChild(0).GetComponent<Image>().color = newColorID;
            image = rotateRightButton.transform.GetChild(0).GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.7f);*/
            colorOneID = newColorID;

            // UI Pause Button //
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

        // UI PauseButton .//
    }

    public void ColorHamsterChanger(Color newColorID)
    {
        if (colorHamsterID != newColorID)
        {
            
            hamsterBall.GetComponent<SpriteRenderer>().color = newColorID;
            if (GameObject.FindGameObjectWithTag("Trail"))
            {
                GameObject.FindGameObjectWithTag("Trail").GetComponent<ParticleSystem>().startColor = newColorID;
                Gradient grad = new Gradient();
                grad.SetKeys(new GradientColorKey[] { new GradientColorKey(newColorID, 1.0f), new GradientColorKey(newColorID, 0.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
                var colorOverLifetime = GameObject.FindGameObjectWithTag("Trail").transform.GetComponent<ParticleSystem>().colorOverLifetime;
                colorOverLifetime.color = grad;
                for (int i = 0; i < GameObject.FindGameObjectWithTag("Trail").transform.childCount; i++)
                {
                    GameObject.FindGameObjectWithTag("Trail").transform.GetChild(i).GetComponent<ParticleSystem>().startColor = newColorID;
                    var col = GameObject.FindGameObjectWithTag("Trail").transform.GetChild(i).GetComponent<ParticleSystem>().colorOverLifetime;
                    if (GameObject.FindGameObjectWithTag("Trail").transform.GetChild(i).GetComponent<ParticleSystem>().colorOverLifetime.enabled == true)
                        col.color = grad;
                }
            }
            colorHamsterID = newColorID;
        }
    }
}