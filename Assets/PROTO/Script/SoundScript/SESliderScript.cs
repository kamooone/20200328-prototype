using UnityEngine;
using UnityEngine.UI;

public class SESliderScript : MonoBehaviour
{
    Slider slider;

    //BGM音量
    static float volume = 0.5f;

    void Start()
    {
        slider = this.GetComponent<Slider>();
        //バックアップした音量取得
        slider.value = PlayerPrefs.GetFloat("SEVOLUME", volume);
    }

    void Update()
    {
        //現在の音量をバックアップ
        volume = slider.value;
    }

    //sliderの所にこれを起動しています
    public void masterVol(Slider slider)
    {
        //現在の音量をバックアップ
        PlayerPrefs.SetFloat("SEVOLUME", volume);
    }

}