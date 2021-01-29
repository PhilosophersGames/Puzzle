using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float moveSpeed;
    private bool rotatePlayer = true;

    private bool sameRoomAsPlayer;

    private GameObject player;

    void Start() 
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        //transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0f);
        if (RoomTransition.isRotating == false)
            rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), moveSpeed * Input.GetAxis("Vertical"));
        else
        {
            rb.velocity = new Vector2(0, 0);
            if (rotatePlayer == true && this.CompareTag("Player"))
            {
                if(RoomTransition.rotationDirection == true)
                transform.Rotate(0, 0, -90);
                if(RoomTransition.rotationDirection == false)
                transform.Rotate(0, 0, 90);
            }
            if (rotatePlayer == true && this.CompareTag("Phantom") && this.transform.parent == player.transform.parent)
            {
                if(RoomTransition.rotationDirection == true)
                transform.Rotate(0, 0, -90);
                if(RoomTransition.rotationDirection == false)
                transform.Rotate(0, 0, 90);
            }
        }
        if (RoomTransition.isRotating == true)
            rotatePlayer = false;
        else
            rotatePlayer = true;

        if (rb.velocity != Vector2.zero) {
             animator.SetFloat ("Input_x", rb.velocity.x);
             animator.SetFloat ("Input_y", rb.velocity.y);     
    }
}
}