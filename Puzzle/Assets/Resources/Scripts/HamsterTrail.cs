using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterTrail : MonoBehaviour
{
    public GameObject actualTrail;

    public int actualTrailID = -1;

    public GameObject[] referenceTrails;

    private Color newColorID;


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
            newColorID = GameObject.FindGameObjectWithTag("SkinManager").GetComponent<TileSwap>().colorHamsterID;
            if (actualTrail)
                Destroy(actualTrail);
            actualTrail = Instantiate(referenceTrails[newTrailID], transform.position, Quaternion.identity);
            actualTrail.transform.SetParent(null);
            actualTrail.GetComponent<ParticleSystem>().startColor = GameObject.FindGameObjectWithTag("SkinManager").GetComponent<TileSwap>().colorHamsterID;
          /*  Gradient grad = new Gradient();
            grad.SetKeys(new GradientColorKey[] { new GradientColorKey(newColorID, 1.0f), new GradientColorKey(newColorID, 0.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
            var colorOverLifetime = actualTrail.transform.GetComponent<ParticleSystem>().colorOverLifetime;
            colorOverLifetime.color = grad;
            for (int i = 0; i < actualTrail.transform.childCount; i++)
            {
                actualTrail.transform.GetChild(i).GetComponent<ParticleSystem>().startColor = newColorID;
                var colorOverLifetimeTwo = actualTrail.transform.GetChild(i).GetComponent<ParticleSystem>().colorOverLifetime;
                if (actualTrail.transform.GetChild(i).GetComponent<ParticleSystem>().colorOverLifetime.enabled == true)
                    colorOverLifetimeTwo.color = grad;
            }*/
            actualTrailID = newTrailID;
        }
    }
}
