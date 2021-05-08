using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyColorSlotConfirmationPanel : MonoBehaviour
{
    public GameObject colorSlot;
    
    public void SendPurchaseConfirmation(bool purchase)
    {
        colorSlot.SendMessage("PurchaseColor", purchase);
        gameObject.SetActive(false);
    }
}
