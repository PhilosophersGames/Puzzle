using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomTransition : MonoBehaviour
{
   // public GameObject camera;
    private GameObject movePoint;
    public bool canRotate;
    public float rotSpeed;
    public bool isRotating = false;

    void Start()
    {
        movePoint = GameObject.Find("MovePoint");
    }
    void Update()
    {

        if (Input.GetKeyDown("r") && canRotate && !isRotating)
        {
            float currentAngle = transform.rotation.eulerAngles.z;
            StartCoroutine(Rotate(currentAngle, currentAngle + 90f));
            isRotating = true;
        }
        if (Input.GetKeyDown("q") && canRotate && !isRotating)
        {
            StartCoroutine(Rotate2());
            isRotating = true;
        }
    }


    IEnumerator Rotate(float angle, float targetAngle)
    {
        float t = 0f;

        while (t <= 1f)
        {

            transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, 0, angle), Quaternion.Euler(0, 0, targetAngle), t);
            t += Time.deltaTime * rotSpeed;
            Debug.Log($"t: {t}");
            Debug.Log("Coroutine running");
            yield return null;
        }
        transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, 0, angle), Quaternion.Euler(0, 0, targetAngle), t);
        isRotating = false;

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canRotate = true;
        //    camera.SetActive(true);
            other.transform.parent = this.transform;
            movePoint.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canRotate = false;
            // camera.SetActive(false);
            //    other.transform.parent = null;
            //    movePoint.transform.parent = null;
        }
    }
}
