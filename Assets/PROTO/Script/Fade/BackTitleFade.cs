﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //LoadSceneを使うために必要

public class BackTitleFade : MonoBehaviour
{
    GameObject TitleObj;

    float speed = 0.01f;//透明化の速さ
    float alfa = 0;//A値を操作するための変数(スクリプトでは0～1の範囲)
    float red = 0.0f, green = 0.0f, blue = 0.0f;//RGBを操作するための変数

    // Start is called before the first frame update
    void Start()
    {
        TitleObj = GameObject.Find("SoundObject");

        red = 0.0f;
        green = 0.0f;
        blue = 0.0f;
        alfa = 0.0f;
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
    }

    // Update is called once per frame
    void Update()
    {
        if (Menu.TitleFadeFlag == true)
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
                Menu.TitleFadeFlag = false;

                //ポーズ解除
                Time.timeScale = 1f;

                // Titleのオブジェクトを消す(BGMを消すため)
                Destroy(TitleObj);

                if (Menu.StageNo == 1)
                {
                    SceneManager.LoadScene("GameScene1");
                    Menu.NowStageNo = 1;
                }

                if (Menu.StageNo == 2)
                {
                    SceneManager.LoadScene("GameScene2");
                    Menu.NowStageNo = 2;
                }

                if (Menu.StageNo == 3)
                {
                    SceneManager.LoadScene("GameScene3");
                    Menu.NowStageNo = 3;
                }

                if (Menu.StageNo == 4)
                {
                    SceneManager.LoadScene("GameScene4");
                    Menu.NowStageNo = 4;
                }

                if (Menu.StageNo == 5)
                {
                    SceneManager.LoadScene("GameScene5");
                    Menu.NowStageNo = 5;
                }


                if (Menu.StageNo == 7)
                {
                    SceneManager.LoadScene("TitleScene");
                    Menu.NowStageNo = 7;
                }
            }
        }
    }
}
