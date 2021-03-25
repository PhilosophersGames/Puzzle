using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideManager : MonoBehaviour
{
    public bool drawBorderCollider;

    private IEnumerator coroutine;
    private void Start()
    {
        //  StartChangeBool();   
    }

    public void StartChangeBool()
    {
        coroutine = ChangeBool();
        StartCoroutine(coroutine);
    }
    public IEnumerator ChangeBool()
    {
        float waitTime = 0.1f;

        yield return new WaitForSeconds(waitTime);
        drawBorderCollider = false;
        Debug.Log(drawBorderCollider);
    }
}
