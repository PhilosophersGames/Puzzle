using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class RoomTransition : MonoBehaviour
{
    // SWIPE 
    RaycastHit2D hit;
    Vector2 touchPos;
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
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
    public bool canRotate;
    public float rotSpeed;
    public static bool isRotating = false;
    public static bool rotationDirection;
    public int HamsterRotation;
    public PolygonCollider2D polygoneCollider;
    //   public Rigidbody2D rigidBodyRoom;
    //   public GameObject tileMap;

    private void Awake()
    {
        achievementManager = FindObjectOfType<AchievementManager>();
    }

    void Start()
    {
        //   crates = GameObject.Find("Crates");
        //     rigidBodyRoom = GetComponent<Rigidbody2D>();
        //     rigidBodyRoom = tileMap.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //MobileTouchControls();
        Swipe();
        if (HamsterRotation == 100)
        {
            achievementManager.UnlockAchievement(Achievements.HamsterMind);
        }
        if ((mobileTap == 1 || Input.GetKeyDown("e")) && canRotate && !isRotating) //&& !player.isMoving)
        {
            rotationDirection = true;
            achievementManager.UnlockAchievement(Achievements.FirstStep);
            float currentAngle = transform.rotation.eulerAngles.z;
            polygoneCollider.enabled = false;
            transform.localScale -= new Vector3(0.3f, 0.3f, 0);
            //     rigidBodyRoom.isKinematic = false;
            StartCoroutine(Rotate(currentAngle, currentAngle + 90f));
            isRotating = true;
            HamsterRotation++;
            mobileTap = 0;
        }
        if ((mobileTap == 2 || Input.GetKeyDown("r")) && canRotate && !isRotating) //&& !player.isMoving)
        {
            rotationDirection = false;
            achievementManager.UnlockAchievement(Achievements.FirstStep);
            float currentAngle = transform.rotation.eulerAngles.z;
            polygoneCollider.enabled = false;
            transform.localScale -= new Vector3(0.3f, 0.3f, 0);
            //    rigidBodyRoom.isKinematic = false;
            StartCoroutine(Rotate(currentAngle, currentAngle - 90f));
            isRotating = true;
            HamsterRotation++;
            mobileTap = 0;
        }
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
        //   rigidBodyRoom.isKinematic = true;
    }

    IEnumerator Rotate2(float angle, float targetAngle)
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
        //   rigidBodyRoom.isKinematic = true;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canRotate = true;
            other.transform.parent = this.transform;
            this.GetComponentInParent<BoxCollider2D>().enabled = true;
        }
        if (other.CompareTag("Object") || other.CompareTag("Coin") || other.CompareTag("FreezingEye") || other.CompareTag("Phantom"))
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canRotate = false;
            this.GetComponentInParent<BoxCollider2D>().enabled = false;
        }
    }

    void MobileTouchControls()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if ((touch.position.x < Screen.width / 2) && (touch.position.y > Screen.height / 3) && canRotate)
            {
                mobileTap = 1;
            }
            else if ((touch.position.x > Screen.width / 2) && canRotate)
            {
                mobileTap = 2;
            }
        }
        else
            mobileTap = 0;
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
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && hit.transform.gameObject.tag == ("Room"))
            {
                currentPosition = Input.GetTouch(0).position;
                Vector2 Distance = currentPosition - startTouchPosition;
                MiddleofRooms = GameObject.Find("MiddleofRooms").transform;
                if (!stopTouch)
                {
                    swipeRange = 5f;
                    if (Distance.x < -swipeRange && canRotate && touchPos.y > MiddleofRooms.position.y && touchPos.x > MiddleofRooms.position.x)
                    {
                        // TOP RIGHT TO TOP LEFT
                        mobileTap = 1;
                        stopTouch = true;
                    }
                    if (Distance.x < -swipeRange && canRotate && touchPos.y <= MiddleofRooms.position.y && touchPos.x > MiddleofRooms.position.x)
                    {
                        // BOTTOM RIGHT TO BOTTOM LEFT
                        mobileTap = 2;
                        stopTouch = true;
                    }
                    if (Distance.x > swipeRange && canRotate && touchPos.y > MiddleofRooms.position.y && touchPos.x <= MiddleofRooms.position.x)
                    {
                        if (GameObject.Find("Hand-Cursor"))
                            GameObject.Find("Hand-Cursor").GetComponent<Animator>().SetBool("SwipeRight", true);
                        // TOP LEFT TO TOP RIGHT
                        mobileTap = 2;
                        stopTouch = true;
                    }
                    if (Distance.x > swipeRange && canRotate && touchPos.y <= MiddleofRooms.position.y && touchPos.x <= MiddleofRooms.position.x)
                    {
                        // BOTTOM LEFT TO BOTTOM RIGHT
                        mobileTap = 1;
                        stopTouch = true;
                    }
                    if (Distance.y < -swipeRange && canRotate && touchPos.x > MiddleofRooms.position.x && touchPos.y > MiddleofRooms.position.y)
                    {
                        // TOP RIGHT TO BOTTOM RIGHT
                        if (GameObject.Find("Hand-Cursor"))
                            GameObject.Find("Hand-Cursor").GetComponent<Animator>().SetBool("SwipeDown", true);
                        mobileTap = 2;
                        stopTouch = true;
                    }
                    if (Distance.y < -swipeRange && canRotate && touchPos.x <= MiddleofRooms.position.x && touchPos.y > MiddleofRooms.position.y)
                    {
                        // TOP LEFT TO BOTTOM LEFT
                        mobileTap = 1;
                        stopTouch = true;
                    }
                    if (Distance.y > swipeRange && canRotate && touchPos.x > MiddleofRooms.position.x && touchPos.y <= MiddleofRooms.position.y)
                    {
                        // BOTTOM RIGHT TO TOP RIGHT
                        mobileTap = 1;
                        stopTouch = true;
                    }
                    if (Distance.y > swipeRange && canRotate && touchPos.x <= MiddleofRooms.position.x && touchPos.y <= MiddleofRooms.position.y)
                    {
                        // BOTTOM LEFT TOP TOP LEFT
                        mobileTap = 2;
                        stopTouch = true;
                    }
                    /*      else if (Distance.y > swipeRange)
                            {
                            outputText.text = "Up";
                            stopTouch = true;
                            }
                            else if (Distance.y < -swipeRange)
                            {
                            outputText.text = "Down";
                            stopTouch = true;
                    } */
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
}
