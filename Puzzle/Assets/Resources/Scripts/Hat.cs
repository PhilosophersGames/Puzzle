using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    private GameObject hatButton;
    public bool hatEquiped = false;

    public GameObject hatSprite;
    public int hatType;

    private void Awake() 
    {
        hatButton = GameObject.FindGameObjectWithTag("HatButton");
        hatButton.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Phantom"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            if (hatType == 0)
                hatButton.transform.GetChild(0).gameObject.SetActive(true);
            EquipHat();
        }
    }

    public void EquipHat()
    {
        hatEquiped = true;
        hatSprite.SetActive(true);
        transform.GetComponent<SpriteRenderer>().enabled = false;
    }
    
    public void UnequipHat()
    {
        hatEquiped = false;
        hatSprite.SetActive(false);
    }

    void RotateNeighborRoom()
    {

    }
}