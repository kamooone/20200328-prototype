﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleFade : MonoBehaviour
{
    float speed = 0.01f;//透明化の速さ
    float alfa = 0;//A値を操作するための変数(スクリプトでは0～1の範囲)
    float red = 0.0f, green = 0.0f, blue = 0.0f;//RGBを操作するための変数

    // Start is called before the first frame update
    void Start()
    {
        red = 0.0f;
        green = 0.0f;
        blue = 0.0f;
        alfa = 0.0f;
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
    }

    // Update is called once per frame
    void Update()
    {
        if (Title.FadeFlag == true)
        {
            if (alfa <= 1.0f)
            {
                //red -= speed;
                //green -= speed;
                //blue -= speed;
                alfa += speed;
                GetComponent<Image>().color = new Color(red, green, blue, alfa);
            }
            if (alfa >= 1.0f)
            {
                Menu.StageNo = 1;
<<<<<<< Updated upstream
                SceneManager.LoadScene("SelectScene");
=======
                SceneManager.LoadScene("NewSelectScene");
>>>>>>> Stashed changes
            }
        }
    }
}
