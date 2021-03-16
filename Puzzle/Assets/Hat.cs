using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    private GameObject hatButton;
    public bool hatEquiped = false;

    private void Awake() 
    {
        hatButton = GameObject.FindGameObjectWithTag("HatButton");
        hatButton.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hatButton.SetActive(true);
            EquipHat();
        }
    }

    public void EquipHat()
    {
        hatEquiped = true;
        transform.GetComponent<SpriteRenderer>().enabled = true;
    }
    
    public void UnequipHat()
    {
        hatEquiped = false;
        transform.GetComponent<SpriteRenderer>().enabled = false;
    }

    void RotateNeighborRoom()
    {

    }
}