using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    public Joystick joystick;
    public Animator animator;
    public Rigidbody2D rb;
    public float moveSpeed;

    float roundHorizontal;
    float roundVertical;
    private bool rotatePlayer = true;



    void Awake()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    private bool sameRoomAsPlayer;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        //transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0f);
        ComputerMovement();
        MobileMovement();
    }


    void ComputerMovement()
    {
        if (RoomTransition.isRotating == false)
        {
            if (Mathf.Abs(moveSpeed * roundHorizontal) < Mathf.Abs(moveSpeed * Input.GetAxis("Horizontal")) || Mathf.Abs(moveSpeed * roundVertical) < Mathf.Abs(moveSpeed * Input.GetAxis("Vertical")))
                rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), moveSpeed * Input.GetAxis("Vertical"));
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            if (rotatePlayer == true && this.CompareTag("Player"))
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
            }
        }
        if (RoomTransition.isRotating == true)
            rotatePlayer = false;
        else
            rotatePlayer = true;

        if (rb.velocity != Vector2.zero)
        {
            animator.SetFloat("Input_x", rb.velocity.x);
            animator.SetFloat("Input_y", rb.velocity.y);
        }
    }
    void MobileMovement()
    {

        if (RoomTransition.isRotating == false)
        {
            roundHorizontal = 0f;
            roundVertical = 0f;
            if (Mathf.Abs(joystick.Horizontal) > Mathf.Abs(joystick.Vertical) && joystick.Horizontal > 0)
            {
                roundHorizontal = 1f;
                roundVertical = 0f;
            }
            else if (Mathf.Abs(joystick.Horizontal) > Mathf.Abs(joystick.Vertical) && joystick.Horizontal < 0)
            {
                roundHorizontal = -1f;
                roundVertical = 0f;
            }
            if (Mathf.Abs(joystick.Vertical) > Mathf.Abs(joystick.Horizontal) && joystick.Vertical > 0)
            {
                roundVertical = 1f;
                roundHorizontal = 0f;
            }
            else if (Mathf.Abs(joystick.Vertical) > Mathf.Abs(joystick.Horizontal) && joystick.Vertical < 0)
            {
                roundVertical = -1f;
                roundHorizontal = 0f;
            }
           // if (Mathf.Abs(moveSpeed * roundHorizontal) > Mathf.Abs(moveSpeed * Input.GetAxis("Horizontal")) || Mathf.Abs(moveSpeed * roundVertical) > Mathf.Abs(moveSpeed * Input.GetAxis("Vertical")))
            //    rb.velocity = new Vector2(moveSpeed * roundHorizontal, moveSpeed * roundVertical);
            rb.velocity = new Vector2(moveSpeed * roundHorizontal, moveSpeed * roundVertical);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            if (rotatePlayer == true)
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
            }
        }
        if (RoomTransition.isRotating == true)
        {
            rotatePlayer = false;
        }
        else
            rotatePlayer = true;

        if (rb.velocity != Vector2.zero)
        {
            animator.SetFloat("Input_x", rb.velocity.x);
            animator.SetFloat("Input_y", rb.velocity.y);
        }
    }
}