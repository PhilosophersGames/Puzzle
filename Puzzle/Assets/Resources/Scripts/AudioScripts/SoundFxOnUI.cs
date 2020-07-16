using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundFxOnUI : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData ped)
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.AshkanMouseOverSFX);
   //     transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData ped)
    {
     //   transform.GetChild(0).gameObject.SetActive(false);
    }
    public void OnPointerDown(PointerEventData ped)
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.AshkanMouseClickSFX);
        //  SoundManager.Play("MouseClickButton"); 
    }
}