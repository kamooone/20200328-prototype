using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameObject FadeObject;
    SelectFade SelectFadeScript;

    Button stage1;
    Button stage2;
    Button stage3;
    Button stage4;
    Button stage5;
    Button stage6;
    Button stage7;
    Button stage8;
    Button stage9;
    Button stage10;
    Button stage11;
    Button stage12;
    Button stage13;
    Button stage14;
    Button stage15;
    Button stage16;
    Button stage17;
    Button stage18;
    Button stage19;
    Button stage20;


    Button sound;
    Button title;
    Button GameEnd;

    GameObject SoundPanel;
    Slider BGMSlider;
    Slider SESlider;

    public static int StageNo = 1;
    public static int NowStageNo = 1;

    public bool SoundControll = false;
    public int SoundVolume = 0;

    public AudioClip CursorSE;
    public AudioClip DecidedSE;
    AudioSource aud;

    public static bool FadeFlag = false;
    public static bool TitleFadeFlag = false;

    //チャタリング防止
    bool LeftFlag = false;
    bool RightFlag = false;
    bool UpFlag = false;
    bool DownFlag = false;
    bool stick = false;
    bool Upstick = false;

    void Start()
    {
        FadeObject = GameObject.Find("Fadeout");
        SelectFadeScript = FadeObject.GetComponent<SelectFade>();


        // ボタンコンポーネントの取得
        stage1 = GameObject.Find("StageSelectCanvas/stage/World1/stage1").GetComponent<Button>();
        stage2 = GameObject.Find("StageSelectCanvas/stage/World1/stage2").GetComponent<Button>();
        stage3 = GameObject.Find("StageSelectCanvas/stage/World1/stage3").GetComponent<Button>();
        stage4 = GameObject.Find("StageSelectCanvas/stage/World1/stage4").GetComponent<Button>();
        stage5 = GameObject.Find("StageSelectCanvas/stage/World1/stage5").GetComponent<Button>();
        stage6 = GameObject.Find("StageSelectCanvas/stage/World2/stage1").GetComponent<Button>();
        stage7 = GameObject.Find("StageSelectCanvas/stage/World2/stage2").GetComponent<Button>();
        stage8 = GameObject.Find("StageSelectCanvas/stage/World2/stage3").GetComponent<Button>();
        stage9 = GameObject.Find("StageSelectCanvas/stage/World2/stage4").GetComponent<Button>();
        stage10 = GameObject.Find("StageSelectCanvas/stage/World2/stage5").GetComponent<Button>();
        stage11 = GameObject.Find("StageSelectCanvas/stage/World3/stage1").GetComponent<Button>();
        stage12 = GameObject.Find("StageSelectCanvas/stage/World3/stage2").GetComponent<Button>();
        stage13 = GameObject.Find("StageSelectCanvas/stage/World3/stage3").GetComponent<Button>();
        stage14 = GameObject.Find("StageSelectCanvas/stage/World3/stage4").GetComponent<Button>();
        stage15 = GameObject.Find("StageSelectCanvas/stage/World3/stage5").GetComponent<Button>();
        stage16 = GameObject.Find("StageSelectCanvas/stage/World4/stage1").GetComponent<Button>();
        stage17 = GameObject.Find("StageSelectCanvas/stage/World4/stage2").GetComponent<Button>();
        stage18 = GameObject.Find("StageSelectCanvas/stage/World4/stage3").GetComponent<Button>();
        stage19 = GameObject.Find("StageSelectCanvas/stage/World4/stage4").GetComponent<Button>();
        stage20 = GameObject.Find("StageSelectCanvas/stage/World4/stage5").GetComponent<Button>();


        sound = GameObject.Find("StageSelectCanvas/stage/sound").GetComponent<Button>(); ;

        SoundPanel = GameObject.Find("StageSelectCanvas/stage/SoundPanel");
        BGMSlider = GameObject.Find("StageSelectCanvas/stage/SoundPanel/BGMSlider").GetComponent<Slider>();
        SESlider = GameObject.Find("StageSelectCanvas/stage/SoundPanel/SESlider").GetComponent<Slider>();

        title = GameObject.Find("StageSelectCanvas/stage/title").GetComponent<Button>();
        GameEnd = GameObject.Find("StageSelectCanvas/stage/GameEnd").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        stage1.Select();

        this.aud = GetComponent<AudioSource>();

        FadeFlag = false;
        TitleFadeFlag = false;
    }


    void Update()
    {
        //L Stick
        float Left = Input.GetAxis("L");
        float Right = Input.GetAxis("R");
        float Up = Input.GetAxis("W");
        float Down = Input.GetAxis("S");

        //チャタリング防止
        if (Left >= 0.5 && stick == false)
        {
            LeftFlag = true;
            stick = true;
        }
        if (Right >= 0.5 && stick == false)
        {
            RightFlag = true;
            stick = true;
        }
        if (Up >= 0.5 && Upstick == false)
        {
            UpFlag = true;
            Upstick = true;
        }
        if (Down >= 0.5 && Upstick == false)
        {
            DownFlag = true;
            Upstick = true;
        }



        //ステージを選択
        if (SoundControll == false && FadeFlag == false && TitleFadeFlag == false)
        {
            if (RightFlag == true || Input.GetKeyDown("right"))
            {
                if (StageNo < 23)
                {
                    StageNo++;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                RightFlag = false;
            }
            if (LeftFlag == true || Input.GetKeyDown("left"))
            {
                if (StageNo > 1)
                {
                    StageNo--;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                LeftFlag = false;
            }
        }

        if (SoundControll == false && FadeFlag == false && TitleFadeFlag == false)
        {
            if (UpFlag == true || Input.GetKeyDown("up"))
            {
                if (StageNo >= 6)
                {
                    StageNo-=5;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                UpFlag = false;
            }
            if (DownFlag == true || Input.GetKeyDown("down"))
            {
                if (StageNo >= 16 && StageNo <= 20)
                {
                    StageNo=21;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                if (StageNo <= 15)
                {
                    StageNo += 5;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                DownFlag = false;
            }
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
        if (Up == 0)
        {
            Upstick = false;
        }
        if (Down == 0)
        {
            Upstick = false;
        }



        if (Up >= 0.5 && Upstick == false)
        {
            UpFlag = true;
            stick = true;
        }
        if (Down >= 0.5 && Upstick == false)
        {
            DownFlag = true;
            stick = true;
        }


        //BGMかSEかを選択
        if (SoundControll == true && FadeFlag == false && TitleFadeFlag == false)
        {
            if (DownFlag == true || Input.GetKeyDown("down"))
            {
                if (SoundVolume < 1)
                {
                    Debug.Log("BGM音量アップ");
                    SoundVolume++;
                }
                DownFlag = false;
            }
            if (UpFlag == true || Input.GetKeyDown("up"))
            {
                if (SoundVolume > 0)
                {
                    Debug.Log("BGM音量daun");
                    SoundVolume--;
                }
                UpFlag = false;
            }
        }

        //チャタリング防止
        if (Up == 0)
        {
            Upstick = false;
        }
        if (Down == 0)
        {
            Upstick = false;
        }



        //サウンド画面消去
        if ((Input.GetKeyDown("o") || Input.GetKeyDown("joystick button 1")) && SoundControll == true && FadeFlag == false && TitleFadeFlag == false)
        {
            this.aud.PlayOneShot(this.DecidedSE);
            SoundControll = false;
            SoundPanel.gameObject.SetActive(false);
            stage1.gameObject.SetActive(true);
            stage2.gameObject.SetActive(true);
            stage3.gameObject.SetActive(true);
            stage4.gameObject.SetActive(true);
            stage5.gameObject.SetActive(true);
            stage6.gameObject.SetActive(true);
            stage7.gameObject.SetActive(true);
            stage8.gameObject.SetActive(true);
            stage9.gameObject.SetActive(true);
            stage10.gameObject.SetActive(true);

            sound.gameObject.SetActive(true);
            title.gameObject.SetActive(true);
            GameEnd.gameObject.SetActive(true);
        }


        //シーン遷移
        if (SoundControll == false && FadeFlag == false && TitleFadeFlag == false)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && StageNo <= 20)
            {
                this.aud.PlayOneShot(this.DecidedSE);

                //フェードインフェードアウト処理
                FadeFlag = true;
            }



            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && StageNo == 21)
            {
                this.aud.PlayOneShot(this.DecidedSE);
                SoundControll = true;

                stage1.gameObject.SetActive(false);
                stage2.gameObject.SetActive(false);
                stage3.gameObject.SetActive(false);
                stage4.gameObject.SetActive(false);
                stage5.gameObject.SetActive(false);
                stage6.gameObject.SetActive(false);
                stage7.gameObject.SetActive(false);
                stage8.gameObject.SetActive(false);
                stage9.gameObject.SetActive(false);
                stage10.gameObject.SetActive(false);

                sound.gameObject.SetActive(false);
                title.gameObject.SetActive(false);
                GameEnd.gameObject.SetActive(false);

                //サウンド処理表示
                SoundPanel.gameObject.SetActive(true);
            }


            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && StageNo == 22)
            {
                this.aud.PlayOneShot(this.DecidedSE);

                //フェードインフェードアウト処理
                TitleFadeFlag = true;
            }

            //ゲーム終了
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && StageNo == 23)
            {
                //エディタ用
                // UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
            }
        }


        //選んでいるやつを赤く表示する
        if (StageNo == 1)
        {
            stage1.Select();
        }
        if (StageNo == 2)
        {
            stage2.Select();
        }
        if (StageNo == 3)
        {
            stage3.Select();
        }
        if (StageNo == 4)
        {
            stage4.Select();
        }
        if (StageNo == 5)
        {
            stage5.Select();
        }
        if (StageNo == 6)
        {
            stage6.Select();
        }
        if (StageNo == 7)
        {
            stage7.Select();
        }
        if (StageNo == 8)
        {
            stage8.Select();
        }
        if (StageNo == 9)
        {
            stage9.Select();
        }
        if (StageNo == 10)
        {
            stage10.Select();
        }
        if (StageNo == 11)
        {
            stage11.Select();
        }
        if (StageNo == 12)
        {
            stage12.Select();
        }
        if (StageNo == 13)
        {
            stage13.Select();
        }
        if (StageNo == 14)
        {
            stage14.Select();
        }
        if (StageNo == 15)
        {
            stage15.Select();
        }
        if (StageNo == 16)
        {
            stage16.Select();
        }
        if (StageNo == 17)
        {
            stage17.Select();
        }
        if (StageNo == 18)
        {
            stage18.Select();
        }
        if (StageNo == 19)
        {
            stage19.Select();
        }
        if (StageNo == 20)
        {
            stage20.Select();
        }


        if (StageNo == 21)
        {
            sound.Select();
        }
        if (StageNo == 22)
        {
            title.Select();
        }
        if (StageNo == 23)
        {
            GameEnd.Select();
        }
    }
}