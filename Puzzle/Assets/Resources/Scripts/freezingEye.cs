using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezingEye : MonoBehaviour
{

    // Start is called before the first frame update


    private LineRenderer lineRenderer;

    private GameObject analogues;
    private GameObject Target;
    private bool inSight;
    public GameObject tempPlayer;
    [SerializeField] private LayerMask layerMaskTab;
    void Awake()
    {
        Target = GameObject.FindWithTag("Player");
    }


    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        analogues = GameObject.Find("Rotation Buttons");
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast
        // look at the target, cast a raycast, and constraint rotation if the player is inSight
        Vector3 dir = Target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;


        Debug.DrawRay(transform.position, Target.transform.position - transform.position, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Target.transform.position - transform.position, Mathf.Infinity, ~layerMaskTab);

        // SET the linerenderer position on sight
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, Target.transform.position);


        if (hit.collider.tag == "Player" && inSight == false)
        {

            tempPlayer = hit.collider.gameObject;
            inSight = true;
            hit.collider.transform.parent.GetComponentInChildren<RoomTransition>().canRotate = false;
            analogues.SetActive(false);
            Debug.Log("Player In sight");
        }
        if (hit.collider.tag != "Player" && inSight == true)
        {
            inSight = false;
            lineRenderer.enabled = false;
            analogues.SetActive(true);
            tempPlayer.transform.parent.GetComponentInChildren<RoomTransition>().canRotate = true;
        }
        if (inSight == true)
        {
            transform.rotation = Quaternion.AngleAxis(angle - 100, Vector3.forward);
            lineRenderer.enabled = true;
            tempPlayer = hit.collider.gameObject;
            analogues.SetActive(false);
            tempPlayer.transform.parent.GetComponentInChildren<RoomTransition>().canRotate = false;
        }
    }
}

