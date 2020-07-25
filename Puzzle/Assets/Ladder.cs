using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PolygonCollider2D>().isTrigger = true;
             other.transform.parent.GetComponentInChildren<roomTransition>().canRotate = false;
        }
    }
    
        private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            other.transform.GetComponent<PolygonCollider2D>().isTrigger = false;
            other.transform.parent.GetComponentInChildren<roomTransition>().canRotate = true;
        }
    }
}