using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotate1 : MonoBehaviour
{
    float rotate = 0.0f;

    public static bool RotateFlag = false;

    public static bool RotateReverseFlag = false;

    public static bool KeyDestroy = false;

    // Start is called before the first frame update
    void Start()
    {
        rotate = 0.0f;
        RotateFlag = false;
        RotateReverseFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateFlag == true)
        {
            KeyDestroy = true;

            if (rotate > -90.0f)
            {
                transform.Rotate(new Vector3(0f, 0f, -0.5f));
                rotate -= 0.5f;
            }
        }

        if (RotateReverseFlag == true)
        {
            KeyDestroy = true;

            if (rotate < 90.0f)
            {
                transform.Rotate(new Vector3(0f, 0f, 0.5f));
                rotate += 0.5f;
            }
        }
    }
}
