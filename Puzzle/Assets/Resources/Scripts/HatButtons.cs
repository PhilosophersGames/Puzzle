using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatButtons : MonoBehaviour
{
    private GameObject hat;
        private void Start()
        {
            if (GameObject.FindGameObjectWithTag("Hat"))
                hat = GameObject.FindGameObjectWithTag("Hat");
        }

        public void EquipHat()
        {
            hat.GetComponent<Hat>().EquipHat();
        }

        public void UnequipHat()
        {
            hat.GetComponent<Hat>().UnequipHat();
        }
}