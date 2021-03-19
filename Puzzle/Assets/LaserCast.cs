using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCast : MonoBehaviour
{
    public bool activeLaser;

    public Transform laserHit;
    private LineRenderer lineRenderer;
    [SerializeField] private LayerMask layerMaskTab;
    void Start()
    {
       lineRenderer = GetComponent<LineRenderer>();
       lineRenderer.enabled = true;
       lineRenderer.useWorldSpace = true;
    }
    void Update()
    {
        if (activeLaser)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward);
            Debug.DrawRay(transform.position, hit.point, Color.red);
            laserHit.position = hit.point;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, laserHit.position);
        }
    }
}
