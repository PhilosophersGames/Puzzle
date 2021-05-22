using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Vector3 bossDeplacement;

    public float slideSpeed;

    private int frame;

    public int probabilityShooting = 50;

    private int deplacementCount;

    public GameObject box;

    private float distance;

    private GameObject[] slideArray;

    void Start()
    {
        bossDeplacement = this.transform.position;
        slideArray = GameObject.FindGameObjectsWithTag("Rail");
        //  distance = Mathf.Abs(this.transform.position.x - paternPosition.transform.position.x) / 15;
        distance = 1.60128f;
    }

    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, bossDeplacement, distance/slideSpeed * Time.deltaTime);
        frame++;
        if (frame >= slideSpeed)
        {
            if (Random.Range(0, 100) <= probabilityShooting)
                ShootProjectile();
            if (deplacementCount < 15)
                bossDeplacement.x += distance;
            else
                bossDeplacement.x -= distance;
            deplacementCount++;
            if (deplacementCount > 29)
                deplacementCount = 0;
            frame = 0;
        }
    }
    
    public void BossDefeated()
    {
        foreach (GameObject slide in slideArray)
        {
            slide.GetComponent<SpriteRenderer>().color = Color.white;
        }
        Destroy(this.gameObject);
    }

    void ShootProjectile()
    {
        Debug.Log("SHOOT");
        Instantiate(box, transform.position, Quaternion.identity);
    }
}
