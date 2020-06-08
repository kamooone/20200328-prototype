using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameObject FadeObject;
    SelectFade SelectFadeScript;

<<<<<<< Updated upstream
    Button World1;
    Button World2;
    Button World3;
    Button World4;
=======
    //ワールド
    Button stage1;
    Button stage2;
    Button stage3;
    Button stage4;

    //ステージ
    Button stage5;
    Button stage6;
    Button stage7;
    Button stage8;
    Button stage9;
>>>>>>> Stashed changes

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

    public static int WorldNo = 1;

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
    bool Space = true;

    void Start()
    {
        FadeObject = GameObject.Find("Fadeout");
        SelectFadeScript = FadeObject.GetComponent<SelectFade>();

        // ボタンコンポーネントの取得
<<<<<<< Updated upstream
        World1 = GameObject.Find("StageSelectCanvas/stage/World1").GetComponent<Button>();
        World2 = GameObject.Find("StageSelectCanvas/stage/World2").GetComponent<Button>();
        World3 = GameObject.Find("StageSelectCanvas/stage/World3").GetComponent<Button>();
        World4 = GameObject.Find("StageSelectCanvas/stage/World4").GetComponent<Button>();
=======
        stage1 = GameObject.Find("StageSelectCanvas/stage/World1").GetComponent<Button>();
        stage2 = GameObject.Find("StageSelectCanvas/stage/World2").GetComponent<Button>();
        stage3 = GameObject.Find("StageSelectCanvas/stage/World3").GetComponent<Button>();
        stage4 = GameObject.Find("StageSelectCanvas/stage/World4").GetComponent<Button>();

        stage5  = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage1").GetComponent<Button>();
        stage6  = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage2").GetComponent<Button>();
        stage7  = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage3").GetComponent<Button>();
        stage8  = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage4").GetComponent<Button>();
        stage9  = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage5").GetComponent<Button>();
>>>>>>> Stashed changes

        sound = GameObject.Find("StageSelectCanvas/stage/sound").GetComponent<Button>(); ;

        SoundPanel = GameObject.Find("StageSelectCanvas/stage/SoundPanel");
        BGMSlider  = GameObject.Find("StageSelectCanvas/stage/SoundPanel/BGMSlider").GetComponent<Slider>();
        SESlider   = GameObject.Find("StageSelectCanvas/stage/SoundPanel/SESlider").GetComponent<Slider>();

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

<<<<<<< Updated upstream
        //ボタン選択
        if (SoundControll == false && FadeFlag == false && TitleFadeFlag == false && stageControll == false) 
=======
        //左右キー入力処理
        if (SoundControll == false && FadeFlag == false && TitleFadeFlag == false)
>>>>>>> Stashed changes
        {
            //右キー(ステージ選択時)
            if (RightFlag == true || Input.GetKeyDown("right") && StageNo >= 5 && StageNo <= 24) 
            {
<<<<<<< Updated upstream
                if (ButtonNo > 4 && ButtonNo < 7) 
                {
                    ButtonNo++;
=======
                if (StageNo == 9 || StageNo == 14 || StageNo == 19 || StageNo == 24)
                {
                    StageNo -= 4;
                    this.aud.PlayOneShot(this.CursorSE);
                    RightFlag = false;
                }
                else
                {                  
                    StageNo++;
>>>>>>> Stashed changes
                    this.aud.PlayOneShot(this.CursorSE);
                    RightFlag = false;
                }         
            }
            //下の3つを選んでるとき
            if (RightFlag == true || Input.GetKeyDown("right") && StageNo >= 25)
            {
                if (StageNo < 27)
                {
                    StageNo += 1;
                    this.aud.PlayOneShot(this.CursorSE);
                    RightFlag = false;
                }
                else
                {
                    StageNo = 25;
                    this.aud.PlayOneShot(this.CursorSE);
                    RightFlag = false;
                }                
            }

            //左キー
            if (LeftFlag == true || Input.GetKeyDown("left") && StageNo >= 5 && StageNo <= 24)
            {
<<<<<<< Updated upstream
                if (ButtonNo > 1)
=======
                //ステージ選択時
                if (StageNo == 5 || StageNo == 10 || StageNo == 15 || StageNo == 20)
                {
                    StageNo += 4;
                    this.aud.PlayOneShot(this.CursorSE);
                    LeftFlag = false;
                }
                else
>>>>>>> Stashed changes
                {
                    ButtonNo--;
                    this.aud.PlayOneShot(this.CursorSE);
                    LeftFlag = false;
                }
            }
            //下の3つを選んでるとき
            if (LeftFlag == true || Input.GetKeyDown("left") && StageNo >= 25)
            {
                if (StageNo > 25)
                {
                    StageNo -= 1;
                    this.aud.PlayOneShot(this.CursorSE);
                    LeftFlag = false;
                }
                else
                {
                    StageNo = 27;
                    this.aud.PlayOneShot(this.CursorSE);
                    LeftFlag = false;
                }
            }
<<<<<<< Updated upstream
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
=======
        }

        //上下キー入力処理
        if (SoundControll == false && FadeFlag == false && TitleFadeFlag == false)
        {
            if (UpFlag == true || Input.GetKeyDown("up"))
            {
                if (StageNo <= 4)
                {
                    StageNo-=1;
                    WorldNo -= 1;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                if (StageNo == 0) 
                {
                    StageNo = 4;
                    WorldNo = 4;
>>>>>>> Stashed changes
                    this.aud.PlayOneShot(this.CursorSE);
                }
                UpFlag = false;
                stick = false;
            }
<<<<<<< Updated upstream
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
=======
            if (DownFlag == true || Input.GetKeyDown("down"))
            {
                if (StageNo <= 4)
                {
                    StageNo += 1;
                    WorldNo += 1;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                if (StageNo == 5) 
                {
                    StageNo = 1;
                    WorldNo = 1;
>>>>>>> Stashed changes
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
                    Debug.Log("BGM音量ダウン");
                    SoundVolume++;
                }
                DownFlag = false;
            }
            if (UpFlag == true || Input.GetKeyDown("up"))
            {
                if (SoundVolume > 0)
                {
<<<<<<< Updated upstream
                    Debug.Log("BGM音量ダウン");
=======
                    Debug.Log("BGM音量アップ");
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
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
=======
        //サウンド画面消去
        if ((Input.GetKeyDown("o") || Input.GetKeyDown("joystick button 1")) && SoundControll == true && FadeFlag == false && TitleFadeFlag == false)
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
            stage6.gameObject.SetActive(true);
            stage7.gameObject.SetActive(true);
            stage8.gameObject.SetActive(true);
            stage9.gameObject.SetActive(true);
>>>>>>> Stashed changes

            sound.gameObject.SetActive(true);
            title.gameObject.SetActive(true);
            GameEnd.gameObject.SetActive(true);
        }

        //ステージ選択に移動
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) && StageNo <= 4) 
        {
            if (Space == true)
            {
                StageNo *= 5;
                this.aud.PlayOneShot(this.DecidedSE);
                Space = false;
            }

            //押したワールドによって変化する
            if (WorldNo == 1)
            {
                stage2.gameObject.SetActive(false);
                stage3.gameObject.SetActive(false);
                stage4.gameObject.SetActive(false);
            }
            if (WorldNo == 2)
            {
                stage1.gameObject.SetActive(false);
                stage3.gameObject.SetActive(false);
                stage4.gameObject.SetActive(false);
            }
            if (WorldNo == 3)
            {
                stage1.gameObject.SetActive(false);
                stage2.gameObject.SetActive(false);
                stage4.gameObject.SetActive(false);
            }
            if (WorldNo == 4)
            {
                stage1.gameObject.SetActive(false);
                stage2.gameObject.SetActive(false);
                stage3.gameObject.SetActive(false);
            }
        }
        else
        {
            Space = true;
        }

        //ワールド選択に移動
        if ((Input.GetKeyDown("o") || Input.GetKeyDown("joystick button 1")) && StageNo >= 5 && StageNo <= 24)
        {
            if (StageNo >= 5 && StageNo <= 9) 
            {
                StageNo = 1;
                WorldNo = 1;
                this.aud.PlayOneShot(this.CursorSE);
            }
            if (StageNo >= 10 && StageNo <= 14) 
            {
                StageNo = 2;
                WorldNo = 2;
                this.aud.PlayOneShot(this.CursorSE);
            }
            if (StageNo >= 15 && StageNo <= 19) 
            {
                StageNo = 3;
                WorldNo = 3;
                this.aud.PlayOneShot(this.CursorSE);
            }
            if (StageNo >= 20 && StageNo <= 24)
            {
                StageNo = 4;
                WorldNo = 4;
                this.aud.PlayOneShot(this.CursorSE);
            }
            stage1.gameObject.SetActive(true);
            stage2.gameObject.SetActive(true);
            stage3.gameObject.SetActive(true);
            stage4.gameObject.SetActive(true);
        }

        //コンフィグの下3つに移動
        if ((Input.GetKeyDown(KeyCode.C)|| Input.GetKeyDown("joystick button 3")))
        {
            if (StageNo <= 4) 
            {
                StageNo = 25;
                this.aud.PlayOneShot(this.DecidedSE);
            }
            else if (StageNo == 25 || StageNo == 26 || StageNo == 27)
            {
                StageNo = 1;
                this.aud.PlayOneShot(this.DecidedSE);
            }
            
        }

        //ワールドボタンを押した場合
        if (SoundControll == false && FadeFlag == false && TitleFadeFlag == false && stageControll == false)
        {
<<<<<<< Updated upstream
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
=======
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) && StageNo >= 5 && StageNo <= 24 && Space == true)
            {
                this.aud.PlayOneShot(this.DecidedSE);
                Space = false;
                //フェードインフェードアウト処理
                FadeFlag = true;
            }
            else
            {
                Space = true;
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && StageNo == 25)
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
                stage6.gameObject.SetActive(false);
                stage7.gameObject.SetActive(false);
                stage8.gameObject.SetActive(false);
                stage9.gameObject.SetActive(false);
>>>>>>> Stashed changes

                sound.gameObject.SetActive(false);
                title.gameObject.SetActive(false);
                GameEnd.gameObject.SetActive(false);

                //サウンド処理表示
                SoundPanel.gameObject.SetActive(true);
            }

            //タイトルに戻る
<<<<<<< Updated upstream
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && ButtonNo == 6)
=======
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && StageNo == 26)
>>>>>>> Stashed changes
            {
                this.aud.PlayOneShot(this.DecidedSE);

                //フェードインフェードアウト処理
                TitleFadeFlag = true;
            }

            //ゲーム終了
