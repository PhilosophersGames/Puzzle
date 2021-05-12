using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class SkinSlot : MonoBehaviour
{
    public GameObject trailSkin;

    public int slotID;

    private GameObject hamsterTrail;

    public bool isUnlocked;


    void Start()
    {
        hamsterTrail = GameObject.Find("HamsterTrail");
    }

    private void Update()
    {
        if (transform.childCount > 1)
        {
            foreach (Transform child in transform)
            {
                if (child.tag == "Element")
                {
                    if (child.GetComponent<DragDrop>().elementID == 4)
                       hamsterTrail.GetComponent<HamsterTrail>().SendMessage("ChangeTrail", trailSkin);
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