using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("IceBlock"))
        {
            Debug.Log("Destoyed");
            Destroy(other.gameObject);
        }
    }
 }
