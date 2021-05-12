using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class SkinSlot : MonoBehaviour
{
  //  public int trailSkinID;

    public int slotID;

    private GameObject player;

    public bool isUnlocked;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                if (child.tag == "Element")
                {
                    if (child.GetComponent<DragDrop>().elementID == 4)
                       player.GetComponent<HamsterTrail>().SendMessage("ChangeTrail", slotID);
                }
            }
        }
    }

    public void SwitchElements(GameObject skinSlot)
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Element")
            {
               // PlayerPrefs.SetInt($"AssignedskinSlot{child.GetComponent<DragDrop>().elementID.ToString()}", skinSlot.GetComponent<SkinSlot>().slotID + 1);
                child.transform.position = skinSlot.transform.position;
                child.SetParent(skinSlot.transform);
            }
        }
    }
}