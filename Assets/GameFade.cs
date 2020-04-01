using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //LoadSceneを使うために必要

public class GameFade : MonoBehaviour
{
    float fade_in_speed = 0.005f;
    float speed = 0.001f;//透明化の速さ
    float alfa = 0;//A値を操作するための変数(スクリプトでは0～1の範囲)
    float red = 0.0f, green = 0.0f, blue = 0.0f;//RGBを操作するための変数

    public bool GameFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        red = 0.0f;
        green = 0.0f;
        blue = 0.0f;
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
            Debug.Log("ゴール");
            SceneManager.LoadScene("ClearScene");
        }
    }

    public void Fade_out_White()
    {
        alfa += speed;
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        if (alfa >= 1.0f)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }


    public void Fade_in()
    {
        if (red <= 1.0f)
        {
            red += fade_in_speed;
            green += fade_in_speed;
            blue += fade_in_speed;
            alfa -= fade_in_speed;
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
        }
    }
}
