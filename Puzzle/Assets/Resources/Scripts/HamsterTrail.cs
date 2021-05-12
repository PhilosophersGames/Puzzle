using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterTrail : MonoBehaviour
{
    public GameObject actualTrail;

    public int actualTrailID = -1;

    public GameObject[] referenceTrails;


    void Start()
    {
    }

    void Update()
    {
        if (actualTrail)
            actualTrail.transform.position = transform.position;
    }

    public void ChangeTrail(int newTrailID)
    {
        
        if (!actualTrail || (actualTrail && actualTrailID != newTrailID))
        {
            
            if (actualTrail)
                Destroy(actualTrail);
            actualTrail = Instantiate(referenceTrails[newTrailID], transform.position, Quaternion.identity);
            actualTrail.transform.SetParent(null);
            actualTrail.GetComponent<ParticleSystem>().startColor = GameObject.FindGameObjectWithTag("SkinManager").GetComponent<TileSwap>().colorHamsterID;
            for (int i = 0; i < actualTrail.transform.childCount; i++)
            {
                actualTrail.transform.GetChild(i).GetComponent<ParticleSystem>().startColor = GameObject.FindGameObjectWithTag("SkinManager").GetComponent<TileSwap>().colorHamsterID;
            }
            actualTrailID = newTrailID;
        }
    }
}
