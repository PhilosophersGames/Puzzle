using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    private GameObject hatButton;
    public bool hatEquiped;

    private void Awake() {
        hatButton = GameObject.FindGameObjectWithTag("HatButton");
        hatButton.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
           EquipHat();
        }
    }

    void EquipHat()
    {
        hatEquiped = true;
        hatButton.SetActive(true);
        transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
       // transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    
    void UnequipHat()
    {
        hatEquiped = false;
        transform.GetComponent<SpriteRenderer>().enabled = false;
    }

    void RotateNeighborRoom()
    {

    }
}