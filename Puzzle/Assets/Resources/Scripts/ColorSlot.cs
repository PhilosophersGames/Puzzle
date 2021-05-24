using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class ColorSlot : MonoBehaviour
{
    public Color colorID;
    public int slotID;

    private GameObject skinManager;

    [Header("SHOP")]
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject User;
    public int colorPrice;
    public bool isUnlocked;
    public GameObject BuyConfirmationPanel;

    [Header("Save System")]
    public GameObject[] element;

    void Start()
    {
        text.text = colorPrice.ToString();
        if(transform.childCount > 1 && PlayerPrefs.GetInt($"AssignedColorSlot{transform.GetChild(1).GetComponent<DragDrop>().elementID.ToString()}") == 0)
            PlayerPrefs.SetInt($"AssignedColorSlot{transform.GetChild(1).GetComponent<DragDrop>().elementID.ToString()}", slotID + 1);
        // load the LockState of the Colorslot
         if(slotID > 3)
        isUnlocked = PlayerPrefs.GetInt($"Color{slotID.ToString()}LockState") == 1 ? true : false;
        //Load element's previously chosen slots
        for(int i = 0; i < element.Length; i++)
        {
            if(PlayerPrefs.GetInt($"AssignedColorSlot{element[i].GetComponent<DragDrop>().elementID.ToString()}") == slotID + 1)
            {
                element[i].transform.position = transform.position;
                element[i].transform.SetParent(transform);
            }
        }
        if(isUnlocked)
        transform.GetChild(0).gameObject.SetActive(false);
        skinManager = GameObject.FindGameObjectWithTag("SkinManager");
        colorID = GetComponent<Image>().color;
    }

    private void Update()
    {
        if (transform.childCount > 0)
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
                    else if (child.GetComponent<DragDrop>().elementID == 3)
                        skinManager.GetComponent<TileSwap>().SendMessage("ColorHamsterChanger", colorID);
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
                PlayerPrefs.SetInt($"AssignedColorSlot{child.GetComponent<DragDrop>().elementID.ToString()}", colorSlot.GetComponent<ColorSlot>().slotID + 1);
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
            PlayerPrefs.SetInt($"Color{slotID.ToString()}LockState", 1);
            transform.GetChild(0).gameObject.SetActive(false);
            User.SendMessage("UpdateUserMoney", -colorPrice);
        }
    }
}