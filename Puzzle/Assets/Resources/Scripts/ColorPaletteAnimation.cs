using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaletteAnimation : MonoBehaviour
{
   [SerializeField] private Animator anim;

    public GameObject panel;

	private bool firstUpdateFrame = true;

    public void Update()
    {
        if(panel.active && firstUpdateFrame)
		{
            panel.SetActive(false);
			firstUpdateFrame = false;
		}
    }

    public void ActivePanel()
    {
        if (panel.active)
            anim.SetTrigger("ClosePanel");
        else
        {
			panel.SetActive(true);
            anim.SetTrigger("OpenPanel");
        }
    }
}
