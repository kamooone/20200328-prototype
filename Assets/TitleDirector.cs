using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadSceneを使うために必要

public class TitleDirector : MonoBehaviour
{
    GameObject FadeObject;
    TitleFade TitleFadeScript;

    bool TitleFlag = true;
    // Start is called before the first frame update
    void Start()
    {
        FadeObject = GameObject.Find("Panel");
        TitleFadeScript = FadeObject.GetComponent<TitleFade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TitleFlag == true)
        {
            TitleFadeScript.Fade_in();
        }
        if (Input.GetMouseButtonDown(0))
        {
            TitleFlag = false;
        }
        if (TitleFlag == false)
        {
            TitleFadeScript.Fade_out_Black();
        }
    }
}
