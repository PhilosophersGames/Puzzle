using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Transform initialSlot;
    public int elementID;

    public bool isItColorSlot;

    private void Start()
    {
        initialSlot = transform.parent;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (isItColorSlot)
            canvas = GameObject.Find("PaletteCanvasColor").GetComponent<Canvas>();
        else
            canvas = GameObject.Find("PaletteCanvasSkin").GetComponent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        initialSlot = transform.parent;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position += new Vector3(eventData.delta.x, eventData.delta.y, 0);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        //  ================================================================= Drag an Element in a ColorSlot =================================================================

        if ((isItColorSlot && eventData.pointerCurrentRaycast.gameObject && eventData.pointerCurrentRaycast.gameObject.tag == "ColorSlot" && eventData.pointerCurrentRaycast.gameObject.GetComponent<ColorSlot>().isUnlocked)
            || (!isItColorSlot && eventData.pointerCurrentRaycast.gameObject && eventData.pointerCurrentRaycast.gameObject.tag == "SkinSlot" && eventData.pointerCurrentRaycast.gameObject.GetComponent<SkinSlot>().isUnlocked))
        {
            if (isItColorSlot && eventData.pointerCurrentRaycast.gameObject.transform.childCount > 1)
                eventData.pointerCurrentRaycast.gameObject.GetComponent<ColorSlot>().SwitchElements(initialSlot.gameObject);
            if (!isItColorSlot && eventData.pointerCurrentRaycast.gameObject.transform.childCount > 1)
                eventData.pointerCurrentRaycast.gameObject.GetComponent<SkinSlot>().SwitchElements(initialSlot.gameObject);
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
        }


        //  ================================================================= Drag an Element in another element =================================================================

        else if ((isItColorSlot && eventData.pointerCurrentRaycast.gameObject && eventData.pointerCurrentRaycast.gameObject.tag == "Element" && eventData.pointerCurrentRaycast.gameObject.transform.parent.GetComponent<ColorSlot>().isUnlocked)
            || (!isItColorSlot &&eventData.pointerCurrentRaycast.gameObject && eventData.pointerCurrentRaycast.gameObject.tag == "Element" && eventData.pointerCurrentRaycast.gameObject.transform.parent.GetComponent<SkinSlot>().isUnlocked))
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.transform);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.transform.position;
            if (eventData.pointerCurrentRaycast.gameObject.transform.parent.transform.childCount > 1)
                eventData.pointerCurrentRaycast.gameObject.transform.parent.GetComponent<ColorSlot>().SwitchElements(initialSlot.gameObject);
        }
        // ================================================================= Drag an Element anywhere else =================================================================
        else
            transform.position = initialSlot.position;   
        if (isItColorSlot)
            PlayerPrefs.SetInt($"AssignedColorSlot{elementID.ToString()}", transform.parent.GetComponent<ColorSlot>().slotID + 1);
    }
}