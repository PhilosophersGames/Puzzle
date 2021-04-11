using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomColorChanger : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isPlayerHere = false;

    public GameObject[] neighborRoom = new GameObject[4];

    public int roomID;

    private GameObject player;

    public Tilemap colider;
    public Tilemap path;
    public Tilemap decoration;

    private Color color;

    public GameObject hat;

    public float RotationSpeed = 100;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (GameObject.FindGameObjectWithTag("Hat"))
            hat = GameObject.FindGameObjectWithTag("Hat");
        ColorChamber(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hat && hat.GetComponent<Hat>().hatEquiped)
        {
            if (isPlayerHere)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (neighborRoom[i].GetComponent<RoomDetector>().room)
                        neighborRoom[i].GetComponent<RoomDetector>().room.transform.GetComponent<RoomColorChanger>().ColorChamber(true);
                    else
                        neighborRoom[i].transform.parent.parent.GetComponent<RoomColorChanger>().ColorChamber(false);
                }
            }
        }
        else if (!hat || (hat && !hat.GetComponent<Hat>().hatEquiped))
            ColorChamber(isPlayerHere);
    }

    public void ColorChamber(bool delta)
    {
        /*if (delta == true)
        {
            color = Color.white;
            color.a = 1f;
            colider.color = color;
            path.color = color;
            decoration.color = color;
        }
        else if (delta == false)
        {
            color = new Color(0.5f, 0.5f, 0.5f, 1f);
            colider.color = color;
            path.color = color;
            decoration.color = color;
        }*/
        if (delta == true)
            transform.GetChild(2).transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime ));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerHere = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerHere = false;
        for (int i = 0; i < 4; i++)
        {
            //Debug.Log(neighborRoom[i].GetComponent<RoomDetector>().room);
            if (neighborRoom[i].GetComponent<RoomDetector>().room)
                neighborRoom[i].GetComponent<RoomDetector>().room.transform.GetComponent<RoomColorChanger>().ColorChamber(false);
            else
                neighborRoom[i].transform.parent.parent.GetComponent<RoomColorChanger>().ColorChamber(false);
        }
    }
}