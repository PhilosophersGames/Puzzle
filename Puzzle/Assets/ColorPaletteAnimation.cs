using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaletteAnimation : MonoBehaviour
{
   [SerializeField] private Animator anim;
 
    public void TriggerColorPaletteAnimation()
    {
            anim.SetTrigger("Active");
    }
}