<<<<<<< Updated upstream
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && ButtonNo == 7)
=======
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && StageNo == 27)
>>>>>>> Stashed changes
            {
                //エディタ用
                // UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
            }
        }

        //選んでいるやつを赤く表示する
<<<<<<< Updated upstream
        if (ButtonNo == 1)
=======
        //ステージ
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
        if (StageNo == 5 || StageNo == 10 || StageNo == 15 || StageNo == 20) 
        {
            stage5.Select();
        }
        if (StageNo == 6|| StageNo == 11| StageNo == 16|| StageNo == 21)
>>>>>>> Stashed changes
        {
            World1.Select();
        }
<<<<<<< Updated upstream
        if (ButtonNo == 2)
=======
        if (StageNo == 7|| StageNo == 12|| StageNo == 17|| StageNo == 22)
>>>>>>> Stashed changes
        {
            World2.Select();
        }
<<<<<<< Updated upstream
        if (ButtonNo == 3)
=======
        if (StageNo == 8|| StageNo == 13|| StageNo == 18|| StageNo == 23)
>>>>>>> Stashed changes
        {
            World3.Select();
        }
<<<<<<< Updated upstream
        if (ButtonNo == 4)
=======
        if (StageNo == 9 || StageNo == 14 || StageNo == 19 || StageNo == 24)
>>>>>>> Stashed changes
        {
            World4.Select();
        }
<<<<<<< Updated upstream
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
=======

        //サウンド設定
        if (StageNo == 25)
        {
            sound.Select();
        }
        //タイトルへ移動
        if (StageNo == 26)
        {
            title.Select();
        }
        //ゲーム終了
        if (StageNo == 27)
        {
            GameEnd.Select();
        }
    }//update
>>>>>>> Stashed changes
}