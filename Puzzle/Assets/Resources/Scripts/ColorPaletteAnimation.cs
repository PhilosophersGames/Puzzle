using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaletteAnimation : MonoBehaviour
{
   [SerializeField] private GameObject[] panel;
   [SerializeField] private GameObject panelManager;
   [SerializeField] private Animator panelManagerAnim;
                                                                                                                                                             
    private bool firstUpdateFrame = true;

    /*public void LateUpdate()
    {
        if(panel[0].active && firstUpdateFrame)
		{
            panel[0].SetActive(false);
            panel[1].SetActive(false);
			firstUpdateFrame = false;
		}
    }*/

    public void OpenPanel()
    {
        panelManagerAnim.SetTrigger("OpenPanel");
    }

    public void ClosePanel()
    {
            panelManagerAnim.SetTrigger("ClosePanel");
    }
}