using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjacentRooms : MonoBehaviour
{

    private GameObject[] neighborRoom;

    public GameObject[] roomDetector;
    // Start is called before the first frame update
    void Start()
    {
        neighborRoom = new GameObject[roomDetector.Length];
        int i = 0;
        foreach (GameObject room in roomDetector)
        {
            neighborRoom[i] = room.GetComponent<RoomDetector>().room;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
