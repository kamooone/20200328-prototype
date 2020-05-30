﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    Button PauseMenu1;
    Button PauseMenu2;
    Button PauseMenu3;

    int PauseMenuNo = 1;

    public AudioClip CursorSE;
    public AudioClip DecidedSE;
    AudioSource aud;

    //チャタリング防止
    bool LeftFlag = false;
    bool RightFlag = false;
    bool stick = false;

    void Start()
    {
        // ボタンコンポーネントの取得
        PauseMenu1 = GameObject.Find("PauseUI/retry").GetComponent<Button>();
        PauseMenu2 = GameObject.Find("PauseUI/select").GetComponent<Button>();
        PauseMenu3 = GameObject.Find("PauseUI/title").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        PauseMenu1.Select();

        this.aud = GetComponent<AudioSource>();
    }


    void Update()
    {
        //L Stick
        float Left = Input.GetAxis("L");
        float Right = Input.GetAxis("R");

        //チャタリング防止
        if (Left == 1 && stick == false)
        {
            LeftFlag = true;
            stick = true;
        }
        if (Right == 1 && stick == false)
        {
            RightFlag = true;
            stick = true;
        }



        //ステージを選択
        if (RightFlag == true || Input.GetKeyDown("right"))
        {
            if (PauseMenuNo < 3)
            {
                PauseMenuNo++;
                this.aud.PlayOneShot(this.CursorSE);
            }
            RightFlag = false;
        }
        if (LeftFlag == true || Input.GetKeyDown("left"))
        {
            if (PauseMenuNo > 1)
            {
                PauseMenuNo--;
                this.aud.PlayOneShot(this.CursorSE);
            }
            LeftFlag = false;
        }


        //チャタリング防止
        if (Left == 0)
        {
            stick = false;
        }
        if (Right == 0)
        {
            stick = false;
        }




        //シーン遷移
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && PauseMenuNo == 1)
        {
            //ポーズ解除
            Time.timeScale = 1f;

            this.aud.PlayOneShot(this.DecidedSE);

            //リトライ遷移
            //if (Menu.ButtonNo == 1)
            //{
            //    this.aud.PlayOneShot(this.DecidedSE);
            //    SceneManager.LoadScene("GameScene1");
            //    Menu.NowButtonNo = 1;
            //}

            //if (Menu.ButtonNo == 2)
            //{
            //    this.aud.PlayOneShot(this.DecidedSE);
            //    SceneManager.LoadScene("GameScene2");
            //    Menu.NowButtonNo = 2;
            //}

            //if (Menu.ButtonNo == 3)
            //{
            //    this.aud.PlayOneShot(this.DecidedSE);
            //    SceneManager.LoadScene("GameScene3");
            //    Menu.NowButtonNo = 3;
            //}

            //if (Menu.ButtonNo == 4)
            //{
            //    this.aud.PlayOneShot(this.DecidedSE);
            //    SceneManager.LoadScene("GameScene4");
            //    Menu.NowButtonNo = 4;
            //}

            //if (Menu.ButtonNo == 5)
            //{
            //    this.aud.PlayOneShot(this.DecidedSE);
            //    SceneManager.LoadScene("GameScene5");
            //    Menu.NowButtonNo = 5;
            //}

            //フェードインフェードアウト処理
            Menu.TitleFadeFlag = true;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && PauseMenuNo == 2)
        {
            //ポーズ解除
            Time.timeScale = 1f;
            this.aud.PlayOneShot(this.DecidedSE);
            SceneManager.LoadScene("NewSelectScene");
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && PauseMenuNo == 3)
        {
            //ポーズ解除
            Time.timeScale = 1f;
            this.aud.PlayOneShot(this.DecidedSE);


            //SceneManager.LoadScene("TitleScene");

            //フェードインフェードアウト処理
            Menu.ButtonNo = 17;
            Menu.TitleFadeFlag = true;
        }


        //選んでいるやつを赤く表示する
        if (PauseMenuNo == 1)
        {
            Debug.Log("1");
            PauseMenu1.Select();
        }
        if (PauseMenuNo == 2)
        {
            Debug.Log("2");
            PauseMenu2.Select();
        }
        if (PauseMenuNo == 3)
        {
            Debug.Log("3");
            PauseMenu3.Select();
        }
    }
}