using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEmitter : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Transform laserPoint;
    private float rotation = 90;

    public bool activeLaser;

    [SerializeField] private LayerMask layerMaskTab;

    void Start()
    {
        laserPoint = transform.GetChild(0);
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (activeLaser)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, laserPoint.position - transform.position, Mathf.Infinity, ~layerMaskTab);
            lineRenderer.SetPosition(0, laserPoint.position);
            lineRenderer.SetPosition(1, hit.point);
        if (hit.collider.tag == "Mirror")
            {
                hit.collider.SendMessage("ActivateLaser");
            }
        }
    }
}
