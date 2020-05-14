using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotate : MonoBehaviour
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
        KeyDestroy = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateReverseFlag == true)
        {
            KeyDestroy = true;

            //コライダー無効
            GetComponent<BoxCollider>().enabled = false;

            if (rotate > -100.0f)
            {
                transform.Rotate(new Vector3(0f, -speed, 0f));
                rotate -= speed;
            }
        }

        if (RotateFlag == true)
        {
            KeyDestroy = true;

            //コライダー無効
            GetComponent<BoxCollider>().enabled = false;

            if (rotate < 100.0f)
            {
                transform.Rotate(new Vector3(0f, speed, 0f));
                rotate += speed;
            }
        }
    }
}
