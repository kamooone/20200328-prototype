using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameObject FadeObject;
    SelectFade SelectFadeScript;

    Button World1;
    Button World2;
    Button World3;
    Button World4;

    Button sound;
    Button title;
    Button GameEnd;

    GameObject SoundPanel;
    Slider BGMSlider;
    Slider SESlider;

    GameObject stage;
    Button stage1;
    Button stage2;
    Button stage3;
    Button stage4;
    Button stage5;

    public static int ButtonNo = 1;
    public static int NowButtonNo = 1;

    public static int StageNo = 1;
    public static int NowStageNo = 1;

    public bool SoundControll = false;
    public int SoundVolume = 0;

    public static bool stageControll = false;

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
        World1 = GameObject.Find("StageSelectCanvas/stage/World1").GetComponent<Button>();
        World2 = GameObject.Find("StageSelectCanvas/stage/World2").GetComponent<Button>();
        World3 = GameObject.Find("StageSelectCanvas/stage/World3").GetComponent<Button>();
        World4 = GameObject.Find("StageSelectCanvas/stage/World4").GetComponent<Button>();

        sound = GameObject.Find("StageSelectCanvas/stage/sound").GetComponent<Button>(); ;

        SoundPanel = GameObject.Find("StageSelectCanvas/stage/SoundPanel");
        BGMSlider = GameObject.Find("StageSelectCanvas/stage/SoundPanel/BGMSlider").GetComponent<Slider>();
        SESlider = GameObject.Find("StageSelectCanvas/stage/SoundPanel/SESlider").GetComponent<Slider>();

        stage  = GameObject.Find("StageSelectCanvas/stage/StageCanvas");
        stage1 = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage1").GetComponent<Button>();
        stage2 = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage2").GetComponent<Button>();
        stage3 = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage3").GetComponent<Button>();
        stage4 = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage4").GetComponent<Button>();
        stage5 = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage5").GetComponent<Button>();

        title = GameObject.Find("StageSelectCanvas/stage/title").GetComponent<Button>();
        GameEnd = GameObject.Find("StageSelectCanvas/stage/GameEnd").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        World1.Select();

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

        //ボタン選択
        if (SoundControll == false && FadeFlag == false && TitleFadeFlag == false && stageControll == false) 
        {
            if (RightFlag == true || Input.GetKeyDown("right"))
            {
                if (ButtonNo > 4 && ButtonNo < 7) 
                {
                    ButtonNo++;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                RightFlag = false;
            }
            if (LeftFlag == true || Input.GetKeyDown("left"))
            {
                if (ButtonNo > 1)
                {
                    ButtonNo--;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                LeftFlag = false;
            }
            //上キー入力処理
            if (UpFlag == true || Input.GetKeyDown("up")) 
            {
                if (ButtonNo > 1)
                {
                    ButtonNo--;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                else
                {
                    ButtonNo = 7;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                UpFlag = false;
                stick = false;
            }
            //下キー入力処理
            if (DownFlag == true || Input.GetKeyDown("down")) 
            {                
                if (ButtonNo < 7)
                {
                    ButtonNo++;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                else
                {
                    ButtonNo = 1;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                DownFlag = false;
                stick = false;
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
            Upstick = true;
        }
        if (Down >= 0.5 && Upstick == false)
        {
            DownFlag = true;
            Upstick = true;
        }

        //BGMかSEかを選択
        if (SoundControll == true && FadeFlag == false && TitleFadeFlag == false && stageControll == false)
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
                    Debug.Log("BGM音量ダウン");
                    SoundVolume--;
                }
                UpFlag = false;
            }
        }

        //ステージの選択
        if (SoundControll == false && FadeFlag == false && TitleFadeFlag == false && stageControll == true)
        {
            if (RightFlag == true || Input.GetKeyDown("right"))
            {
                if (StageNo < 5)
                {
                    StageNo++;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                else
                {
                    StageNo = 1;
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
                else
                {
                    StageNo = 5;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                LeftFlag = false;
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")))
            {
                FadeFlag = true;
                this.aud.PlayOneShot(this.DecidedSE);
            }
        }

        //ステージ選択消去
        if ((Input.GetKeyDown("o") || Input.GetKeyDown("joystick button 1")) && SoundControll == false && FadeFlag == false && TitleFadeFlag == false && stageControll == true)
        {
            this.aud.PlayOneShot(this.DecidedSE);
            stageControll = false;
            StageNo = 1;
            World1.gameObject.SetActive(true);
            World2.gameObject.SetActive(true);
            World3.gameObject.SetActive(true);
            World4.gameObject.SetActive(true);

            sound.gameObject.SetActive(true);
            title.gameObject.SetActive(true);
            GameEnd.gameObject.SetActive(true);
        }

            //サウンド画面消去
            if ((Input.GetKeyDown("o") || Input.GetKeyDown("joystick button 1")) && SoundControll == true && FadeFlag == false && TitleFadeFlag == false && stageControll == false)
        {
            this.aud.PlayOneShot(this.DecidedSE);
            SoundControll = false;
            SoundPanel.gameObject.SetActive(false);
            World1.gameObject.SetActive(true);
            World2.gameObject.SetActive(true);
            World3.gameObject.SetActive(true);
            World4.gameObject.SetActive(true);
            stage1.gameObject.SetActive(true);
            stage2.gameObject.SetActive(true);
            stage3.gameObject.SetActive(true);
            stage4.gameObject.SetActive(true);
            stage5.gameObject.SetActive(true);

            sound.gameObject.SetActive(true);
            title.gameObject.SetActive(true);
            GameEnd.gameObject.SetActive(true);
        }


        //ワールドボタンを押した場合
        if (SoundControll == false && FadeFlag == false && TitleFadeFlag == false && stageControll == false)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && ButtonNo <= 4)
            {
                this.aud.PlayOneShot(this.DecidedSE);
                stageControll = true;

                if (ButtonNo == 1) 
                {
                    World2.gameObject.SetActive(false);
                    World3.gameObject.SetActive(false);
                    World4.gameObject.SetActive(false);
                }
                if (ButtonNo == 2) 
                {
                    World1.gameObject.SetActive(false);
                    World3.gameObject.SetActive(false);
                    World4.gameObject.SetActive(false);
                }
                if (ButtonNo == 3)
                {
                    World1.gameObject.SetActive(false);
                    World2.gameObject.SetActive(false);
                    World4.gameObject.SetActive(false);
                }
                if (ButtonNo == 4)
                {
                    World1.gameObject.SetActive(false);
                    World2.gameObject.SetActive(false);
                    World3.gameObject.SetActive(false);
                }

                //sound.gameObject.SetActive(false);
                //title.gameObject.SetActive(false);
                //GameEnd.gameObject.SetActive(false);

                stage.gameObject.SetActive(true);
                //フェードインフェードアウト処理
                //FadeFlag = true;
            }

            //音量設定
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && ButtonNo == 5)
            {
                this.aud.PlayOneShot(this.DecidedSE);
                SoundControll = true;

                World1.gameObject.SetActive(false);
                World2.gameObject.SetActive(false);
                World3.gameObject.SetActive(false);
                World4.gameObject.SetActive(false);
                stage1.gameObject.SetActive(false);
                stage2.gameObject.SetActive(false);
                stage3.gameObject.SetActive(false);
                stage4.gameObject.SetActive(false);
                stage5.gameObject.SetActive(false);

                sound.gameObject.SetActive(false);
                title.gameObject.SetActive(false);
                GameEnd.gameObject.SetActive(false);

                //サウンド処理表示
                SoundPanel.gameObject.SetActive(true);
            }

            //タイトルに戻る
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && ButtonNo == 6)
            {
                this.aud.PlayOneShot(this.DecidedSE);

                //フェードインフェードアウト処理
                TitleFadeFlag = true;
            }

            //ゲーム終了
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && ButtonNo == 7)
            {
                //エディタ用
                // UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
            }
        }


        //選んでいるやつを赤く表示する
        if (ButtonNo == 1)
        {
            World1.Select();
        }
        if (ButtonNo == 2)
        {
            World2.Select();
        }
        if (ButtonNo == 3)
        {
            World3.Select();
        }
        if (ButtonNo == 4)
        {
            World4.Select();
        }
        if (ButtonNo == 5)
        {
            sound.Select();
        }
        if (ButtonNo == 6)
        {
            title.Select();
        }
        if (ButtonNo == 7)
        {
            GameEnd.Select();
        }

        //ステージ選択時
        if(stageControll==true)
        {
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
        }       
    }
}