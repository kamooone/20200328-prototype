using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    Button PauseMenu1;
    Button PauseMenu2;
    Button PauseMenu3;
    Slider BGMSlider;
    Slider SESlider;
    GameObject SoundPanel;

    GameObject PauseObject;
    PauseScript Pause;

    public static bool SoundControll = false;
    public static int SoundVolume = 0;

    public AudioClip CursorSE;
    public AudioClip DecidedSE;
    AudioSource aud;

    //　ポーズした時に表示するUI
    [SerializeField]
    private GameObject pauseUI;

    //チャタリング防止
    bool LeftFlag = false;
    bool RightFlag = false;
    bool UpFlag = false;
    bool DownFlag = false;
    bool stick = false;
    bool Upstick = false;

    void Start()
    {
        // ボタンコンポーネントの取得
        PauseMenu1 = GameObject.Find("PauseUI/retry").GetComponent<Button>();
        PauseMenu2 = GameObject.Find("PauseUI/select").GetComponent<Button>();
        PauseMenu3 = GameObject.Find("PauseUI/sound").GetComponent<Button>();

        SoundPanel = GameObject.Find("PauseUI/SoundPanel");
        BGMSlider = GameObject.Find("PauseUI/SoundPanel/BGMSlider").GetComponent<Slider>();
        SESlider = GameObject.Find("PauseUI/SoundPanel/SESlider").GetComponent<Slider>();

        PauseObject = GameObject.Find("MainCamera");
        Pause = PauseObject.GetComponent<PauseScript>();

        this.aud = GetComponent<AudioSource>();

        SoundPanel.gameObject.SetActive(false);
    }


    void Update()
    {
        //L Stick
        float Left = Input.GetAxis("L");
        float Right = Input.GetAxis("R");
        float Up = Input.GetAxis("W");
        float Down = Input.GetAxis("S");

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


        if ((Input.GetKeyDown("o") || Input.GetKeyDown("joystick button 1")) && SoundControll == true)
        {
            //this.aud.PlayOneShot(this.DecidedSE);

            PauseMenu1.gameObject.SetActive(true);
            PauseMenu2.gameObject.SetActive(true);
            PauseMenu3.gameObject.SetActive(true);

            SoundControll = false;
            SoundPanel.gameObject.SetActive(false);
            BGMSlider.gameObject.SetActive(false);
            SESlider.gameObject.SetActive(false);
        }

        //ポーズ画面のメニューを選択
        if (SoundControll == false)
        {
            SoundVolume = 0;
            SoundPanel.gameObject.SetActive(false);

            if (RightFlag == true || Input.GetKeyDown("right"))
            {
                if (Pause.PauseMenuNo < 3)
                {
                    Pause.PauseMenuNo++;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                RightFlag = false;
            }
            if (LeftFlag == true || Input.GetKeyDown("left"))
            {
                if (Pause.PauseMenuNo > 1)
                {
                    Pause.PauseMenuNo--;
                    this.aud.PlayOneShot(this.CursorSE);
                }
                LeftFlag = false;
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


        if (Up == 1 && Upstick == false)
        {
            UpFlag = true;
            stick = true;
        }
        if (Down == 1 && Upstick == false)
        {
            DownFlag = true;
            stick = true;
        }


        //BGMかSEかを選択
        if (SoundControll == true)
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


        //シーン遷移
        if (SoundControll == false)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) && Pause.PauseMenuNo == 1)
            {

                //　ポーズUIのアクティブ、非アクティブを切り替え
                pauseUI.SetActive(!pauseUI.activeSelf);

                //this.aud.PlayOneShot(this.DecidedSE);

                //if (Menu.NowButtonNo == 1)
                //{
                //    SceneManager.LoadScene("GameScene1");
                //}
                //
                //if (Menu.NowButtonNo == 2)
                //{
                //    SceneManager.LoadScene("GameScene2");
                //}
                //
                //if (Menu.NowButtonNo == 3)
                //{
                //    SceneManager.LoadScene("GameScene3");
                //}
                //
                //if (Menu.NowButtonNo == 4)
                //{
                //    SceneManager.LoadScene("GameScene4");
                //}
                //
                //if (Menu.NowButtonNo == 5)
                //{
                //    SceneManager.LoadScene("GameScene5");
                //}

                //フェードインフェードアウト処理
                Menu.TitleFadeFlag = true;
            }
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) && Pause.PauseMenuNo == 2)
            {
                //ポーズ解除
                Time.timeScale = 1f;
                this.aud.PlayOneShot(this.DecidedSE);
                SceneManager.LoadScene("NewSelectScene");
            }
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) && Pause.PauseMenuNo == 3)
            {
                this.aud.PlayOneShot(this.DecidedSE);
                
                PauseMenu1.gameObject.SetActive(false);
                PauseMenu2.gameObject.SetActive(false);
                PauseMenu3.gameObject.SetActive(false);

                SoundControll = true;
                SoundPanel.gameObject.SetActive(true);
                BGMSlider.gameObject.SetActive(true);
                SESlider.gameObject.SetActive(true);
            }
        }


        //選んでいるやつを赤く表示する
        if (Pause.PauseMenuNo > 0)
        {
            if (Pause.PauseMenuNo == 1)
            {
                Debug.Log("1");
                PauseMenu1.Select();
            }
            if (Pause.PauseMenuNo == 2)
            {
                Debug.Log("2");
                PauseMenu2.Select();
            }
            if (Pause.PauseMenuNo == 3)
            {
                Debug.Log("3");
                PauseMenu3.Select();
            }
        }
    }
}