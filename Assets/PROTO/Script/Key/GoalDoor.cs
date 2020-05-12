using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalDoor : MonoBehaviour
{
    float rotate = 0.0f;

    public static bool GoalFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        rotate = 0.0f;
        GoalFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalFlag == true)
        {
            if (rotate > -92.0f)
            {
                transform.Rotate(new Vector3(0f, -0.25f, 0.0f));
            }
            rotate -= 0.25f;
            if (rotate < -150.0f)
            {
                SceneManager.LoadScene("ClearScene");
            }
        }
    }
}
