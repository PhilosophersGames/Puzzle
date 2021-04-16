using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class ColorSlot : MonoBehaviour
{

    public int colorID;

    private GameObject skinManager;

    void Start()
    {
        skinManager = GameObject.FindGameObjectWithTag("SkinManager");
    }

    private void Update()
    {
        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).GetComponent<DragDrop>().elementID == 0)
                skinManager.GetComponent<TileSwap>().ColorColliderOneChanger(colorID);
            else if (transform.GetChild(0).GetComponent<DragDrop>().elementID == 1)
                skinManager.GetComponent<TileSwap>().ColorColliderTwoChanger(colorID);
            else if (transform.GetChild(0).GetComponent<DragDrop>().elementID == 2)
                  skinManager.GetComponent<TileSwap>().ColorPathChanger(colorID);
        }
    }

    public void SwitchElements(GameObject colorSlot)
    {
        Debug.Log(colorSlot.name);
        transform.GetChild(0).transform.position = colorSlot.transform.position;
        transform.GetChild(0).SetParent(colorSlot.transform);
    }
}