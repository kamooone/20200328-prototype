using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFade : MonoBehaviour
{
    float speed = 0.02f;//透明化の速さ
    float alfa = 0;//A値を操作するための変数(スクリプトでは0～1の範囲)
    float red = 0.0f, green = 0.0f, blue = 0.0f;//RGBを操作するための変数

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
    void Update()
    {
        if (alfa > 0.0f)
        {
            //red -= speed;
            //green -= speed;
            //blue -= speed;
            alfa -= speed;
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
        }
    }
}
