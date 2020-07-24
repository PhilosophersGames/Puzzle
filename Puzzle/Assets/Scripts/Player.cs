using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public float gridSize = 1f;
    public LayerMask stopsMovement;
    public bool isMoving;


    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        if (transform.position != movePoint.position)
            isMoving = true; 
        else 
            isMoving = false;
        if (RoomTransition.isRotating == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime * gridSize);

            if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f && RoomTransition.isRotating == false)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal") * gridSize, 0, 0), 0.2f, stopsMovement))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * gridSize, 0f, 0f);
                    }
                }

                if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, Input.GetAxisRaw("Vertical") * gridSize, 0), 0.2f, stopsMovement))
                    {
                        movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical") * gridSize, 0);
                    }
                }
            }
        }
      //  else
         //   transform.position = movePoint.position;
    }
}