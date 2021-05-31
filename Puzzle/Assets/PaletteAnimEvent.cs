using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteAnimEvent : MonoBehaviour
{

    [SerializeField] private GameObject switchPaletteButton;
    
    public void DisablePanel()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void EnableSwitchPaletteButton()
    {
        switchPaletteButton.SetActive(true);
    }

    public void DisableSwitchPaletteButton()
    {
        switchPaletteButton.SetActive(false);
    }
}
