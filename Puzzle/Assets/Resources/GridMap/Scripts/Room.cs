using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(5, 5, 1f, new Vector3(0, 0, 0), this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
