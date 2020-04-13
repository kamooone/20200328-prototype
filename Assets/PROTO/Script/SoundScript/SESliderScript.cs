using UnityEngine;
using UnityEngine.UI;

public class SESliderScript : MonoBehaviour
{
    Slider slider;

    GameObject PauseObject;
    PauseMenu Pause;

    //BGM音量
    static float volume = -40.0f;

    void Start()
    {
        slider = this.GetComponent<Slider>();
        //バックアップした音量取得
        slider.value = PlayerPrefs.GetFloat("SEVOLUME", volume);

        PauseObject = GameObject.Find("PauseUI");
        Pause = PauseObject.GetComponent<PauseMenu>();
    }

    void Update()
    {
        //現在の音量をバックアップ
        volume = slider.value;

        //BGMの音量調節
        if (Pause.SoundControll == true && Pause.SoundVolume == 1)
        {
            slider.Select();

            Debug.Log("SE音量アップ");
            if (Input.GetKeyDown("right"))
            {
                if (slider.value < 0.0f)
                {
                    Debug.Log("SE音量アップ");
                    slider.value += 0.00000001f;
                }
            }
            if (Input.GetKeyDown("left"))
            {
                if (slider.value > -80.0f)
                {
                    Debug.Log("SE音量ダウン");
                    slider.value -= 0.00000001f;
                }
            }
        }
        //現在の音量をバックアップ
        PlayerPrefs.SetFloat("SEVOLUME", volume);
    }

    //sliderの所にこれを起動しています
    public void masterVol(Slider slider)
    {
        //現在の音量をバックアップ
        PlayerPrefs.SetFloat("SEVOLUME", volume);
    }



}