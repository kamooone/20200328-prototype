using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //LoadSceneを使うために必要

public class ClearFade : MonoBehaviour
{
    float fade_in_speed = 0.001f;
    float speed = 0.001f;//透明化の速さ
    float alfa = 0;//A値を操作するための変数(スクリプトでは0～1の範囲)
    float red = 0.0f, green = 0.0f, blue = 0.0f;//RGBを操作するための変数

    // Start is called before the first frame update
    void Start()
    {
        red = 1.0f;
        green = 1.0f;
        blue = 1.0f;
        alfa = 1.0f;
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
    }

    // Update is called once per frame
    public void Fade_out_Black()
    {
        if (red >= 0.0f)
        {
            red -= speed;
            green -= speed;
            blue -= speed;
            alfa += speed;
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
        }
        if (red <= 0.0f)
        {
            SceneManager.LoadScene("StartScene");
        }
    }

    public void Fade_out_White()
    {
        alfa += speed;
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
    }

    public void Fade_in()
    {
        if (alfa > 0.0f)
        {
            alfa -= fade_in_speed;
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
        }
    }

}
