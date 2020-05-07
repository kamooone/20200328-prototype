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
    Button sound;
    Button title;

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

    void Start()
    {
        FadeObject = GameObject.Find("Fadeout");
        SelectFadeScript = FadeObject.GetComponent<SelectFade>();


        // ボタンコンポーネントの取得
        stage1 = GameObject.Find("StageSelectCanvas/stage/stage1").GetComponent<Button>();
        stage2 = GameObject.Find("StageSelectCanvas/stage/stage2").GetComponent<Button>();
        stage3 = GameObject.Find("StageSelectCanvas/stage/stage3").GetComponent<Button>();
        stage4 = GameObject.Find("StageSelectCanvas/stage/stage4").GetComponent<Button>();
        stage5 = GameObject.Find("StageSelectCanvas/stage/stage5").GetComponent<Button>();
        sound = GameObject.Find("StageSelectCanvas/stage/sound").GetComponent<Button>(); ;

        SoundPanel = GameObject.Find("StageSelectCanvas/stage/SoundPanel");
        BGMSlider = GameObject.Find("StageSelectCanvas/stage/SoundPanel/BGMSlider").GetComponent<Slider>();
        SESlider = GameObject.Find("StageSelectCanvas/stage/SoundPanel/SESlider").GetComponent<Slider>();

        title = GameObject.Find("StageSelectCanvas/stage/title").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        stage1.Select();

        this.aud = GetComponent<AudioSource>();

        FadeFlag = false;
        TitleFadeFlag = false;
    }


    void Update()
    {
        
        //ステージを選択
        if (SoundControll == false && FadeFlag == false && TitleFadeFlag == false)
        {
            if (Input.GetKeyDown("right"))
            {
                if (StageNo < 7)
                {
                    StageNo++;
                    this.aud.PlayOneShot(this.CursorSE);
                }
            }
            if (Input.GetKeyDown("left"))
            {
                if (StageNo > 1)
                {
                    StageNo--;
                    this.aud.PlayOneShot(this.CursorSE);
                }
            }
        }

        //BGMかSEかを選択
        if (SoundControll == true && FadeFlag == false && TitleFadeFlag == false)
        {
            if (Input.GetKeyDown("down"))
            {
                if (SoundVolume < 1)
                {
                    Debug.Log("BGM音量アップ");
                    SoundVolume++;
                }
            }
            if (Input.GetKeyDown("up"))
            {
                if (SoundVolume > 0)
                {
                    Debug.Log("BGM音量daun");
                    SoundVolume--;
                }
            }
        }

        //サウンド画面消去
        if (Input.GetKeyDown("o") && SoundControll == true && FadeFlag == false && TitleFadeFlag == false)
        {
            this.aud.PlayOneShot(this.DecidedSE);
            SoundControll = false;
            SoundPanel.gameObject.SetActive(false);
            stage1.gameObject.SetActive(true);
            stage2.gameObject.SetActive(true);
            stage3.gameObject.SetActive(true);
            sound.gameObject.SetActive(true);
        }


        //シーン遷移
        if (SoundControll == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && StageNo <= 5)
            {
                this.aud.PlayOneShot(this.DecidedSE);

                //フェードインフェードアウト処理
                FadeFlag = true;
            }



            if (Input.GetKeyDown(KeyCode.Space) && StageNo == 6)
            {
                this.aud.PlayOneShot(this.DecidedSE);
                SoundControll = true;

                stage1.gameObject.SetActive(false);
                stage2.gameObject.SetActive(false);
                stage3.gameObject.SetActive(false);
                sound.gameObject.SetActive(false);

                //サウンド処理表示
                SoundPanel.gameObject.SetActive(true);
            }


            if (Input.GetKeyDown(KeyCode.Space) && StageNo == 7)
            {
                this.aud.PlayOneShot(this.DecidedSE);

                //フェードインフェードアウト処理
                TitleFadeFlag = true;
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
            sound.Select();
        }
        if (StageNo == 7)
        {
            title.Select();
        }
    }
}