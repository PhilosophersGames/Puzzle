using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaletteAnimation : MonoBehaviour
{
   [SerializeField] private Animator anim;

    public GameObject panel;

    public void TriggerColorPaletteAnimation()
    {
            anim.SetTrigger("Active");
    }

    public void ActivePanel()
    {
        if (panel.active)
            panel.SetActive(false);
        else
        {
            panel.SetActive(true);
            TriggerColorPaletteAnimation();
        }
    }
}
