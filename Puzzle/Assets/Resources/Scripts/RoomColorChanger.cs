using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomColorChanger : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isPlayerHere = false;

    public int roomID;

    private GameObject player;

    public Tilemap colider;
    public Tilemap path;
    public Tilemap decoration;

    private Color color;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerHere)
        {
            color = Color.white;
            color.a = 1f;
            colider.color = color;
            path.color = color;
            decoration.color = color;
        }
        else
        {
            color = new Color(0.70f,0.70f,0.70f,1f);
           // color.a = 0.8f;
            colider.color = color;
            path.color = color;
            decoration.color = color;
        }
        
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
    }
}

