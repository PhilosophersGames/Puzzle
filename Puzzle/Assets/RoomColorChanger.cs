using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomColorChanger : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isPlayerHere = false;

    private GameObject player;

    public Tilemap colider;
    public Tilemap path;
    public Tilemap decoration;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerHere)
        {
            colider.color = Color.white;
            path.color = Color.white;
            decoration.color = Color.white;
        }
        else
        {
            colider.color = Color.red;
            path.color = Color.red;
            decoration.color = Color.red;
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
