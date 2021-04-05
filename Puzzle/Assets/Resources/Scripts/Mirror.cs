﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{

    public int direction;
    private bool isActive = false;
    private int inactiveFrames;
    private Transform laserPoint;
    private LineRenderer lineRenderer;
    private float rotation = 45;

    private RaycastHit2D hit;

    private GameObject saveLaserReceiver;

    [SerializeField] private LayerMask layerMaskTab;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        laserPoint = transform.GetChild(0);

        if (direction == 1)
        {
            transform.Rotate(0, 0, -90, Space.Self);
        }
        if (direction == 2)
        {
            transform.Rotate(0, 0, -180, Space.Self);
        }
        if (direction == 3)
        {
            transform.Rotate(0, 0, -270, Space.Self);
        }
    }
    void Update()
    {
        if (isActive)
        {
            lineRenderer.enabled = true;
            hit = Physics2D.Raycast(transform.position, laserPoint.position - transform.position, Mathf.Infinity, ~layerMaskTab);
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
        if (hit)
        {
            if (hit.collider.tag == "LaserReceiver")
            {
                saveLaserReceiver = hit.collider.gameObject;
                hit.collider.SendMessage("OpenDoor", true);
            }
            else if (saveLaserReceiver && (!hit.collider || !(hit.collider.tag == "LaserReceiver")))
                saveLaserReceiver.SendMessage("OpenDoor", false);
        }

    }
    public void ActivateLaser()
    {
        inactiveFrames = 0;
        isActive = true;
    }
}
