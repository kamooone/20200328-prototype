using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Title : MonoBehaviour
{
    public AudioClip DecidedSE;
    AudioSource aud;

    public static bool FadeFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        FadeFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (FadeFlag == false)
            {
                this.aud.PlayOneShot(this.DecidedSE);
                FadeFlag = true;
            }
        }
    }
}
