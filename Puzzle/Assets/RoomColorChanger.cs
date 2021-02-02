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
            colider.SetColor(new Vector3Int(255, 255, 255), Color.white);
            path.SetColor(new Vector3Int(255, 255, 255), Color.white);
            decoration.SetColor(new Vector3Int(255, 255, 255), Color.white);
        }
        else
        {
            colider.SetColor(new Vector3Int(120, 120, 120), Color.white);
            path.SetColor(new Vector3Int(120, 120, 120), Color.white);
            decoration.SetColor(new Vector3Int(120, 120, 120), Color.white);
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
