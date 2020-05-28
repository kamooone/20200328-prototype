using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalDoorMinasu : MonoBehaviour
{
    float rotate = 0.0f;
    float scalerotate = 0.0f;

    float speed = 0.5f;
    float scalespeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        rotate = 0.0f;
        scalerotate = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (GoalDoor.GoalFlag == true)
        {
            if (rotate < 90.0f)
            {
                transform.Rotate(new Vector3(0f, -speed, 0f));
                rotate += speed;
                transform.localScale = new Vector3(1f + scalerotate, 1f, 1f);
                scalerotate += scalespeed;
            }
        }
    }
}
