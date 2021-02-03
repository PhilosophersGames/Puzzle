using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButton : MonoBehaviour
{
    // Start is called before the first frame update
    public bool rotateLeft;
    public bool rotateRight;
    public void RotateRight()
    {
            rotateRight = true;
    }

    public void RotateLeft()
    {
        rotateLeft = true;
    }

}
