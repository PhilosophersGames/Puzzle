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
        coroutine = ChangeBool();
        StartCoroutine(coroutine);
    }
    public IEnumerator ChangeBool()
    {
        float waitTime = 0.01f;

        yield return new WaitForSeconds(waitTime);
        drawBorderCollider = false;
        thereIsColliders = true;
    }
}
