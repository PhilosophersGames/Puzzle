using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    private GameObject hatButton;
    public bool hatEquiped = false;
    public bool phantomHatEquiped = false;
    public GameObject hatSprite;
    private GameObject character;
    public int hatType;

    private void Awake() 
    {
        hatButton = GameObject.FindGameObjectWithTag("HatButton");
        hatButton.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            character = other.gameObject;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            if (hatType == 0)
                hatButton.transform.GetChild(0).gameObject.SetActive(true);
            EquipHat();
        }
        if(other.CompareTag("Phantom"))
        {
            character = other.gameObject;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            phantomHatEquiped = true;
            character.transform.GetChild(1).gameObject.SetActive(true);
            transform.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void EquipHat()
    {
        hatEquiped = true;
        character.transform.GetChild(1).gameObject.SetActive(true);
        transform.GetComponent<SpriteRenderer>().enabled = false;
    }
    
    public void UnequipHat()
    {
        hatEquiped = false;
        character.transform.GetChild(1).gameObject.SetActive(false);
    }

    void RotateNeighborRoom()
    {

    }
}