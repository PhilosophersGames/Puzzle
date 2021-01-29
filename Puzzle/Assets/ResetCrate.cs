using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCrate : MonoBehaviour
{
    private GameObject CrateButton;
    public GameObject crate;
    public Transform resetPosition;
    private bool zoneEnter;

    void Start()
    {
        CrateButton = GameObject.Find("GameManager/UIcanvas/ResetCrateButton");
        CrateButton.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            RstCrate();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            zoneEnter = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            zoneEnter = false;
        }
    }

    public void RstCrate()
    {
        if (zoneEnter == true)
        {
            crate.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            crate.transform.position = new Vector3(resetPosition.position.x, resetPosition.position.y, 0);
        }
    }
}
