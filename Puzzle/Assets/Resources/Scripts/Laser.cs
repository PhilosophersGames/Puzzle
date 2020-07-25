using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{

    public int reflections;
    public float maxLenght;
    private LineRenderer lineRenderer;
    private Ray2D ray;
    // Start is called before the first frame update

    private void Awake()
     {
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
         Debug.DrawRay(transform.position, -Vector2.up* 4, Color.red);

         if (hit.collider != null )
         {
             if (hit.collider.tag == "IceBlock")
                Destroy(hit.collider.gameObject);
             print(hit.transform.tag);
         }
    }
}
