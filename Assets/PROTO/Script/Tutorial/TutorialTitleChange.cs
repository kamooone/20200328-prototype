using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTitleChange : MonoBehaviour//チュートリアルチェンジ
{
    public Text text;//タイトル文

    int No;//現在のチュートリアル番号


    // Start is called before the first frame update
    void Start()
    {
        No = 0;//最初のチュートリアル
    }

    // Update is called once per frame
    void Update()
    {
        if (No == 0)
        {
            text.text = "チュートリアル1　移動";
        }

        if (No == 1)
        {
            text.text = "チュートリアル2　はしご";
        }

        if (No == 2)
        {
            text.text = "チュートリアル3　スプリンクラー";
        }

        if (No == 3)
        {
            text.text = "チュートリアル4　鍵";
        }

        if (No == 4)
        {
            text.text = "";
        }

    }
    public void NunberTitleChange()//番号変更
    {
        No++;//次のチュートリアルへ
    }

}
