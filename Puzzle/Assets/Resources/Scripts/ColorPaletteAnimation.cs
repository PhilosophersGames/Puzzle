using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaletteAnimation : MonoBehaviour
{
   [SerializeField] private Animator[] anim;

   [SerializeField] private Animator showUIButtonAnim;

   [SerializeField] private GameObject showUIButton;

    [SerializeField] private GameObject pauseButton;

   [SerializeField] private GameObject[] panel;

	private bool firstUpdateFrame = true;

    public void LateUpdate()
    {
        if(panel[0].active && firstUpdateFrame)
		{
            panel[0].SetActive(false);
            panel[1].SetActive(false);
			firstUpdateFrame = false;
		}
    }

    public void ActivePanel()
    {
        if (panel[0].active)
        {
            showUIButtonAnim.SetTrigger("HideUI");
            pauseButton.SetActive(false);
            anim[0].SetTrigger("ClosePanel");
            anim[1].SetTrigger("ClosePanel");
        }
        else
        {
            showUIButtonAnim.SetTrigger("ShowUI");           
            pauseButton.SetActive(true);
			panel[0].SetActive(true);
            anim[0].SetTrigger("OpenPanel");
            panel[1].SetActive(true);
            anim[1].SetTrigger("OpenPanel");
        }
    }
}
