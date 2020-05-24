using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotate1 : MonoBehaviour
{
    public AudioClip Rotate;

    AudioSource aud;

    bool soundflag = false;

    float rotate = 0.0f;
    float scalerotate = 0.0f;

    public static bool RotateFlag = false;

    public static bool RotateReverseFlag = false;

    public static bool KeyDestroy = false;

    float speed = 1.0f;
    float scalespeed = 0.006f;

    // Start is called before the first frame update
    void Start()
    {
        rotate = 0.0f;
        scalerotate = 0.0f;
        RotateFlag = false;
        RotateReverseFlag = false;
        KeyDestroy = false;

        this.aud = GetComponent<AudioSource>();
        soundflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateReverseFlag == true)
        {
            KeyDestroy = true;

            //コライダー無効
            GetComponent<BoxCollider>().enabled = false;

            if (rotate > -90.0f)
            {
                if (soundflag == false)
                {
                    this.aud.PlayOneShot(this.Rotate);
                    soundflag = true;
                }

                transform.Rotate(new Vector3(0f, speed, 0f));
                rotate -= speed;
                transform.localScale = new Vector3(1f - scalerotate, 1f, 1f);
                scalerotate += scalespeed;
            }
        }

        if (RotateFlag == true)
        {
            KeyDestroy = true;

            //コライダー無効
            GetComponent<BoxCollider>().enabled = false;

            if (rotate < 90.0f)
            {
                if (soundflag == false)
                {
                    this.aud.PlayOneShot(this.Rotate);
                    soundflag = true;
                }

                transform.Rotate(new Vector3(0f, -speed, 0f));
                rotate += speed;
                transform.localScale = new Vector3(1f - scalerotate, 1f, 1f);
                scalerotate += scalespeed;
            }
        }
    }
}
