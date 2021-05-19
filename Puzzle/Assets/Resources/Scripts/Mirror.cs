using System.Collections;
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

    private RaycastHit2D fakeHit;

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
       /* if (GameObject.FindGameObjectWithTag("RoomsContainer").GetComponent<SlideManager>().thereIsColliders)
            lineRenderer.enabled = true;
        else
            lineRenderer.enabled = false;*/
        if (isActive)
        {
            lineRenderer.enabled = true;
            hit = Physics2D.Raycast(laserPoint.position, laserPoint.position - transform.position, Mathf.Infinity, ~layerMaskTab);
            lineRenderer.SetPosition(0, laserPoint.position);
            lineRenderer.SetPosition(1, hit.point);
            inactiveFrames += 1;
            if (hit.collider.tag == "Mirror")
                hit.collider.SendMessage("ActivateLaser");
            if (hit.collider.tag == "LaserReceiver")
            {
                saveLaserReceiver = hit.collider.gameObject;
                hit.collider.SendMessage("OpenDoorFromLaserReceiver", true);
            }
            if (saveLaserReceiver && (!hit.collider || !(hit.collider.tag == "LaserReceiver")))
                saveLaserReceiver.SendMessage("OpenDoorFromLaserReceiver", false);
            if (hit.collider.tag == "Boss")
            {
                Destroy(hit.collider.gameObject);
                Destroy(this.gameObject);
            }
        }
        else
        {
            lineRenderer.enabled = false;
            hit = Physics2D.Raycast(laserPoint.position, laserPoint.position, 0f, ~layerMaskTab);
            if (saveLaserReceiver)
                saveLaserReceiver.SendMessage("OpenDoorFromLaserReceiver", false);
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
}