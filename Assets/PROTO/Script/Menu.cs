using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameObject FadeObject;
    SelectFade SelectFadeScript;

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

    Button sound;
    Button title;
    Button GameEnd;

    GameObject SoundPanel;
    Slider BGMSlider;
    Slider SESlider;

    public static int StageNo = 1;
    public static int NowStageNo = 1;

    public static int WorldNo = 1;

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
    bool Space = true;

    void Start()
    {
        FadeObject = GameObject.Find("Fadeout");
        SelectFadeScript = FadeObject.GetComponent<SelectFade>();

        // ボタンコンポーネントの取得
        stage1 = GameObject.Find("StageSelectCanvas/stage/World1").GetComponent<Button>();
        stage2 = GameObject.Find("StageSelectCanvas/stage/World2").GetComponent<Button>();
        stage3 = GameObject.Find("StageSelectCanvas/stage/World3").GetComponent<Button>();
        stage4 = GameObject.Find("StageSelectCanvas/stage/World4").GetComponent<Button>();

        stage5  = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage1").GetComponent<Button>();
        stage6  = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage2").GetComponent<Button>();
        stage7  = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage3").GetComponent<Button>();
        stage8  = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage4").GetComponent<Button>();
        stage9  = GameObject.Find("StageSelectCanvas/stage/StageCanvas/stage5").GetComponent<Button>();

        sound = GameObject.Find("StageSelectCanvas/stage/sound").GetComponent<Button>(); ;

        SoundPanel = GameObject.Find("StageSelectCanvas/stage/SoundPanel");
        BGMSlider  = GameObject.Find("StageSelectCanvas/stage/SoundPanel/BGMSlider").GetComponent<Slider>();
        SESlider   = GameObject.Find("StageSelectCanvas/stage/SoundPanel/SESlider").GetComponent<Slider>();

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

        //左右キー入力処理
        if (SoundControll == false && FadeFlag == false && TitleFadeFlag == false)
        {
            //右キー(ステージ選択時)
            if (RightFlag == true || Input.GetKeyDown("right") && StageNo >= 5 && StageNo <= 24) 
            {
                if (StageNo == 9 || StageNo == 14 || StageNo == 19 || StageNo == 24)
                {
                    StageNo -= 4;
                    this.aud.PlayOneShot(this.CursorSE);
                    RightFlag = false;
                }
                else
                {                  
                    StageNo++;
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
                //ステージ選択時
                if (StageNo == 5 || StageNo == 10 || StageNo == 15 || StageNo == 20)
                {
                    StageNo += 4;
                    this.aud.PlayOneShot(this.CursorSE);
                    LeftFlag = false;
                }
                else
                {
                    StageNo--;
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
                    this.aud.PlayOneShot(this.CursorSE);
                }
                UpFlag = false;
            }
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
                    Debug.Log("BGM音量ダウン");
                    SoundVolume++;
                }
                DownFlag = false;
            }
            if (UpFlag == true || Input.GetKeyDown("up"))
            {
                if (SoundVolume > 0)
                {
                    Debug.Log("BGM音量アップ");
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

            sound.gameObject.SetActive(true);
            title.gameObject.SetActive(true);
            GameEnd.gameObject.SetActive(true);
        }

        //ステージ選択に移動
        if ((Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("joystick button 0")) && StageNo <= 4))
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

        //シーン遷移
        if (SoundControll == false && FadeFlag == false && TitleFadeFlag == false)
        {
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

                sound.gameObject.SetActive(false);
                title.gameObject.SetActive(false);
                GameEnd.gameObject.SetActive(false);

                //サウンド処理表示
                SoundPanel.gameObject.SetActive(true);
            }

            //タイトルに戻る
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && StageNo == 26)
            {
                this.aud.PlayOneShot(this.DecidedSE);

                //フェードインフェードアウト処理
                TitleFadeFlag = true;
            }

            //ゲーム終了
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))  && StageNo == 27)
            {
                //エディタ用
                // UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
            }
        }

        //選んでいるやつを赤く表示する
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
        {
            stage6.Select();
        }
        if (StageNo == 7|| StageNo == 12|| StageNo == 17|| StageNo == 22)
        {
            stage7.Select();
        }
        if (StageNo == 8|| StageNo == 13|| StageNo == 18|| StageNo == 23)
        {
            stage8.Select();
        }
        if (StageNo == 9 || StageNo == 14 || StageNo == 19 || StageNo == 24)
        {
            stage9.Select();
        }

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
}