using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    public AchievementManager achievementManager;
    public Rigidbody2D rb;
    public float moveSpeed;

    void Update()
    {
        if (Input.anyKey)
//                 achievementManager.UnlockAchievement(Achievements.FirstStep);
        //transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0f);
        if (RoomTransition.isRotating == false)
            rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), moveSpeed * Input.GetAxis("Vertical"));
        else
            rb.velocity = new Vector2(0, 0);
    }
}