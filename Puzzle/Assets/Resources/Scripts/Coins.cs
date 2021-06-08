using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private GameObject hatButton;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            EquipHat();
        }
    }

    void EquipHat()
    {
        GameObject.FindGameObjectWithTag("HatButton").gameObject.SetActive(true);
    }
}
