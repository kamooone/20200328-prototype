using UnityEngine;
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


        //ステージを選択
        if (Input.GetKeyDown("right"))
        {
            if (PauseMenuNo < 3)
            {
                PauseMenuNo++;
                this.aud.PlayOneShot(this.CursorSE);
            }
        }
        if (Input.GetKeyDown("left"))
        {
            if (PauseMenuNo > 1)
            {
                PauseMenuNo--;
                this.aud.PlayOneShot(this.CursorSE);
            }
        }

        //シーン遷移
        if (Input.GetKeyDown(KeyCode.Space) && PauseMenuNo == 1)
        {
            //ポーズ解除
            Time.timeScale = 1f;

            this.aud.PlayOneShot(this.DecidedSE);

            //リトライ遷移
            //if (Menu.StageNo == 1)
            //{
            //    this.aud.PlayOneShot(this.DecidedSE);
            //    SceneManager.LoadScene("GameScene1");
            //    Menu.NowStageNo = 1;
            //}

            //if (Menu.StageNo == 2)
            //{
            //    this.aud.PlayOneShot(this.DecidedSE);
            //    SceneManager.LoadScene("GameScene2");
            //    Menu.NowStageNo = 2;
            //}

            //if (Menu.StageNo == 3)
            //{
            //    this.aud.PlayOneShot(this.DecidedSE);
            //    SceneManager.LoadScene("GameScene3");
            //    Menu.NowStageNo = 3;
            //}

            //if (Menu.StageNo == 4)
            //{
            //    this.aud.PlayOneShot(this.DecidedSE);
            //    SceneManager.LoadScene("GameScene4");
            //    Menu.NowStageNo = 4;
            //}

            //if (Menu.StageNo == 5)
            //{
            //    this.aud.PlayOneShot(this.DecidedSE);
            //    SceneManager.LoadScene("GameScene5");
            //    Menu.NowStageNo = 5;
            //}

            //フェードインフェードアウト処理
            Menu.TitleFadeFlag = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && PauseMenuNo == 2)
        {
            //ポーズ解除
            Time.timeScale = 1f;
            this.aud.PlayOneShot(this.DecidedSE);
            SceneManager.LoadScene("NewSelectScene");
        }
        if (Input.GetKeyDown(KeyCode.Space) && PauseMenuNo == 3)
        {
            //ポーズ解除
            Time.timeScale = 1f;
            this.aud.PlayOneShot(this.DecidedSE);


            //SceneManager.LoadScene("TitleScene");

            //フェードインフェードアウト処理
            Menu.StageNo = 7;
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