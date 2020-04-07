using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDownUI : MonoBehaviour//水を下げる処理
{
    public GameObject gameobj;//上昇させたいオブジェクト
    public GameObject past_gameobj;//初期のゲームオブジェクト(最初にあった場所の座標)
    Transform myTransform;//transform取得

    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameobj.transform;//初期座標取得
    }

    // Update is called once per frame
    void Update()
    {
        myTransform = gameobj.transform;//座標更新
    }

    //ボタンをクリックした時の処理
    public void OnClick()
    {
        Vector3 localpos = myTransform.localPosition;//ローカル座標

        if (localpos.y != past_gameobj.transform.position.y)//上昇してなかったら
        {
            localpos.y = past_gameobj.transform.position.y;//初期のオブジェクトのy座標に移動
            myTransform.localPosition = localpos;//座標を設定
        }
        else//上昇してたら変更なし
        {

        }
    }
}
