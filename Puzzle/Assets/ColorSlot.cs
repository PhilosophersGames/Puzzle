using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class ColorSlot : MonoBehaviour
{
    public int colorID;
    private GameObject skinManager;

    [Header("SHOP")]
 
    [SerializeField] private GameObject User;
    public int colorPrice;
    public bool isUnlocked;
    public GameObject BuyConfirmationPanel;
    void Start()
    {
        skinManager = GameObject.FindGameObjectWithTag("SkinManager");

    }
    private void Update()
    {
        if (transform.childCount > 1)
        {
            foreach(Transform child in transform)
            {
                if(child.tag == "Element")
                {
                if (child.GetComponent<DragDrop>().elementID == 0)
                    skinManager.GetComponent<TileSwap>().SendMessage("ColorColliderOneChanger", colorID);
                else if (child.GetComponent<DragDrop>().elementID == 1)
                    skinManager.GetComponent<TileSwap>().SendMessage("ColorColliderTwoChanger", colorID);
                else if (child.GetComponent<DragDrop>().elementID == 2)
                    skinManager.GetComponent<TileSwap>().SendMessage("ColorPathChanger", colorID);
                }
            }
        }
    }

    public void SwitchElements(GameObject colorSlot)
    {
        Debug.Log(colorSlot.name);
        foreach(Transform child in transform)
        {
            if(child.tag == "Element")
            {
                child.transform.position = colorSlot.transform.position;
                child.SetParent(colorSlot.transform);
            }
        }
    }

    // SHOP related Scripts //

    public void EnableBuyConfirmationPanel()
    {
        BuyConfirmationPanel.SetActive(true);
        BuyConfirmationPanel.GetComponent<BuyColorSlotConfirmationPanel>().colorSlot = gameObject;
    }

        public void DisableBuyConfirmationPanel()
    {
        BuyConfirmationPanel.SetActive(false);
    }

    public void PurchaseColor(bool purchase)
    {
        if(purchase && colorPrice <= User.GetComponent<User>().wallet)
        {
            isUnlocked = true;
            transform.GetChild(0).gameObject.SetActive(false);
            User.SendMessage("UpdateUserMoney", -colorPrice);
        }
    }
}