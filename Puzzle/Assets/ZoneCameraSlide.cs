using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCameraSlide : MonoBehaviour
{

    public GameObject camera;

    public float slideSpeed;

    private bool enterNewZone;

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (enterNewZone)
        {
            if (camera.transform.position != this.transform.position)
                camera.transform.position = Vector3.MoveTowards(camera.transform.position, this.transform.position, Time.deltaTime * slideSpeed);
            else
                enterNewZone = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            enterNewZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            enterNewZone = false;
        }
    }
}
