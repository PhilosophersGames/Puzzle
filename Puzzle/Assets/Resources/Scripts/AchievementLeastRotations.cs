using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementLeastRotations : MonoBehaviour
{
   public bool achievement = false;
   public int rotationNumbers = 0;

   private bool multipleCount = true;

    void Update() 
    {
       if (achievement == true)
       {       
         if (RoomTransition.isRotating == true && multipleCount == true)
         {
            rotationNumbers++;
            multipleCount = false;
         }
         if (RoomTransition.isRotating == false)
            multipleCount = true;
        }
    }
}