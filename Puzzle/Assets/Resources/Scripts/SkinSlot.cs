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

    [SerializeField] private GameObject element;

    [Header("SHOP")]
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject User;
    [SerializeField] private GameObject joystickThumb;
    public int skinPrice;
    public GameObject BuyConfirmationPanel;
    private GameObject skinManager;

    void Start()
    {
        text.text = skinPrice.ToString();
        if(transform.childCount > 1 && PlayerPrefs.GetInt($"AssignedTrailSlot") == 0)
            PlayerPrefs.SetInt("AssignedTrailSlot", slotID + 1);
            if(PlayerPrefs.GetInt("AssignedTrailSlot") == slotID + 1)
            {
                element.transform.position = transform.position;
                element.transform.SetParent(transform);
            }

        /// element id = 5 -> TILES
        if(transform.childCount > 1 && PlayerPrefs.GetInt($"AssignedTilesSlot") == 0 && transform.GetChild(1).gameObject.GetComponent<DragDrop>().elementID == 5)
            PlayerPrefs.SetInt("AssignedTilesSlot", slotID + 1);
        if (transform.childCount > 1 && PlayerPrefs.GetInt("AssignedTilesSlot") == slotID + 1 && transform.GetChild(1).gameObject.GetComponent<DragDrop>().elementID == 5)
        {
            element.transform.position = transform.position;
            element.transform.SetParent(transform);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        if(slotID != 0)
            isUnlocked = PlayerPrefs.GetInt($"Skin{slotID.ToString()}LockState") == 1 ? true : false;
        if(isUnlocked)
            transform.GetChild(0).gameObject.SetActive(false);
        skinManager = GameObject.FindGameObjectWithTag("SkinManager");
    }

    private void Update()
    {
        if (transform.childCount > 1)
        {
           if (transform.GetChild(1).GetComponent<DragDrop>().elementID == 4 && player.GetComponent<HamsterTrail>().actualTrailID != slotID)
           {
                player.GetComponent<HamsterTrail>().SendMessage("ChangeTrail", slotID);
                if(joystickThumb)
                {
                    joystickThumb.GetComponent<HamsterTrail>().SendMessage("ChangeTrail", slotID);
           }
           else if (transform.GetChild(1).GetComponent<DragDrop>().elementID == 5)
           {
                skinManager.GetComponent<TileSwap>().SkinChanger(slotID);
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
        if (purchase && skinPrice <= User.GetComponent<User>().wallet)
        {
            isUnlocked = true;
            PlayerPrefs.SetInt($"Skin{slotID.ToString()}LockState", 1);
            transform.GetChild(0).gameObject.SetActive(false);
            User.SendMessage("UpdateUserMoney", -skinPrice);
        }
    }
}