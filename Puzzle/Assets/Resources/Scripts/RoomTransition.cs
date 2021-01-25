using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
   // public GameObject camera;
    public AchievementManager achievementManager;
    private GameObject movePoint;
 //   private GameObject crates;
    private Player player;
    public bool canRotate;
    public float rotSpeed;
    public static bool isRotating = false;
    public static bool rotationDirection;
    public int HamsterRotation;
    public PolygonCollider2D polygoneCollider;
 //   public Rigidbody2D rigidBodyRoom;
 //   public GameObject tileMap;

    private void Awake() {
                achievementManager = FindObjectOfType<AchievementManager>();
    }
    void Start()
    {
        movePoint = GameObject.Find("MovePoint");
        player = GameObject.Find("Player").GetComponent<Player>();
     //   crates = GameObject.Find("Crates");
   //     rigidBodyRoom = GetComponent<Rigidbody2D>();
   //     rigidBodyRoom = tileMap.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
            if (HamsterRotation == 100)
            {
                    achievementManager.UnlockAchievement(Achievements.HamsterMind);
            }
        if (Input.GetKeyDown("e") && canRotate && !isRotating && !player.isMoving)
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
        }
        if (Input.GetKeyDown("r") && canRotate && !isRotating && !player.isMoving)
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
            //   camera.SetActive(true);
            //   movePoint.transform.parent = this.transform;
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
           // camera.SetActive(false);
            //    other.transform.parent = null;
            //    movePoint.transform.parent = null;
        }
    }
}