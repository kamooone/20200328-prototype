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
        if (Input.GetKeyDown("o") && SoundControll == true)
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

            if (Input.GetKeyDown("right"))
            {
                if (Pause.PauseMenuNo < 3)
                {
                    Pause.PauseMenuNo++;
                    this.aud.PlayOneShot(this.CursorSE);
                }
            }
            if (Input.GetKeyDown("left"))
            {
                if (Pause.PauseMenuNo > 1)
                {
                    Pause.PauseMenuNo--;
                    this.aud.PlayOneShot(this.CursorSE);
                }
            }
        }


        //BGMかSEかを選択
        if (SoundControll == true)
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



        //シーン遷移
        if (SoundControll == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Pause.PauseMenuNo == 1)
            {
                //ポーズ解除
                Time.timeScale = 1f;
                this.aud.PlayOneShot(this.DecidedSE);

                if (Menu.NowStageNo == 1)
                {
                    SceneManager.LoadScene("GameScene1");
                }

                if (Menu.NowStageNo == 2)
                {
                    SceneManager.LoadScene("GameScene2");
                }

                if (Menu.NowStageNo == 3)
                {
                    SceneManager.LoadScene("GameScene3");
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && Pause.PauseMenuNo == 2)
            {
                //ポーズ解除
                Time.timeScale = 1f;
                this.aud.PlayOneShot(this.DecidedSE);
                SceneManager.LoadScene("SelectScene");
            }
            if (Input.GetKeyDown(KeyCode.Space) && Pause.PauseMenuNo == 3)
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