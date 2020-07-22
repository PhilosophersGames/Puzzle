using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomTransition : MonoBehaviour
{
    public GameObject camera;
    private GameObject movePoint;
    public bool canRotate;
   
    void  Start()
    {
        movePoint = GameObject.Find("MovePoint");
    }
    void Update()
    {
        if (Input.GetKeyDown("r") && canRotate == true)
        {
            transform.Rotate(0, 00, -90);
        }
        if (Input.GetKeyDown("e") && canRotate == true)
        {
            transform.Rotate(0, 00, 90);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canRotate = true;
            camera.SetActive(true);
           other.transform.parent = this.transform;
          //  movePoint.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canRotate = false;
            camera.SetActive(false);
        //    other.transform.parent = null;
        //    movePoint.transform.parent = null;
        }
    }
}
