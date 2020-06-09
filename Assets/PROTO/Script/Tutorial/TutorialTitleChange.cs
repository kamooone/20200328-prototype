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
            text.text = "チュートリアル1 (左右移動)";
        }

        if (No == 1)
        {
            text.text = "チュートリアル2 (上下移動)";
        }

        if (No == 2)
        {
            text.text = "チュートリアル3 (水の上下)";
        }

        if (No == 3)
        {
            text.text = "チュートリアル4 (鍵の出現)";
        }

        if (No == 4)
        {
            text.text = "チュートリアル5 (ゴール)";
        }

    }
    public void NunberTitleChange()//番号変更
    {
        No++;//次のチュートリアルへ
    }

}
