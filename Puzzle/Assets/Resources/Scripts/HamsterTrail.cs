using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterTrail : MonoBehaviour
{
    public GameObject actualTrail;

    public GameObject player;

    void Start()
    {
    
    }

    void Update()
    {
        if (transform.GetChild(0))
        {
            actualTrail = transform.GetChild(0).gameObject;
            actualTrail.transform.parent = null;
        }
        if (actualTrail)
            actualTrail.transform.position = player.transform.position;
    }

    public void ChangeTrail(GameObject newTrail)
    {
        Destroy(actualTrail);
        actualTrail = Instantiate(newTrail, transform.position, Quaternion.identity);
    }
}
