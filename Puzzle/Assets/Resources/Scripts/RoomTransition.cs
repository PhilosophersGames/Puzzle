using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class RoomTransition : MonoBehaviour
{


    private Button rotateLeftButton;
    private Button rotateRightButton;
    // SWIPE 
    RaycastHit2D hit;
    Vector2 touchPos;
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;

    public Vector3 slide;
    private bool stopTouch = false;

    private Transform MiddleofRooms;

    private bool roro;
    public float swipeRange;
    public float tapRange;

    // swipe
    // public GameObject camera;
    public int mobileTap;
    public AchievementManager achievementManager;
    //   private GameObject crates;
    private GameObject player;
    private bool buttonRotateLeft;
    public bool canRotate;

    public bool canSlide;
    public float rotSpeed;
    public static bool isRotating = false;
    public static bool rotationDirection;
    public static int HamsterRotation;

    public GameObject hat;

    public GameObject[] rooms;

    private GameObject[] ghosts;

    public PolygonCollider2D polygoneCollider;

    private float roomScale;

    public bool slideInBetween;

    private GameObject[] mirrorBox;

    private void Awake()
    {
        achievementManager = FindObjectOfType<AchievementManager>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rotateLeftButton = GameObject.FindGameObjectWithTag("RotateLeftButton").GetComponent<Button>();
        rotateRightButton = GameObject.FindGameObjectWithTag("RotateRightButton").GetComponent<Button>();
        rotateLeftButton.onClick.AddListener(() => RotateLeftButtonTrue());
        rotateRightButton.onClick.AddListener(() => RotateRightButtonTrue());
        HamsterRotation = 0;
        if (GameObject.FindGameObjectWithTag("Hat"))
            hat = GameObject.FindGameObjectWithTag("Hat");
        roomScale = GameObject.FindGameObjectWithTag("RoomsContainer").transform.localScale.x;
        mirrorBox = GameObject.FindGameObjectsWithTag("Mirror");
    }
    void Update()
    {
        ComputerSlideRoom();
        Swipe();
        if (HamsterRotation == 100)
        {
            achievementManager.UnlockAchievement(Achievements.HamsterMind);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (GameObject.FindGameObjectWithTag("UIcanvas") && (!hat || (hat && !hat.GetComponent<Hat>().hatEquiped)))
        {
            if ((mobileTap == 1 || Input.GetKeyDown("e")) && canRotate && !isRotating && !player.GetComponent<Movement>().isMoving)
                RoomRotation(-1);
            else if ((mobileTap == 2 || Input.GetKeyDown("r")) && canRotate && !isRotating && !player.GetComponent<Movement>().isMoving)
                RoomRotation(1);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        else if (GameObject.FindGameObjectWithTag("UIcanvas") && hat && hat.GetComponent<Hat>().hatEquiped)
        {
            if ((mobileTap == 1 || Input.GetKeyDown("e")) && canRotate && !isRotating && !player.GetComponent<Movement>().isMoving)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (player.transform.parent.transform.parent.GetComponentInChildren<AdjacentRooms>().neighborRoom[i])
                        player.transform.parent.transform.parent.GetComponentInChildren<AdjacentRooms>().neighborRoom[i].GetComponentInChildren<RoomTransition>().RoomRotation(-1);
                }
                mobileTap = 0;
            }
            else if ((mobileTap == 2 || Input.GetKeyDown("r")) && canRotate && !isRotating && !player.GetComponent<Movement>().isMoving)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (player.transform.parent.transform.parent.GetComponentInChildren<AdjacentRooms>().neighborRoom[i])
                        player.transform.parent.transform.parent.GetComponentInChildren<AdjacentRooms>().neighborRoom[i].GetComponentInChildren<RoomTransition>().RoomRotation(1);
                }
            }
            mobileTap = 0;
        }
        if (slideInBetween == true)
        {
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            foreach (GameObject box in mirrorBox)
                box.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GameObject.FindGameObjectWithTag("RoomsContainer").GetComponent<SlideManager>().thereIsColliders = false;
            GameObject.FindGameObjectWithTag("RoomsContainer").GetComponent<SlideManager>().drawBorderCollider = true;
            canRotate = false;
            canSlide = false;
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, saveSlidePosition, Time.deltaTime * rotSpeed * 8);
            if (transform.parent.position == saveSlidePosition)
            {
                slideInBetween = false;
                GameObject.FindGameObjectWithTag("RoomsContainer").GetComponent<SlideManager>().StartChangeBool();
                canRotate = true;
                canSlide = true;
                player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                foreach (GameObject box in mirrorBox)
                    box.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    public void RoomRotation(int delta)
    {
        rotationDirection = true;
        if (delta == 1)
            rotationDirection = false;
        achievementManager.UnlockAchievement(Achievements.FirstStep);
        float currentAngle = transform.rotation.eulerAngles.z;
        polygoneCollider.enabled = false;
        transform.localScale -= new Vector3(0.3f, 0.3f, 0);
        transform.parent.transform.GetChild(2).localScale -= new Vector3(0.3f, 0.3f, 0);
        StartCoroutine(Rotate(currentAngle, currentAngle - (90f * delta)));
        isRotating = true;
        HamsterRotation++;
        mobileTap = 0;
        if (GameObject.FindGameObjectWithTag("Player") && (!hat || !hat.GetComponent<Hat>().hatEquiped))
            GameObject.FindGameObjectWithTag("Player").transform.Rotate(0, 0, 90 * delta);
        if (GameObject.FindGameObjectWithTag("Phantom"))
        {
            ghosts = GameObject.FindGameObjectsWithTag("Phantom");
            if (!hat || !hat.GetComponent<Hat>().hatEquiped)
            {
                foreach (GameObject ghost in ghosts)
                {
                    if (ghost.transform.parent == player.transform.parent)
                        ghost.transform.Rotate(0, 0, 90 * delta);
                }
            }
            else if (hat && hat.GetComponent<Hat>().hatEquiped)
            {
                foreach (GameObject ghost in ghosts)
                {
                    if (ghost.transform.parent == transform)
                        ghost.transform.Rotate(0, 0, 90 * delta);
                }
            }
        }
    }
    void RotateLeftButtonTrue()
    {
        if (canRotate && !isRotating)
            mobileTap = 1;
    }

    void RotateRightButtonTrue()
    {
        if (canRotate && !isRotating)
            mobileTap = 2;
    }

    IEnumerator Rotate(float angle, float targetAngle)
    {
        float t = 0f;

        while (t <= 1f)
        {
            transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, 0, angle), Quaternion.Euler(0, 0, targetAngle), t);
            t += Time.deltaTime * rotSpeed;
            yield return null;
        }
        transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, 0, angle), Quaternion.Euler(0, 0, targetAngle), t);
        isRotating = false;
        polygoneCollider.enabled = true;
        transform.localScale += new Vector3(0.3f, 0.3f, 0);
        transform.parent.transform.GetChild(2).localScale += new Vector3(0.3f, 0.3f, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canRotate = true;
            canSlide = true;
            other.transform.parent = this.transform;
            this.GetComponentInParent<BoxCollider2D>().enabled = true;
        }
        if (other.CompareTag("Object") || other.CompareTag("Coin") || other.CompareTag("FreezingEye") || other.CompareTag("Phantom") || other.CompareTag("Hat") ||
         other.CompareTag("LaserBox") || other.CompareTag("LaserReceiver") || other.CompareTag("Mirror"))
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canRotate = false;
            canSlide = false;
            this.GetComponentInParent<BoxCollider2D>().enabled = false;
            /*    if (!isRotating)
                    player.transform.SetParent(GameObject.FindGameObjectWithTag("RoomsContainer").transform);*/
        }
    }

    public void ComputerSlideRoom()
    {
        if (GameObject.FindGameObjectWithTag("RoomsContainer").GetComponent<SlideManager>().drawBorderCollider == false && canRotate && canSlide)
        {
            //Right to Left
            if (Input.GetKeyDown("j") && player.transform.parent == transform)
            {
                if (player.transform.parent.transform.parent.GetComponentInChildren<AdjacentRooms>().roomDetector[3].GetComponent<RoomDetector>().isSlidable)
                {
                    slide = transform.parent.position;
                    slide.x -= 10 * roomScale;
                    SlideRoom(3);
                }
            }

            //Left to Right
            if (Input.GetKeyDown("l") && player.transform.parent == transform)
            {
                if (player.transform.parent.transform.parent.GetComponentInChildren<AdjacentRooms>().roomDetector[1].GetComponent<RoomDetector>().isSlidable)
                {
                    slide = transform.parent.position;
                    slide.x += 10 * roomScale;
                    SlideRoom(1);
                }
            }
            //Top to Bottom
            if (Input.GetKeyDown("k") && player.transform.parent == transform)
            {
                if (player.transform.parent.transform.parent.GetComponentInChildren<AdjacentRooms>().roomDetector[2].GetComponent<RoomDetector>().isSlidable)
                {
                    slide = transform.parent.position;
                    slide.y -= 10 * roomScale;
                    SlideRoom(2);
                }
            }

            // Bottom to Top
            if (Input.GetKeyDown("i") && player.transform.parent == transform)
            {
                if (player.transform.parent.transform.parent.GetComponentInChildren<AdjacentRooms>().roomDetector[0].GetComponent<RoomDetector>().isSlidable)
                {
                    slide = transform.parent.position;
                    slide.y += 10 * roomScale;
                    SlideRoom(0);
                }
            }
        }
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            startTouchPosition = Input.GetTouch(0).position;
            hit = Physics2D.Raycast(touchPos, (Input.GetTouch(0).position));
        }
        if (hit)
        {
            Debug.Log(hit.transform.tag);
            swipeRange = 5f;
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && hit.transform.gameObject.tag == ("RoomSkin"))
            {
                currentPosition = Input.GetTouch(0).position;
                Vector2 Distance = currentPosition - startTouchPosition;
                MiddleofRooms = GameObject.Find("MiddleofRooms").transform;
                if (!stopTouch && canRotate && canSlide && GameObject.FindGameObjectWithTag("RoomsContainer").GetComponent<SlideManager>().drawBorderCollider == false)
                {
                    swipeRange = 5f;
                    if (Distance.x < -swipeRange && canRotate && touchPos.x > MiddleofRooms.position.x)
                    {
                        //  RIGHT TO LEFT
                        if (player.transform.parent.transform.parent.GetComponentInChildren<AdjacentRooms>().roomDetector[3].GetComponent<RoomDetector>().isSlidable)
                        {
                            slide = transform.parent.localPosition;
                            slide.x -= 10;
                            SlideRoom(3);
                        }
                        stopTouch = true;
                    }
                    if (Distance.x > swipeRange && canRotate && touchPos.x <= MiddleofRooms.position.x)
                    {
                        Debug.Log("toleftright");
                        if (GameObject.Find("Hand-Cursor"))
                            GameObject.Find("Hand-Cursor").GetComponent<Animator>().SetBool("SwipeRight", true);
                        // LEFT TO RIGHT
                        if (player.transform.parent.transform.parent.GetComponentInChildren<AdjacentRooms>().roomDetector[1].GetComponent<RoomDetector>().isSlidable)
                            SlideRoom(1);
                        stopTouch = true;
                    }
                    if (Distance.y < -swipeRange && canRotate && touchPos.y > MiddleofRooms.position.y)
                    {
                        Debug.Log("toptobottom");
                        // TOP TO BOTTOM
                        if (GameObject.Find("Hand-Cursor"))
                            GameObject.Find("Hand-Cursor").GetComponent<Animator>().SetBool("SwipeDown", true);
                        if (player.transform.parent.transform.parent.GetComponentInChildren<AdjacentRooms>().roomDetector[2].GetComponent<RoomDetector>().isSlidable)
                            SlideRoom(2);
                        stopTouch = true;
                    }
                    if (Distance.y > swipeRange && canRotate && touchPos.y <= MiddleofRooms.position.y)
                    {
                        Debug.Log("bottomtotop");
                        // BOTTOM TO TOP
                        if (player.transform.parent.transform.parent.GetComponentInChildren<AdjacentRooms>().roomDetector[0].GetComponent<RoomDetector>().isSlidable)
                            SlideRoom(0);
                        stopTouch = true;
                    }
                }
            }
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
            Vector2 Distance = endTouchPosition - startTouchPosition;
            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                Debug.Log("tap");
            }
        }
    }
    private GameObject[] bigRooms;
    private Vector3 saveSlidePosition;
    public void SlideRoom(int i)
    {
        saveSlidePosition = player.transform.parent.transform.parent.GetComponentInChildren<AdjacentRooms>().roomDetector[i].GetComponent<RoomDetector>().slidableRoom.transform.position;
        player.transform.parent.transform.parent.GetComponentInChildren<AdjacentRooms>().roomDetector[i].GetComponent<RoomDetector>().slidableRoom.transform.position = transform.parent.position;
        slideInBetween = true;
    }
    public void RotationButtonRight()
    {
        mobileTap = 1;
    }
    public void RotationButtonLeft()
    {
        mobileTap = 2;
    }
}