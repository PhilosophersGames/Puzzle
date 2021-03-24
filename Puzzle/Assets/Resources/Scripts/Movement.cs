using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    //public Joystick joystick;
    public Animator animator;
    public Rigidbody2D rb;
    public float moveSpeed;

    float roundHorizontal;
    float roundVertical;
    private bool rotatePlayer = true;

    public bool isMoving;



    void Awake()
    {
        //   joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    private bool sameRoomAsPlayer;

    private GameObject player;

    public bool canMove;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        canMove = true;
    }
    void Update()
    {
        ComputerMovement();
        MobileMovement();
    }

    void ComputerMovement()
    {
        if (RoomTransition.isRotating == false && canMove)
        {
            //         if (Mathf.Abs(moveSpeed * roundHorizontal) < Mathf.Abs(moveSpeed * Input.GetAxis("Horizontal")) || Mathf.Abs(moveSpeed * roundVertical) < Mathf.Abs(moveSpeed * Input.GetAxis("Vertical")))
            rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), moveSpeed * Input.GetAxis("Vertical"));
        }
        else
        {
            // rb.velocity = new Vector2(0, 0);
            /*  if (rotatePlayer == true && this.CompareTag("Player"))
             {
                 if (RoomTransition.rotationDirection == true)
                     transform.Rotate(0, 0, -90);
                 if (RoomTransition.rotationDirection == false)
                     transform.Rotate(0, 0, 90);
             }
             if (rotatePlayer == true && this.CompareTag("Phantom") && this.transform.parent == player.transform.parent)
             {
                 if (RoomTransition.rotationDirection == true)
                     transform.Rotate(0, 0, -90);
                 if (RoomTransition.rotationDirection == false)
                     transform.Rotate(0, 0, 90);
             } */
        }
        /*         if (RoomTransition.isRotating == true)
                    rotatePlayer = false;
                else
                    rotatePlayer = true;
         */
        if (rb.velocity != Vector2.zero)
        {
            isMoving = true;
            animator.SetFloat("Input_x", rb.velocity.x);
            animator.SetFloat("Input_y", rb.velocity.y);
        }
        else
            isMoving = false;
    }
    void MobileMovement()
    {
        if (RoomTransition.isRotating == false && canMove)
        {
            rb.velocity = new Vector2(moveSpeed * SimpleInput.GetAxis("Horizontal"), moveSpeed * SimpleInput.GetAxis("Vertical"));
            isMoving = false;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            isMoving = true;
        }
        if (rb.velocity != Vector2.zero)
        {
            animator.SetFloat("Input_x", rb.velocity.x);
            animator.SetFloat("Input_y", rb.velocity.y);
        }
    }
}