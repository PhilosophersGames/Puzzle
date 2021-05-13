using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteAnimEvent : MonoBehaviour
{
    public void DisablePanel()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
