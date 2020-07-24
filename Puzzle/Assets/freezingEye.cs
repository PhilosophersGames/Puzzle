using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezingEye : MonoBehaviour
{
 
    // Start is called before the first frame update

    private GameObject Target;
    private bool inSight;
    public GameObject tempPlayer;
    void Awake()
    {
        Target = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        // Raycast
         // look at the target, cast a raycast, and constraint rotation if the player is inSight
        Vector3 dir = Target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle -100, Vector3.forward);
            Debug.DrawRay(transform.position, Target.transform.position - transform.position, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Target.transform.position - transform.position);
        if(hit.collider.tag == "Player" && inSight == false)
        {
            tempPlayer = hit.collider.gameObject;
            inSight = true;
            hit.collider.transform.parent.GetComponentInChildren<roomTransition>().canRotate = false;
            Debug.Log("Player In sight");
        }
        
        if (hit.collider.tag != "Player" && inSight == true)
         {
            inSight = false;
            tempPlayer.transform.parent.GetComponentInChildren<roomTransition>().canRotate = true;
         }
        if (inSight == true)
        {
        tempPlayer = hit.collider.gameObject;
        tempPlayer.transform.parent.GetComponentInChildren<roomTransition>().canRotate = false;
        }

    }
}

