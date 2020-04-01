using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadSceneを使うために必要

public class ClearDirector : MonoBehaviour
{
    GameObject FadeObject;
    ClearFade ClearFadeScript;

    bool ClearFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        FadeObject = GameObject.Find("Panel");
        ClearFadeScript = FadeObject.GetComponent<ClearFade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ClearFlag == true)
        {
            ClearFadeScript.Fade_in();
        }
        if (Input.GetMouseButtonDown(0))
        {
            ClearFlag = false;
        }
        if(ClearFlag == false)
        {
            ClearFadeScript.Fade_out_Black();
        }
    }
}
