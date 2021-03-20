using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    private bool isActive = false;
    private int inactiveFrames;
    private Transform laserPoint;
    private LineRenderer lineRenderer;
    private float rotation = 45;


    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        laserPoint = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            lineRenderer.enabled = true;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, laserPoint.position - transform.position);
            lineRenderer.SetPosition(0, laserPoint.position);
            lineRenderer.SetPosition(1, hit.point);
            inactiveFrames += 1;
        }
        else
        {
            lineRenderer.enabled = false;
        }
        if (inactiveFrames > 5)
        {
            isActive = false;
        }

    }

    public void ActivateLaser()
    {
        inactiveFrames = 0;
        isActive = true;
    }

    public void Interaction()
    {
        transform.eulerAngles += Vector3.forward * rotation;
    }
}
