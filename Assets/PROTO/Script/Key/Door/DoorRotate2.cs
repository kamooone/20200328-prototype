using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotate2 : MonoBehaviour
{
    float rotate = 0.0f;

    public static bool RotateFlag = false;

    public static bool RotateReverseFlag = false;

    public static bool KeyDestroy = false;

    float speed = 1.0f;

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

            //コライダー無効
            GetComponent<BoxCollider>().enabled = false;

            if (rotate > -90.0f)
            {
                transform.Rotate(new Vector3(0f, 0f, -speed));
                rotate -= speed;
            }
        }

        if (RotateReverseFlag == true)
        {
            KeyDestroy = true;

            //コライダー無効
            GetComponent<BoxCollider>().enabled = false;

            if (rotate < 90.0f)
            {
                transform.Rotate(new Vector3(0f, 0f, speed));
                rotate += speed;
            }
        }
    }
}
