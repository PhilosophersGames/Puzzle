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
    public GameObject[] emissionPoints = new GameObject[4];

    public int wichPoint;

    private Vector2 direction;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Start()
    {
        if (wichPoint == 0)
            direction = Vector2.up;
        if (wichPoint == 1)
            direction = Vector2.right;
        if (wichPoint == 2)
            direction = Vector2.down;
        if (wichPoint == 3)
            direction = Vector2.left;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(emissionPoints[wichPoint].transform.position, direction);
        Debug.DrawRay(emissionPoints[wichPoint].transform.position, direction * 20, Color.red);
        /* RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
          Debug.DrawRay(transform.position, -Vector2.up* 4, Color.red);

          if (hit.collider != null )
          {
              if (hit.collider.tag == "IceBlock")
                 Destroy(hit.collider.gameObject);
              print(hit.transform.tag);
          }*/
    }
}
