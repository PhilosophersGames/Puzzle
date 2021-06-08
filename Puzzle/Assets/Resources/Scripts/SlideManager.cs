using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideManager : MonoBehaviour
{
    public bool drawBorderCollider;

    private IEnumerator coroutine;

    public bool thereIsColliders;

    private void Start()
    {   
        thereIsColliders = true;
    }

    public void StartChangeBool()
    {
        drawBorderCollider = false;
        thereIsColliders = true;
    }
}
