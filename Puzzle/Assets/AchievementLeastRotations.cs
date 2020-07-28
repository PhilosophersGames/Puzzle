using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementLeastRotations : MonoBehaviour
{
   public bool achievement = false;
   public int rotationNumbers = 0;

    void Update() 
    {
       if (achievement == true)
       {
           if (Input.GetKeyDown("e") || Input.GetKeyDown("r"))
           {
               rotationNumbers++;
           }        
        }
    }
}